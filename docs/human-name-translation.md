# Skyrim Human Name Translation Guide

Practical guide for translating human and humanoid proper names in Skyrim mods while staying aligned with the shipped Chinese localization.

## Role

Use this guide when an AI agent or human translator needs to translate:

- NPC names
- historical figures
- family names
- titles attached to names
- sobriquets and epithets
- book authors
- named quest characters

This guide is specifically for **person names and name-like character labels**. For broader item, place, faction, and lore term work, continue using [esp-translation.md](esp-translation.md).

## Read This When

Read this file when you are:

- translating a mod with many new named characters
- unsure whether to transliterate or translate a name
- trying to match the style of Skyrim's official Chinese names
- standardizing a glossary across multiple NPCs, books, and quests

## Read This After

Read these first:

1. [../AGENTS.md](../AGENTS.md)
2. [esp-translation.md](esp-translation.md)
3. [../dictionaries/README.agent-format.md](../dictionaries/README.agent-format.md)
4. [knowledge_base/README.md](knowledge_base/README.md) when the name is lore-heavy or historical

## Core Principle

Treat names as part of the game's worldbuilding, not as isolated strings.

Your first goal is not inventiveness. It is:

1. consistency with the shipped game
2. recognizability for players
3. stability across mods, patches, books, subtitles, and guides

If the base game already established the pattern, follow it.

## Base-Game Anchors

Use the shipped dictionary as your default authority for style and phonetic shape.

Concrete examples already present in the local corpus:

- `Karliah` -> `卡莱亚`
- `Enthir` -> `恩希尔`
- `Calcelmo` -> `卡塞莫`
- `Meridia` -> `美瑞蒂亚`
- `Mercer Frey` -> `墨瑟·弗雷`

These examples show the project's default style:

- stable transliteration over reinvention
- readable modern Chinese characters over obscure phonetic perfection
- selective use of the middle dot for multi-part personal names
- title words translated separately from the personal name

## Name Classification

Before translating, classify the string.

### 1. Personal Name

Examples:

- `Karliah`
- `Enthir`
- `Calcelmo`

Default handling:

- transliterate
- search the dictionary first
- do not force literal meaning unless the source is clearly not a personal name

### 2. Personal Name with Family Name

Examples:

- `Mercer Frey`
- `Maven Black-Briar`

Default handling:

- preserve the given-name + surname structure
- use the middle dot when the base game does
- treat the surname conservatively unless an established translation already exists

### 3. Personal Name with Title

Examples:

- `Vigilant Tyranus`
- `Jarl Balgruuf`
- `Captain Aldis`

Default handling:

- translate the title
- translate or transliterate the name independently

Examples of the pattern:

- `Vigilant Tyranus` -> `警戒者提拉努斯`
- `Jarl Balgruuf` -> `领主巴尔古夫`

### 4. Epithet or Sobriquet

Examples:

- `Umaril the Unfeathered`
- `the Foolkiller`
- `the Wolf Queen`

Default handling:

- translate the epithet for meaning
- keep the personal name stable

Pattern:

- `Umaril the Unfeathered` -> `无羽者乌玛瑞尔`

### 5. Pure Role Label Disguised as a Name

Examples:

- unnamed guards
- generic priests
- generic nobles

Default handling:

- do not transliterate if the source is not actually a unique personal name
- translate it as a role label

## Transliteration Rules

### Rule 1: Follow the Shipped Chinese Sound Shape

Do not transliterate as if you are making a linguistics paper.

Prefer forms that feel like existing Skyrim Chinese names:

- short to medium length
- easy to read aloud
- avoid rare or archaic characters

Good target qualities:

- `卡莱亚`
- `恩希尔`
- `卡塞莫`

Avoid:

- over-precise sound mapping
- unusual characters chosen only for pronunciation
- inconsistent vowel rendering between similar names

### Rule 2: Similar Sources Should Produce Similar Chinese Shapes

If two names obviously belong to the same language family or naming culture, keep the transliteration strategy parallel.

Examples:

- if one Nordic-style name is rendered blunt and heavy, do not render the next one in an ornate, Latinate way
- if one Dunmer-style name uses a given-name shape already seen in game, stay close to that shape

### Rule 3: Favor Player Memory Over Phonetic Purism

The best translation is the one a player can:

- recognize on second encounter
- connect across documents
- type into a note or search box

If a perfect phonetic spelling harms readability, choose readability.

### Rule 4: Reuse Existing Syllable Patterns

When inventing a new transliteration, bias toward syllable patterns already common in the base game.

Examples from shipped names:

- `卡-`
- `恩-`
- `-尔`
- `-莫`
- `-亚`

This does not mean copy the same endings blindly. It means the name should feel like it belongs in the same Chinese localization universe.

## When to Translate Meaning Instead of Sound

Translate meaning when the string is primarily functioning as:

- a title
- a rank
- a descriptive epithet
- a legendary byname
- a role within an order

Examples:

- `Listener` -> `聆听者`
- `Harbinger` -> `先驱`
- `the Unfeathered` -> `无羽者`
- `the Wolf Queen` -> `狼后`

