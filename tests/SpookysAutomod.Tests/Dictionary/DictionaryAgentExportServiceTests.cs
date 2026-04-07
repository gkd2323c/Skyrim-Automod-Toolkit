using System.Text.Json;
using SpookysAutomod.Core.Logging;
using SpookysAutomod.Dictionaries.Models;
using SpookysAutomod.Dictionaries.Services;

namespace SpookysAutomod.Tests.Dictionary;

public class DictionaryAgentExportServiceTests
{
    [Fact]
    public void Export_CreatesManifestAndJsonlShards()
    {
        var root = CreateTempDirectory();
        var input = Path.Combine(root, "input");
        var output = Path.Combine(root, "output");
        Directory.CreateDirectory(input);

        try
        {
            File.WriteAllText(Path.Combine(input, "Test_english_chinese.xml"), """
                <?xml version="1.0" encoding="UTF-8" standalone="yes"?>
                <SSTXMLRessources>
                  <Params>
                    <Addon>Test</Addon>
                    <Source>english</Source>
                    <Dest>chinese</Dest>
                    <Version>2</Version>
                  </Params>
                  <Content>
                    <String List="0" sID="000001">
                      <EDID>TestBook</EDID>
                      <REC>BOOK:FULL</REC>
                      <Source>Test Book</Source>
                      <Dest>测试之书</Dest>
                    </String>
                    <String List="0" sID="000002">
                      <EDID>TestBook</EDID>
                      <REC>BOOK:DESC</REC>
                      <Source>Hello   world</Source>
                      <Dest>你好   世界</Dest>
                    </String>
                    <String List="0" sID="000003">
                      <EDID>TestSpell</EDID>
                      <REC id="1" idMax="2">SPEL:FULL</REC>
                      <Source>Flames</Source>
                      <Dest>火焰</Dest>
                    </String>
                  </Content>
                </SSTXMLRessources>
                """);

            var service = new DictionaryAgentExportService(new SilentLogger());
            var result = service.Export(new DictionaryAgentExportOptions
            {
                InputDirectory = input,
                OutputDirectory = output,
                ShardSize = 2
            });

            Assert.True(result.Success, result.Error);
            Assert.NotNull(result.Value);
            Assert.Equal(3, result.Value!.TotalEntries);
            Assert.Equal(2, result.Value.TotalRecordDocuments);

            var manifestPath = Path.Combine(output, "manifest.json");
            Assert.True(File.Exists(manifestPath));

            var manifestJson = File.ReadAllText(manifestPath);
            Assert.Contains("\"totalEntries\": 3", manifestJson);
            Assert.Contains("\"totalRecordDocuments\": 2", manifestJson);

            var manifest = JsonSerializer.Deserialize<DictionaryAgentExportSummary>(manifestJson, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            Assert.NotNull(manifest);
            Assert.Equal("../input", manifest!.InputDirectory);
            Assert.Equal(".", manifest.OutputDirectory);
            Assert.All(manifest.GeneratedFiles, path => Assert.False(Path.IsPathRooted(path), $"Expected relative path but got: {path}"));
            Assert.Contains("entries/Test.entries.part-0001.jsonl", manifest.GeneratedFiles);
            Assert.Contains("records/Test.records.part-0001.jsonl", manifest.GeneratedFiles);
            Assert.Contains("manifest.json", manifest.GeneratedFiles);
            Assert.All(manifest.Addons.SelectMany(addon => addon.EntryFiles), path => Assert.False(Path.IsPathRooted(path), $"Expected relative path but got: {path}"));
            Assert.All(manifest.Addons.SelectMany(addon => addon.RecordFiles), path => Assert.False(Path.IsPathRooted(path), $"Expected relative path but got: {path}"));

            var entryFiles = Directory.GetFiles(Path.Combine(output, "entries"), "*.jsonl");
            var recordFiles = Directory.GetFiles(Path.Combine(output, "records"), "*.jsonl");
            Assert.Equal(2, entryFiles.Length);
            Assert.Single(recordFiles);

            var firstEntry = JsonSerializer.Deserialize<DictionaryAgentEntry>(File.ReadLines(entryFiles[0]).First(), new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            Assert.NotNull(firstEntry);
            Assert.Equal("TestBook", firstEntry!.Edid);
            Assert.Equal("test book", firstEntry.EnglishNormalized);
            Assert.Contains("Chinese: 测试之书", firstEntry.AgentText);
        }
        finally
        {
            if (Directory.Exists(root))
                Directory.Delete(root, true);
        }
    }

    [Fact]
    public void Export_FailsWhenNoXmlFilesExist()
    {
        var root = CreateTempDirectory();
        Directory.CreateDirectory(root);

        try
        {
            var service = new DictionaryAgentExportService(new SilentLogger());
            var result = service.Export(new DictionaryAgentExportOptions
            {
                InputDirectory = root,
                OutputDirectory = Path.Combine(root, "output")
            });

            Assert.False(result.Success);
            Assert.Contains("No XML dictionaries or exported JSONL shards found", result.Error);
        }
        finally
        {
            if (Directory.Exists(root))
                Directory.Delete(root, true);
        }
    }

    private static string CreateTempDirectory() =>
        Path.Combine(Path.GetTempPath(), "SpookysAutomod.DictionaryTests", Guid.NewGuid().ToString("N"));
}
