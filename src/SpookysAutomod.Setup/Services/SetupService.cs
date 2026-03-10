using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net.Http;
using System.Text.Json;

namespace SpookysAutomod.Setup.Services;

public class SetupService
{
    private static readonly HttpClient _httpClient = new();

    public string ToolkitRoot { get; }

    public SetupService()
    {
        // Toolkit root is where this exe lives (or 4 levels up from bin/Debug output)
        var exeDir = AppContext.BaseDirectory;

        // Check if we're running from the root (published exe)
        if (File.Exists(Path.Combine(exeDir, "SpookysAutomod.sln")))
        {
            ToolkitRoot = exeDir;
        }
        else
        {
            // Running from bin/Debug/net8.0-windows/ - walk up to find .sln
            var dir = new DirectoryInfo(exeDir);
            while (dir != null && !File.Exists(Path.Combine(dir.FullName, "SpookysAutomod.sln")))
                dir = dir.Parent;
            ToolkitRoot = dir?.FullName ?? exeDir;
        }
    }

    #region Skyrim Detection

    public List<SkyrimInstallation> DetectSkyrimInstallations()
    {
        var installations = new List<SkyrimInstallation>();
        var candidates = new List<(string path, SkyrimEdition edition, string exe)>
        {
            (@"C:\Program Files (x86)\Steam\steamapps\common\Skyrim Special Edition", SkyrimEdition.SE, "SkyrimSE.exe"),
            (@"C:\Program Files\Steam\steamapps\common\Skyrim Special Edition", SkyrimEdition.SE, "SkyrimSE.exe"),
            (@"D:\SteamLibrary\steamapps\common\Skyrim Special Edition", SkyrimEdition.SE, "SkyrimSE.exe"),
            (@"D:\Steam\steamapps\common\Skyrim Special Edition", SkyrimEdition.SE, "SkyrimSE.exe"),
            (@"E:\SteamLibrary\steamapps\common\Skyrim Special Edition", SkyrimEdition.SE, "SkyrimSE.exe"),
            (@"D:\Games\Steam\steamapps\common\Skyrim Special Edition", SkyrimEdition.SE, "SkyrimSE.exe"),
            (@"E:\Games\Steam\steamapps\common\Skyrim Special Edition", SkyrimEdition.SE, "SkyrimSE.exe"),
            (@"C:\Program Files (x86)\Steam\steamapps\common\SkyrimVR", SkyrimEdition.VR, "SkyrimVR.exe"),
            (@"C:\Program Files\Steam\steamapps\common\SkyrimVR", SkyrimEdition.VR, "SkyrimVR.exe"),
            (@"D:\SteamLibrary\steamapps\common\SkyrimVR", SkyrimEdition.VR, "SkyrimVR.exe"),
            (@"D:\Steam\steamapps\common\SkyrimVR", SkyrimEdition.VR, "SkyrimVR.exe"),
            (@"E:\SteamLibrary\steamapps\common\SkyrimVR", SkyrimEdition.VR, "SkyrimVR.exe"),
        };

        // Parse Steam library folders for additional paths
        try
        {
            var steamPaths = new[]
            {
                @"C:\Program Files (x86)\Steam",
                @"C:\Program Files\Steam"
            };

            foreach (var steamPath in steamPaths)
            {
                var vdfPath = Path.Combine(steamPath, "steamapps", "libraryfolders.vdf");
                if (!File.Exists(vdfPath)) continue;

                var content = File.ReadAllText(vdfPath);
                foreach (var line in content.Split('\n'))
                {
                    var trimmed = line.Trim();
                    if (!trimmed.StartsWith("\"path\"")) continue;

                    var parts = trimmed.Split('"');
                    if (parts.Length < 4) continue;

                    var libPath = parts[3].Replace("\\\\", "\\");
                    candidates.Add((Path.Combine(libPath, "steamapps", "common", "Skyrim Special Edition"), SkyrimEdition.SE, "SkyrimSE.exe"));
                    candidates.Add((Path.Combine(libPath, "steamapps", "common", "SkyrimVR"), SkyrimEdition.VR, "SkyrimVR.exe"));
                }
            }
        }
        catch { /* Ignore VDF parsing failures */ }

        foreach (var (path, edition, exe) in candidates)
        {
            if (!Directory.Exists(path) || !File.Exists(Path.Combine(path, exe))) continue;
            if (installations.Any(i => i.Path.Equals(path, StringComparison.OrdinalIgnoreCase))) continue;

            var scriptSource = FindScriptSourceDir(path);
            installations.Add(new SkyrimInstallation
            {
                Path = path,
                Edition = edition,
                HasScriptHeaders = scriptSource != null,
                ScriptSourcePath = scriptSource
            });
        }

        return installations;
    }

    public string? FindScriptSourceDir(string skyrimPath)
    {
        var candidates = new[]
        {
            Path.Combine(skyrimPath, "Data", "Scripts", "Source"),
            Path.Combine(skyrimPath, "Data", "Source", "Scripts"),
            Path.Combine(skyrimPath, "Data", "Scripts", "Source", "Base"),
        };

        foreach (var candidate in candidates)
        {
            if (Directory.Exists(candidate) &&
                Directory.GetFiles(candidate, "*.psc", SearchOption.TopDirectoryOnly).Length > 0)
            {
                return candidate;
            }
        }
        return null;
    }

