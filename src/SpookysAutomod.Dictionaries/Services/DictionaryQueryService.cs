using SpookysAutomod.Core.Logging;
using SpookysAutomod.Core.Models;
using SpookysAutomod.Dictionaries.Models;

namespace SpookysAutomod.Dictionaries.Services;

public sealed class DictionaryQueryService
{
    private readonly DictionaryCatalogService _catalogService;

    public DictionaryQueryService(IModLogger logger)
    {
        _catalogService = new DictionaryCatalogService(logger);
    }

    public Result<DictionaryLookupResult> Lookup(DictionaryLookupOptions options)
    {
        if (string.IsNullOrWhiteSpace(options.Edid))
        {
            return Result<DictionaryLookupResult>.Fail(
                "EDID is required for lookup.",
                suggestions: new List<string> { "Pass the EDID as the first argument to dictionary lookup." });
        }

        var catalogResult = _catalogService.Load(options.InputDirectory);
        if (!catalogResult.Success || catalogResult.Value is null)
            return Result<DictionaryLookupResult>.Fail(catalogResult.Error!, catalogResult.ErrorContext, catalogResult.Suggestions);

        var matches = catalogResult.Value.Files
            .SelectMany(file => file.RecordDocuments)
            .Where(record =>
                string.Equals(record.Edid, options.Edid, StringComparison.OrdinalIgnoreCase) &&
                MatchesFilters(record, options.Addon, options.RecordType, options.Field))
            .OrderBy(record => record.Addon, StringComparer.OrdinalIgnoreCase)
            .ThenBy(record => record.Edid, StringComparer.OrdinalIgnoreCase)
            .ToList();

        if (matches.Count == 0)
        {
            return Result<DictionaryLookupResult>.Fail(
                $"No dictionary record found for EDID: {options.Edid}",
                suggestions: new List<string>
                {
                    "Check the EDID spelling.",
                    "Try dictionary search with --text to do a fuzzy match.",
                    "Use --addon if you want to narrow to a specific game or DLC."
                });
        }

        return Result<DictionaryLookupResult>.Ok(new DictionaryLookupResult
        {
            Edid = options.Edid,
            MatchCount = matches.Count,
            Matches = matches
        });
    }

    public Result<DictionarySearchResult> Search(DictionarySearchOptions options)
    {
        if (string.IsNullOrWhiteSpace(options.Text))
        {
            return Result<DictionarySearchResult>.Fail(
                "Search text is required.",
                suggestions: new List<string> { "Pass --text with an EDID, English term, or Chinese term." });
        }

        if (options.Limit <= 0)
        {
            return Result<DictionarySearchResult>.Fail(
                "Limit must be greater than zero.",
                suggestions: new List<string> { "Use a positive value such as --limit 20." });
        }

        var catalogResult = _catalogService.Load(options.InputDirectory);
        if (!catalogResult.Success || catalogResult.Value is null)
            return Result<DictionarySearchResult>.Fail(catalogResult.Error!, catalogResult.ErrorContext, catalogResult.Suggestions);

        var normalizedQuery = options.Text.Trim().ToLowerInvariant();
        var matchingEntries = catalogResult.Value.Files
            .SelectMany(file => file.Entries)
            .Where(entry =>
                MatchesFilters(entry, options.Addon, options.RecordType, options.Field) &&
                MatchesScope(entry, normalizedQuery, options.Scope))
            .OrderBy(entry => entry.Addon, StringComparer.OrdinalIgnoreCase)
            .ThenBy(entry => entry.Edid, StringComparer.OrdinalIgnoreCase)
            .ThenBy(entry => entry.RecordType, StringComparer.OrdinalIgnoreCase)
            .ThenBy(entry => entry.Field, StringComparer.OrdinalIgnoreCase)
            .ThenBy(entry => entry.Sid, StringComparer.OrdinalIgnoreCase)
            .ToList();

        if (options.GroupBy == DictionaryResultGrouping.Record)
        {
            var matchedKeys = matchingEntries
                .Select(entry => $"{entry.Addon}:{entry.Edid}")
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .ToHashSet(StringComparer.OrdinalIgnoreCase);

            var matchingRecords = catalogResult.Value.Files
                .SelectMany(file => file.RecordDocuments)
                .Where(record => matchedKeys.Contains($"{record.Addon}:{record.Edid}"))
                .OrderBy(record => record.Addon, StringComparer.OrdinalIgnoreCase)
                .ThenBy(record => record.Edid, StringComparer.OrdinalIgnoreCase)
                .ToList();

            return Result<DictionarySearchResult>.Ok(new DictionarySearchResult
            {
                Text = options.Text,
                Scope = options.Scope.ToString().ToLowerInvariant(),
                GroupBy = options.GroupBy.ToString().ToLowerInvariant(),
                TotalMatches = matchingRecords.Count,
                ReturnedCount = Math.Min(options.Limit, matchingRecords.Count),
                Records = matchingRecords.Take(options.Limit).ToList()
            });
        }

        return Result<DictionarySearchResult>.Ok(new DictionarySearchResult
        {
            Text = options.Text,
            Scope = options.Scope.ToString().ToLowerInvariant(),
            GroupBy = options.GroupBy.ToString().ToLowerInvariant(),
            TotalMatches = matchingEntries.Count,
            ReturnedCount = Math.Min(options.Limit, matchingEntries.Count),
            Entries = matchingEntries.Take(options.Limit).ToList()
        });
    }

