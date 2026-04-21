# ESP Translation Workflow

Dictionary-backed workflow for AI agents translating user-visible text in Skyrim plugins while keeping terminology consistent with the game's existing Chinese vocabulary.

## Role

Use this guide when an AI agent needs to translate names, descriptions, book text, quest labels, or other visible strings in an `.esp` or `.esl` file without drifting away from established vanilla terminology.

## Read This When

Read this file when you are:

- translating an existing plugin into Chinese
- localizing new records you are creating with the toolkit
- trying to keep names, places, factions, and gameplay terms aligned with the shipped dictionary corpus
- unsure whether to use `dictionary lookup` or `dictionary search`

## Read This After

Read these first:

1. [../AGENTS.md](../AGENTS.md)
2. [esp.md](esp.md)
3. [../dictionaries/README.agent-format.md](../dictionaries/README.agent-format.md)
4. [human-name-translation.md](human-name-translation.md) when the task is mostly about NPC, author, or historical figure names
5. [knowledge_base/README.md](knowledge_base/README.md) when the text depends on lore or canon context
6. [llm-guide.md](llm-guide.md) when the translation task becomes multi-step

## What Counts as Translation Work

This workflow is for user-visible text such as:

- record display names
- perk and quest descriptions
- book titles and book bodies
- location names
- faction names
- NPC names

For detailed person-name guidance, including titles, surnames, epithets, and base-game naming anchors, use [human-name-translation.md](human-name-translation.md).

This workflow is not for:

- `EditorID`
- `FormKey` or `FormID`
- script names
- Papyrus property names
- internal keywords unless the user explicitly wants internal identifiers renamed

## Non-Negotiable Rules

1. Always inspect the record before translating it.
2. Always query the dictionary before finalizing important terms such as place names, factions, creatures, schools of magic, perk concepts, and item classes.
3. Prefer the exported `dictionaries/agent-readable` corpus when it exists. The query commands already do this by default.
4. When a term is lore-heavy or ambiguous, search the local UESP knowledge base before choosing final wording.
5. Keep a working glossary for the current plugin so the same English term maps to the same Chinese term unless there is clear in-game evidence for a context-specific exception.
6. Never translate `EditorID`, script names, or other technical identifiers as if they were player-facing strings.
7. Do not claim the plugin has been fully translated unless the translated text has actually been written back through a supported path.

## Current Capability Boundary

The toolkit is already strong at:

- inventorying records in a plugin
- inspecting record properties as JSON
- creating new records with translated `--name`, `--description`, or `--text`
- creating override patches as a safe starting point for existing-mod work
- querying the bilingual dictionary corpus to keep terminology aligned with vanilla Skyrim

The toolkit does not yet provide a generic command to rewrite arbitrary text fields on arbitrary existing records. For existing plugins, the agent can reliably do terminology planning, auditing, and override staging today. If the target record type still lacks a safe write-back path, say so clearly and hand off instead of pretending the translation is complete.

## Recommended Workflow

### 1. Inventory the Plugin

Start by finding the records most likely to contain player-visible text.

```bash
dotnet run --project src/SpookysAutomod.Cli -- esp info "MyMod.esp" --json
dotnet run --project src/SpookysAutomod.Cli -- esp list-records "MyMod.esp" --type book --limit 200 --json
dotnet run --project src/SpookysAutomod.Cli -- esp list-records "MyMod.esp" --type quest --limit 200 --json
dotnet run --project src/SpookysAutomod.Cli -- esp list-records "MyMod.esp" --type location --limit 200 --json
```

Use `esp list-records` to narrow the translation surface before you inspect individual records in detail.

### 2. Inspect Each Candidate Record

Inspect the record in structured JSON before translating anything.

```bash
dotnet run --project src/SpookysAutomod.Cli -- esp view-record "MyMod.esp" --editor-id "MyMod_AncientVault" --type location --json
dotnet run --project src/SpookysAutomod.Cli -- esp view-record "MyMod.esp" --editor-id "MyMod_LoreBook01" --type book --include-raw --json
```

Look for:

- the player-facing source text
- nearby context such as record type, parent objects, and gameplay purpose
- proper nouns that may already exist in vanilla Skyrim terminology
- whether the string is a short UI label, a functional description, or long-form prose

### 3. Resolve Terminology with the Dictionary

Use dictionary queries as evidence, not as decoration. The goal is to anchor the translation in existing in-game terms whenever possible.

#### Pattern A: Exact Vanilla Anchor by EDID

If the mod references or imitates a known vanilla concept, start with exact lookup.

```bash
dotnet run --project src/SpookysAutomod.Cli -- dictionary lookup "RiftenRatway02" --addon Skyrim --record-type CELL --field FULL --json
```

Use this when:

- the mod reuses a vanilla place, faction, spell idea, or item name
- the record name obviously mirrors an existing vanilla object
- you already know the relevant vanilla `EDID`

#### Pattern B: English Phrase Search

If you do not know the `EDID`, search by the visible English phrase or its head noun.

```bash
dotnet run --project src/SpookysAutomod.Cli -- dictionary search --text "vault" --scope english --group-by record --limit 10 --json
dotnet run --project src/SpookysAutomod.Cli -- dictionary search --text "battle mage" --scope english --group-by entry --limit 20 --json
```

Use `--group-by record` when you want full per-record context. Use `--group-by entry` when you want to scan many raw bilingual pairs quickly.

#### Pattern C: Narrow by Record Type and Field

When a broad term returns too many results, narrow it to the kind of label you are translating.

