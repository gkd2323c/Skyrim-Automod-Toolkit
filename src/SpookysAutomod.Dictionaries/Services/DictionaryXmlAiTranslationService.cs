using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Xml.Linq;
using SpookysAutomod.Core.Logging;
using SpookysAutomod.Core.Models;
using SpookysAutomod.Dictionaries.Models;

namespace SpookysAutomod.Dictionaries.Services;

public sealed class DictionaryXmlAiTranslationService
{
    private const int SampleLimit = 20;
    private const string DefaultModel = "gpt-4.1-mini";
    private const string DefaultEndpoint = "https://api.openai.com/v1/responses";
    private const int DefaultBatchSize = 20;
    private const double DefaultMinConfidence = 0.75;
    private const int DefaultMaxOutputTokens = 4000;
    private const string DefaultSystemPrompt = """
        You translate Skyrim Special Edition player-facing text from English to Simplified Chinese for SSTXMLRessources exports.

        Rules:
        - Preserve placeholders and markup exactly, including tokens like <Alias=...>, <Global=...>, %s, and line breaks.
        - Keep technical identifiers untouched; translate only the player-facing source text.
        - Prefer established vanilla Skyrim Chinese terminology over literal invention.
        - Translate titles and functional descriptors, but do not over-translate personal names just because they have surface meaning.
        - Return only valid JSON matching the requested schema.
        - Confidence is a number between 0 and 1.
        """;
    private const string DefaultUserPromptPreamble = """
        Translate the following entries.
        Return JSON with shape: {"translations":[{"id":"...","translation":"...","confidence":0.0,"notes":"..."}]}
        Entries:
        """;
    private static readonly JsonSerializerOptions ReportJsonOptions = new()
    {
        WriteIndented = true
    };

    private readonly IModLogger _logger;
    private readonly DictionaryXmlTranslationService _dictionaryTranslationService;
    private readonly IAiTranslationClient _aiTranslationClient;
    private readonly AiTranslationSettingsService _settingsService;

    public DictionaryXmlAiTranslationService(IModLogger logger)
        : this(logger, new OpenAiResponsesTranslationClient(logger))
    {
    }

    public DictionaryXmlAiTranslationService(IModLogger logger, IAiTranslationClient aiTranslationClient)
    {
        _logger = logger;
        _dictionaryTranslationService = new DictionaryXmlTranslationService(logger);
        _aiTranslationClient = aiTranslationClient;
        _settingsService = new AiTranslationSettingsService();
    }

