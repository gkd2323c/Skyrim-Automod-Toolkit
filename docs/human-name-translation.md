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

## Race-by-Race Name Style

Use race or culture as a style control, not as a rigid phonetic formula.

The point is not to reconstruct fictional linguistics perfectly. The point is to make a new name feel like it belongs beside shipped names of the same group.

### Nords

Typical feel:

- hard, short, weighty
- strong consonant clusters in English
- blunt and martial in Chinese rhythm

Chinese rendering goals:

- prefer firm, clean syllables
- avoid over-ornate characters
- let the name feel sturdy rather than elegant

Good style shape:

- `乌弗瑞克`
- `巴尔古夫`
- `布林乔夫`

Do:

- keep the rhythm compact
- allow a slightly rough or heavy sound
- favor readability over exact sound preservation

Do not:

- make Nordic names sound courtly or delicate
- over-Latinize them
- add unnecessary extra syllables

Common pattern:

- given names are usually enough
- titles often carry much of the social meaning

Base-game examples:

- `Ulfric Stormcloak` -> `乌弗瑞克·风暴斗篷`
- `Balgruuf the Greater` -> `“伟岸者”巴尔古夫`
- `Brynjolf` -> `布林乔夫`

### Imperials

Typical feel:

- orderly
- formal
- more Latin or Cyrodilic in structure
- smoother than Nordic names

Chinese rendering goals:

- favor balanced, proper-sounding transliterations
- preserve the sense of administration, nobility, or institutional status

Good style shape:

- `提拉努斯`
- `墨瑟·弗雷`

Do:

- keep multi-part names neat
- use the middle dot when appropriate for full formal names
- translate rank words clearly

Do not:

- make Imperial names sound too barbaric or clipped
- flatten surnames when the base game preserves full-name formality

Common pattern:

- more likely than Nords to have clear surname-bearing full names
- often paired with ranks, offices, or formal descriptors

Base-game examples:

- `Tullius` -> `图留斯`
- `Vittoria Vici` -> `维托利亚·维齐`
- `Emperor Titus Mede II` -> `皇帝提图斯·迈德二世`

### Bretons

Typical feel:

- softer than Nords
- often slightly courtly, literary, or knightly
- Western-European fantasy tone

Chinese rendering goals:

- keep them smooth and readable
- allow a little elegance, but do not over-romanticize

Do:

- let the sound feel human and social rather than harsh
- preserve noble or knightly tone where present

Do not:

- turn every Breton into a poetic title
- make them sound indistinguishable from Altmer names

Common pattern:

- personal name plus house, family, or court identity is common
- titles matter for social position

Base-game examples:

- `Delphine` -> `戴尔芬`
- `Colette Marence` -> `柯莱特·玛仑斯`
- `Mirabelle Ervine` -> `米拉贝勒·厄文`

### Redguards

Typical feel:

- sharper and more flowing at once
- often carries Arabic- or North-African-adjacent rhythm in English presentation
- dignified and martial

Chinese rendering goals:

- keep names smooth but distinct
- do not force them into Nordic or Imperial sound patterns

Do:

- preserve the slightly foreign rhythm relative to Skyrim's Nordic majority
- keep the name clean and memorable

Do not:

- blunt them into short Nordic shapes
- overcomplicate them with rare transliteration characters

Common pattern:

- many names feel self-contained and dignified
- titles and honorifics may matter, but the personal name usually carries strong identity by itself

Base-game examples:

- `Kematu` -> `凯马图`
- `Saadia` -> `萨蒂亚`
- `Nazeem` -> `纳奇姆`

### Dunmer

Typical feel:

- layered
- sharper and more exotic than human names
- often carries a house, lineage, or learned-culture flavor

Chinese rendering goals:

- allow slightly denser syllable structure
- keep a dark-elf feel without becoming unreadable

Good style shape:

- `卡莱亚`
- `法利昂`

Do:

- tolerate a little more phonetic complexity than with human names
- preserve recurring Dunmer-friendly syllables when they resemble shipped names

Do not:

- make every Dunmer name overly long
- use ornate characters just to signal exoticness

Common pattern:

- House affiliations often matter more than with many other cultures
- authors, priests, mages, and nobles recur across books and dialogue, so glossary discipline is especially important

Base-game examples:

- `Karliah` -> `卡莱亚`
- `Neloth` -> `内洛斯`
- `Revyn Sadri` -> `瑞温·萨德利`

### Altmer

Typical feel:

- formal
- elevated
- polished
- often longer and more flowing than Nordic or Imperial names

Chinese rendering goals:

- preserve elegance and smoothness
- keep the name feeling refined rather than rough

Do:

- allow slightly more elaborate syllable flow
- maintain a cultivated tone for titled or scholarly figures

Do not:

- make Altmer names abrupt or overly harsh
- confuse elegant with overwritten

Common pattern:

- titles, offices, and scholarly identity often matter
- personal names may look more ceremonial in context

Base-game examples:

- `Ancano` -> `安卡诺`
- `Nirya` -> `尼尔雅`
- `Elenwen` -> `爱琳温`

### Bosmer

Typical feel:

- lighter and more agile than Altmer
- often natural, sly, or quick in tone
- less rigidly formal than high-elf naming in presentation

Chinese rendering goals:

- keep the name nimble and readable
- avoid making Bosmer names too grand or stately

Do:

- preserve a sense of movement and informality where appropriate
- let hunters, scouts, and tricksters sound distinct from courtly elves

Do not:

- inflate every Bosmer into a noble register
- collapse them into generic human naming

Base-game examples:

- `Faendal` -> `法恩达尔`
- `Valindor` -> `瓦林多`
- `Malborn` -> `马伯恩`

### Orsimer

Typical feel:

- strong
- direct
- clan-conscious
- often structurally marked

Chinese rendering goals:

- preserve clan markers and lineage markers faithfully
- keep the overall feel strong and grounded

Do:

- preserve `gro-` / `gra-` style structures when present in a way that matches existing Chinese usage
- treat clan-linked forms as meaningful parts of the full name

Do not:

- strip off lineage markers as if they were decorative
- make Orc names sound delicate or aristocratic without reason

Common pattern:

- clan relation and kin markers are central
- a full Orc name may carry social information that should not be compressed away

Base-game examples:

- `Ugor` -> `乌戈尔`
- `Ghorza gra-Bagol` -> `果扎·格拉-巴果`
- `Borgakh the Steel Heart` -> `“钢心”波加克`

### Khajiit

Typical feel:

- highly distinctive
- often uses apostrophes, prefixes, or culturally specific internal structure
- social title and furstock identity may matter

Chinese rendering goals:

- preserve distinctiveness
- do not flatten Khajiit naming into ordinary human transliteration

Do:

- keep apostrophe-bearing or segmented structures legible
- preserve cultural particles if they are part of the actual name

Do not:

- normalize them into plain Imperial-style names
- arbitrarily delete separators that carry identity

Common pattern:

- some Khajiit names behave almost like titles plus names
- some are highly race-specific and should be left structurally unusual in Chinese if that unusualness is part of the identity

Base-game examples:

- `Kharjo` -> `哈由`
- `M'aiq the Liar` -> `骗子麦'奎`
- `J'zargo` -> `杰'扎格`

### Argonians

Typical feel:

- two parallel traditions often appear
- Jel/native-style names
- Tamrielic translated names that behave like phrases

Chinese rendering goals:

- first determine which naming system you are dealing with

If it is a translated Tamrielic-style Argonian name:

- translate it as a phrase
- preserve the descriptive sense

If it is a native-style Argonian name:

- transliterate conservatively
- keep the alien rhythm intact

Do:

- separate phrase-names from true phonetic names before translating
- preserve the cultural strangeness when the source intends it

Do not:

- transliterate a phrase-name that should obviously be understood
- over-translate a native Jel-like name into a made-up Chinese meaning

Base-game examples:

- `Scouts-Many-Marshes` -> `巡哨众沼`
- `From-Deepest-Fathoms` -> `源自深处`
- `Deeja` -> `蒂亚`

### Falmer and Ancient / Snow-Elf Names

Typical feel:

- archaic
- elegiac
- often encountered through books, translations, inscriptions, or scholarly contexts

Chinese rendering goals:

- stay conservative
- search existing references first
- preserve historical gravity

Do:

- look for a shipped or dictionary-backed form first
- keep the tone older and more formal when context demands it

Do not:

- improvise freely on one-off scholarly names without checking recurrence
- make them sound like ordinary modern NPC names

Base-game examples:

- `Knight-Paladin Gelebor` -> `圣骑士盖勒布`
- `Arch-Curate Vyrthur` -> `教士长维苏尔`
- `Snow Prince` -> `雪王子`

### Daedra, Demiprinces, and Other Non-Mortal Humanoids

Typical feel:

- can range from pure proper name to title-like label
- often carries explicit semantic or ceremonial weight

Chinese rendering goals:

- first decide whether it is truly a personal name, a title, a species label, or an epithet

Do:

- keep divine and prince names fixed to shipped forms
- translate epithets when they are functional
- transliterate personal names conservatively

Do not:

- drift away from base-game divine-name anchors
- treat a title as a personal name

Base-game examples:

- `Meridia` -> `美瑞蒂亚`
- `Nocturnal` -> `诺克图娜尔`
- `Sheogorath` -> `谢尔格拉`

## Race-Specific Decision Heuristic

When you meet a new name, ask:

1. Which culture does this character belong to?
2. In the shipped Chinese game, do names from that culture sound blunt, smooth, elaborate, or title-heavy?
3. Is the string functioning as a personal name, a phrase-name, or a title-bearing label?
4. If I place this translated name beside known names from the same race, does it feel native to that group?

If the answer to the last question is no, revise before finalizing.

## Prefixes, Suffixes, and Common Failure Modes

This section is the quick-reference layer.

Use it when you already know the character's culture and need to avoid the most common mistakes fast.

### Nords

Common shapes:

- compound surnames with clear imagery
- blunt one-word given names
- epithets tied to war, weather, beasts, strength, or age

Common examples in shipped style:

- `Stormcloak`
- `the Greater`
- `the Younger`

How to handle:

- given name: usually transliterate
- epithet: usually translate
- surname: preserve existing official form if one exists; otherwise be cautious about literalization

Danger zones:

- making Nordic names too elegant
- translating every surname literally when the official game uses a stable proper-name form
- losing the rough, martial tone

Heuristic:

If the name sounds like a warrior, hunter, or jarl should carry it, keep it compact and weighty.

### Imperials

Common shapes:

- personal name plus family name
- rank plus formal personal name
- dynastic numerals

Common examples in shipped style:

- `Titus Mede II`
- `Vittoria Vici`

How to handle:

- keep the middle dot in full formal names
- preserve Roman numerals or dynastic numbering in Chinese form
- translate office words separately

Danger zones:

- dropping the dynasty marker
- flattening a formal name into a casual one
- translating the surname's dictionary meaning instead of preserving the family-name function

Heuristic:

If the name looks courtly, legal, or dynastic, preserve its formal structure.

### Bretons

Common shapes:

- smooth multi-syllable names
- surnames that look courtly or provincial
- mages, knights, and noble-house forms

How to handle:

- prioritize smoothness
- do not overload with archaic characters
- keep court and guild context readable

Danger zones:

- making Breton names sound Altmer
- over-poetic translation of ordinary names
- giving every Breton a grand fantasy flourish

Heuristic:

If the name belongs in a court, chapel, or knightly order, it should read smoothly and formally, but not sound divine.

### Redguards

Common shapes:

- names with distinct internal rhythm
- occasional honorific or martial flavor
- smoother than Nordic, sharper than Breton

How to handle:

- keep the sound pattern distinct from Cyrodilic names
- avoid clipping too much
- preserve dignity and directness

Danger zones:

- Nordic-izing the name
- using awkward transliteration characters to mimic Arabic sound too literally
- making all Redguard names sound the same

Heuristic:

If the name sounds travel-worn, martial, and self-possessed in English, keep that feeling in Chinese.

### Dunmer

Common shapes:

- denser phonetic clusters
- House names
- scholar, priest, or aristocratic forms

Common examples you may also see in lore-heavy work:

- `House Redoran`
- `House Telvanni`

How to handle:

- personal name: transliterate conservatively
- House name: always check dictionary and lore sources first
- recurring political or priestly figures: enforce glossary consistency strictly

Danger zones:

- inventing a new House translation when the base game already has one
- making Dunmer names too short and plain
- overcompensating with bizarre characters

Heuristic:

If the name is attached to a House, temple, or book tradition, check recurrence before you touch it.

### Altmer

Common shapes:

- refined and often longer
- scholarly or aristocratic tone
- titles and offices frequently matter

How to handle:

- keep flow elegant
- let names breathe slightly more than Nordic ones
- preserve hierarchy and dignity