Do **not** over-translate true personal names just because the source word has a dictionary meaning.

## Titles and Name Order

Use the game's established Chinese order.

### Translate the Title, Preserve the Name

Examples:

- `Vigilant Tyranus` -> `警戒者提拉努斯`
- `Jarl Balgruuf` -> `领主巴尔古夫`
- `Arch-Mage Savos Aren` -> `首席法师萨沃斯·阿兰`

### Keep One Pattern Per Project

Do not alternate between:

- `提拉努斯警戒者`
- `警戒者提拉努斯`

unless the base game itself makes that distinction for a specific grammatical reason.

## Family Names and Compound Surnames

Handle surnames conservatively.

### If the Base Game Already Fixed It, Reuse It

Never replace a known vanilla surname with your own version.

### If the Surname Is Clearly a Literal Compound

Only translate it when there is strong evidence the Chinese community already treats it as a meaning-bearing surname.

Otherwise:

- transliterate or partially preserve the established form
- do not force a clever literal surname

### If You Are Unsure

Prefer stability over flair.

## Historical Figures and Lore Characters

Be even more conservative for:

- saints
- kings
- famous mages
- book authors
- major faction founders
- gods and princes

These names tend to recur across:

- books
- quests
- loading screens
- dialogue
- external guides

For these, always:

1. search the dictionary
2. search the local knowledge base
3. only invent if no existing form appears

## Recommended Workflow

### 1. Search the Exact Name in the Dictionary

```bash
dotnet run --project src/SpookysAutomod.Cli -- dictionary search --text "Karliah" --scope english --group-by entry --limit 10 --json
dotnet run --project src/SpookysAutomod.Cli -- dictionary search --text "Enthir" --scope english --group-by entry --limit 10 --json
dotnet run --project src/SpookysAutomod.Cli -- dictionary search --text "Calcelmo" --scope english --group-by entry --limit 10 --json
```

Use this first for any name that might already exist in vanilla Skyrim or its shipped add-ons.

### 2. Search the Title Separately

If the string contains both a title and a name, split them.

```bash
dotnet run --project src/SpookysAutomod.Cli -- dictionary search --text "Vigilant" --scope english --group-by entry --limit 20 --json
dotnet run --project src/SpookysAutomod.Cli -- dictionary search --text "Tyranus" --scope english --group-by entry --limit 20 --json
```

This keeps you from accidentally transliterating a title or over-translating a personal name.

### 3. Check Related In-Game Characters

If the name is new but belongs to a known culture:

- search nearby vanilla names from that culture
- compare syllable shape and Chinese rhythm

The goal is not exact linguistic reconstruction. The goal is style fit.

### 4. Use the Knowledge Base for Lore-History Names

When the person is a historical or mythic figure:

```bash
rg -n "Umaril|Pelinal|Reman|Auri-El" docs/knowledge_base/uesp -m 20
```

Do this before finalizing the Chinese wording.

### 5. Record the Decision in a Glossary

Keep a project-local glossary with:

| English | Chinese | Type | Basis | Notes |
| --- | --- | --- | --- | --- |
| Karliah | 卡莱亚 | personal name | shipped dictionary | vanilla anchor |
| Enthir | 恩希尔 | personal name | shipped dictionary | vanilla anchor |
| Calcelmo | 卡塞莫 | personal name | shipped dictionary | vanilla anchor |
| Meridia | 美瑞蒂亚 | divine name | shipped dictionary | use unchanged |
| Vigilant | 警戒者 | title | shipped dictionary pattern | title only |

## Human Name Style Rules by Function

### Ordinary Named NPCs

- default to transliteration
- keep them short and readable
- do not literary-ize them

### Nobles, Court Figures, and Mages

- transliterate the personal name
- translate the rank
- preserve formality

### Bandits, Mercenaries, and Rough Types

- still transliterate the actual name
- only translate the nickname if it is clearly functioning as a nickname

### Book Authors

- preserve the same Chinese form every time
- if the book uses `by <name>`, do not create a second translation for the same author elsewhere

## Do Not Do These

1. Do not translate a personal name just because the source word has a surface meaning.
2. Do not invent a new Chinese form when the base game already has one.
3. Do not use rare characters only to chase pronunciation.
4. Do not vary one name across files unless the source truly varies.
5. Do not translate titles and surnames inconsistently across the same mod.
6. Do not replace a stable official divine or prince name with a community variant.

## Quality Checks Before Finalizing

Before you lock a person-name translation, confirm:

1. Did I search the exact string in the dictionary?
2. If there is a title, did I split title and name?
3. Does the result look like existing Skyrim Chinese naming?
4. Would a player recognize the same person if they appeared in dialogue, a quest log, and a book?
5. Have I recorded the final form in the glossary?

## Summary

If you only remember one rule, remember this:

- personal names should usually **sound like Skyrim Chinese already sounds**
- titles and epithets should usually **mean what the player needs them to mean**
- official base-game translations beat clever new inventions

When unsure, search first and invent last.
