using SpookysAutomod.Core.Logging;
using SpookysAutomod.Core.Models;
using SpookysAutomod.Nif.CliWrappers;

namespace SpookysAutomod.Nif.Services;

/// <summary>
/// High-level service for NIF mesh operations.
/// Note: NIF reading/writing requires native dependencies that may not be available.
/// This module provides basic file operations with plans for full mesh editing support.
/// </summary>
public class NifService
{
    private readonly IModLogger _logger;
    private readonly NifToolWrapper? _nifToolWrapper;

    public NifService(IModLogger logger, NifToolWrapper? nifToolWrapper = null)
    {
        _logger = logger;
        _nifToolWrapper = nifToolWrapper;
    }

    private NifToolWrapper GetWrapper() => _nifToolWrapper ?? new NifToolWrapper(_logger);

    /// <summary>
    /// Get basic information about a NIF file by reading its header.
    /// </summary>
    public Result<NifInfo> GetInfo(string nifPath)
    {
        if (!File.Exists(nifPath))
        {
            return Result<NifInfo>.Fail($"File not found: {nifPath}");
        }

        try
        {
            using var stream = File.OpenRead(nifPath);
            using var reader = new BinaryReader(stream);

            // Read NIF header
            var headerLine = ReadString(reader, 64);
            if (!headerLine.StartsWith("Gamebryo") && !headerLine.StartsWith("NetImmerse"))
            {
                return Result<NifInfo>.Fail(
                    "Not a valid NIF file",
                    $"Header: {headerLine.Substring(0, Math.Min(40, headerLine.Length))}");
            }

            var info = new NifInfo
            {
                FilePath = nifPath,
                FileName = Path.GetFileName(nifPath),
                FileSize = new FileInfo(nifPath).Length,
                HeaderString = headerLine.Trim('\0', '\n', '\r')
            };

            // Parse version from header
            if (headerLine.Contains("Version"))
            {
                var verStart = headerLine.IndexOf("Version") + 8;
                var verEnd = headerLine.IndexOf('\n', verStart);
                if (verEnd > verStart)
                {
                    info.Version = headerLine.Substring(verStart, verEnd - verStart).Trim();
                }
            }

            return Result<NifInfo>.Ok(info);
        }
        catch (Exception ex)
        {
            return Result<NifInfo>.Fail(
                $"Failed to read NIF: {ex.Message}",
                ex.StackTrace);
        }
    }

    /// <summary>
    /// Scale operation is not yet implemented.
    /// </summary>
    public Result<string> Scale(string nifPath, float factor, string outputPath)
    {
        if (!File.Exists(nifPath))
        {
            return Result<string>.Fail($"File not found: {nifPath}");
        }

        return Result<string>.Fail(
            "NIF scaling not yet implemented",
            suggestions: new List<string>
            {
                "Use NifSkope for mesh scaling",
                "Use Outfit Studio for batch operations"
            });
    }

