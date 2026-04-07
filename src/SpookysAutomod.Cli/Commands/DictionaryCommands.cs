using System.CommandLine;
using SpookysAutomod.Core.Logging;
using SpookysAutomod.Core.Models;
using SpookysAutomod.Dictionaries.Models;
using SpookysAutomod.Dictionaries.Services;

namespace SpookysAutomod.Cli.Commands;

public static class DictionaryCommands
{
    private const string DefaultDictionaryInputDirectory = "dictionaries";
    private static Option<bool> _jsonOption = null!;
    private static Option<bool> _verboseOption = null!;

    public static Command Create(Option<bool> jsonOption, Option<bool> verboseOption)
    {
        _jsonOption = jsonOption;
        _verboseOption = verboseOption;

        var dictionaryCommand = new Command("dictionary", "Dictionary conversion and export utilities");
        dictionaryCommand.AddCommand(CreateLookupCommand());
        dictionaryCommand.AddCommand(CreateSearchCommand());
        dictionaryCommand.AddCommand(CreateExportAgentCommand());

        return dictionaryCommand;
    }

    private static IModLogger CreateLogger(bool json, bool verbose) =>
        json ? new SilentLogger() : new ConsoleLogger(verbose);

    private static Command CreateLookupCommand()
    {
        var edidArg = new Argument<string>("edid", "Exact EDID to look up");
        var inputOption = new Option<string>(
            aliases: new[] { "--input", "-i" },
            getDefaultValue: GetPreferredQueryInputDirectory,
            description: "Dictionary input directory. Defaults to ./dictionaries/agent-readable when present, otherwise ./dictionaries");
        var addonOption = new Option<string?>("--addon", "Restrict lookup to a specific addon such as Skyrim or Dragonborn");
        var recordTypeOption = new Option<string?>("--record-type", "Restrict results to a specific record type such as INFO or BOOK");
        var fieldOption = new Option<string?>("--field", "Restrict results to a specific field such as FULL or RNAM");

        var cmd = new Command("lookup", "Look up a dictionary record by exact EDID")
        {
            edidArg,
            inputOption,
            addonOption,
            recordTypeOption,
            fieldOption
        };

        cmd.SetHandler((edid, input, addon, recordType, field, json, verbose) =>
        {
            var logger = CreateLogger(json, verbose);
            var service = new DictionaryQueryService(logger);
            var result = service.Lookup(new DictionaryLookupOptions
            {
                InputDirectory = input,
                Edid = edid,
                Addon = addon,
                RecordType = recordType,
                Field = field
            });

            if (json)
            {
                Console.WriteLine(result.ToJson(true));
                return;
            }

            if (!result.Success || result.Value is null)
            {
                Console.Error.WriteLine($"Error: {result.Error}");
                if (result.Suggestions is { Count: > 0 })
                {
                    Console.Error.WriteLine("Suggestions:");
                    foreach (var suggestion in result.Suggestions)
                        Console.Error.WriteLine($"  - {suggestion}");
                }

                Environment.ExitCode = 1;
                return;
            }

            Console.WriteLine($"EDID: {result.Value.Edid}");
            Console.WriteLine($"Matches: {result.Value.MatchCount}");
            foreach (var match in result.Value.Matches)
            {
                Console.WriteLine($"\n[{match.Addon}] {match.Edid}");
                foreach (var translation in match.Translations)
                    Console.WriteLine($"  {translation.Record}: {translation.English} -> {translation.Chinese}");
            }
        }, edidArg, inputOption, addonOption, recordTypeOption, fieldOption, _jsonOption, _verboseOption);

        return cmd;
    }

