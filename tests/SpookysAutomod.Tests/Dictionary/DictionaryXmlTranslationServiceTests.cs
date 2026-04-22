using System.Xml.Linq;
using SpookysAutomod.Core.Logging;
using SpookysAutomod.Dictionaries.Models;
using SpookysAutomod.Dictionaries.Services;

namespace SpookysAutomod.Tests.Dictionary;

public class DictionaryXmlTranslationServiceTests
{
    [Fact]
    public void Translate_FillsUntranslatedDestUsingExactRecordMatch()
    {
        var root = CreateTempRoot();

        try
        {
            var referenceDirectory = Path.Combine(root, "references");
            Directory.CreateDirectory(referenceDirectory);
            WriteDictionary(referenceDirectory, "Skyrim_english_chinese.xml", """
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
                      <EDID>MS01</EDID>
                      <REC id="12" idMax="13">QUST:NNAM</REC>
                      <Source>Read Nepos&apos; Journal</Source>
                      <Dest>阅读尼普斯的日志</Dest>
                    </String>
                  </Content>
                </SSTXMLRessources>
                """);

            var inputFile = Path.Combine(root, "ussep.xml");
            File.WriteAllText(inputFile, """
                <?xml version="1.0" encoding="UTF-8" standalone="yes"?>
                <SSTXMLRessources>
                  <Params>
                    <Addon>unofficial skyrim special edition patch.esp</Addon>
                    <Source>english</Source>
                    <Dest>chinese</Dest>
                    <Version>2</Version>
                  </Params>
                  <Content>
                    <String List="0">
                      <EDID>MS01</EDID>
                      <REC id="12" idMax="13">QUST:NNAM</REC>
                      <Source>Read Nepos&apos; Journal</Source>
                      <Dest>Read Nepos&apos; Journal</Dest>
                    </String>
                  </Content>
                </SSTXMLRessources>
                """);

            var outputFile = Path.Combine(root, "translated.xml");
            var service = new DictionaryXmlTranslationService(new SilentLogger());

            var result = service.Translate(new DictionaryTranslateXmlOptions
            {
                InputFile = inputFile,
                OutputFile = outputFile,
                ReferenceDirectory = referenceDirectory
            });

            Assert.True(result.Success, result.Error);
            Assert.NotNull(result.Value);
            Assert.Equal(1, result.Value!.TranslatedEntries);
            Assert.Equal(0, result.Value.UnmatchedEntries);

            var output = XDocument.Load(outputFile);
            var translatedDest = output.Root!.Element("Content")!.Element("String")!.Element("Dest")!.Value;
            Assert.Equal("阅读尼普斯的日志", translatedDest);
        }
        finally
        {
            Cleanup(root);
        }
    }

    [Fact]
    public void Translate_DoesNotOverwriteExistingTranslationByDefault()
    {
        var root = CreateTempRoot();

        try
        {
            var referenceDirectory = Path.Combine(root, "references");
            Directory.CreateDirectory(referenceDirectory);
            WriteDictionary(referenceDirectory, "Skyrim_english_chinese.xml", """
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
                      <Dest>雪漫城</Dest>
                    </String>
                  </Content>
                </SSTXMLRessources>
                """);

            var outputFile = Path.Combine(root, "translated.xml");
            var service = new DictionaryXmlTranslationService(new SilentLogger());

            var result = service.Translate(new DictionaryTranslateXmlOptions
            {
                InputFile = inputFile,
                OutputFile = outputFile,
                ReferenceDirectory = referenceDirectory
            });

            Assert.True(result.Success, result.Error);
            Assert.NotNull(result.Value);
            Assert.Equal(0, result.Value!.TranslatedEntries);
            Assert.Equal(1, result.Value.SkippedExistingEntries);

            var output = XDocument.Load(outputFile);
            var dest = output.Root!.Element("Content")!.Element("String")!.Element("Dest")!.Value;
            Assert.Equal("雪漫城", dest);
        }
        finally
        {
            Cleanup(root);
        }
    }

    [Fact]
    public void Translate_SkipsAmbiguousSourceMatches()
    {
        var root = CreateTempRoot();

        try
        {
            var referenceDirectory = Path.Combine(root, "references");
            Directory.CreateDirectory(referenceDirectory);
            WriteDictionary(referenceDirectory, "Skyrim_english_chinese.xml", """
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
                      <EDID>ContainerOne</EDID>
                      <REC>CONT:FULL</REC>
                      <Source>Chest</Source>
                      <Dest>箱子</Dest>
                    </String>
                    <String List="0" sID="000002">
                      <EDID>ContainerTwo</EDID>
                      <REC>CONT:FULL</REC>
                      <Source>Chest</Source>
                      <Dest>宝箱</Dest>
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
                      <EDID>BrandNewChest</EDID>
                      <REC>CONT:FULL</REC>
                      <Source>Chest</Source>
                      <Dest>Chest</Dest>
                    </String>
                  </Content>
                </SSTXMLRessources>
                """);

            var outputFile = Path.Combine(root, "translated.xml");
            var service = new DictionaryXmlTranslationService(new SilentLogger());

            var result = service.Translate(new DictionaryTranslateXmlOptions
            {
                InputFile = inputFile,
                OutputFile = outputFile,
                ReferenceDirectory = referenceDirectory
            });

            Assert.True(result.Success, result.Error);
            Assert.NotNull(result.Value);
            Assert.Equal(0, result.Value!.TranslatedEntries);
            Assert.Equal(1, result.Value.AmbiguousEntries);
            Assert.Single(result.Value.AmbiguousSamples);

            var output = XDocument.Load(outputFile);
            var dest = output.Root!.Element("Content")!.Element("String")!.Element("Dest")!.Value;
            Assert.Equal("Chest", dest);
        }
        finally
        {
            Cleanup(root);
        }
    }

    private static string CreateTempRoot()
    {
        var root = Path.Combine(Path.GetTempPath(), "SpookysAutomod.DictionaryXmlTranslationTests", Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(root);
        return root;
    }

    private static void WriteDictionary(string directory, string fileName, string content)
    {
        File.WriteAllText(Path.Combine(directory, fileName), content);
    }

    private static void Cleanup(string root)
    {
        if (Directory.Exists(root))
            Directory.Delete(root, true);
    }
}
