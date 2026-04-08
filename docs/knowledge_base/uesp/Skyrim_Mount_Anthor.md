# Mount Anthor

| --- | --- | --- |
| [](https://en.uesp.net/wiki/File:SR-mapicon-Dragon_Lair.png) | Dragon Lair: <br> Mount Anthor <br> ([view on map](https://gamemap.uesp.net/sr/?world=Skyrim&centeron=Mount+Anthor)) ([lore page](https://en.uesp.net/wiki/Lore:Mount_Anthor)) | |
| [Clearable](Skyrim_Dungeons.md#Clearing) | Yes | |
| [Dungeon](Skyrim_Dungeons.md) | Yes | |
| [Respawn Time](https://en.uesp.net/wiki/Skyrim:Respawn) | 10 days or 30 days | |
| [Level](https://en.uesp.net/wiki/Skyrim:Encounter_Zone_Level) | Min: 10 | |
| Occupants | | |
| [Dragon](Skyrim_Dragon.md), [Warlocks](Skyrim_Warlock.md) | | |
| Console Location Code(s) | | |
| Mount Anthor Exterior01, Mount Anthor Exterior02, Mount Anthor Exterior03, Mount Anthor Exterior04, Mount Anthor Exterior05, Mount Anthor Exterior06, Mount Anthor Exterior07 | | |
| Region | | |
| [Winterhold](Skyrim_Winterhold_(region).md) | | |
| Location | | |
| South-southwest of [Winterhold](Skyrim_Winterhold.md) <br> North of [Yorgrim Overlook](https://en.uesp.net/wiki/Skyrim:Yorgrim_Overlook) | | |
| Special Features | | |
| [Word Wall](Skyrim_Word_Wall.md) | [Ice Form](Skyrim_Ice_Form.md) | |
| # of [Alchemy Labs](Skyrim_Alchemy_Labs.md) | 1 | |

[![](https://images.uesp.net/thumb/c/ce/SR-place-Mount_Anthor.jpg/200px-SR-place-Mount_Anthor.jpg)](https://en.uesp.net/wiki/File:SR-place-Mount_Anthor.jpg) [](https://en.uesp.net/wiki/File:SR-place-Mount_Anthor.jpg) Mount Anthor **Mount Anthor** is a mountaintop [dragon lair](Skyrim_Dragon_Lairs.md) south-southwest of [Winterhold](Skyrim_Winterhold.md). Its [word wall](Skyrim_Word_Wall.md) teaches part of the [Ice Form](Skyrim_Ice_Form.md) [shout](Skyrim_Dragon_Shouts.md).

## Related Quests
- **[Bounty: Dragon](Skyrim_Bounty__Dragon.md)**: Kill a [dragon](Skyrim_Dragon.md) in its [lair](Skyrim_Dragon_Lairs.md). ([radiant](Skyrim_Radiant.md))
- **[Dragon Seekers](Skyrim_Dragon_Seekers.md)**: Go to a [dragon lair](Skyrim_Dragon_Lairs.md) with [Farkas](Skyrim_Farkas.md) or [Vilkas](Skyrim_Vilkas.md) and kill the dragon. ([radiant](Skyrim_Radiant.md))

- This location is one of many potential targets for [one or more of the Radiant quests](Skyrim_Radiant.md#Quest_Locations).

## Walkthrough
Before the [dragons' return](Skyrim_Dragon_Rising.md), the word wall will be guarded by two leveled [warlocks](Skyrim_Warlock.md).

After the dragons' return, the word wall will be guarded by a leveled [dragon](Skyrim_Dragon.md).

Regardless of whether [Dragon Rising](Skyrim_Dragon_Rising.md) has been completed, there is an [alchemy lab](Skyrim_Alchemy_Labs.md) on the altar in the middle of the lair, one urn, and one burial urn. At the top of the main stairway in the center of the lair is the word wall.

## Notes
- Mount Anthor is the only dragon lair with no treasure chest.
- The path southwest up the mountain to the lair continues to the south, then east, looping back to the [Shrine of Azura](https://en.uesp.net/wiki/Skyrim:Shrine_of_Azura). It appears that an avalanche killed a party of [refugees](Skyrim_Refugee.md) on this path. Their three bodies, along with a wrecked cart piled up with their belongings, can be found partially buried in the snow. Among the detritus are a few useful items: a coin purse, a potion, an apothecary's satchel, a leveled battleaxe, and a copy of the [Enchanting](Skyrim_Enchanting.md) [skill book](Skyrim_Skill_Books.md) *[Enchanter's Primer](https://en.uesp.net/wiki/Skyrim:Enchanter%27s_Primer)*.
- Mount Anthor was the site of the battle between [Olaf One-Eye](Lore_Olaf_One-Eye.md) and the dragon Numinex which occurred during the [First Era](Lore_First_Era.md).
- Mount Anthor also [appears](https://en.uesp.net/wiki/Legends:Mount_Anthor) in [Legends](https://en.uesp.net/wiki/Legends:Legends).

## Bugs
- If the dragon at the wall is the subject of a bounty, it may not appear after the main quest has been completed.
- Sometimes after killing the dragon, you won't absorb its soul. You may also be unable to harvest Dragon Heartscales with [Kahvozein's Fang](Skyrim_Quest_Items.md#Kahvozein.27s_Fang).
- If the dragon is killed while on the stairs, occasionally the skeletal remains will clip incorrectly and fall through the stairs, rendering the dragon soul unavailable. <sup>**?**</sup>
- The dragon sometimes doesn't spawn correctly. This sometimes causes the compass to point toward an incorrect location, even if the map itself centers on the correct location. - [![On PC](https://images.uesp.net/d/d7/Computer.svg)](https://www.wikipedia.org/wiki/PC_game) If the dragon is the target of a quest, you may use the [console](Skyrim_Console.md) command `sqt` to review the quest variables for the dragon's [reference ID](Skyrim_Form_ID.md), then use further commands to force the dragon to appear or respawn. For example, if the dragon's reference ID is "32AC2", the command `prid 32AC2` followed by the command `moveto player` should force the dragon to appear. Alternatively, if the dragon isn't dead or disabled (i.e., `prid 32AC2` then `getdead` and `getdisabled` both return "0"), you can instead use `prid 32AC2` followed by `resetai`, which should cause the dragon to start circling the area again after a few seconds. Finally, you may simply skip the quest by using the command `setstage *quest ID* 100` (see the relevant quest page to confirm the quest ID and stage variables).
- You may use splash damage spells (Fireball, runes, etc.) to damage the dragon hiding in the terrain. Cast the spell in the direction of the arrow icon on the map, and the dragon should reappear.