    #endregion

    #region Script Headers (Symlink)

    public (bool success, string message) SetupScriptHeaders(string scriptSourceDir)
    {
        try
        {
            var targetLink = Path.Combine(ToolkitRoot, "skyrim-script-headers");

            // Remove existing directory/link if it exists
            if (Directory.Exists(targetLink))
            {
                var info = new DirectoryInfo(targetLink);
                if (info.Attributes.HasFlag(FileAttributes.ReparsePoint))
                {
                    // It's already a symlink - remove it
                    Directory.Delete(targetLink, false);
                }
                else
                {
                    // It's a real directory with copied files - remove it
                    Directory.Delete(targetLink, true);
                }
            }

            // Create directory junction (doesn't require admin, unlike symlinks)
            var result = RunProcess("cmd.exe", $"/c mklink /J \"{targetLink}\" \"{scriptSourceDir}\"");
            if (result.exitCode != 0)
            {
                return (false, $"Failed to create junction: {result.output}");
            }

            // Verify the junction works
            var pscCount = Directory.GetFiles(targetLink, "*.psc", SearchOption.TopDirectoryOnly).Length;
            return (true, $"Linked to {scriptSourceDir} ({pscCount} script headers available)");
        }
        catch (Exception ex)
        {
            return (false, $"Error: {ex.Message}");
        }
    }

    #endregion

    #region Tool Downloads

    public async Task<(bool success, string message)> DownloadToolAsync(
        string owner, string repo, string assetPattern, string targetFolder,
        IProgress<(int percent, string status)>? progress = null)
    {
        try
        {
            var targetDir = Path.Combine(ToolkitRoot, "tools", targetFolder);

            // Check if already downloaded
            if (Directory.Exists(targetDir) && Directory.EnumerateFiles(targetDir, "*", SearchOption.AllDirectories).Any())
            {
                progress?.Report((100, "Already installed"));
                return (true, "Already installed");
            }

            progress?.Report((10, "Fetching release info..."));

            // Get latest release from GitHub
            var apiUrl = $"https://api.github.com/repos/{owner}/{repo}/releases/latest";
            _httpClient.DefaultRequestHeaders.UserAgent.Clear();
            _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("SpookysAutomodSetup/1.0");

            var releaseJson = await _httpClient.GetStringAsync(apiUrl);
            var release = JsonSerializer.Deserialize<JsonElement>(releaseJson);

            string? downloadUrl = null;
            string? assetName = null;

            foreach (var asset in release.GetProperty("assets").EnumerateArray())
            {
                var name = asset.GetProperty("name").GetString() ?? "";
                if (MatchesPattern(name, assetPattern))
                {
                    downloadUrl = asset.GetProperty("browser_download_url").GetString();
                    assetName = name;
                    break;
                }
            }

            if (downloadUrl == null)
            {
                return (false, $"No matching asset found for pattern: {assetPattern}");
            }

            progress?.Report((30, $"Downloading {assetName}..."));

            // Download the asset
            var response = await _httpClient.GetAsync(downloadUrl, HttpCompletionOption.ResponseHeadersRead);
            response.EnsureSuccessStatusCode();

            var totalBytes = response.Content.Headers.ContentLength ?? -1;
            var tempFile = Path.GetTempFileName();

            using (var contentStream = await response.Content.ReadAsStreamAsync())
            using (var fileStream = new FileStream(tempFile, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                var buffer = new byte[8192];
                long totalRead = 0;
                int bytesRead;

                while ((bytesRead = await contentStream.ReadAsync(buffer)) > 0)
                {
                    await fileStream.WriteAsync(buffer.AsMemory(0, bytesRead));
                    totalRead += bytesRead;

                    if (totalBytes > 0)
                    {
                        var pct = (int)(30 + (totalRead * 60.0 / totalBytes));
                        progress?.Report((pct, $"Downloading... {totalRead / 1024:N0} KB"));
                    }
                }
            }

            progress?.Report((90, "Extracting..."));

            // Extract
            Directory.CreateDirectory(targetDir);
            if (assetName!.EndsWith(".zip", StringComparison.OrdinalIgnoreCase))
            {
                ZipFile.ExtractToDirectory(tempFile, targetDir, overwriteFiles: true);
            }
            else
            {
                File.Copy(tempFile, Path.Combine(targetDir, assetName), overwrite: true);
            }

            File.Delete(tempFile);
            progress?.Report((100, "Installed"));
            return (true, $"Downloaded and extracted to {targetDir}");
        }
        catch (Exception ex)
        {
            return (false, $"Download failed: {ex.Message}");
        }
    }

    private static bool MatchesPattern(string name, string pattern)
    {
        if (pattern.Contains('*'))
        {
            var prefix = pattern.Split('*')[0];
            var suffix = pattern.Split('*').Last();
            return name.StartsWith(prefix, StringComparison.OrdinalIgnoreCase) &&
                   name.EndsWith(suffix, StringComparison.OrdinalIgnoreCase);
        }
        return name.Equals(pattern, StringComparison.OrdinalIgnoreCase);
    }

    public bool IsToolInstalled(string toolFolder)
    {
        var dir = Path.Combine(ToolkitRoot, "tools", toolFolder);
        return Directory.Exists(dir) && Directory.EnumerateFiles(dir, "*", SearchOption.AllDirectories).Any();
    }

    #endregion

    #region .NET Check

    public (bool installed, string version) CheckDotNet()
    {
        try
        {
            var result = RunProcess("dotnet", "--version");
            if (result.exitCode == 0)
            {
                var version = result.output.Trim();
                var isNet8 = version.StartsWith("8.");
                return (isNet8, version);
            }
            return (false, "Not found");
        }
        catch
        {
            return (false, "Not found");
        }
    }

    #endregion

    #region Build Solution

    public Task<(bool success, string output)> BuildSolutionAsync(
        IProgress<string>? progress = null)
    {
        try
        {
            var slnPath = Path.Combine(ToolkitRoot, "SpookysAutomod.sln");
            if (!File.Exists(slnPath))
            {
                return Task.FromResult<(bool, string)>((false, $"Solution file not found: {slnPath}"));
            }

            progress?.Report("Restoring NuGet packages...");

            var restoreResult = RunProcess("dotnet", $"restore \"{slnPath}\"", ToolkitRoot);
            if (restoreResult.exitCode != 0)
            {
                // Try adding NuGet source first
                RunProcess("dotnet", "nuget add source https://api.nuget.org/v3/index.json -n nuget.org", ToolkitRoot);
                restoreResult = RunProcess("dotnet", $"restore \"{slnPath}\"", ToolkitRoot);
                if (restoreResult.exitCode != 0)
                {
                    return Task.FromResult<(bool, string)>((false, $"Restore failed:\n{restoreResult.output}"));
                }
            }

            progress?.Report("Building solution...");

            var buildResult = RunProcess("dotnet", $"build \"{slnPath}\" --no-restore --verbosity quiet", ToolkitRoot);
            if (buildResult.exitCode != 0)
            {
                return Task.FromResult<(bool, string)>((false, $"Build failed:\n{buildResult.output}"));
            }

            return Task.FromResult<(bool, string)>((true, "Build succeeded"));
        }
        catch (Exception ex)
        {
            return Task.FromResult<(bool, string)>((false, $"Build error: {ex.Message}"));
        }
    }

    #endregion

    #region Init Prompt

    public string? GetInitPrompt()
    {
        var promptPath = Path.Combine(ToolkitRoot, "docs", "llm-init-prompt.md");
        if (!File.Exists(promptPath)) return null;
        return File.ReadAllText(promptPath);
    }

    #endregion

    #region Settings

    public void SaveSettings(SetupSettings settings)
    {
        var path = Path.Combine(ToolkitRoot, "settings.json");
        var json = JsonSerializer.Serialize(settings, new JsonSerializerOptions
        {
            WriteIndented = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });
        File.WriteAllText(path, json);
    }

    public SetupSettings? LoadSettings()
    {
        var path = Path.Combine(ToolkitRoot, "settings.json");
        if (!File.Exists(path)) return null;
        var json = File.ReadAllText(path);
        return JsonSerializer.Deserialize<SetupSettings>(json, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });
    }