    public Result<DictionaryTranslateXmlAiResult> Translate(DictionaryTranslateXmlAiOptions options)
    {
        var resolved = ResolveOptions(options);

        if (string.IsNullOrWhiteSpace(resolved.ApiKey))
        {
            return Result<DictionaryTranslateXmlAiResult>.Fail(
                "OpenAI API key is required.",
                suggestions: new List<string>
                {
                    "Pass --api-key or set the OPENAI_API_KEY environment variable."
                });
        }

        if (string.IsNullOrWhiteSpace(resolved.Model))
        {
            return Result<DictionaryTranslateXmlAiResult>.Fail(
                "A model name is required.",
                suggestions: new List<string>
                {
                    "Pass --model or set the OPENAI_MODEL environment variable."
                });
        }

        if (resolved.BatchSize <= 0)
        {
            return Result<DictionaryTranslateXmlAiResult>.Fail(
                "Batch size must be greater than zero.",
                suggestions: new List<string> { "Use a positive value such as --batch-size 20." });
        }

        if (resolved.MinConfidence is < 0 or > 1)
        {
            return Result<DictionaryTranslateXmlAiResult>.Fail(
                "Min confidence must be between 0 and 1.",
                suggestions: new List<string> { "Use a value such as --min-confidence 0.75." });
        }

        var dictionaryResult = _dictionaryTranslationService.Translate(new DictionaryTranslateXmlOptions
        {
            InputFile = resolved.InputFile,
            OutputFile = resolved.OutputFile,
            ReferenceDirectory = resolved.ReferenceDirectory,
            OverwriteExisting = resolved.OverwriteExisting
        });

        if (!dictionaryResult.Success || dictionaryResult.Value is null)
            return Result<DictionaryTranslateXmlAiResult>.Fail(dictionaryResult.Error!, dictionaryResult.ErrorContext, dictionaryResult.Suggestions);

        var outputFile = dictionaryResult.Value.OutputFile;

        try
        {
            var document = XDocument.Load(outputFile, LoadOptions.PreserveWhitespace);
            var contentElement = document.Root?.Element("Content");
            if (contentElement is null)
            {
                return Result<DictionaryTranslateXmlAiResult>.Fail(
                    "Translated XML is missing the Content element.",
                    suggestions: new List<string> { "Make sure the input file is an SSTXMLRessources export." });
            }

            var pendingEntries = contentElement.Elements("String")
                .Select((element, index) => PendingTranslationEntry.FromElement(element, index))
                .Where(entry => entry.NeedsTranslation)
                .ToList();

            var aiTranslatedEntries = 0;
            var lowConfidenceEntries = 0;
            var failedAiEntries = 0;
            var lowConfidenceSamples = new List<DictionaryTranslateXmlAiSample>();
            var failedAiSamples = new List<DictionaryTranslateXmlAiSample>();

            foreach (var batch in Chunk(pendingEntries, resolved.BatchSize))
            {
                _logger.Info($"AI translating batch of {batch.Count} entries...");
                var batchResult = _aiTranslationClient.TranslateBatch(new AiTranslationRequest
                {
                    ApiKey = resolved.ApiKey,
                    Endpoint = resolved.Endpoint,
                    Model = resolved.Model,
                    MaxOutputTokens = resolved.MaxOutputTokens,
                    SystemPrompt = resolved.SystemPrompt,
                    UserPromptPreamble = resolved.UserPromptPreamble,
                    Entries = batch.Select(entry => new AiTranslationRequestEntry
                    {
                        Id = entry.Id,
                        Edid = entry.Edid,
                        Record = entry.Record,
                        Source = entry.Source
                    }).ToList()
                });

                if (!batchResult.Success || batchResult.Value is null)
                {
                    failedAiEntries += batch.Count;
                    foreach (var entry in batch.Take(Math.Max(0, SampleLimit - failedAiSamples.Count)))
                    {
                        failedAiSamples.Add(new DictionaryTranslateXmlAiSample
                        {
                            Edid = entry.Edid,
                            Record = entry.Record,
                            Source = entry.Source,
                            Notes = batchResult.Error
                        });
                    }

                    continue;
                }

                var translationsById = batchResult.Value.Translations
                    .ToDictionary(item => item.Id, StringComparer.Ordinal);

                foreach (var entry in batch)
                {
                    if (!translationsById.TryGetValue(entry.Id, out var translation))
                    {
                        failedAiEntries++;
                        if (failedAiSamples.Count < SampleLimit)
                        {
                            failedAiSamples.Add(new DictionaryTranslateXmlAiSample
                            {
                                Edid = entry.Edid,
                                Record = entry.Record,
                                Source = entry.Source,
                                Notes = "Model response did not include this entry."
                            });
                        }

                        continue;
                    }

                    if (string.IsNullOrWhiteSpace(translation.Translation))
                    {
                        failedAiEntries++;
                        if (failedAiSamples.Count < SampleLimit)
                        {
                            failedAiSamples.Add(new DictionaryTranslateXmlAiSample
                            {
                                Edid = entry.Edid,
                                Record = entry.Record,
                                Source = entry.Source,
                                Confidence = translation.Confidence,
                                Notes = translation.Notes ?? "Model returned an empty translation."
                            });
                        }

                        continue;
                    }

                    if (translation.Confidence < resolved.MinConfidence)
                    {
                        lowConfidenceEntries++;
                        if (lowConfidenceSamples.Count < SampleLimit)
                        {
                            lowConfidenceSamples.Add(new DictionaryTranslateXmlAiSample
                            {
                                Edid = entry.Edid,
                                Record = entry.Record,
                                Source = entry.Source,
                                Translation = translation.Translation,
                                Confidence = translation.Confidence,
                                Notes = translation.Notes
                            });
                        }

                        continue;
                    }

                    entry.DestElement.Value = translation.Translation;
                    aiTranslatedEntries++;
                }
            }

            using (var writer = new StreamWriter(outputFile, false, new UTF8Encoding(true)))
            {
                document.Save(writer);
            }

            var remainingUntranslatedEntries = contentElement.Elements("String")
                .Select(PendingTranslationEntry.FromElement)
                .Count(entry => entry.NeedsTranslation);

            string? reportFile = null;
            if (!string.IsNullOrWhiteSpace(resolved.ReportFile))
            {
                reportFile = Path.GetFullPath(resolved.ReportFile);
                var reportDirectory = Path.GetDirectoryName(reportFile);
                if (!string.IsNullOrWhiteSpace(reportDirectory))
                    Directory.CreateDirectory(reportDirectory);

                var reportResult = new DictionaryTranslateXmlAiResult
                {
                    InputFile = dictionaryResult.Value.InputFile,
                    OutputFile = outputFile,
                    ConfigFile = resolved.ConfigFile,
                    ReportFile = reportFile,
                    ReferenceDirectory = dictionaryResult.Value.ReferenceDirectory,
                    Model = resolved.Model,
                    TotalEntries = dictionaryResult.Value.TotalEntries,
                    DictionaryTranslatedEntries = dictionaryResult.Value.TranslatedEntries,
                    AiAttemptedEntries = pendingEntries.Count,
                    AiTranslatedEntries = aiTranslatedEntries,
                    SkippedExistingEntries = dictionaryResult.Value.SkippedExistingEntries,
                    DictionaryUnmatchedEntries = dictionaryResult.Value.UnmatchedEntries,
                    DictionaryAmbiguousEntries = dictionaryResult.Value.AmbiguousEntries,
                    LowConfidenceEntries = lowConfidenceEntries,
                    FailedAiEntries = failedAiEntries,
                    RemainingUntranslatedEntries = remainingUntranslatedEntries,
                    LowConfidenceSamples = lowConfidenceSamples,
                    FailedAiSamples = failedAiSamples
                };

                File.WriteAllText(reportFile, JsonSerializer.Serialize(reportResult, ReportJsonOptions), new UTF8Encoding(true));
            }

            return Result<DictionaryTranslateXmlAiResult>.Ok(new DictionaryTranslateXmlAiResult
            {
                InputFile = dictionaryResult.Value.InputFile,
                OutputFile = outputFile,
                ConfigFile = resolved.ConfigFile,
                ReportFile = reportFile,
                ReferenceDirectory = dictionaryResult.Value.ReferenceDirectory,
                Model = resolved.Model,
                TotalEntries = dictionaryResult.Value.TotalEntries,
                DictionaryTranslatedEntries = dictionaryResult.Value.TranslatedEntries,
                AiAttemptedEntries = pendingEntries.Count,
                AiTranslatedEntries = aiTranslatedEntries,
                SkippedExistingEntries = dictionaryResult.Value.SkippedExistingEntries,
                DictionaryUnmatchedEntries = dictionaryResult.Value.UnmatchedEntries,
                DictionaryAmbiguousEntries = dictionaryResult.Value.AmbiguousEntries,
                LowConfidenceEntries = lowConfidenceEntries,
                FailedAiEntries = failedAiEntries,
                RemainingUntranslatedEntries = remainingUntranslatedEntries,
                LowConfidenceSamples = lowConfidenceSamples,
                FailedAiSamples = failedAiSamples
            });
        }
        catch (Exception ex)
        {
            _logger.Error("Failed to apply AI translations to XML file.", ex);
            return Result<DictionaryTranslateXmlAiResult>.Fail(
                "Failed to translate XML file with AI fallback.",
                ex.Message,
                new List<string>
                {
                    "Check the output XML path and report path.",
                    "Try again with a smaller --batch-size if the model response is too large."
                });
        }
    }