    private static bool MatchesFilters(
        DictionaryAgentRecordDocument record,
        string? addon,
        string? recordType,
        string? field)
    {
        if (!string.IsNullOrWhiteSpace(addon) &&
            !string.Equals(record.Addon, addon, StringComparison.OrdinalIgnoreCase))
            return false;

        if (string.IsNullOrWhiteSpace(recordType) && string.IsNullOrWhiteSpace(field))
            return true;

        return record.Translations.Any(translation =>
            (string.IsNullOrWhiteSpace(recordType) ||
             string.Equals(translation.RecordType, recordType, StringComparison.OrdinalIgnoreCase)) &&
            (string.IsNullOrWhiteSpace(field) ||
             string.Equals(translation.Field, field, StringComparison.OrdinalIgnoreCase)));
    }

    private static bool MatchesFilters(
        DictionaryAgentEntry entry,
        string? addon,
        string? recordType,
        string? field)
    {
        if (!string.IsNullOrWhiteSpace(addon) &&
            !string.Equals(entry.Addon, addon, StringComparison.OrdinalIgnoreCase))
            return false;

        if (!string.IsNullOrWhiteSpace(recordType) &&
            !string.Equals(entry.RecordType, recordType, StringComparison.OrdinalIgnoreCase))
            return false;

        if (!string.IsNullOrWhiteSpace(field) &&
            !string.Equals(entry.Field, field, StringComparison.OrdinalIgnoreCase))
            return false;

        return true;
    }

    private static bool MatchesScope(
        DictionaryAgentEntry entry,
        string normalizedQuery,
        DictionarySearchScope scope)
    {
        return scope switch
        {
            DictionarySearchScope.Edid => Contains(entry.Edid, normalizedQuery),
            DictionarySearchScope.English => Contains(entry.EnglishNormalized, normalizedQuery),
            DictionarySearchScope.Chinese => Contains(entry.ChineseNormalized, normalizedQuery),
            _ => Contains(entry.Edid, normalizedQuery) ||
                 Contains(entry.EnglishNormalized, normalizedQuery) ||
                 Contains(entry.ChineseNormalized, normalizedQuery) ||
                 Contains(entry.Record, normalizedQuery) ||
                 Contains(entry.RecordType, normalizedQuery) ||
                 Contains(entry.Field, normalizedQuery) ||
                 Contains(entry.Addon, normalizedQuery)
        };
    }

    private static bool Contains(string value, string normalizedQuery) =>
        !string.IsNullOrWhiteSpace(value) &&
        value.Contains(normalizedQuery, StringComparison.OrdinalIgnoreCase);
}