    private static Command CreateSearchCommand()
    {
        var textOption = new Option<string>(
            "--text",
            description: "Search text to match against EDID, English, Chinese, or record metadata")
        { IsRequired = true };
        var inputOption = new Option<string>(
            aliases: new[] { "--input", "-i" },
            getDefaultValue: GetPreferredQueryInputDirectory,
            description: "Dictionary input directory. Defaults to ./dictionaries/agent-readable when present, otherwise ./dictionaries");
        var addonOption = new Option<string?>("--addon", "Restrict search to a specific addon such as Skyrim or Dragonborn");
        var recordTypeOption = new Option<string?>("--record-type", "Restrict results to a specific record type such as INFO or BOOK");
        var fieldOption = new Option<string?>("--field", "Restrict results to a specific field such as FULL or RNAM");
        var scopeOption = new Option<string>(
            "--scope",
            getDefaultValue: () => "all",
            description: "Search scope: all, edid, english, or chinese");
        var groupByOption = new Option<string>(
            "--group-by",
            getDefaultValue: () => "entry",
            description: "Result grouping: entry or record");
        var limitOption = new Option<int>(
            "--limit",
            getDefaultValue: () => 20,
            description: "Maximum number of results to return");

        var cmd = new Command("search", "Search dictionary entries or grouped records")
        {
            textOption,
            inputOption,
            addonOption,
            recordTypeOption,
            fieldOption,
            scopeOption,
            groupByOption,
            limitOption
        };

        cmd.SetHandler((context) =>
        {
            var text = context.ParseResult.GetValueForOption(textOption) ?? string.Empty;
            var input = context.ParseResult.GetValueForOption(inputOption) ?? GetPreferredQueryInputDirectory();
            var addon = context.ParseResult.GetValueForOption(addonOption);
            var recordType = context.ParseResult.GetValueForOption(recordTypeOption);
            var field = context.ParseResult.GetValueForOption(fieldOption);
            var scope = context.ParseResult.GetValueForOption(scopeOption) ?? "all";
            var groupBy = context.ParseResult.GetValueForOption(groupByOption) ?? "entry";
            var limit = context.ParseResult.GetValueForOption(limitOption);
            var json = context.ParseResult.GetValueForOption(_jsonOption);
            var verbose = context.ParseResult.GetValueForOption(_verboseOption);

            if (!TryParseScope(scope, out var parsedScope))
            {
                OutputValidationError("Invalid --scope. Use: all, edid, english, chinese.", json);
                return;
            }

            if (!TryParseGrouping(groupBy, out var parsedGrouping))
            {
                OutputValidationError("Invalid --group-by. Use: entry or record.", json);
                return;
            }

            var logger = CreateLogger(json, verbose);
            var service = new DictionaryQueryService(logger);
            var result = service.Search(new DictionarySearchOptions
            {
                InputDirectory = input,
                Text = text,
                Addon = addon,
                RecordType = recordType,
                Field = field,
                Limit = limit,
                Scope = parsedScope,
                GroupBy = parsedGrouping
            });

            if (json)
            {
                Console.WriteLine(result.ToJson(true));
                return;
            }

            if (!result.Success || result.Value is null)
            {
                Console.Error.WriteLine($"Error: {result.Error}");
                if (result.Suggestions is { Count: > 0 })
                {
                    Console.Error.WriteLine("Suggestions:");
                    foreach (var suggestion in result.Suggestions)
                        Console.Error.WriteLine($"  - {suggestion}");
                }

                Environment.ExitCode = 1;
                return;
            }

            Console.WriteLine($"Search: {result.Value.Text}");
            Console.WriteLine($"Scope: {result.Value.Scope}");
            Console.WriteLine($"Group By: {result.Value.GroupBy}");
            Console.WriteLine($"Returned: {result.Value.ReturnedCount} / {result.Value.TotalMatches}");

            if (result.Value.Entries is { Count: > 0 })
            {
                foreach (var entry in result.Value.Entries)
                    Console.WriteLine($"[{entry.Addon}] {entry.Edid} {entry.Record}: {entry.English} -> {entry.Chinese}");
            }
            else if (result.Value.Records is { Count: > 0 })
            {
                foreach (var record in result.Value.Records)
                    Console.WriteLine($"[{record.Addon}] {record.Edid} ({record.Translations.Count} translations)");
            }
        });

        return cmd;
    }