    private static IEnumerable<List<PendingTranslationEntry>> Chunk(IReadOnlyList<PendingTranslationEntry> source, int batchSize)
    {
        for (var index = 0; index < source.Count; index += batchSize)
            yield return source.Skip(index).Take(batchSize).ToList();
    }

    private ResolvedDictionaryTranslateXmlAiOptions ResolveOptions(DictionaryTranslateXmlAiOptions options)
    {
        var settingsLoad = _settingsService.Load(options.ConfigFile);
        var settings = settingsLoad.Settings;

        return new ResolvedDictionaryTranslateXmlAiOptions
        {
            InputFile = options.InputFile,
            OutputFile = options.OutputFile,
            ReferenceDirectory = options.ReferenceDirectory,
            ConfigFile = settingsLoad.ConfigFile,
            ReportFile = FirstNonEmpty(options.ReportFile, settings?.ReportFile),
            OverwriteExisting = options.OverwriteExisting,
            ApiKey = FirstNonEmpty(options.ApiKey, settings?.ApiKey, Environment.GetEnvironmentVariable("OPENAI_API_KEY")) ?? string.Empty,
            Model = FirstNonEmpty(options.Model, settings?.Model, Environment.GetEnvironmentVariable("OPENAI_MODEL"), DefaultModel) ?? DefaultModel,
            Endpoint = FirstNonEmpty(options.Endpoint, settings?.Endpoint, Environment.GetEnvironmentVariable("OPENAI_BASE_URL"), DefaultEndpoint) ?? DefaultEndpoint,
            SystemPrompt = FirstNonEmpty(options.SystemPrompt, settings?.SystemPrompt, DefaultSystemPrompt) ?? DefaultSystemPrompt,
            UserPromptPreamble = FirstNonEmpty(options.UserPromptPreamble, settings?.UserPromptPreamble, DefaultUserPromptPreamble) ?? DefaultUserPromptPreamble,
            BatchSize = FirstPositive(options.BatchSize, settings?.BatchSize, DefaultBatchSize),
            MinConfidence = options.MinConfidence > 0 ? options.MinConfidence : settings?.MinConfidence ?? DefaultMinConfidence,
            MaxOutputTokens = FirstPositive(options.MaxOutputTokens, settings?.MaxOutputTokens, DefaultMaxOutputTokens)
        };
    }

