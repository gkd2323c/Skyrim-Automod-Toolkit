#  Bandit Boss

| **Eliminate a bandit leader for a bounty reward.** |
| --- |

| Quest Giver: | Any innkeeper, Jarl or steward |
| --- | --- |
| Location(s): | None |
| Reward: | 100 gold |
| ID: | BQ01 |

[![](https://images.uesp.net/thumb/1/19/SR-quest-Kill_the_Bandit_Leader.jpg/200px-SR-quest-Kill_the_Bandit_Leader.jpg)](https://en.uesp.net/wiki/File:SR-quest-Kill_the_Bandit_Leader.jpg) [](https://en.uesp.net/wiki/File:SR-quest-Kill_the_Bandit_Leader.jpg) Time to pay your bounty.
## Radiant Options
Any innkeeper, Jarl, or hold steward can give you this quest. You will be directed to one of the possible locations that contain bandits in the same hold, and you will then need to obtain your reward from the Jarl or steward of the hold.

| [Eastmarch](Skyrim_Eastmarch.md) | [Falkreath Hold](Skyrim_Falkreath_Hold.md) | [Haafingar](Skyrim_Haafingar.md) | [Hjaalmarch](Skyrim_Hjaalmarch.md) | [The Pale](Skyrim_The_Pale.md) | [The Reach](Skyrim_The_Reach.md) | [The Rift](Skyrim_The_Rift.md) | [Whiterun Hold](Skyrim_Whiterun_Hold.md) | [Winterhold](Skyrim_Winterhold_(region).md) |
| --- | --- | --- | --- | --- | --- | --- | --- | --- |
| [Cragslane Cavern](Skyrim_Cragslane_Cavern.md) <br> [Gallows Rock](Skyrim_Gallows_Rock.md) <br> [Lost Knife Hideout](Skyrim_Lost_Knife_Hideout.md) <br> [Stony Creek Cave](Skyrim_Stony_Creek_Cave.md) <br> [Uttering Hills Camp](Skyrim_Uttering_Hills_Camp.md) | [Bilegulch Mine](Skyrim_Bilegulch_Mine.md) <br> [Cracked Tusk Keep](Skyrim_Cracked_Tusk_Keep.md) <br> [Embershard](Skyrim_Embershard.md) <br> [Knifepoint Ridge](Skyrim_Knifepoint_Ridge.md) | [Broken Oar Grotto](Skyrim_Broken_Oar_Grotto.md) <br> [Orphan's Tear](Skyrim_Orphan%27s_Tear.md) | [Orotheim](Skyrim_Orotheim.md) <br> [Robber's Gorge](Skyrim_Robber%27s_Gorge.md) | [Frostmere Crypt](Skyrim_Frostmere_Crypt.md) | [Four Skull Lookout](Skyrim_Four_Skull_Lookout.md) | [Broken Helm Hollow](Skyrim_Broken_Helm_Hollow.md) <br> [Faldar's Tooth](Skyrim_Faldar%27s_Tooth.md) <br> [Nilheim](Skyrim_Nilheim.md) <br> [Rift Watchtower](Skyrim_Rift_Watchtower.md) <br> [Ruins of Bthalft](Skyrim_Ruins_of_Bthalft.md) <br> [Treva's Watch](Skyrim_Treva%27s_Watch.md) | [Halted Stream Camp](Skyrim_Halted_Stream_Camp.md) <br> [Redoran's Retreat](Skyrim_Redoran%27s_Retreat.md) <br> [Silent Moons Camp](Skyrim_Silent_Moons_Camp.md) <br> [Valtheim Keep](Skyrim_Valtheim_Keep.md) | [Fort Fellhammer](Skyrim_Fort_Fellhammer.md) <br> [Snowpoint Beacon](Skyrim_Snowpoint_Beacon.md) <br> [Winter War](Skyrim_Winter_War.md) |

## Quick Walkthrough
1. Get the bounty from an innkeeper, Jarl, or steward.
2. Kill the bandit leader at the given location.
3. Return to the Jarl or steward for a reward.

## Detailed Walkthrough
Asking an innkeeper, Jarl's steward, or Jarl about work may lead them to give you a [letter of bounty](Skyrim_Bounty_(bandits).md) for a bandit leader, found in a location in the hold you are in. Head to the location and kill the bandit leader. There may be multiple bandits at the location, but you only have to kill the marked leader to mark this objective as complete. Once the bandit is dead, return to the Jarl or Jarl's steward for your reward of 100 gold.

## Notes
- The "bandit leader" might be a standard low-level bandit.

## Bugs
- If the ruins are cleared out before the quest is given to kill the bandit leader, the ruins may not repopulate, causing this quest to not be completable. - [![On PC](https://images.uesp.net/d/d7/Computer.svg)](https://www.wikipedia.org/wiki/PC_game) To fix this, approach the boss and open the console. After clicking on him, type `resurrect 1`. This will bring him back to life and allow you to complete the quest.
- [![On PC](https://images.uesp.net/d/d7/Computer.svg)](https://www.wikipedia.org/wiki/PC_game) Another fix is to open the console and type `setstage bq01 100 ` (if started by the steward) or `setstage bq01 101` (if started by the Jarl). This will clear the bandit leader and point you to collect the bounty.

## Quest Stages
| Bounty: Bandit Boss (BQ01) | | |
| --- | --- | --- |
| Stage | Finishes Quest | Journal Entry |
| 10 | | *Objective 10:* Kill the bandit leader located at <Alias=Bounty Location> |
| 100 | | *Objective 100:* Collect bounty from <Alias=Steward> *Objective 101:* Collect bounty from <Alias=Jarl> |

- The following empty quest stages were omitted from the table: 0, 200.

Notes - Any text displayed in angle brackets (e.g., `<Alias=Location Hold>`) is dynamically set by the Radiant Quest system, and will be filled in with the appropriate word(s) when seen in game.
- Not all Journal Entries may appear in your journal; which entries appear and which entries do not depends on the manner in which the quest is done.
- Stages are not always in order of progress. This is usually the case with quests that have multiple possible outcomes or quests where certain tasks may be done in any order. Some stages may therefore repeat objectives seen in other stages.
- If an entry is marked as "Finishes Quest" it means the quest disappears from the Active Quest list, but you may still receive new entries for that quest.
- On the PC, it is possible to use the [console](Skyrim_Console.md) to advance through the quest by entering `setstage BQ01 stage`, where `stage` is the number of the stage you wish to complete. It is not possible to un-complete (i.e. go back) quest stages, but it is possible to clear all stages of the quest using `resetquest BQ01`.