Danger zones:

- harsh transliteration
- over-decoration
- making ordinary Altmer sound like mythic beings unless the source actually does

Heuristic:

If the character belongs in an embassy, college, or royal court, keep the Chinese elegant but controlled.

### Bosmer

Common shapes:

- lean, quick, natural-feeling
- less ceremonious than Altmer
- often fits hunters, scouts, wanderers, and infiltrators

How to handle:

- keep names nimble
- avoid giving every Bosmer a grand, noble cadence
- let the name feel lighter than Altmer and less blunt than Nord

Danger zones:

- collapsing Bosmer into generic human naming
- making them sound too regal
- overusing floral or mystical wording that is not present in the source

Heuristic:

If the character feels like a scout, archer, or go-between, the Chinese should feel agile and readable.

### Orsimer

Common shapes:

- personal name with kin marker
- strong clan identity
- name plus epithet

Critical markers:

- `gro-`
- `gra-`

How to handle:

- preserve the marker
- do not delete it for convenience
- if an epithet follows, translate the epithet but keep the name structure stable

Danger zones:

- stripping away `gro-` / `gra-`
- treating the clan marker like ignorable punctuation
- softening Orc names too much

Heuristic:

If you remove the kin marker and the name loses social meaning, you translated it incorrectly.

### Khajiit

Common shapes:

- apostrophes
- segmented names
- title-like constructions
- culturally marked particles

Critical markers:

- apostrophe-bearing forms such as `J'zargo`
- article-like or role-like constructions such as `M'aiq the Liar`

How to handle:

- preserve the apostrophe when the shipped game preserves it
- do not “repair” the name into standard human punctuation
- if the second half is an epithet, translate the epithet and preserve the personal core

Danger zones:

- deleting apostrophes
- translating the whole name as if it were a phrase when it is actually a proper name plus epithet
- transliterating the epithet instead of translating it

Heuristic:

If a Khajiit name looks unusual, that unusualness is probably part of the identity and should survive in Chinese.

### Argonians

Common shapes:

- phrase-names
- native-style names
- role- or motion-based descriptive names

Common phrase-name signals:

- verb-like opening
- directional or environmental imagery
- hyphenated English phrase structure

How to handle:

- phrase-name: translate as a phrase
- native name: transliterate
- do not mix the two strategies

Danger zones:

- transliterating `Scouts-Many-Marshes`-type names
- over-explaining the phrase in Chinese
- turning a native Argonian name into an invented descriptive phrase

Heuristic:

If the English already reads like a meaningful sentence fragment, translate the meaning, not the sound.

### Falmer and Ancient Snow Elves

Common shapes:

- priestly or ceremonial offices
- translated chronicler names
- heroic or tragic sobriquets

Critical forms:

- rank-bearing religious offices such as `Arch-Curate`
- historical labels such as `Snow Prince`

How to handle:

- titles: translate
- personal core: transliterate using shipped precedent
- preserve the antique and solemn tone

Danger zones:

- making sacred offices too casual
- treating mythic labels as ordinary NPC names
- inventing new phonetic patterns without checking recurrence in books

Heuristic:

If the name appears in a translation note, chronicle, or shrine text, preserve historical gravity over cleverness.

### Daedra and Other Non-Mortals

Common shapes:

- divine names
- prince names
- honorific or title-heavy entities
- names that are semantically loaded

How to handle:

- divine and prince names: always use shipped forms
- epithets: translate for meaning
- lesser named daedra: transliterate cautiously unless the source is clearly title-like

Danger zones:

- drifting from official divine-name spellings
- mixing community variants with base-game forms
- treating a ceremonial label as a phonetic name

Heuristic:

If the being belongs to the game's religious backbone, the official name anchor beats every community alternative.

## Quick Triage Table

| If You See | Usually Means | Default Action |
| --- | --- | --- |
| `gro-` / `gra-` | Orc kin marker | Preserve it |
| apostrophe in a Khajiit name | Khajiit structural identity | Preserve it |
| hyphenated Argonian phrase-name | Meaning-bearing descriptive name | Translate the phrase |
| `the <descriptor>` after a name | epithet or sobriquet | Translate the descriptor |
| rank before a name | title + person | Translate title, preserve name |
| dynasty numeral | formal imperial naming | Preserve full formal structure |

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