    private static Command CreateExportAgentCommand()
    {
        var inputOption = new Option<string>(
            aliases: new[] { "--input", "-i" },
            getDefaultValue: () => "dictionaries",
            description: "Directory containing *_english_chinese.xml files");
        var outputOption = new Option<string>(
            aliases: new[] { "--output", "-o" },
            getDefaultValue: () => Path.Combine("dictionaries", "agent-readable"),
            description: "Output directory for agent-readable JSONL shards and manifest");
        var shardSizeOption = new Option<int>(
            "--shard-size",
            getDefaultValue: () => 5000,
            description: "Maximum documents per JSONL shard");

        var cmd = new Command(
            "export-agent",
            "Convert XML game dictionaries into sharded JSONL and EDID-grouped documents for AI agents")
        {
            inputOption,
            outputOption,
            shardSizeOption
        };

        cmd.SetHandler((input, output, shardSize, json, verbose) =>
        {
            var logger = CreateLogger(json, verbose);
            var service = new DictionaryAgentExportService(logger);

            var result = service.Export(new DictionaryAgentExportOptions
            {
                InputDirectory = input,
                OutputDirectory = output,
                ShardSize = shardSize
            });

            if (json)
            {
                Console.WriteLine(result.ToJson(true));
                return;
            }

            if (!result.Success || result.Value is null)
            {
                Console.Error.WriteLine($"Error: {result.Error}");
                if (!string.IsNullOrWhiteSpace(result.ErrorContext))
                    Console.Error.WriteLine(result.ErrorContext);

                if (result.Suggestions is { Count: > 0 })
                {
                    Console.Error.WriteLine("Suggestions:");
                    foreach (var suggestion in result.Suggestions)
                        Console.Error.WriteLine($"  - {suggestion}");
                }

                Environment.ExitCode = 1;
                return;
            }

            var summary = result.Value;
            Console.WriteLine($"Exported {summary.TotalEntries:N0} entries into {summary.TotalRecordDocuments:N0} grouped record documents.");
            Console.WriteLine($"Source files: {summary.TotalSourceFiles}");
            Console.WriteLine($"Output: {summary.OutputDirectory}");
            Console.WriteLine($"Manifest: {Path.Combine(summary.OutputDirectory, "manifest.json")}");
            Console.WriteLine($"Generated shards: {summary.GeneratedFiles.Count(file => file.EndsWith(".jsonl", StringComparison.OrdinalIgnoreCase)):N0}");
        }, inputOption, outputOption, shardSizeOption, _jsonOption, _verboseOption);

        return cmd;
    }

    private static string GetPreferredQueryInputDirectory()
    {
        var exportedDirectory = Path.Combine(DefaultDictionaryInputDirectory, "agent-readable");
        return LooksLikeAgentReadableDirectory(exportedDirectory)
            ? exportedDirectory
            : DefaultDictionaryInputDirectory;
    }

    private static bool LooksLikeAgentReadableDirectory(string directory)
    {
        if (!Directory.Exists(directory))
            return false;

        return File.Exists(Path.Combine(directory, "manifest.json"))
               || Directory.Exists(Path.Combine(directory, "entries"))
               || Directory.Exists(Path.Combine(directory, "records"));
    }

    private static bool TryParseScope(string scope, out DictionarySearchScope parsed)
    {
        switch (scope.Trim().ToLowerInvariant())
        {
            case "all":
                parsed = DictionarySearchScope.All;
                return true;
            case "edid":
                parsed = DictionarySearchScope.Edid;
                return true;
            case "english":
                parsed = DictionarySearchScope.English;
                return true;
            case "chinese":
                parsed = DictionarySearchScope.Chinese;
                return true;
            default:
                parsed = default;
                return false;
        }
    }

    private static bool TryParseGrouping(string groupBy, out DictionaryResultGrouping parsed)
    {
        switch (groupBy.Trim().ToLowerInvariant())
        {
            case "entry":
                parsed = DictionaryResultGrouping.Entry;
                return true;
            case "record":
                parsed = DictionaryResultGrouping.Record;
                return true;
            default:
                parsed = default;
                return false;
        }
    }

    private static void OutputValidationError(string error, bool json)
    {
        if (json)
            Console.WriteLine(Result.Fail(error).ToJson(true));
        else
        {
            Console.Error.WriteLine($"Error: {error}");
            Environment.ExitCode = 1;
        }
    }
}
