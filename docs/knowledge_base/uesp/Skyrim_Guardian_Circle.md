# Guardian Circle

| [](https://en.uesp.net/wiki/File:SR-icon-spell-Turn_Undead.png) | Guardian Circle | [](https://en.uesp.net/wiki/File:SR-icon-book-Spell Tome Restoration.png) | |
| --- | --- | --- | --- |
| School | [Restoration](Skyrim_Restoration.md) | Difficulty | Master |
| Type | Defensive | Casting | Fire and Forget |
| Delivery | Self | Equip | Both Hands |
| [Spell ID](Skyrim_Form_ID.md) | 00 0e0ccf | Editor ID | Guardian Circle |
| [Base Cost](Skyrim_Magic_Overview.md#Spell_Cost) | 716 | Charge Time | 3.0 |
| [Duration](Skyrim_Magic_Overview.md#Duration) | 60 secs | Range | 0 |
| Magnitude | 35 | Area | 12 |
| [Tome ID](Skyrim_Form_ID.md) | 00 0fde7b | Tome Value | 1220 |
| Purchase from (after [Restoration Ritual Spell](https://en.uesp.net/wiki/Skyrim:Restoration_Ritual_Spell)) | | | |
| - [Colette Marence](Skyrim_Colette_Marence.md) | | | |

[![](https://images.uesp.net/thumb/c/c9/SR-spell-Guardian_Circle.jpg/200px-SR-spell-Guardian_Circle.jpg)](https://en.uesp.net/wiki/File:SR-spell-Guardian_Circle.jpg) [](https://en.uesp.net/wiki/File:SR-spell-Guardian_Circle.jpg) Guardian Circle
- *Undead up to level 35 entering the circle will flee. Caster heals 20 health per second inside it.*

**Guardian Circle** is a master level [Restoration](Skyrim_Restoration.md) spell, which will cause any [undead](Skyrim_Undead.md) up to level 35 who enter the circle to flee from combat for 30 seconds, and also heal the caster while inside the circle.

## Effects
- Guardian Circle, 35 pts for 30 secs
- [Restore Health](Skyrim_Restore_Health.md), 20 pts for 2 secs

## Perks
- [Necromage](Skyrim_Necromage_(perk).md), increases duration of the turn undead effect to 90 seconds and affects undead up to level 43 (requires USKP).
- [Restoration Dual Casting](https://en.uesp.net/wiki/Skyrim:Restoration_Dual_Casting), increases the turn undead effect duration to over 2 minutes.

## Notes
- The fear duration is independent from the circle's duration, i.e.: If an undead creature enters the circle after 29 seconds, it will still flee for a full 30 seconds, even though the circle itself has expired.
- The circle does not move with the caster, but stays where it is when cast for 60 seconds. There is no requirement that the caster remain within the circle to keep it going. However, you will not receive healing unless you are in the circle.
- The circle will not heal your allies or anyone else, only the caster. Also, unlike standard healing spells, it will not heal stamina, even with the [Respite](https://en.uesp.net/wiki/Skyrim:Respite) perk. It will however replenish magicka if you have the [Atronach](Skyrim_Alteration.md#Skill_Perks) perk as it counts as being "hit" by a spell from an outside source.
- You can only have at most one Guardian Circle active at a time. Casting a second will dispel the first. However, you can cast it along with a [Circle of Protection](Skyrim_Circle_of_Protection.md), and have both running at once.

## Bugs
- The circle's Turn Undead duration is 30 seconds, and the healing duration is only 2 seconds, while the intended duration for both is 60 seconds. - ![PC Only](https://images.uesp.net/d/d7/Computer.svg)
The [Unofficial Skyrim Patch](https://en.uesp.net/wiki/Skyrim_Mod:Unofficial_Skyrim_Patch), version 4.1.3, fixes this bug. ([details](https://afktrack.afkmods.com/index.php?a=issues&i=22959))
- Guardian Circle also would not properly heal you if 100% spell absorption is in place due to the lack of proper flags to override that. - The [Unofficial Skyrim Special Edition Patch](https://en.uesp.net/wiki/Skyrim_Mod:Unofficial_Skyrim_Special_Edition_Patch), version 4.1.3, fixes this bug.
- Colette is supposed to sell this spell after [Restoration Ritual Spell](https://en.uesp.net/wiki/Skyrim:Restoration_Ritual_Spell) has been completed, but it may not be available for sale. - ![PC Only](https://images.uesp.net/d/d7/Computer.svg)
The [Unofficial Skyrim Patch](https://en.uesp.net/wiki/Skyrim_Mod:Unofficial_Skyrim_Patch), version 1.3.1, fixes this bug.

- The book is added to Colette's inventory after the quest until the next inventory reset. This is because the game erroneously sets the completion flag for the Alteration ritual quest instead of the Restoration ritual quest, so the leveled list containing the book remains disabled.
- [![On PC](https://images.uesp.net/d/d7/Computer.svg)](https://www.wikipedia.org/wiki/PC_game) At any time after the Augur's test, enter the following command into the console to make the book available: `set MGRitual Rest Book to 0`. If Tolfdir incorrectly has Mass Paralysis and you wish to get rid of it, enter: `set MGRitual Alt Book to 100`. In either case, you may have to wait for the merchant's inventory to reset.
- One possible way to prevent the bug is to run to Colette as quickly as possible once you pass the Augur's test. This can be made easier by doing the test at night so that Colette will be in her bed, memorizing the path out from The Midden Dark to the Hall of Countenance, setting the difficulty to Novice, and standing next to the Augur's door to sprint out as soon as it opens (don't stop to put on clothes or change spells).
- Another option, if you can afford it, is to purchase everything (maybe just the books) from Colette before the Augur's test. This seems to correct the inventory reset to include the Guardian Circle Spell Tome. - This option was done successfully by only purchasing some Soul Gems from her.
- It appears that removing your follower from your service before starting the trial may prevent the bug.
- It seems that only using restoration spells during this test also works.
- The "hazard" effect for this spell doesn't match up with the spell's duration, which can cause the visible effects to disperse before the spell expires. - ![PC Only](https://images.uesp.net/d/d7/Computer.svg)
The [Unofficial Skyrim Patch](https://en.uesp.net/wiki/Skyrim_Mod:Unofficial_Skyrim_Patch), version 2.0.8, fixes this bug.