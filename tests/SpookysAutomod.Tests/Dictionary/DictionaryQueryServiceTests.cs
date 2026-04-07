using SpookysAutomod.Core.Logging;
using SpookysAutomod.Dictionaries.Models;
using SpookysAutomod.Dictionaries.Services;

namespace SpookysAutomod.Tests.Dictionary;

public class DictionaryQueryServiceTests
{
    [Fact]
    public void Lookup_ReturnsGroupedRecordForExactEdid()
    {
        var root = CreateSampleDictionaryDirectory();

        try
        {
            var service = new DictionaryQueryService(new SilentLogger());
            var result = service.Lookup(new DictionaryLookupOptions
            {
                InputDirectory = root,
                Edid = "TestBook"
            });

            Assert.True(result.Success, result.Error);
            Assert.NotNull(result.Value);
            Assert.Equal(1, result.Value!.MatchCount);
            Assert.Equal("TestBook", result.Value.Matches[0].Edid);
            Assert.Equal(2, result.Value.Matches[0].Translations.Count);
        }
        finally
        {
            if (Directory.Exists(root))
                Directory.Delete(root, true);
        }
    }

    [Fact]
    public void Search_ByEnglishScope_ReturnsMatchingEntries()
    {
        var root = CreateSampleDictionaryDirectory();

        try
        {
            var service = new DictionaryQueryService(new SilentLogger());
            var result = service.Search(new DictionarySearchOptions
            {
                InputDirectory = root,
                Text = "hello",
                Scope = DictionarySearchScope.English,
                GroupBy = DictionaryResultGrouping.Entry,
                Limit = 10
            });

            Assert.True(result.Success, result.Error);
            Assert.NotNull(result.Value);
            Assert.Single(result.Value!.Entries!);
            Assert.Equal("TestBook", result.Value.Entries![0].Edid);
            Assert.Equal("Hello world", result.Value.Entries[0].English);
        }
        finally
        {
            if (Directory.Exists(root))
                Directory.Delete(root, true);
        }
    }

    [Fact]
    public void Search_GroupByRecord_DeduplicatesEntriesIntoRecords()
    {
        var root = CreateSampleDictionaryDirectory();

        try
        {
            var service = new DictionaryQueryService(new SilentLogger());
            var result = service.Search(new DictionarySearchOptions
            {
                InputDirectory = root,
                Text = "测试",
                Scope = DictionarySearchScope.Chinese,
                GroupBy = DictionaryResultGrouping.Record,
                Limit = 10
            });

            Assert.True(result.Success, result.Error);
            Assert.NotNull(result.Value);
            Assert.Single(result.Value!.Records!);
            Assert.Equal("TestBook", result.Value.Records![0].Edid);
        }
        finally
        {
            if (Directory.Exists(root))
                Directory.Delete(root, true);
        }
    }

    [Fact]
    public void Lookup_CanReadPreviouslyExportedJsonlDirectory()
    {
        var root = CreateSampleDictionaryDirectory();
        var exportDirectory = Path.Combine(root, "agent-readable");

        try
        {
            var exportService = new DictionaryAgentExportService(new SilentLogger());
            var exportResult = exportService.Export(new DictionaryAgentExportOptions
            {
                InputDirectory = root,
                OutputDirectory = exportDirectory,
                ShardSize = 10
            });

            Assert.True(exportResult.Success, exportResult.Error);

            var service = new DictionaryQueryService(new SilentLogger());
            var result = service.Lookup(new DictionaryLookupOptions
            {
                InputDirectory = exportDirectory,
                Edid = "TestBook"
            });

            Assert.True(result.Success, result.Error);
            Assert.NotNull(result.Value);
            Assert.Equal(1, result.Value!.MatchCount);
            Assert.Equal("测试之书", result.Value.Matches[0].Translations[0].Chinese);
        }
        finally
        {
            if (Directory.Exists(root))
                Directory.Delete(root, true);
        }
    }

    [Fact]
    public void Search_CanReadPreviouslyExportedJsonlDirectory()
    {
        var root = CreateSampleDictionaryDirectory();
        var exportDirectory = Path.Combine(root, "agent-readable");

        try
        {
            var exportService = new DictionaryAgentExportService(new SilentLogger());
            var exportResult = exportService.Export(new DictionaryAgentExportOptions
            {
                InputDirectory = root,
                OutputDirectory = exportDirectory,
                ShardSize = 10
            });

            Assert.True(exportResult.Success, exportResult.Error);

            var service = new DictionaryQueryService(new SilentLogger());
            var result = service.Search(new DictionarySearchOptions
            {
                InputDirectory = exportDirectory,
                Text = "测试",
                Scope = DictionarySearchScope.Chinese,
                GroupBy = DictionaryResultGrouping.Record,
                Limit = 10
            });

            Assert.True(result.Success, result.Error);
            Assert.NotNull(result.Value);
            Assert.Single(result.Value!.Records!);
            Assert.Equal("TestBook", result.Value.Records![0].Edid);
        }
        finally
        {
            if (Directory.Exists(root))
                Directory.Delete(root, true);
        }
    }

    private static string CreateSampleDictionaryDirectory()
    {
        var root = Path.Combine(Path.GetTempPath(), "SpookysAutomod.DictionaryQueryTests", Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(root);

        File.WriteAllText(Path.Combine(root, "Test_english_chinese.xml"), """
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
                  <Dest>测试简介</Dest>
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

        return root;
    }
}