```bash
dotnet run --project src/SpookysAutomod.Cli -- dictionary search --text "guardian" --scope english --record-type NPC_ --field FULL --group-by entry --limit 20 --json
dotnet run --project src/SpookysAutomod.Cli -- dictionary search --text "power attack" --scope english --record-type PERK --field DESC --group-by entry --limit 20 --json
```

Useful field filters:

- `FULL` for names and titles
- `DESC` for descriptions

#### Pattern D: Reverse-Check the Chinese Candidate

Once you have a likely translation, reverse-search the Chinese term to see how consistently it is already used.

```bash
dotnet run --project src/SpookysAutomod.Cli -- dictionary search --text "<chosen-Chinese-term>" --scope chinese --group-by entry --limit 10 --json
```

Use this to catch:

- inconsistent synonyms
- over-literal translations that do not match the shipped localization
- cases where your proposed Chinese phrase already has a stronger vanilla equivalent

### 4. Add Lore Context from the Local Knowledge Base

Use the local UESP mirror when the dictionary gives you a term but not enough context to choose the best Chinese phrasing.

Typical cases:

- book titles or book bodies that mention historical figures or factions
- terms with multiple plausible Chinese phrasings
- names that sound generic in English but are specific in Elder Scrolls lore
- references to institutions, houses, cults, provinces, or series titles

Start narrow:

```bash
rg --files docs/knowledge_base/uesp | rg "Redoran|Indoril|Vivec"
rg -n "House Redoran|Indoril|Vivec" docs/knowledge_base/uesp -m 20
```

Then open the best candidate pages and use their local `Up`, `Prev`, `Next`, and inline links to gather only the context you need. The knowledge base helps you understand what the term means and how it relates to nearby lore. The dictionary still decides whether your final Chinese wording matches the game's established localization.

### 5. Build a Plugin-Local Glossary

Keep a small working glossary while translating. A simple table is enough:

| English | Chosen Chinese | Evidence | Notes |
| --- | --- | --- | --- |
| Ratway | `<chosen-Chinese-term>` | `dictionary lookup RiftenRatway02` | Use the vanilla Chinese district name consistently |
| Vault | `<chosen-Chinese-term>` | `CELL:FULL` hits in Skyrim | Prefer the established noun over ad hoc dungeon wording |

This matters most for:

- repeated place names
- faction and organization names
- combat and perk vocabulary
- item classes and equipment slots
- lore-specific nouns that recur in books and quest text

## Choosing the Right Translation Style

### Short Names

For names in `FULL`-style fields:

- prefer concise vanilla-style phrasing
- prioritize established proper nouns over literal invention
- keep repeated nouns stable across related records

Examples:

- location names
- quest names
- faction names
- item names

### Functional Descriptions

For descriptions in `DESC`-style fields:

- prioritize gameplay clarity first
- match the style of vanilla perk and spell descriptions
- query comparable vanilla descriptions before deciding on phrasing

### Long-Form Prose

For books and narrative text:

- still query the dictionary for proper nouns, creatures, places, and institutions
- preserve tone after terminology is locked
- do not let prose creativity override established canon terms

## Safe Application Patterns

### Best-Supported Path: Translate While Creating New Records

If you are creating records with the toolkit, provide the final translated text at creation time.

```bash
dotnet run --project src/SpookysAutomod.Cli -- esp add-book "MyMod.esp" "MyMod_LoreBook01" --name "<final-Chinese-title>" --text "<final-translated-book-text>" --json
dotnet run --project src/SpookysAutomod.Cli -- esp add-perk "MyMod.esp" "MyMod_BattleMage" --name "<final-Chinese-name>" --description "<final-Chinese-description>" --effect spell-power --bonus 20 --json
```

### Existing Plugins: Inspect, Stage, Then Be Honest

For an existing plugin:

1. inspect the source record with `esp view-record`
2. resolve terminology with `dictionary lookup` and `dictionary search`
3. create an override patch if you need a safe translation target
4. only report completion if you also have a supported write-back path for the relevant text field

Example staging command:

```bash
dotnet run --project src/SpookysAutomod.Cli -- esp create-override "SourceMod.esp" -o "SourceMod_ChinesePatch.esp" --editor-id "SourceMod_AncientVault" --type location --json
```

If the record type still needs a generic text mutation tool, report the result as:

- terminology researched
- glossary established
- translation draft prepared
- write-back pending

That is a successful handoff. Pretending the binary text was changed when it was not is not.

## Flexible Query Strategy Cheat Sheet

Use this order by default:

1. `dictionary lookup` when you know the vanilla `EDID`
2. `dictionary search --scope english` when you only know the English phrase
3. search `docs/knowledge_base/uesp/` when the term is lore-heavy, book-related, or context-sensitive
4. `dictionary search --record-type ... --field ...` when a term is too broad
5. `dictionary search --scope chinese` to validate your chosen Chinese candidate
6. inspect grouped record results when one line is not enough to disambiguate the term

## Completion Checklist

Before you say the translation is done, confirm:

1. every player-facing string was identified from record inspection rather than guessed from `EditorID`
2. important nouns were checked against the dictionary
3. lore-heavy or ambiguous terms were checked against the local UESP knowledge base when needed
4. repeated terms were added to a plugin-local glossary
5. the final wording matches the text type: name, description, or prose
6. the translated text was actually written back through a supported workflow, or clearly marked as pending

## Summary

The practical idea is simple:

- use `esp` commands to discover and inspect what needs translation
- use `dictionary lookup` and `dictionary search` as evidence for terminology
- use the local UESP knowledge base when lore context affects the wording
- keep a glossary while translating
- only claim completion when the translated text has truly been applied

That combination keeps AI agents both consistent and honest.