    /// <summary>
    /// Copy a NIF file.
    /// </summary>
    public Result<string> Copy(string nifPath, string outputPath)
    {
        if (!File.Exists(nifPath))
        {
            return Result<string>.Fail($"File not found: {nifPath}");
        }

        try
        {
            var dir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(dir))
                Directory.CreateDirectory(dir);
            File.Copy(nifPath, outputPath, overwrite: true);
            return Result<string>.Ok(outputPath);
        }
        catch (Exception ex)
        {
            return Result<string>.Fail(
                $"Failed to copy NIF: {ex.Message}",
                ex.StackTrace);
        }
    }

    #region nif-tool Integration

    /// <summary>
    /// Check if nif-tool is available.
    /// </summary>
    public bool IsNifToolAvailable() => GetWrapper().IsAvailable();

    /// <summary>
    /// List textures using nif-tool (supports folders, shows block/slot info).
    /// </summary>
    public async Task<Result<NifToolOutput>> ListTexturesFromToolAsync(string path)
    {
        var wrapper = GetWrapper();
        if (!wrapper.IsAvailable())
            return NifToolNotFound();

        var raw = await wrapper.ListTexturesAsync(path);
        if (!raw.Success)
            return Result<NifToolOutput>.Fail(raw.Error!, raw.ErrorContext, raw.Suggestions);

        return Result<NifToolOutput>.Ok(new NifToolOutput { Output = raw.Value! });
    }

    /// <summary>
    /// Replace texture path substrings in NIF files.
    /// </summary>
    public async Task<Result<NifToolOutput>> ReplaceTexturesAsync(
        string path, string oldStr, string newStr, bool dryRun = false, bool backup = true)
    {
        var wrapper = GetWrapper();
        if (!wrapper.IsAvailable())
            return NifToolNotFound();

        var raw = await wrapper.ReplaceTexturesAsync(path, oldStr, newStr, dryRun, backup);
        if (!raw.Success)
            return Result<NifToolOutput>.Fail(raw.Error!, raw.ErrorContext, raw.Suggestions);

        return Result<NifToolOutput>.Ok(new NifToolOutput
        {
            Output = raw.Value!,
            DryRun = dryRun
        });
    }

    /// <summary>
    /// List NIF string table entries using nif-tool.
    /// </summary>
    public async Task<Result<NifToolOutput>> ListStringsFromToolAsync(string path)
    {
        var wrapper = GetWrapper();
        if (!wrapper.IsAvailable())
            return NifToolNotFound();

        var raw = await wrapper.ListStringsAsync(path);
        if (!raw.Success)
            return Result<NifToolOutput>.Fail(raw.Error!, raw.ErrorContext, raw.Suggestions);

        return Result<NifToolOutput>.Ok(new NifToolOutput { Output = raw.Value! });
    }

    /// <summary>
    /// Rename string table entries in NIF files.
    /// </summary>
    public async Task<Result<NifToolOutput>> RenameStringsAsync(
        string path, string oldStr, string newStr, bool dryRun = false, bool backup = true)
    {
        var wrapper = GetWrapper();
        if (!wrapper.IsAvailable())
            return NifToolNotFound();

        var raw = await wrapper.RenameStringsAsync(path, oldStr, newStr, dryRun, backup);
        if (!raw.Success)
            return Result<NifToolOutput>.Fail(raw.Error!, raw.ErrorContext, raw.Suggestions);

        return Result<NifToolOutput>.Ok(new NifToolOutput
        {
            Output = raw.Value!,
            DryRun = dryRun
        });
    }

    /// <summary>
    /// Get shader flag info from NIF files.
    /// </summary>
    public async Task<Result<NifToolOutput>> GetShaderInfoAsync(string path)
    {
        var wrapper = GetWrapper();
        if (!wrapper.IsAvailable())
            return NifToolNotFound();

        var raw = await wrapper.ShaderInfoAsync(path);
        if (!raw.Success)
            return Result<NifToolOutput>.Fail(raw.Error!, raw.ErrorContext, raw.Suggestions);

        return Result<NifToolOutput>.Ok(new NifToolOutput { Output = raw.Value! });
    }

    /// <summary>
    /// Fix eye ghosting bug in FaceGen NIFs.
    /// </summary>
    public async Task<Result<NifToolOutput>> FixEyesAsync(
        string path, bool dryRun = false, bool backup = true)
    {
        var wrapper = GetWrapper();
        if (!wrapper.IsAvailable())
            return NifToolNotFound();

        var raw = await wrapper.FixEyesAsync(path, dryRun, backup);
        if (!raw.Success)
            return Result<NifToolOutput>.Fail(raw.Error!, raw.ErrorContext, raw.Suggestions);

        return Result<NifToolOutput>.Ok(new NifToolOutput
        {
            Output = raw.Value!,
            DryRun = dryRun
        });
    }

    /// <summary>
    /// Verify byte-perfect roundtrip of NIF files.
    /// </summary>
    public async Task<Result<NifToolOutput>> VerifyAsync(string path)
    {
        var wrapper = GetWrapper();
        if (!wrapper.IsAvailable())
            return NifToolNotFound();

        var raw = await wrapper.VerifyAsync(path);
        if (!raw.Success)
            return Result<NifToolOutput>.Fail(raw.Error!, raw.ErrorContext, raw.Suggestions);

        return Result<NifToolOutput>.Ok(new NifToolOutput { Output = raw.Value! });
    }

    /// <summary>
    /// Restore NIF files from .nif.bak backups.
    /// </summary>
    public async Task<Result<NifToolOutput>> RestoreAsync(string path)
    {
        var wrapper = GetWrapper();
        if (!wrapper.IsAvailable())
            return NifToolNotFound();

        var raw = await wrapper.RestoreAsync(path);
        if (!raw.Success)
            return Result<NifToolOutput>.Fail(raw.Error!, raw.ErrorContext, raw.Suggestions);

        return Result<NifToolOutput>.Ok(new NifToolOutput { Output = raw.Value! });
    }

    private static Result<NifToolOutput> NifToolNotFound() =>
        Result<NifToolOutput>.Fail(
            "nif-tool not found",
            suggestions: new List<string>
            {
                "Place nif-tool.exe in tools/nif-tool/",
                "nif-tool is a separate Rust binary for NIF file manipulation"
            });

    #endregion

    private static string ReadString(BinaryReader reader, int maxLength)
    {
        var chars = new List<char>();
        for (int i = 0; i < maxLength; i++)
        {
            var c = reader.ReadChar();
            chars.Add(c);
            if (c == '\n') break;
        }
        return new string(chars.ToArray());
    }

}

public class NifInfo
{
    public string FilePath { get; set; } = "";
    public string FileName { get; set; } = "";
    public long FileSize { get; set; }
    public string HeaderString { get; set; } = "";
    public string Version { get; set; } = "";
}

/// <summary>
/// Output from nif-tool commands. Contains the raw text output
/// which is already well-formatted for display.
/// </summary>
public class NifToolOutput
{
    public string Output { get; set; } = "";
    public bool DryRun { get; set; }
}
