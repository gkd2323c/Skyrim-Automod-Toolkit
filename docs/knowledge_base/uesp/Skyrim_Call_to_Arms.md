# Call to Arms

| [](https://en.uesp.net/wiki/File:SR-icon-spell-Illusion_Light.png) | Call to Arms | [](https://en.uesp.net/wiki/File:SR-icon-book-Spell Tome Illusion.png) | |
| --- | --- | --- | --- |
| School | [Illusion](Skyrim_Illusion.md) | Difficulty | Master |
| Type | Defensive | Casting | Fire and Forget |
| Delivery | Self | Equip | Both Hands |
| [Spell ID](Skyrim_Form_ID.md) | 00 07e8dd | Editor ID | Call To Arms |
| [Base Cost](Skyrim_Magic_Overview.md#Spell_Cost) | 655 | Charge Time | 3.0 |
| [Duration](Skyrim_Magic_Overview.md#Duration) | 10 min | Range | 0 |
| Magnitude | 25 | Area | 100 ft |
| [Tome ID](Skyrim_Form_ID.md) | 00 0a271b | Tome Value | 1150 |
| Purchase from (after [Illusion Ritual Spell](Skyrim_Illusion_Ritual_Spell.md)) | | | |
| - [Drevis Neloren](Skyrim_Drevis_Neloren.md) | | | |

- *Targets have improved combat skills, health and stamina for 10 minutes.*

**Call to Arms** is a master level [Illusion](Skyrim_Illusion.md) spell that increases the combat skills, health, and stamina of all allies within 100 feet of the caster for 10 minutes.

## Effects
- [Fortify Marksman](Skyrim_Fortify_Marksman.md), 25 pts for 600 secs in 100 ft
- [Fortify One-handed](Skyrim_Fortify_One-Handed.md), 25 pts for 600 secs in 100 ft
- [Fortify Two-handed](Skyrim_Fortify_Two-Handed.md), 25 pts for 600 secs in 100 ft
- [Fortify Health](Skyrim_Fortify_Health.md), 25 pts for 600 secs in 100 ft
- [Fortify Stamina](Skyrim_Fortify_Stamina.md), 25 pts for 600 secs in 100 ft

## Perks
- [Animage](Skyrim_Animage.md), +8 to Fortify magnitudes when cast on animals.
- [Kindred Mage](Skyrim_Kindred_Mage.md), +10 to Fortify magnitudes when cast on people.
- [Master of the Mind](Skyrim_Master_of_the_Mind.md), allows spell to work on undead, daedra, and automata.

This gives the following performance:

| | Fortify Magnitude |
| --- | --- |
| Default | 25 |
| Animage | 33 |
| Kindred Mage | 35 |

*Master of the Mind* will *not* stack with *Kindred Mage* or *Animage*, which is primarily of interest when attempting to cast spells on friendly undead, typically people or animals you have raised yourself. It's also worth noting that if you are a [vampire](Skyrim_Vampire.md), [Champion of the Night](Skyrim_Vampirism.md#Champion_of_the_Night) will apply to the Fortify magnitude, not the duration, as will [Necromage](Skyrim_Necromage_(perk).md), when cast on undead.

## Notes
- If a follower who is [Protected](Skyrim_Protected_NPCs.md) has had their health reduced to the point where they are crawling around on the ground, this spell will get them to stand up and fight again, mainly due to the Fortify Health part. However, if their health is then reduced again, and not restored before the effect wears off, they may die, as the extra health is removed and reduces them to below 0.
- Unlike the earlier spells [Courage](Skyrim_Courage.md) and [Rally](Skyrim_Rally_(spell).md), this won't necessarily prevent targets from fleeing, though with increased health and skills it does make it less likely they'll need to.
- This spell has by far the longest duration of any (non-permanent) spell in the game.
- The effects of this spell are independent from [Rally](Skyrim_Rally_(spell).md) and [Courage](Skyrim_Courage.md). Thus, the bonuses from all 3 spells can be stacked together.

## Bugs
- The Fortify Marksman, Fortify One-handed, and Fortify-Two-handed effects will not work on undead, daedra, or automatons even with the Master of the Mind perk unlocked. From looking through the creation kit, this is due to the corresponding magic effects not existing. - ![PC Only](https://images.uesp.net/d/d7/Computer.svg)
The [Unofficial Skyrim Patch](https://en.uesp.net/wiki/Skyrim_Mod:Unofficial_Skyrim_Patch), version 2.0.4, fixes this bug. ([details](https://afktrack.afkmods.com/index.php?a=issues&i=15488))