    private static string? FirstNonEmpty(params string?[] values) =>
        values.FirstOrDefault(value => !string.IsNullOrWhiteSpace(value));

    private static int FirstPositive(params int?[] values) =>
        values.FirstOrDefault(value => value.HasValue && value.Value > 0) ?? 0;

    private sealed class PendingTranslationEntry
    {
        public string Id { get; init; } = string.Empty;
        public string Edid { get; init; } = string.Empty;
        public string Record { get; init; } = string.Empty;
        public string Source { get; init; } = string.Empty;
        public XElement DestElement { get; init; } = null!;
        public bool NeedsTranslation { get; init; }

        public static PendingTranslationEntry FromElement(XElement element, int index = 0)
        {
            var source = NormalizeText(element.Element("Source")?.Value);
            var destElement = element.Element("Dest") ?? new XElement("Dest");
            if (destElement.Parent is null)
                element.Add(destElement);

            var dest = NormalizeText(destElement.Value);

            return new PendingTranslationEntry
            {
                Id = $"entry-{index:D6}",
                Edid = NormalizeText(element.Element("EDID")?.Value),
                Record = NormalizeText(element.Element("REC")?.Value),
                Source = source,
                DestElement = destElement,
                NeedsTranslation = string.IsNullOrWhiteSpace(dest) || string.Equals(source, dest, StringComparison.Ordinal)
            };
        }

        private static string NormalizeText(string? value) =>
            string.IsNullOrWhiteSpace(value) ? string.Empty : value.Trim();
    }

    private sealed class ResolvedDictionaryTranslateXmlAiOptions
    {
        public string InputFile { get; init; } = string.Empty;
        public string OutputFile { get; init; } = string.Empty;
        public string ReferenceDirectory { get; init; } = string.Empty;
        public string? ConfigFile { get; init; }
        public string? ReportFile { get; init; }
        public bool OverwriteExisting { get; init; }
        public string ApiKey { get; init; } = string.Empty;
        public string Model { get; init; } = string.Empty;
        public string Endpoint { get; init; } = string.Empty;
        public string SystemPrompt { get; init; } = string.Empty;
        public string UserPromptPreamble { get; init; } = string.Empty;
        public int BatchSize { get; init; }
        public double MinConfidence { get; init; }
        public int MaxOutputTokens { get; init; }
    }
}

public interface IAiTranslationClient
{
    Result<AiTranslationBatchResult> TranslateBatch(AiTranslationRequest request);
}

public sealed class AiTranslationRequest
{
    public string ApiKey { get; init; } = string.Empty;
    public string Endpoint { get; init; } = string.Empty;
    public string Model { get; init; } = string.Empty;
    public int MaxOutputTokens { get; init; }
    public string SystemPrompt { get; init; } = string.Empty;
    public string UserPromptPreamble { get; init; } = string.Empty;
    public List<AiTranslationRequestEntry> Entries { get; init; } = new();
}

public sealed class AiTranslationRequestEntry
{
    public string Id { get; init; } = string.Empty;
    public string Edid { get; init; } = string.Empty;
    public string Record { get; init; } = string.Empty;
    public string Source { get; init; } = string.Empty;
}

public sealed class AiTranslationBatchResult
{
    public List<AiTranslationBatchItem> Translations { get; init; } = new();
}

