# Local AI Agent Translation Plan

Execution plan for local AI agents translating Skyrim `SSTXMLRessources` exports with this toolkit.

## Role

Use this document when a local AI agent needs to take a translation XML file, run the toolkit end to end, and produce:

- a translated XML output
- a review report for unresolved items
- a stable working glossary for the current file or mod

This is an execution plan, not just a style guide. It defines the phases, inputs, outputs, and stop conditions a local agent should follow.

## Read This When

Read this file when you are:

- running a local AI agent against `_english_chinese.xml` exports
- translating new quest text, books, dialogue, or descriptions that are not fully covered by the shipped dictionary
- trying to keep multiple local agents aligned on one translation task
- building a repeatable offline or semi-automatic translation workflow

## Read This After

Read these first:

1. [../AGENTS.md](../AGENTS.md)
2. [esp-translation.md](esp-translation.md)
3. [human-name-translation.md](human-name-translation.md)
4. [../dictionaries/README.agent-format.md](../dictionaries/README.agent-format.md)
5. [knowledge_base/README.md](knowledge_base/README.md) when lore context matters
6. [local-ai-translation-prompts.md](local-ai-translation-prompts.md) when you want copy-paste prompt templates
7. [local-ai-translation-prompts-by-model.md](local-ai-translation-prompts-by-model.md) when you want Codex / Claude / Gemini-specific prompt variants

## Goal

The local agent should produce a translation result that is:

1. terminology-stable against vanilla Skyrim Chinese
2. conservative about proper nouns and placeholders
3. explicit about uncertainty
4. reviewable by a human without reverse-engineering what happened

## Inputs

Minimum required inputs:

- source XML file in `SSTXMLRessources` format
- toolkit root
- dictionary corpus under `dictionaries/` or `dictionaries/agent-readable`

Recommended inputs:

- `settings.json` with `aiTranslation` configured
- local knowledge base under `docs/knowledge_base/uesp/`
- a target output path
- a report path

## Outputs

Each run should aim to produce:

- translated XML
- JSON report for unresolved, low-confidence, or failed entries
- small glossary file or glossary section in the report

If the agent cannot safely finish, it must still produce:

- a partial translated XML
- a report that explains what remains

## Non-Negotiable Rules

1. Never translate `EditorID`, script names, property names, or internal identifiers as player-facing text.
2. Always preserve placeholders and markup exactly, including `&lt;Alias=...&gt;`, `&lt;Global=...&gt;`, `%s`, and line breaks.
3. Always run dictionary-backed translation before AI free translation.
4. Always use the local knowledge base when a proper noun, faction, place, or lore term is ambiguous.
5. Never silently overwrite existing human translations unless the operator explicitly requested it.
6. Never invent certainty. Low-confidence items must go to report output instead of being claimed complete.

## Execution Phases

### Phase 1: Validate Inputs

The agent should:

1. confirm the XML file exists
2. confirm the dictionary corpus exists
3. confirm whether `settings.json` exists
4. confirm whether AI fallback is available

Suggested commands:

```powershell
dotnet run --project src/SpookysAutomod.Cli -- dictionary lookup "RiftenRatway02" --json
```

If AI fallback is intended:

- verify `settings.json` or `--config`
- verify API key presence

### Phase 2: Dictionary-First Pass

Run the safe dictionary pass first:

```powershell
dotnet run --project src/SpookysAutomod.Cli -- dictionary translate-xml ".\SomeMod_english_chinese.xml" --output ".\SomeMod_english_chinese.translated.xml" --json
```

Purpose:

- lock known vanilla terms
- reduce the AI surface
- expose only genuinely new or ambiguous strings to the model

Stop and record:

- translated count
- unmatched count
- ambiguous count

### Phase 3: AI Fallback Pass

If unmatched content remains, run AI fallback:

```powershell
dotnet run --project src/SpookysAutomod.Cli -- dictionary translate-xml-ai ".\SomeMod_english_chinese.xml" --output ".\SomeMod_english_chinese.translated.xml" --report ".\SomeMod_english_chinese.report.json" --json
```

The agent should treat this as a controlled fallback, not a license to rewrite everything.

AI fallback should only handle:

- untranslated rows
- rows still equal to source text
- rows explicitly approved for overwrite

### Phase 4: Lore and Proper-Noun Review

For unresolved or low-confidence entries, the agent should inspect local lore before making a final choice.

Typical searches:

```powershell
rg -n "Redoran|Indoril|Telvanni|Companion|Watcher" docs/knowledge_base/uesp -m 20
dotnet run --project src/SpookysAutomod.Cli -- dictionary search --text "watcher" --scope english --group-by entry --limit 20 --json
```

Use this phase especially for:

- names of people
- factions
- provinces and settlements
- institutions and titles
- book or quest titles with lore references

### Phase 5: Glossary Consolidation

The agent should build a working glossary from repeated important terms.

Minimum glossary fields:

| English | Chinese | Source | Notes |
| --- | --- | --- | --- |
| Watcher | `<chosen-term>` | dictionary or AI + review | keep stable across the file |
| Jarl | 领主 | vanilla anchor | title word |
| Ratway | 鼠道 | vanilla anchor | place name |

This glossary can live:

- in the JSON report
- in a companion markdown note
- in the operator's review system

### Phase 6: Review Gate

Before claiming completion, the agent must check:

1. all placeholders remain intact
2. obvious proper nouns were not literally mistranslated
3. repeated terms stay stable
4. low-confidence items are reported, not hidden
5. remaining untranslated rows are counted explicitly

## Recommended Single-Agent Mode

Use this when the file is modest or the operator wants simplicity.

Flow:

1. validate inputs
2. run `translate-xml`
3. run `translate-xml-ai`
4. inspect low-confidence report entries
5. optionally rerun after prompt or glossary adjustment

Best for:

- one file
- under a few thousand rows
- limited need for parallel review

## Recommended Multi-Agent Mode

Use this when the file is large or terminology consistency matters across many records.

Suggested local roles:

1. inventory agent
   responsibility: run the dictionary pass, count unmatched and ambiguous entries, prepare the worklist
2. terminology agent
   responsibility: resolve repeated nouns, places, factions, titles, and known vanilla anchors
3. lore agent
   responsibility: query `docs/knowledge_base/uesp/` for unclear lore-heavy entries
4. prose agent
   responsibility: review long-form quest text and book text after terminology is locked
5. verifier agent
   responsibility: confirm placeholders, confidence thresholds, and unresolved-entry counts

Shared rule:

- only one agent should own the final glossary

## Prompting Contract for Local Agents

When a local agent is asked to translate entries, its instructions should emphasize:

1. preserve placeholders exactly
2. prefer shipped Chinese terminology
3. do not translate technical identifiers
4. report uncertainty numerically and textually
5. return structured output only

Good local system-prompt themes:

- terminology before style
- consistency before creativity
- report uncertainty instead of guessing

For reusable copy-paste prompt blocks, use [local-ai-translation-prompts.md](local-ai-translation-prompts.md).
For model-tuned variants, use [local-ai-translation-prompts-by-model.md](local-ai-translation-prompts-by-model.md).

## Failure Handling

If dictionary pass fails:

- stop and report path or XML issues

If AI pass fails:

- keep dictionary-pass output
- report the API/config failure
- do not pretend the file is fully translated

If low-confidence count is high:

- keep those items untranslated or report-only
- recommend prompt or glossary refinement before rerun

## Completion Contract

A local AI agent may only say the file is complete when:

1. the translated XML exists
2. unresolved counts are explicit
3. confidence-gated items were handled honestly
4. repeated key terms are stable
5. any remaining review items are listed

If not complete, the correct completion statement is:

- dictionary pass complete
- AI fallback complete
- review still needed on listed items

## Example Operator Runbook

### With Config File

1. copy [settings.example.json](/D:/SteamLibrary/steamapps/common/Skyrim%20Special%20Edition/Data/Skyrim-Automod-Toolkit/settings.example.json) to `settings.json`
2. edit the `aiTranslation` section
3. run:

```powershell
dotnet run --project src/SpookysAutomod.Cli -- dictionary translate-xml-ai "C:\Path\To\SomeMod_english_chinese.xml" --output "C:\Path\To\SomeMod_english_chinese.translated.xml" --report "C:\Path\To\SomeMod_english_chinese.report.json" --json
```

### With Explicit Override

```powershell
dotnet run --project src/SpookysAutomod.Cli -- dictionary translate-xml-ai "C:\Path\To\SomeMod_english_chinese.xml" --config ".\settings.json" --model "gpt-4.1-mini" --min-confidence 0.8 --json
```

## Summary

The recommended local-agent translation strategy is:

1. dictionary first
2. AI only for the remainder
3. lore review for proper nouns and ambiguous terms
4. glossary consolidation
5. confidence-gated reporting

That keeps local agents fast enough to be useful while still staying grounded in Skyrim's existing Chinese terminology.
