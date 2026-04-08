# Conjure Frost Atronach

| --- | --- | --- | --- |
| School | [Conjuration](Skyrim_Conjuration.md) | Difficulty | Adept |
| Type | Offensive | Casting | Fire and Forget |
| Delivery | Target Location | Equip | Either Hand |
| [Spell ID](Skyrim_Form_ID.md) | 00 0204c4 | Editor ID | Conjure Frost Atronach |
| [Base Cost](Skyrim_Magic_Overview.md#Spell_Cost) | 214 | Charge Time | 0.5 |
| [Duration](Skyrim_Magic_Overview.md#Duration) | 60 sec | Range | 24 ft |
| [Tome ID](Skyrim_Form_ID.md) | 00 0a26ef | Tome Value | 347 |
| Appears in [random loot](Skyrim_Spell_Tomes.md#Spell_Tome_Locations) at level | 23+ | | |
| Purchase from ([Conjuration](Skyrim_Conjuration.md) lvl 40+) | | | |
| \| - [Calcelmo](Skyrim_Calcelmo.md) <br> - [Falion](Skyrim_Falion.md) \| - [Phinis Gestor](https://en.uesp.net/wiki/Skyrim:Phinis_Gestor) \| <br> \| --- \| --- \| | - [Calcelmo](Skyrim_Calcelmo.md) <br> - [Falion](Skyrim_Falion.md) | - [Phinis Gestor](https://en.uesp.net/wiki/Skyrim:Phinis_Gestor) | |
| - [Calcelmo](Skyrim_Calcelmo.md) <br> - [Falion](Skyrim_Falion.md) | - [Phinis Gestor](https://en.uesp.net/wiki/Skyrim:Phinis_Gestor) | | |
| Notes | | | |
| - Can be created at the [Atronach Forge](Skyrim_Atronach_Forge.md) | | | |

[![](https://images.uesp.net/thumb/1/1f/SR-creature-Frost_Atronach.jpg/200px-SR-creature-Frost_Atronach.jpg)](https://en.uesp.net/wiki/File:SR-creature-Frost_Atronach.jpg) [](https://en.uesp.net/wiki/File:SR-creature-Frost_Atronach.jpg) Frost Atronach *Summons a [Frost Atronach](Skyrim_Frost_Atronach.md) for 60 seconds wherever the caster is pointing.* **Conjure Frost Atronach** is an adept level [Conjuration](Skyrim_Conjuration.md) spell that summons a [Frost Atronach](Skyrim_Frost_Atronach.md) to aid you in combat.

## Effects
- [Conjure Frost Atronach](Skyrim_Summon.md), for 60 secs

or - [Conjure Potent Frost Atronach](Skyrim_Summon.md), for 60 secs (with [Elemental Potency](https://en.uesp.net/wiki/Skyrim:Elemental_Potency) perk)

## Perks
- [Summoner](https://en.uesp.net/wiki/Skyrim:Summoner), increase range to 48 ft at first rank or 72 ft at second rank.
- [Atromancy](https://en.uesp.net/wiki/Skyrim:Atromancy), extends duration to 120 secs.
- [Elemental Potency](https://en.uesp.net/wiki/Skyrim:Elemental_Potency), summons the more powerful Potent Frost Atronach.

## Notes
- The stats of the Frost Atronachs summoned are:

| Creature ([ID](Skyrim_Form_ID.md)) | Lvl | Carries | [](https://en.uesp.net/wiki/File:Skyrim TAG-icon-Health.png) | [](https://en.uesp.net/wiki/File:Skyrim TAG-icon-Magicka.png) | [](https://en.uesp.net/wiki/File:Skyrim TAG-icon-Stamina.png) | Abilities | Attacks | [Soul](Skyrim_Souls.md) |
| --- | --- | --- | --- | --- | --- | --- | --- | --- |
| **Frost Atronach** <br> (00 023aa7) | 16 | [Frost Salts](Skyrim_Frost_Salts.md) | 300 | 25 | 125 | - [Resist Frost](Skyrim_Resist_Frost.md) 100% <br> - [Weakness to Fire](Skyrim_Weakness_to_Fire.md) 33% <br> - [Waterbreathing](Skyrim_Waterbreathing_(effect).md) <br> - Immune to [Paralysis](Skyrim_Paralyze_(effect).md) <br> - Cannot be [Reanimated](Skyrim_Reanimate.md) | - Frost Cloak 10 pts (Opponents in melee range take 10 points frost damage and stamina damage per second.) | Common |
| **Potent Frost Atronach** <br> (00 04e943) | 24 | 503 | 0 | 292 | | | | |

## Bugs
- Under certain conditions, the Enc Atronach Frost base record can be corrupted in saves, causing summoned Frost Atronachs to become invisible with their skills and race altered. This is fixed by deleting the "NPC_ (Skyrim.esm) refid=000204c1" from the save using Fallrim Tools/Re Saver.