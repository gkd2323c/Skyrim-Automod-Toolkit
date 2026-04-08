# Knowledge Base Guide

Agent guide for the local research corpus stored under `docs/knowledge_base/`.

## Role

Use this guide when an AI agent needs Elder Scrolls lore, canon context, naming background, or in-game book references without leaving the repository.

The current corpus is a UESP-derived Markdown mirror stored in `docs/knowledge_base/uesp/`.

## Read This When

Read this file when you are:

- researching places, factions, deities, books, characters, or historical events
- translating ESP text that needs lore context in addition to dictionary terminology
- checking whether a custom quest, item, or book name fits established Elder Scrolls canon
- trying to understand what a proper noun refers to before choosing Chinese wording

## Read This After

Read these first:

1. [../../README.md](../../README.md)
2. [../../AGENTS.md](../../AGENTS.md)
3. [../README.md](../README.md)
4. [../../dictionaries/README.agent-format.md](../../dictionaries/README.agent-format.md) when Chinese terminology matters
5. [../esp-translation.md](../esp-translation.md) when you are localizing plugin text

## What the Corpus Looks Like

The local UESP mirror is a large Markdown corpus with thousands of pages. In practice, an agent should expect:

- one page per concept, book, place, NPC, faction, or game-specific article
- filename patterns such as `Lore_...`, `Skyrim_...`, `Oblivion_...`, and other title-derived page names
- URL-encoded characters such as `%27` in filenames
- disambiguation suffixes such as `(city)` in some page names
- local cross-links between Markdown pages
- a metadata table near the top of many pages with fields such as `Writer`, `Seen In`, `Up`, `Prev`, and `Next`

This means the corpus behaves like a local wiki mirror, not like a flat dump of unrelated text files.

## Best Uses

Use the knowledge base for:

- lore research and canon background
- tracing relationships between people, factions, and places
- understanding the tone and context of books, notes, and historical references
- checking whether a custom noun sounds lore-consistent
- gathering surrounding context before translating book text or quest text

Do not use the knowledge base as the sole authority for:

- actual plugin state, which still comes from `esp info`, `esp list-records`, and `esp view-record`
- Chinese localization choices, which should still be validated with `dictionary lookup` and `dictionary search`
- write-back confirmation, which must come from a supported toolkit workflow rather than from narrative research

## Non-Negotiable Rules

1. Prefer the local knowledge base before browsing the web when the repository already contains the needed lore context.
2. Start with `rg --files` or `rg -n` to narrow candidates; do not open large batches of pages blindly.
3. Prefer local `.md` links over external `https://en.uesp.net/wiki/...` links when a local page exists.
4. Treat page metadata as provenance and navigation help, not as proof of plugin behavior.
5. Use `dictionary lookup` or `dictionary search` before finalizing Chinese terms, even if the lore page makes the English meaning obvious.
6. Cite the exact local file paths you used when you summarize lore evidence for a user or another agent.
7. If variant pages or duplicate-looking pages disagree, say so explicitly instead of forcing a false certainty.
8. On Windows, prefer `Get-Content -LiteralPath` when opening filenames that contain `%27`, commas, or parentheses.

## Search Workflow

### 1. Start from the User Request or the Plugin Record

First identify the concrete noun or text you are researching:

- a place name from `FULL`
- a faction or deity in a quest description
- a person mentioned in a book
- a cultural term that the dictionary alone does not explain

If the question comes from a plugin, inspect the record first with `esp view-record` so you know the exact text and record type before you research lore.

### 2. Search Filenames First

Use filename search when the target is probably a page title.

```bash
rg --files docs/knowledge_base/uesp | rg "Riften|Ratway"
rg --files docs/knowledge_base/uesp | rg "Redoran|Indoril"
rg --files docs/knowledge_base/uesp | rg "Barenziah|Wolf_Queen"
```

This is usually the fastest way to find:

- a named place
- a known book title
- a faction
- a person with a distinctive name

### 3. Search Page Contents When the Title Is Unclear

Use content search when the target might appear inside many pages.

```bash
rg -n "House Redoran|Redoran" docs/knowledge_base/uesp -m 20
rg -n "Sotha Sil" docs/knowledge_base/uesp -m 20
rg -n "Ratway|Riften" docs/knowledge_base/uesp -m 20
```

This is useful for:

- organizations mentioned in books
- events with multiple eyewitness sources
- background terms that are not obvious page titles

### 4. Open the Best Candidate Carefully

On this repository's Windows setup, prefer `-LiteralPath`:

```powershell
Get-Content -LiteralPath ".\\docs\\knowledge_base\\uesp\\Lore_House_Redoran.md" -TotalCount 120
Get-Content -LiteralPath ".\\docs\\knowledge_base\\uesp\\Lore_2920,_Sun%27s_Dawn_(v2).md" -TotalCount 80
```

When you open a page, check:

- the page title
- the top metadata table
- whether the page is a series volume, a general overview, or a game-specific variant
- whether the local links point to better nearby context

### 5. Follow Local Links for Context

Many pages include local navigation hints:

- `Up` points to the parent series or parent concept
- `Prev` and `Next` help with multi-volume books
- inline local links often point to the relevant place, faction, or person pages

Prefer following those local Markdown targets before leaving the repository.

### 6. Synthesize, Then Validate Terminology

After you understand the lore context:

1. summarize the relevant facts in your own words
2. validate important English terms with `dictionary lookup` or `dictionary search`
3. choose Chinese wording that is both lore-appropriate and terminologically consistent

## Use with Dictionary Queries

The two resources answer different questions:

- the dictionary answers "How is this game term localized in Chinese?"
- the knowledge base answers "What is this thing, and what surrounding lore matters?"

For translation or naming work, use them together:

1. inspect the plugin text with `esp view-record`
2. query `dictionary lookup` or `dictionary search`
3. search the UESP knowledge base for lore context
4. keep a glossary note for repeated terms
5. draft the final Chinese wording

Example pattern:

```bash
dotnet run --project src/SpookysAutomod.Cli -- dictionary search --text "Redoran" --scope english --group-by record --limit 10 --json
rg -n "House Redoran|Redoran" docs/knowledge_base/uesp -m 20
```

## Handling Ambiguity and Duplicate Pages

The local mirror may contain:

- page variants for different games such as `Lore_...` and `Skyrim_...`
- volume pages and series pages
- disambiguated titles such as `(city)`
- duplicate-looking filenames that differ by punctuation or encoding

When that happens:

1. prefer the page that best matches the user's game or the plugin's context
2. use the top metadata table and nearby links to confirm what the page represents
3. compare at least two nearby pages if the first result looks ambiguous
4. report uncertainty when the corpus does not clearly collapse to one answer

## Output Contract for Agents

When reporting results based on this corpus:

- distinguish direct page evidence from your own inference
- mention whether the source was a general lore page, a game-specific page, or an in-game book page
- cite the exact local Markdown files you used
- keep dictionary-backed translation choices separate from lore summaries

## Summary

The practical workflow is:

- inspect the mod record first if the question comes from a plugin
- search `docs/knowledge_base/uesp/` with `rg`
- open the smallest useful set of local pages
- follow `Up`, `Prev`, `Next`, and local links for context
- validate Chinese terms with the dictionary before final wording

That keeps agents grounded in local canon material without drifting away from the game's shipped terminology.
