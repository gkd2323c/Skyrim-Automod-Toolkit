# Detect Life (effect)

| [](https://en.uesp.net/wiki/File:SR-icon-spell-Detect_Life.png) | Detect Life |
| --- | --- |
| School | [Alteration](Skyrim_Alteration.md) |
| Type | Other |
| Availability <br> (Click on any item for details) | |
| [Spells](Skyrim_Detect_Life_(spell).md) | |

**Nearby living creatures, but not undead, machines or daedra, can be seen through walls.**

**Detect Life** allows the caster to see NPCs and creatures as glowing shapes even through solid objects. [Undead](Skyrim_Undead.md), [Daedra](Skyrim_Daedra.md) and [Dwarven Automatons](Skyrim_Dwarven_Automatons.md) are not revealed by this effect, although [Detect Dead](Skyrim_Detect_Dead.md) can highlight undead. Enemies appear as red, and currently friendly creatures appear as blue -- although the status of friendly creatures can change when they are approached.

This effect is not available from [enchanting](Skyrim_Enchanting.md) or [potions](Skyrim_Alchemy.md). The only sources of this effect are, the [Gray Cowl of Nocturnal](Skyrim_Gray_Cowl_of_Nocturnal.md) and the [spell](Skyrim_Detect_Life_(spell).md) and [scroll](Skyrim_Scrolls.md#Scroll_of_Detect_Life) of detect life. The cowl is awarded after completion of the quest [The Gray Cowl Returns!](Skyrim_The_Gray_Cowl_Returns!.md) The spell tome is awarded at the completion of the quest [Infiltration](Skyrim_Infiltration.md), or it is available for purchase with sufficient [Alteration](Skyrim_Alteration.md) skill from [Tolfdir](Skyrim_Tolfdir.md) or [Wylandriah](Skyrim_Wylandriah.md). As with most spell tomes, it can also be found in random loot.

The spell actually casts four separate effects simultaneously:

- *Detect Life Enemy Interior* (`000cee00`; `Detect Life Enemy Interior Conc Self`)
- *Detect Life Enemy Exterior* (`000cedff`; `Detect Life Enemy Exterior Conc Self`)
- *Detect Life Friend Exterior* (`000b79e7`; `Detect Life Friend Exterior Conc Self`)
- *Detect Life Friend Interior* (`0001ea74`; `Detect Life Friend Interior Conc Self`)

## Notes
- The game's definition of enemy or friendly may not always match what a player expects. - Some creatures or NPCs that will only attack the player if they get close, such as some bandits and wolves, will be highlighted in blue when at a distance. Once the player approaches and the enemy attacks, its life force will change to red.
- Some non-hostile creatures that flee from the player, such as deer or foxes, will show in red. This is because they enter combat with the player upon sight like any other wild animal, but their combat AI tells them to flee as soon as the fight starts.
- Friendly NPCs actively engaged in activities such as smithing and chopping wood will also appear with a red aura.
- A similar effect is available from the [Aura Whisper](Skyrim_Aura_Whisper.md) shout. Unlike the spell, Aura Whisper identifies all living creatures as well as Dwarven automatons, but does not distinguish friend from foe.
- Casting this spell with two hands increases the duration of the spell only, not the detection range.

## Bugs
- Farm animals will sometimes be shown in red like enemies. If you assault them you will still have bounty on you and surrounding people will attack you as usual. <sup>**?**</sup>