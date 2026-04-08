#  Giant

| **Kill a problematic [giant](Skyrim_Giant.md) for a bounty reward.** |
| --- |

| Location(s): | None |
| --- | --- |
| Reward: | 100 gold |
| ID: | BQ03 |
| Required Level: | 20 |

[![](https://images.uesp.net/thumb/f/fd/SR-quest-Bounty_Giant.jpg/200px-SR-quest-Bounty_Giant.jpg)](https://en.uesp.net/wiki/File:SR-quest-Bounty_Giant.jpg) [](https://en.uesp.net/wiki/File:SR-quest-Bounty_Giant.jpg) Giants are troubling the Jarl's hold.
## Radiant Options
Any innkeeper, [Jarl](Skyrim_Jarl.md) or Jarl's [steward](Skyrim_Steward.md) can give you this quest. You will be directed to one of the [giant camps](Skyrim_Giant_Camps.md) in the hold, where you will then need to kill a [giant](Skyrim_Giant.md) there to obtain your reward from the jarl or steward of the hold.

| [Eastmarch](Skyrim_Eastmarch.md) | [Falkreath Hold](Skyrim_Falkreath_Hold.md) | [Hjaalmarch](Skyrim_Hjaalmarch.md) | [The Pale](Skyrim_The_Pale.md) | [Whiterun Hold](Skyrim_Whiterun_Hold.md) |
| --- | --- | --- | --- | --- |
| [Broken Limb Camp](Skyrim_Broken_Limb_Camp.md) <br> [Cradlecrush Rock](Skyrim_Cradlecrush_Rock.md) <br> [Steamcrag Camp](Skyrim_Steamcrag_Camp.md) | [Secunda's Kiss](Skyrim_Secunda%27s_Kiss.md)<sup>[†](#intnote_secunda)</sup> | [Talking Stone Camp](Skyrim_Talking_Stone_Camp.md) | [Blizzard Rest](Skyrim_Blizzard_Rest.md) <br> [Red Road Pass](Skyrim_Red_Road_Pass.md) <br> [Stonehill Bluff](Skyrim_Stonehill_Bluff.md) <br> [Tumble Arch Pass](Skyrim_Tumble_Arch_Pass.md) | [Bleakwind Basin](Skyrim_Bleakwind_Basin.md) <br> [Guldun Rock](Skyrim_Guldun_Rock.md) <br> [Sleeping Tree Camp](Skyrim_Sleeping_Tree_Camp.md) |

[†](#note_secunda) This location appears as "Secunda's Shelf" in your quest log.
## Quick Walkthrough
1. Get the bounty letter from an innkeeper, Jarl, or steward.
2. Go to the giant camp and kill the giant.
3. Return to the Jarl or the Jarl's steward for the reward.

## Detailed Walkthrough
Speaking with any innkeeper, Jarl, or Jarl's steward about work may lead them to give you a [letter of bounty](Skyrim_Bounty_(giant).md) requesting you to kill a giant. This will give you a miscellaneous objective to kill the giant in a specific camp. Head to the camp specified in the letter and kill the marked giant (there may be multiple giants, but you only have to kill the marked one). Once the giant is killed, you can return to the Jarl or steward for your 100 gold reward.

## Notes
- Sometimes the Jarl may request to kill another giant in a camp previously cleared. This is not a bug. New giants will be spawned and will be correctly associated with markers, killing and quest updates.

## Bugs
- The objective "Collect bounty from Skald" may not clear from quest list. This bug is due to the quest pointer completing stage 100 when you talk to Skald instead of stage 101. - ![PC Only](https://images.uesp.net/d/d7/Computer.svg)
The [Unofficial Skyrim Patch](https://en.uesp.net/wiki/Skyrim_Mod:Unofficial_Skyrim_Patch), version 1.0, fixes this bug.

- [![On PC](https://images.uesp.net/d/d7/Computer.svg)](https://www.wikipedia.org/wiki/PC_game) A possible workaround is to use the [console](Skyrim_Console.md) command `set Objective Completed BQ03 101 1` before turning in the quest to Skald, to clear the journal entry. Then just talk to Skald to get your bounty.

## Quest Stages
| Bounty: Giant (BQ03) | | |
| --- | --- | --- |
| Stage | Finishes Quest | Journal Entry |
| 10 | | *Objective 10:* Kill the giant located at <Alias=Bounty Location> |
| 100 | | *Objective 100:* Collect bounty from <Alias=Steward> *Objective 101:* Collect bounty from <Alias=Jarl> |

- The following empty quest stages were omitted from the table: 0, 200.

Notes - Any text displayed in angle brackets (e.g., `<Alias=Location Hold>`) is dynamically set by the Radiant Quest system, and will be filled in with the appropriate word(s) when seen in game.
- Not all Journal Entries may appear in your journal; which entries appear and which entries do not depends on the manner in which the quest is done.
- Stages are not always in order of progress. This is usually the case with quests that have multiple possible outcomes or quests where certain tasks may be done in any order. Some stages may therefore repeat objectives seen in other stages.
- If an entry is marked as "Finishes Quest" it means the quest disappears from the Active Quest list, but you may still receive new entries for that quest.
- On the PC, it is possible to use the [console](Skyrim_Console.md) to advance through the quest by entering `setstage BQ03 stage`, where `stage` is the number of the stage you wish to complete. It is not possible to un-complete (i.e. go back) quest stages, but it is possible to clear all stages of the quest using `resetquest BQ03`.