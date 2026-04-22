using System.Xml.Linq;
using SpookysAutomod.Core.Logging;
using SpookysAutomod.Core.Models;
using SpookysAutomod.Dictionaries.Models;
using SpookysAutomod.Dictionaries.Services;

namespace SpookysAutomod.Tests.Dictionary;

public class DictionaryXmlAiTranslationServiceTests
{
    [Fact]
    public void Translate_UsesDictionaryFirst_ThenAiForRemainingEntries()
    {
        var root = CreateTempRoot();

        try
        {
            var referenceDirectory = Path.Combine(root, "references");
            Directory.CreateDirectory(referenceDirectory);
            File.WriteAllText(Path.Combine(referenceDirectory, "Skyrim_english_chinese.xml"), """
                <?xml version="1.0" encoding="UTF-8" standalone="yes"?>
                <SSTXMLRessources>
                  <Params>
                    <Addon>Skyrim</Addon>
                    <Source>english</Source>
                    <Dest>chinese</Dest>
                    <Version>2</Version>
                  </Params>
                  <Content>
                    <String List="0" sID="000001">
                      <EDID>WhiterunWorld</EDID>
                      <REC>WRLD:FULL</REC>
                      <Source>Whiterun</Source>
                      <Dest>白漫</Dest>
                    </String>
                  </Content>
                </SSTXMLRessources>
                """);

            var inputFile = Path.Combine(root, "mod.xml");
            File.WriteAllText(inputFile, """
                <?xml version="1.0" encoding="UTF-8" standalone="yes"?>
                <SSTXMLRessources>
                  <Params>
                    <Addon>MyMod.esp</Addon>
                    <Source>english</Source>
                    <Dest>chinese</Dest>
                    <Version>2</Version>
                  </Params>
                  <Content>
                    <String List="0">
                      <EDID>WhiterunWorld</EDID>
                      <REC>WRLD:FULL</REC>
                      <Source>Whiterun</Source>
                      <Dest>Whiterun</Dest>
                    </String>
                    <String List="0">
                      <EDID>MyNewQuest</EDID>
                      <REC>QUST:NNAM</REC>
                      <Source>Meet the watcher at dusk</Source>
                      <Dest>Meet the watcher at dusk</Dest>
                    </String>
                  </Content>
                </SSTXMLRessources>
                """);

            var outputFile = Path.Combine(root, "translated.xml");
            var reportFile = Path.Combine(root, "report.json");
            var service = new DictionaryXmlAiTranslationService(new SilentLogger(), new FakeAiTranslationClient(new Dictionary<string, AiTranslationBatchItem>
            {
                ["entry-000001"] = new()
                {
                    Id = "entry-000001",
                    Translation = "在黄昏时与守望者会面",
                    Confidence = 0.93,
                    Notes = "quest objective"
                }
            }));

            var result = service.Translate(new DictionaryTranslateXmlAiOptions
            {
                InputFile = inputFile,
                OutputFile = outputFile,
                ReportFile = reportFile,
                ReferenceDirectory = referenceDirectory,
                ApiKey = "test-key",
                Model = "test-model",
                Endpoint = "https://example.invalid/v1/responses"
            });

            Assert.True(result.Success, result.Error);
            Assert.NotNull(result.Value);
            Assert.Equal(1, result.Value!.DictionaryTranslatedEntries);
            Assert.Equal(1, result.Value.AiAttemptedEntries);
            Assert.Equal(1, result.Value.AiTranslatedEntries);
            Assert.Equal(0, result.Value.RemainingUntranslatedEntries);
            Assert.True(File.Exists(reportFile));

            var output = XDocument.Load(outputFile);
            var strings = output.Root!.Element("Content")!.Elements("String").ToList();
            Assert.Equal("白漫", strings[0].Element("Dest")!.Value);
            Assert.Equal("在黄昏时与守望者会面", strings[1].Element("Dest")!.Value);
        }
        finally
        {
            Cleanup(root);
        }
    }

