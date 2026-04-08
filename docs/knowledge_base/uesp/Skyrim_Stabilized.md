# Stabilized

| --- |

| Quest Giver: | [Shadr](Skyrim_Shadr.md) |
| --- | --- |
| Location(s): | Riften |
| Reward: | Leveled gold or a leveled [Potion of Invisibility](https://en.uesp.net/wiki/Skyrim:Potion_of_Brief_Invisibility) |
| [Disposition](Skyrim_Disposition.md): | =1 ([Shadr](Skyrim_Shadr.md)) |
| ID: | Freeform Riften22 |
| Suggested Level: | Any |
| Difficulty: | Easy |

[![](https://images.uesp.net/thumb/4/42/SR-quest-Stabilized.jpg/200px-SR-quest-Stabilized.jpg)](https://en.uesp.net/wiki/File:SR-quest-Stabilized.jpg) [](https://en.uesp.net/wiki/File:SR-quest-Stabilized.jpg) Sapphire demands Shadr pay his debts
## Quick Walkthrough
1. Observe the conversation between [Sapphire](Skyrim_Sapphire_(person).md) and [Shadr](Skyrim_Shadr.md).
2. Speak with Shadr.
3. Speak with Sapphire and either [pay or persuade](Skyrim_Speech.md#Skill_Usage) her to clear the debt.
4. Return to Shadr.

## Detailed Walkthrough

### Feeling Blue
Upon your initial entry to [Riften](Skyrim_Riften.md), a conversation will take place between [Sapphire](Skyrim_Sapphire_(person).md), a member of the [Thieves Guild](Skyrim_Thieves_Guild_(faction).md), and [Shadr](Skyrim_Shadr.md). She is berating him for not paying his debt, to which he replies that he couldn't because his shipment was attacked. Sapphire alludes to the fact that she was behind it, but doesn't forgive his debt and demands that he pay it. She then walks off towards [The Bee and Barb](Skyrim_The_Bee_and_Barb.md). Shadr is usually on the bridge near the north entry gate (either standing or sitting on the bench), and when you talk to him he will explain his situation. You may then offer to assist him.

### Dealing with Sapphire
When you speak with Sapphire you have a number of options for rectifying the situation:

**If you are not a member of the Thieves Guild:** You are presented with the options of [persuading](Skyrim_Speech.md#Skill_Usage) Sapphire to clear the debt or paying it yourself. **If you are a member of the Thieves Guild:** You will be presented with the option to be cut in for a leveled amount of gold, or make her forget the debt. Both options are related to threatening to expose her scheme to [Brynjolf](Skyrim_Brynjolf.md). **If you are the Guildmaster:** Sapphire will apologize about the scam and claim that she was going to talk with [Delvin](Skyrim_Delvin_Mallory.md) about cutting the guild into the deal. You can either tell her to forget about the debt or split the take with her. If you accept the cut-in, you still need to return to Shadr to complete the quest.
### Reward
If you were successful in having Sapphire erase the debt, return to Shadr who is grateful and gives you a leveled [potion of invisibility](https://en.uesp.net/wiki/Skyrim:Potion_of_Brief_Invisibility). This will also increase Shadr's [disposition](Skyrim_Disposition.md) towards you, meaning that you may be able to take items from the [Riften Stables](Skyrim_Riften_Stables.md), including borrowing a [horse](Skyrim_Horses.md). If you take Sapphire's offer, whether as a Thieves Guild member or the guildmaster, your cut will be a leveled amount of gold.

| Levels | Payoff |
| --- | --- |
| 1–9 | 250 |
| 10–19 | 400 |
| 20–29 | 500 |
| 30–39 | 600 |
| 40+ | 750 |

## Bugs
- Sapphire has speech options, but none of them perform the proper checks to see if you could succeed. This makes persuading her always succeed by default, no matter what level your [Speech](Skyrim_Speech.md) skill is. - ![PC Only](https://images.uesp.net/d/d7/Computer.svg)
The [Unofficial Skyrim Patch](https://en.uesp.net/wiki/Skyrim:Mod_Unofficial_Skyrim_Patch), version 2.0.4, fixes this bug. ([details](https://afktrack.afkmods.com/index.php?a=issues&i=15507))
- In order to successfully intimidate Sapphire into dropping the debt, you need a Speech level which is unattainable by normal means, as the game setting value for intimidation of foolhardy NPCs is out of balance with the other settings. - ![PC Only](https://images.uesp.net/d/d7/Computer.svg)
The [Unofficial Skyrim Patch](https://en.uesp.net/wiki/Skyrim:Mod_Unofficial_Skyrim_Patch), version 2.1.2, fixes this bug. ([details](https://afktrack.afkmods.com/index.php?a=issues&i=19173))
- Completing this quest will allow you to ride the horses at [Riften Stables](Skyrim_Riften_Stables.md) for free, due to the horses being owned by the stables faction specifically. The problem is that horses cost 1,000 gold, making them way too valuable to let stablemasters let you ride them for free after completing a small favor. - ![PC Only](https://images.uesp.net/d/d7/Computer.svg)
The [Unofficial Skyrim Patch](https://en.uesp.net/wiki/Skyrim:Mod_Unofficial_Skyrim_Patch), version 2.1.2, addresses this issue. ([details](https://afktrack.afkmods.com/index.php?a=issues&i=19062)) The ownership of the horses was changed to just Hofgrir, rather than the faction, preventing this issue.
- Sapphire may not talk to you during this quest. - [![On PC](https://images.uesp.net/d/d7/Computer.svg)](https://www.wikipedia.org/wiki/PC_game) Opening up the console and using the command `resetquest freeformriften22` followed by `setstage freeformriften22 10` re-enables the quest trigger dialogue with Shadr. Don't simply reject helping him (as it triggers the bug) and just talk to Sapphire as usual and the quest will proceed as normal. If you do want to reject helping Shadr (and forfeit the quest reward), you will need to use `stopquest freeformriften22` to get Sapphire to leave the Bee and Barb and move to [The Ragged Flagon](Skyrim_The_Ragged_Flagon_-_Cistern.md).
- Telling Shadr you won't help him still pays you the reward and counts toward the Thane quest even though it shouldn't. - ![PC Only](https://images.uesp.net/d/d7/Computer.svg)
The [Unofficial Skyrim Patch](https://en.uesp.net/wiki/Skyrim:Mod_Unofficial_Skyrim_Patch), version 2.0.5, addresses this issue. A script variable to prevent that from happening was missing and out-of-date.
- The quest may not shut down properly if you refuse to help Shadr with his debt. - ![PC Only](https://images.uesp.net/d/d7/Computer.svg)
The [Unofficial Skyrim Legendary Edition Patch](https://en.uesp.net/wiki/Skyrim:Mod_Unofficial_Skyrim_Legendary_Edition_Patch), version 3.0.1, fixes this bug.

## Quest Stages
| Stabilized (Freeform Riften22) | | |
| --- | --- | --- |
| Stage | Finishes Quest | Journal Entry |
| 20 | | *Objective 10:* Speak to Sapphire about Shadr's debt |
| 30 | | *Objective 20:* Return to Shadr |

- The following empty quest stages were omitted from the table: 10, 200, 250.

Notes - Any text displayed in angle brackets (e.g., `<Alias=Location Hold>`) is dynamically set by the Radiant Quest system, and will be filled in with the appropriate word(s) when seen in game.
- Not all Journal Entries may appear in your journal; which entries appear and which entries do not depends on the manner in which the quest is done.
- Stages are not always in order of progress. This is usually the case with quests that have multiple possible outcomes or quests where certain tasks may be done in any order. Some stages may therefore repeat objectives seen in other stages.
- If an entry is marked as "Finishes Quest" it means the quest disappears from the Active Quest list, but you may still receive new entries for that quest.
- On the PC, it is possible to use the [console](Skyrim_Console.md) to advance through the quest by entering `setstage Freeform Riften22 stage`, where `stage` is the number of the stage you wish to complete. It is not possible to un-complete (i.e. go back) quest stages, but it is possible to clear all stages of the quest using `resetquest Freeform Riften22`.