public sealed class AiTranslationBatchItem
{
    public string Id { get; init; } = string.Empty;
    public string Translation { get; init; } = string.Empty;
    public double Confidence { get; init; }
    public string? Notes { get; init; }
}

internal sealed class OpenAiResponsesTranslationClient : IAiTranslationClient
{
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };

    private readonly IModLogger _logger;

    public OpenAiResponsesTranslationClient(IModLogger logger)
    {
        _logger = logger;
    }

    public Result<AiTranslationBatchResult> TranslateBatch(AiTranslationRequest request)
    {
        try
        {
            using var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", request.ApiKey);

            var payload = BuildPayload(request);
            using var content = new StringContent(payload.ToJsonString(), Encoding.UTF8, "application/json");
            using var response = httpClient.PostAsync(request.Endpoint, content).GetAwaiter().GetResult();
            var responseText = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            if (!response.IsSuccessStatusCode)
            {
                return Result<AiTranslationBatchResult>.Fail(
                    $"OpenAI request failed with status {(int)response.StatusCode}.",
                    responseText,
                    new List<string>
                    {
                        "Check OPENAI_API_KEY / --api-key.",
                        "Try a smaller batch with --batch-size.",
                        "Confirm the selected model is available to this API key."
                    });
            }

            var parsedText = ExtractOutputText(responseText);
            if (string.IsNullOrWhiteSpace(parsedText))
            {
                return Result<AiTranslationBatchResult>.Fail(
                    "OpenAI response did not contain text output.",
                    responseText);
            }

            var json = JsonNode.Parse(parsedText);
            var translations = json?["translations"]?.Deserialize<List<AiTranslationBatchItem>>(JsonOptions);
            if (translations is null)
            {
                return Result<AiTranslationBatchResult>.Fail(
                    "OpenAI response could not be parsed into translations.",
                    parsedText);
            }

            return Result<AiTranslationBatchResult>.Ok(new AiTranslationBatchResult
            {
                Translations = translations
            });
        }
        catch (Exception ex)
        {
            _logger.Error("OpenAI translation batch failed.", ex);
            return Result<AiTranslationBatchResult>.Fail(
                "OpenAI translation batch failed.",
                ex.Message);
        }
    }

    private static JsonObject BuildPayload(AiTranslationRequest request)
    {
        var userBuilder = new StringBuilder()
            .AppendLine(request.UserPromptPreamble);

        foreach (var entry in request.Entries)
        {
            userBuilder.AppendLine(JsonSerializer.Serialize(new
            {
                id = entry.Id,
                edid = entry.Edid,
                record = entry.Record,
                source = entry.Source
            }));
        }

        return new JsonObject
        {
            ["model"] = request.Model,
            ["max_output_tokens"] = request.MaxOutputTokens,
            ["text"] = new JsonObject
            {
                ["format"] = new JsonObject
                {
                    ["type"] = "json_object"
                }
            },
            ["input"] = new JsonArray
            {
                new JsonObject
                {
                    ["role"] = "system",
                    ["content"] = new JsonArray
                    {
                        new JsonObject
                        {
                            ["type"] = "input_text",
                            ["text"] = request.SystemPrompt
                        }
                    }
                },
                new JsonObject
                {
                    ["role"] = "user",
                    ["content"] = new JsonArray
                    {
                        new JsonObject
                        {
                            ["type"] = "input_text",
                            ["text"] = userBuilder.ToString()
                        }
                    }
                }
            }
        };
    }

    private static string ExtractOutputText(string responseText)
    {
        using var document = JsonDocument.Parse(responseText);
        var root = document.RootElement;

        if (root.TryGetProperty("output_text", out var outputTextElement) &&
            outputTextElement.ValueKind == JsonValueKind.String)
        {
            return outputTextElement.GetString() ?? string.Empty;
        }

        if (!root.TryGetProperty("output", out var outputArray) || outputArray.ValueKind != JsonValueKind.Array)
            return string.Empty;

        var builder = new StringBuilder();
        foreach (var output in outputArray.EnumerateArray())
        {
            if (!output.TryGetProperty("content", out var contentArray) || contentArray.ValueKind != JsonValueKind.Array)
                continue;

            foreach (var content in contentArray.EnumerateArray())
            {
                if (content.TryGetProperty("text", out var textElement) && textElement.ValueKind == JsonValueKind.String)
                    builder.Append(textElement.GetString());
            }
        }

        return builder.ToString().Trim();
    }
}
