# Agent-Readable Dictionary Export

These XML files are optimized for game tooling, not for agent retrieval. The toolkit now supports both direct querying and export:

- `dictionary lookup` for exact EDID lookup
- `dictionary search` for fuzzy bilingual search
- `dictionary translate-xml` for filling `Dest` values in exported `SSTXMLRessources` files by reusing the shipped corpus
- `dictionary translate-xml-ai` for dictionary-first translation plus OpenAI fallback on genuinely new content
- `dictionary export-agent` for smaller JSONL shards plus EDID-grouped documents that are easier for AI agents to read, search, and cite

If `dictionaries/agent-readable` exists, `dictionary lookup` and `dictionary search` will prefer that exported JSONL corpus automatically. The source XML files remain the fallback when no export is available.

## Why This Format Helps Agents

- `entries/` keeps one translation per JSON object for exact string lookup.
- `records/` groups all translations for the same `EDID` into one document so an agent can understand a record in one read.
- `manifest.json` gives counts, relative output file paths, and record-type distribution before an agent opens large shards.
- Each JSON object includes `agentText`, a flattened natural-language block that works well for retrieval and embeddings.

## Commands

Direct lookup:

```powershell
dotnet run --project src/SpookysAutomod.Cli -- dictionary lookup "RiftenRatway02" --addon Skyrim --json
```

Lookup against a previous export:

```powershell
dotnet run --project src/SpookysAutomod.Cli -- dictionary lookup "RiftenRatway02" --input ./dictionaries/agent-readable --addon Skyrim --json
```

Fuzzy search:

```powershell
dotnet run --project src/SpookysAutomod.Cli -- dictionary search --text "鼠道" --scope chinese --group-by record --limit 5 --json
```

Translate an exported XML file:

```powershell
dotnet run --project src/SpookysAutomod.Cli -- dictionary translate-xml "./unofficial skyrim special edition patch_english_chinese.xml" --output "./unofficial skyrim special edition patch_english_chinese.translated.xml" --json
```

Translate with AI fallback for new content:

```powershell
dotnet run --project src/SpookysAutomod.Cli -- dictionary translate-xml-ai "./unofficial skyrim special edition patch_english_chinese.xml" --output "./unofficial skyrim special edition patch_english_chinese.translated.xml" --report "./unofficial skyrim special edition patch_english_chinese.report.json" --json
```

Use a config file:

- Copy [settings.example.json](/D:/SteamLibrary/steamapps/common/Skyrim%20Special%20Edition/Data/Skyrim-Automod-Toolkit/settings.example.json) to `settings.json`
- Edit `aiTranslation.endpoint`, `aiTranslation.apiKey`, `aiTranslation.model`, `aiTranslation.systemPrompt`, and any thresholds you want
- Run `dictionary translate-xml-ai` without repeating those flags each time
- Use `--config path\\to\\settings.json` if you want to point at a different file
- Set `aiTranslation.cacheFile` or pass `--cache-file` if you want reruns to reuse completed AI batches instead of starting over

Export:

Run from the repository root:

```powershell
dotnet run --project src/SpookysAutomod.Cli -- dictionary export-agent --input ./dictionaries --output ./dictionaries/agent-readable --shard-size 5000 --json
```

## Output Layout

```text
dictionaries/agent-readable/
|- manifest.json
|- entries/
|  |- Skyrim.entries.part-0001.jsonl
|  |- Skyrim.entries.part-0002.jsonl
|  \- ...
\- records/
   |- Skyrim.records.part-0001.jsonl
   |- Dawnguard.records.part-0001.jsonl
   \- ...
```

## Entry Document Shape

```json
{
  "addon": "Skyrim",
  "sourceLanguage": "english",
  "targetLanguage": "chinese",
  "sourceFile": "Skyrim_english_chinese.xml",
  "sid": "000001",
  "edid": "RiftenRatway02",
  "record": "CELL:FULL",
  "recordType": "CELL",
  "field": "FULL",
  "english": "The Ratway Vaults",
  "chinese": "鼠道地下室",
  "englishNormalized": "the ratway vaults",
  "chineseNormalized": "鼠道地下室",
  "agentText": "Addon: Skyrim\nEDID: RiftenRatway02\nRecord: CELL:FULL\nSID: 000001\nEnglish: The Ratway Vaults\nChinese: 鼠道地下室"
}
```

## Record Document Shape

```json
{
  "addon": "Skyrim",
  "edid": "RiftenRatway02",
  "recordKey": "Skyrim:RiftenRatway02",
  "translations": [
    {
      "sid": "000001",
      "record": "CELL:FULL",
      "english": "The Ratway Vaults",
      "chinese": "鼠道地下室"
    }
  ],
  "agentText": "Addon: Skyrim\nEDID: RiftenRatway02\nTranslations:\n- CELL:FULL | EN: The Ratway Vaults | ZH: 鼠道地下室 | SID: 000001"
}
```

## Agent Usage Guidance

- Open `manifest.json` first to see which addon and shard you need.
- Prefer `records/` when you know an `EDID` and want all labels for the same record.
- Prefer `entries/` when you are matching a specific source string or scanning raw translation rows.
- Use `englishNormalized` and `chineseNormalized` for case-insensitive or whitespace-tolerant matching.
- `dictionary translate-xml` only fills rows whose `Dest` is empty or still equals `Source` unless you pass `--overwrite-existing`.
- XML translation prefers exact `EDID + REC(+id)` matches, then safe exact source-text matches.
- Ambiguous matches are skipped instead of guessed so existing manual review stays trustworthy.
- `dictionary translate-xml-ai` runs the same safe dictionary pass first, then only sends the remaining rows to OpenAI.
- AI fallback requires `OPENAI_API_KEY` or `--api-key`; use `--min-confidence` to keep uncertain output out of the XML and inside the JSON report instead.
- For `translate-xml-ai`, value precedence is: command-line flags -> `settings.json` `aiTranslation` section -> environment variables -> built-in defaults.
- AI cache entries are written incrementally as successful batches complete, so an interrupted run can resume without retranslating already completed entries.
- Before AI calls are made, identical untranslated rows with the same `REC + Source` are deduplicated. The model translates one canonical copy, and the result is applied back to every duplicate occurrence.