    #endregion

    #region Helpers

    private static (int exitCode, string output) RunProcess(string fileName, string arguments, string? workingDir = null)
    {
        var psi = new ProcessStartInfo
        {
            FileName = fileName,
            Arguments = arguments,
            UseShellExecute = false,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            CreateNoWindow = true
        };

        if (workingDir != null)
            psi.WorkingDirectory = workingDir;

        using var process = Process.Start(psi);
        if (process == null) return (-1, "Failed to start process");

        var output = process.StandardOutput.ReadToEnd();
        var error = process.StandardError.ReadToEnd();
        process.WaitForExit(60000);

        return (process.ExitCode, output + error);
    }

    #endregion
}

#region Models

public enum SkyrimEdition
{
    SE,
    VR
}

public class SkyrimInstallation
{
    public string Path { get; set; } = "";
    public SkyrimEdition Edition { get; set; }
    public bool HasScriptHeaders { get; set; }
    public string? ScriptSourcePath { get; set; }

    public string DisplayName => Edition switch
    {
        SkyrimEdition.SE => $"Skyrim Special Edition - {Path}",
        SkyrimEdition.VR => $"Skyrim VR - {Path}",
        _ => Path
    };
}

public class SetupSettings
{
    public string SkyrimPath { get; set; } = "";
    public string SkyrimEdition { get; set; } = "SE";
    public string DataPath { get; set; } = "";
    public string ScriptHeadersPath { get; set; } = "";
    public bool PapyrusCompilerInstalled { get; set; }
    public bool ChampollionInstalled { get; set; }
    public string DotNetVersion { get; set; } = "";
    public DateTime SetupDate { get; set; } = DateTime.Now;
}

#endregion
