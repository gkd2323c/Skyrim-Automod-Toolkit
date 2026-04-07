# Agent-Readable Dictionary Export

These XML files are optimized for game tooling, not for agent retrieval. The toolkit now supports both direct querying and export:

- `dictionary lookup` for exact EDID lookup
- `dictionary search` for fuzzy bilingual search
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
