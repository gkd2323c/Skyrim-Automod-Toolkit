using System.IO;
using System.Text.Json;

namespace SpookysAutomod.TranslationStudio.Services;

public sealed class DictionaryReferenceService
{
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };

    private readonly Lazy<List<DictionaryEntryReference>> _entries;
    private readonly string? _dictionaryDirectory;
    private readonly int _maxHintEnglishLength;
    private readonly int _maxHintChineseLength;

    public DictionaryReferenceService(string? dictionaryDirectory, int maxHintEnglishLength, int maxHintChineseLength)
    {
        _dictionaryDirectory = ResolveDictionaryDirectory(dictionaryDirectory);
        _maxHintEnglishLength = maxHintEnglishLength;
        _maxHintChineseLength = maxHintChineseLength;
        _entries = new Lazy<List<DictionaryEntryReference>>(LoadEntries, isThreadSafe: true);
    }

    public IReadOnlyList<DictionaryHint> FindHints(string record, string source, int limit = 5)
    {
        if (string.IsNullOrWhiteSpace(source) || string.IsNullOrWhiteSpace(_dictionaryDirectory))
            return Array.Empty<DictionaryHint>();

        var normalizedSource = Normalize(source);
        var recordPrefix = record.Split(':', 2)[0];
        var sourceTokens = Tokenize(normalizedSource);

        var matches = _entries.Value
            .Select(entry => new
            {
                Entry = entry,
                Score = Score(entry, normalizedSource, sourceTokens, recordPrefix)
            })
            .Where(item => item.Score > 0)
            .OrderByDescending(item => item.Score)
            .ThenBy(item => item.Entry.English.Length)
            .Take(limit)
            .Select(item => new DictionaryHint
            {
                English = item.Entry.English,
                Chinese = item.Entry.Chinese,
                Record = item.Entry.Record,
                Edid = item.Entry.Edid,
                Score = item.Score
            })
            .Where(hint => !string.Equals(hint.English, hint.Chinese, StringComparison.OrdinalIgnoreCase))
            .Where(hint => hint.Score >= 20)
            .Where(hint => hint.English.Length <= _maxHintEnglishLength)
            .Where(hint => hint.Chinese.Length <= _maxHintChineseLength)
            .ToList();

        return matches;
    }

    private List<DictionaryEntryReference> LoadEntries()
    {
        var results = new List<DictionaryEntryReference>();
        if (string.IsNullOrWhiteSpace(_dictionaryDirectory))
            return results;

        var entriesDirectory = Path.Combine(_dictionaryDirectory, "entries");
        if (!Directory.Exists(entriesDirectory))
            return results;

        foreach (var file in Directory.GetFiles(entriesDirectory, "*.jsonl", SearchOption.TopDirectoryOnly))
        {
            using var reader = new StreamReader(file, true);
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                var entry = JsonSerializer.Deserialize<DictionaryEntryJson>(line, JsonOptions);
                if (entry is null || string.IsNullOrWhiteSpace(entry.English) || string.IsNullOrWhiteSpace(entry.Chinese))
                    continue;

                results.Add(new DictionaryEntryReference
                {
                    English = entry.English,
                    Chinese = entry.Chinese,
                    Record = entry.Record ?? string.Empty,
                    Edid = entry.Edid ?? string.Empty,
                    EnglishNormalized = !string.IsNullOrWhiteSpace(entry.EnglishNormalized)
                        ? entry.EnglishNormalized
                        : Normalize(entry.English),
                    EnglishTokens = Tokenize(!string.IsNullOrWhiteSpace(entry.EnglishNormalized)
                        ? entry.EnglishNormalized
                        : Normalize(entry.English))
                });
            }
        }

        return results;
    }

    private static string? ResolveDictionaryDirectory(string? configuredDirectory)
    {
        if (!string.IsNullOrWhiteSpace(configuredDirectory))
        {
            var full = Path.GetFullPath(configuredDirectory);
            if (Directory.Exists(full))
                return full;
        }

        var dir = new DirectoryInfo(AppContext.BaseDirectory.TrimEnd(Path.DirectorySeparatorChar));
        while (dir is not null && !File.Exists(Path.Combine(dir.FullName, "SpookysAutomod.sln")))
            dir = dir.Parent;

        if (dir is null)
            return null;

        var candidate = Path.Combine(dir.FullName, "dictionaries", "agent-readable");
        return Directory.Exists(candidate) ? candidate : null;
    }

    private static int Score(DictionaryEntryReference entry, string normalizedSource, HashSet<string> sourceTokens, string recordPrefix)
    {
        var score = 0;

        if (string.Equals(entry.EnglishNormalized, normalizedSource, StringComparison.Ordinal))
            score += 100;

        if (!string.IsNullOrWhiteSpace(entry.Record) && entry.Record.StartsWith(recordPrefix, StringComparison.OrdinalIgnoreCase))
            score += 20;

        var entryTokens = entry.EnglishTokens;
        var sharedTokens = sourceTokens.Intersect(entryTokens, StringComparer.OrdinalIgnoreCase).ToList();

        if (sharedTokens.Count == 0 && score < 100)
            return 0;

        if (ContainsWholePhrase(normalizedSource, entry.EnglishNormalized))
            score += 20;

        if (sourceTokens.Count > 1 && sourceTokens.All(token => entryTokens.Contains(token)))
            score += 25;
        else if (entryTokens.Count > 1 && entryTokens.All(token => sourceTokens.Contains(token)))
            score += 10;

        if (entryTokens.Count == 1 && sharedTokens.Count == 1)
        {
            var token = sharedTokens[0];
            if (token.Length >= 6)
                score += 18;
        }

        foreach (var token in sharedTokens)
        {
            score += token.Length >= 6 ? 8 : 5;
        }

        return score;
    }

    private static string Normalize(string value)
    {
        var chars = value
            .ToLowerInvariant()
            .Select(ch => char.IsLetterOrDigit(ch) ? ch : ' ')
            .ToArray();

        return string.Join(' ', new string(chars).Split(' ', StringSplitOptions.RemoveEmptyEntries));
    }

    private static HashSet<string> Tokenize(string normalized) =>
        normalized.Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Where(token => token.Length >= 4)
            .ToHashSet(StringComparer.OrdinalIgnoreCase);

    private static bool ContainsWholePhrase(string haystack, string needle)
    {
        if (string.IsNullOrWhiteSpace(haystack) || string.IsNullOrWhiteSpace(needle))
            return false;

        var wrappedHaystack = $" {haystack} ";
        var wrappedNeedle = $" {needle} ";
        return wrappedHaystack.Contains(wrappedNeedle, StringComparison.OrdinalIgnoreCase);
    }

    private sealed class DictionaryEntryJson
    {
        public string? Edid { get; init; }
        public string? Record { get; init; }
        public string? English { get; init; }
        public string? Chinese { get; init; }
        public string? EnglishNormalized { get; init; }
    }

    private sealed class DictionaryEntryReference
    {
        public string Edid { get; init; } = string.Empty;
        public string Record { get; init; } = string.Empty;
        public string English { get; init; } = string.Empty;
        public string Chinese { get; init; } = string.Empty;
        public string EnglishNormalized { get; init; } = string.Empty;
        public HashSet<string> EnglishTokens { get; init; } = new(StringComparer.OrdinalIgnoreCase);
    }
}

public sealed class DictionaryHint
{
    public string English { get; init; } = string.Empty;
    public string Chinese { get; init; } = string.Empty;
    public string Record { get; init; } = string.Empty;
    public string Edid { get; init; } = string.Empty;
    public int Score { get; init; }
}