    [Fact]
    public void Translate_SkipsLowConfidenceAiResults()
    {
        var root = CreateTempRoot();

        try
        {
            var referenceDirectory = Path.Combine(root, "references");
            Directory.CreateDirectory(referenceDirectory);
            File.WriteAllText(Path.Combine(referenceDirectory, "Skyrim_english_chinese.xml"), """
                <?xml version="1.0" encoding="UTF-8" standalone="yes"?>
                <SSTXMLRessources>
                  <Params>
                    <Addon>Skyrim</Addon>
                    <Source>english</Source>
                    <Dest>chinese</Dest>
                    <Version>2</Version>
                  </Params>
                  <Content />
                </SSTXMLRessources>
                """);

            var inputFile = Path.Combine(root, "mod.xml");
            File.WriteAllText(inputFile, """
                <?xml version="1.0" encoding="UTF-8" standalone="yes"?>
                <SSTXMLRessources>
                  <Params>
                    <Addon>MyMod.esp</Addon>
                    <Source>english</Source>
                    <Dest>chinese</Dest>
                    <Version>2</Version>
                  </Params>
                  <Content>
                    <String List="0">
                      <EDID>MyNewQuest</EDID>
                      <REC>QUST:NNAM</REC>
                      <Source>Meet the watcher at dusk</Source>
                      <Dest>Meet the watcher at dusk</Dest>
                    </String>
                  </Content>
                </SSTXMLRessources>
                """);

            var outputFile = Path.Combine(root, "translated.xml");
            var service = new DictionaryXmlAiTranslationService(new SilentLogger(), new FakeAiTranslationClient(new Dictionary<string, AiTranslationBatchItem>
            {
                ["entry-000000"] = new()
                {
                    Id = "entry-000000",
                    Translation = "在黄昏时与守望者会面",
                    Confidence = 0.41,
                    Notes = "uncertain phrasing"
                }
            }));

            var result = service.Translate(new DictionaryTranslateXmlAiOptions
            {
                InputFile = inputFile,
                OutputFile = outputFile,
                ReferenceDirectory = referenceDirectory,
                ApiKey = "test-key",
                Model = "test-model",
                Endpoint = "https://example.invalid/v1/responses",
                MinConfidence = 0.75
            });

            Assert.True(result.Success, result.Error);
            Assert.NotNull(result.Value);
            Assert.Equal(1, result.Value!.AiAttemptedEntries);
            Assert.Equal(0, result.Value.AiTranslatedEntries);
            Assert.Equal(1, result.Value.LowConfidenceEntries);
            Assert.Equal(1, result.Value.RemainingUntranslatedEntries);

            var output = XDocument.Load(outputFile);
            var dest = output.Root!.Element("Content")!.Element("String")!.Element("Dest")!.Value;
            Assert.Equal("Meet the watcher at dusk", dest);
        }
        finally
        {
            Cleanup(root);
        }
    }

