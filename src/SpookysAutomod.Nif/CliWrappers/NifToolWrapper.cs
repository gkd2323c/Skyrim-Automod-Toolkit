using System.Diagnostics;
using SpookysAutomod.Core.Logging;
using SpookysAutomod.Core.Models;

namespace SpookysAutomod.Nif.CliWrappers;

/// <summary>
/// Wrapper for nif-tool.exe - Rust CLI for rewriting texture paths, string table entries,
/// and shader flags in Skyrim SE NIF files.
/// </summary>
public class NifToolWrapper
{
    private readonly IModLogger _logger;
    private readonly string _toolsDir;
    private string? _toolPath;

    public NifToolWrapper(IModLogger logger, string? toolsDirectory = null)
    {
        _logger = logger;
        _toolsDir = toolsDirectory ?? ResolveToolsDir();
    }

    private static string ResolveToolsDir()
    {
        // Try relative to CWD first (dotnet run --project scenario)
        var cwdPath = Path.Combine(Directory.GetCurrentDirectory(), "tools", "nif-tool");
        if (Directory.Exists(cwdPath)) return cwdPath;

        // Try relative to assembly location
        var asmDir = Path.GetDirectoryName(typeof(NifToolWrapper).Assembly.Location) ?? ".";
        var asmPath = Path.Combine(asmDir, "tools", "nif-tool");
        if (Directory.Exists(asmPath)) return asmPath;

        // Walk up from assembly to find toolkit root
        var dir = new DirectoryInfo(asmDir);
        while (dir != null)
        {
            var candidate = Path.Combine(dir.FullName, "tools", "nif-tool");
            if (Directory.Exists(candidate)) return candidate;
            dir = dir.Parent;
        }

        return cwdPath; // Fallback
    }

    public string GetToolPath()
    {
        if (_toolPath != null) return _toolPath;
        _toolPath = Path.Combine(_toolsDir, "nif-tool.exe");
        return _toolPath;
    }

    public bool IsAvailable() => File.Exists(GetToolPath());

    public async Task<Result<string>> ListTexturesAsync(string path)
    {
        return await RunAsync($"list \"{path}\"");
    }

    public async Task<Result<string>> ReplaceTexturesAsync(
        string path, string oldStr, string newStr, bool dryRun = false, bool backup = true)
    {
        var args = $"replace \"{path}\" --old \"{oldStr}\" --new \"{newStr}\"";
        if (dryRun) args += " --dry-run";
        if (!backup) args += " --backup false";
        return await RunAsync(args);
    }

    public async Task<Result<string>> ListStringsAsync(string path)
    {
        return await RunAsync($"strings \"{path}\"");
    }

    public async Task<Result<string>> RenameStringsAsync(
        string path, string oldStr, string newStr, bool dryRun = false, bool backup = true)
    {
        var args = $"rename \"{path}\" --old \"{oldStr}\" --new \"{newStr}\"";
        if (dryRun) args += " --dry-run";
        if (!backup) args += " --backup false";
        return await RunAsync(args);
    }

    public async Task<Result<string>> ShaderInfoAsync(string path)
    {
        return await RunAsync($"shader-info \"{path}\"");
    }

    public async Task<Result<string>> FixEyesAsync(string path, bool dryRun = false, bool backup = true)
    {
        var args = $"fix-eyes \"{path}\"";
        if (dryRun) args += " --dry-run";
        if (!backup) args += " --backup false";
        return await RunAsync(args);
    }

    public async Task<Result<string>> VerifyAsync(string path)
    {
        return await RunAsync($"verify \"{path}\"");
    }

    public async Task<Result<string>> RestoreAsync(string path)
    {
        return await RunAsync($"restore \"{path}\"");
    }

    private async Task<Result<string>> RunAsync(string arguments, int timeoutMs = 120000)
    {
        var toolPath = GetToolPath();

        if (!File.Exists(toolPath))
        {
            return Result<string>.Fail(
                "nif-tool not found",
                $"Expected at: {toolPath}",
                new List<string>
                {
                    "Place nif-tool.exe in tools/nif-tool/",
                    "nif-tool is a separate Rust binary for NIF manipulation"
                });
        }

        var psi = new ProcessStartInfo
        {
            FileName = toolPath,
            Arguments = arguments,
            UseShellExecute = false,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            CreateNoWindow = true
        };

        _logger.Debug($"Running: nif-tool {arguments}");

        using var process = new Process { StartInfo = psi };
        var stdout = new System.Text.StringBuilder();
        var stderr = new System.Text.StringBuilder();

        process.OutputDataReceived += (_, e) => { if (e.Data != null) stdout.AppendLine(e.Data); };
        process.ErrorDataReceived += (_, e) => { if (e.Data != null) stderr.AppendLine(e.Data); };

        process.Start();
        process.BeginOutputReadLine();
        process.BeginErrorReadLine();

        using var cts = new CancellationTokenSource(timeoutMs);
        try
        {
            await process.WaitForExitAsync(cts.Token);
        }
        catch (OperationCanceledException)
        {
            try { process.Kill(); } catch { }
            return Result<string>.Fail("nif-tool timed out", $"Timeout after {timeoutMs}ms");
        }

        var output = stdout.ToString().TrimEnd();
        var error = stderr.ToString().TrimEnd();

        if (process.ExitCode != 0)
        {
            var errorMsg = !string.IsNullOrEmpty(error) ? error : output;
            return Result<string>.Fail("nif-tool failed", errorMsg);
        }

        return Result<string>.Ok(output);
    }
}
