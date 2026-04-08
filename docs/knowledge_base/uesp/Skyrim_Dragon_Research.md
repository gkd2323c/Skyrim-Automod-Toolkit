# Dragon Research

| --- |

| **Help [Esbern](Skyrim_Esbern.md) complete his research on [dragons](Skyrim_Dragon.md).** |
| --- |

| Location(s): | None | |
| --- | --- | --- |
| Reward: | [Esbern's Potion](https://en.uesp.net/wiki/Skyrim:Esbern%27s_Potion) | |
| ID: | Freeform Sky Haven Temple D | |
| --- | | |
| \| **← Previous** <br> [Dragon Hunting](Skyrim_Dragon_Hunting.md) \| \| <br> \| --- \| --- \| | **← Previous** <br> [Dragon Hunting](Skyrim_Dragon_Hunting.md) | |
| **← Previous** <br> [Dragon Hunting](Skyrim_Dragon_Hunting.md) | | |
| \| ← Previous \| [Dragon Hunting](Skyrim_Dragon_Hunting.md) \| <br> \| --- \| --- \| | ← Previous | [Dragon Hunting](Skyrim_Dragon_Hunting.md) |
| ← Previous | [Dragon Hunting](Skyrim_Dragon_Hunting.md) | |

[![](https://images.uesp.net/thumb/9/9f/SR-creature-Dragon_Dead.jpg/200px-SR-creature-Dragon_Dead.jpg)](https://en.uesp.net/wiki/File:SR-creature-Dragon_Dead.jpg) [](https://en.uesp.net/wiki/File:SR-creature-Dragon_Dead.jpg) Now for the harvest
## Quick Walkthrough
- Speak with [Esbern](Skyrim_Esbern.md).
- Acquire a [dragon bone](Skyrim_Dragon_Bone.md) and a [dragon scale](Skyrim_Dragon_Scales.md).
- Return to Esbern.
- Drink the [potion](https://en.uesp.net/wiki/Skyrim:Esbern%27s_Potion).
- Speak with Esbern once more to complete the quest.

## Detailed Walkthrough
Once you have three followers recruited as [Blades](Skyrim_Blades.md), you can ask [Esbern](Skyrim_Esbern.md) for [dragons](Skyrim_Dragon.md) to kill. Once you agree to kill one, Esbern will send you to a random place where you'll find a dragon. After you kill the dragon, you'll get the update to the quest stating "Return to Esbern". Return and speak to him; he'll ask for a [dragon bone](Skyrim_Dragon_Bone.md) and a [dragon scale](Skyrim_Dragon_Scales.md). Give him the dragon bone and scale and he'll give you a [potion](https://en.uesp.net/wiki/Skyrim:Esbern%27s_Potion). Drink the potion to gain the [Dragon Infusion](https://en.uesp.net/wiki/Skyrim:Dragon_Infusion) perk. Speak with him once more to complete the quest. The potion adds the permanent perk of 25% less melee damage from dragons.

## Bugs
- You do not gain the perk after drinking the potion and it is not obtainable via normal gameplay means. - The [Official Skyrim Patch](Skyrim_Patch.md), version 1.9, fixes this bug.
- The quest journal entry won't update after quest completion. - ![PC Only](https://images.uesp.net/d/d7/Computer.svg)
The [Unofficial Skyrim Patch](https://en.uesp.net/wiki/Skyrim:Mod_Unofficial_Skyrim_Patch), version 1.0, fixes this bug.

- [![On Play Station](https://images.uesp.net/6/64/Playstation.svg)](Skyrim_PlayStation.md) [![On Xbox](https://images.uesp.net/3/33/Xbox.svg)](Skyrim_Xbox.md) If you don't want an uncompleted quest stuck in their quest log, you have the opportunity to back out of dialogue with Esbern after the 'Talk to Esbern' objective but before you inquire about a dragon location. Note: This bug does not appear to be present in the Anniversary Edition.<sup>[*verification needed — how is this affected by the [Paarthurnax](Skyrim_Paarthurnax_(quest).md) quest?*]</sup>
- [![On PC](https://images.uesp.net/d/d7/Computer.svg)](https://www.wikipedia.org/wiki/PC_game) **Workaround** - Basically, you must *not* give the dragon's bone and scale to Esbern; use console commands instead. There are three contexts to consider, each with its own solution: the first one is before returning to Esbern, the second one is before turning-in the dragon's scale and bone asked by Esbern, and the third one is after getting the potion (after giving the dragon's scale and bone). - **Before returning to Esbern** - You killed the dragon and got a new journal entry stating "Return to Esbern". Use the console to add the perk : `player.addspell 000F5FFA`. From then on, you won't be asked to retrieve a dragon's scale and bones and thus won't receive the resulting potion (it seems that one condition for triggering the quest is set by detecting that you don't have the perk yet).
- **Before turning-in a dragon's scale and bone (recommended)** - You've returned to Esbern and told him that the dragon is dead, which triggered a new quest requiring a dragon's bone and scale. In the console, type:
```
player.addspell 000F5FFA
Set Objective Completed Free Form Sky Haven Temple D 10 1
```
- **After giving bone and scale to Esbern** - The quest has already been started and it's supposed to be completed, but the journal entry is still there : you've given the dragon's bone and scale and thus received the potion, however without any effect after you drank it since it has a bug (no perk imbued). You must first reset the quest so as to start it over again, then add the perk to your powers, and finally clear the entry from your journal with the quest set as "completed". In the console, type:
```
Reset Quest Free Form Sky Haven Temple D
Set Stage Free Form Sky Haven Temple D 10
player.addspell 000F5FFA
Set Objective Completed Free Form Sky Haven Temple D 10 1
```
- **How to fix/finish this quest?** - Set quest as "completed". In the console, type:
```
Set Stage Free Form Sky Haven Temple D 100

```
- You can get Esbern's Potion quest line without recruiting any Blades. However, it will not be titled "Dragon Research" and is located in Miscellaneous Quests. After completing Alduin's Wall (also may happen before you even visit Esbern), killing a dragon at a defined radiant location (such as a word wall) will trigger the objective "Return to Esbern". Speaking to Esbern then triggers "Give a Dragon Scale and a Dragon Bone to Esbern". When you give them to him, he will give you Esbern's Potion. - ![PC Only](https://images.uesp.net/d/d7/Computer.svg)
The [Unofficial Skyrim Patch](https://en.uesp.net/wiki/Skyrim:Mod_Unofficial_Skyrim_Patch), version 1.2.5, fixes this bug.

## Quest Stages
| Dragon Research (Freeform Sky Haven Temple D) | | |
| --- | --- | --- |
| Stage | Finishes Quest | Journal Entry |
| 10 | | *Objective 10:* Bring a Dragon Scale and a Dragon Bone to Esbern |

- The following empty quest stages were omitted from the table: 100.

Notes - Any text displayed in angle brackets (e.g., `<Alias=Location Hold>`) is dynamically set by the Radiant Quest system, and will be filled in with the appropriate word(s) when seen in game.
- Not all Journal Entries may appear in your journal; which entries appear and which entries do not depends on the manner in which the quest is done.
- Stages are not always in order of progress. This is usually the case with quests that have multiple possible outcomes or quests where certain tasks may be done in any order. Some stages may therefore repeat objectives seen in other stages.
- If an entry is marked as "Finishes Quest" it means the quest disappears from the Active Quest list, but you may still receive new entries for that quest.
- On the PC, it is possible to use the [console](Skyrim_Console.md) to advance through the quest by entering `setstage Freeform Sky Haven Temple D stage`, where `stage` is the number of the stage you wish to complete. It is not possible to un-complete (i.e. go back) quest stages, but it is possible to clear all stages of the quest using `resetquest Freeform Sky Haven Temple D`.

![](https://images.uesp.net/thumb/4/45/SR-achievement-Platinum_Trophy.png/32px-SR-achievement-Platinum_Trophy.png)