    [Fact]
    public void Translate_CanLoadSettingsFromConfigFile()
    {
        var root = CreateTempRoot();

        try
        {
            var configFile = Path.Combine(root, "settings.json");
            File.WriteAllText(configFile, """
                {
                  "aiTranslation": {
                    "apiKey": "config-key",
                    "model": "config-model",
                    "endpoint": "https://example.invalid/v1/responses",
                    "systemPrompt": "CONFIG_SYSTEM_PROMPT",
                    "userPromptPreamble": "CONFIG_USER_PROMPT",
                    "batchSize": 7,
                    "minConfidence": 0.6,
                    "maxOutputTokens": 1234
                  }
                }
                """);

            var referenceDirectory = Path.Combine(root, "references");
            Directory.CreateDirectory(referenceDirectory);
            File.WriteAllText(Path.Combine(referenceDirectory, "Skyrim_english_chinese.xml"), """
                <?xml version="1.0" encoding="UTF-8" standalone="yes"?>
                <SSTXMLRessources>
                  <Params>
                    <Addon>Skyrim</Addon>
                    <Source>english</Source>
                    <Dest>chinese</Dest>
                    <Version>2</Version>
                  </Params>
                  <Content />
                </SSTXMLRessources>
                """);

            var inputFile = Path.Combine(root, "mod.xml");
            File.WriteAllText(inputFile, """
                <?xml version="1.0" encoding="UTF-8" standalone="yes"?>
                <SSTXMLRessources>
                  <Params>
                    <Addon>MyMod.esp</Addon>
                    <Source>english</Source>
                    <Dest>chinese</Dest>
                    <Version>2</Version>
                  </Params>
                  <Content>
                    <String List="0">
                      <EDID>MyNewQuest</EDID>
                      <REC>QUST:NNAM</REC>
                      <Source>Meet the watcher at dusk</Source>
                      <Dest>Meet the watcher at dusk</Dest>
                    </String>
                  </Content>
                </SSTXMLRessources>
                """);

            var capturingClient = new CapturingAiTranslationClient();
            var outputFile = Path.Combine(root, "translated.xml");
            var service = new DictionaryXmlAiTranslationService(new SilentLogger(), capturingClient);

            var result = service.Translate(new DictionaryTranslateXmlAiOptions
            {
                InputFile = inputFile,
                OutputFile = outputFile,
                ConfigFile = configFile,
                ReferenceDirectory = referenceDirectory
            });

            Assert.True(result.Success, result.Error);
            Assert.NotNull(result.Value);
            Assert.Equal(configFile, result.Value!.ConfigFile);
            Assert.NotNull(capturingClient.LastRequest);
            Assert.Equal("config-key", capturingClient.LastRequest!.ApiKey);
            Assert.Equal("config-model", capturingClient.LastRequest.Model);
            Assert.Equal("https://example.invalid/v1/responses", capturingClient.LastRequest.Endpoint);
            Assert.Equal("CONFIG_SYSTEM_PROMPT", capturingClient.LastRequest.SystemPrompt);
            Assert.Equal("CONFIG_USER_PROMPT", capturingClient.LastRequest.UserPromptPreamble);
            Assert.Equal(1234, capturingClient.LastRequest.MaxOutputTokens);
        }
        finally
        {
            Cleanup(root);
        }
    }

    private static string CreateTempRoot()
    {
        var root = Path.Combine(Path.GetTempPath(), "SpookysAutomod.DictionaryXmlAiTranslationTests", Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(root);
        return root;
    }

    private static void Cleanup(string root)
    {
        if (Directory.Exists(root))
            Directory.Delete(root, true);
    }

    private sealed class FakeAiTranslationClient : IAiTranslationClient
    {
        private readonly IReadOnlyDictionary<string, AiTranslationBatchItem> _translations;

        public FakeAiTranslationClient(IReadOnlyDictionary<string, AiTranslationBatchItem> translations)
        {
            _translations = translations;
        }

        public Result<AiTranslationBatchResult> TranslateBatch(AiTranslationRequest request)
        {
            var items = request.Entries
                .Where(entry => _translations.ContainsKey(entry.Id))
                .Select(entry => _translations[entry.Id])
                .ToList();

            return Result<AiTranslationBatchResult>.Ok(new AiTranslationBatchResult
            {
                Translations = items
            });
        }
    }

    private sealed class CapturingAiTranslationClient : IAiTranslationClient
    {
        public AiTranslationRequest? LastRequest { get; private set; }

        public Result<AiTranslationBatchResult> TranslateBatch(AiTranslationRequest request)
        {
            LastRequest = request;
            return Result<AiTranslationBatchResult>.Ok(new AiTranslationBatchResult
            {
                Translations = new List<AiTranslationBatchItem>
                {
                    new()
                    {
                        Id = request.Entries[0].Id,
                        Translation = "在黄昏时与守望者会面",
                        Confidence = 0.9
                    }
                }
            });
        }
    }
}
