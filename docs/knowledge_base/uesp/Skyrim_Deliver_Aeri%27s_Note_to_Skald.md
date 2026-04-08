# Delivery

- *For other quests with that name see [Delivery (Hillevi)](Skyrim_Delivery_(Hillevi).md) and [Delivery (Sorex)](Skyrim_Delivery_(Sorex).md).*

| **This article could benefit from an image**. <br> See [Help:Images](https://en.uesp.net/wiki/Help:Images) for information on how to upload images. Please remove this template from the page when finished. |
| --- |

| **Deliver an item to an associate.** |
| --- |

| Quest Giver: | [Radiant](#Radiant_Options) |
| --- | --- |
| Location(s): | [Radiant](#Radiant_Options) |
| Reward: | Leveled Gold |
| [Disposition](Skyrim_Disposition.md): | =1 (quest giver) |
| ID: | Favor001 |

## Radiant Options
This is a radiant quest which you can receive from each and every one of the following six people. The item you need to deliver and the recipient are uniquely determined by the quest giver.

| Region | Location | Quest Giver | Quest Item | Dialogue Trigger | Target |
| --- | --- | --- | --- | --- | --- |
| [Eastmarch](Skyrim_Eastmarch.md) | [Windhelm](Skyrim_Windhelm.md), [Candlehearth Hall](Skyrim_Candlehearth_Hall.md) | [Adonato Leotelli](Skyrim_Adonato_Leotelli.md) | [Adonato's Book](Skyrim_Adonato%27s_Book.md) | "What kind of writing do you do?" | [Solitude](Skyrim_Solitude.md), [Giraud Gemane](Skyrim_Giraud_Gemane.md) |
| [Eastmarch](Skyrim_Eastmarch.md) | [Darkwater Crossing](Skyrim_Darkwater_Crossing.md), [Goldenrock Mine](Skyrim_Goldenrock_Mine.md) | [Sondas Drenim](Skyrim_Sondas_Drenim.md) | [Sondas's Note](Skyrim_Sondas%27s_Note.md) | "Have you been working in the mines long?" | [Windhelm](Skyrim_Windhelm.md), [Quintus Navale](Skyrim_Quintus_Navale.md) |
| [Falkreath Hold](Skyrim_Falkreath_Hold.md) | [Falkreath](Skyrim_Falkreath.md), [Dengeir's House](Skyrim_Dengeir%27s_House.md) | [Thadgeir](Skyrim_Thadgeir.md) | [Berit's Ashes](Skyrim_Berit%27s_Ashes.md) | "You said something about a burial?" | [Falkreath](Skyrim_Falkreath.md), [Runil](Skyrim_Runil.md) |
| [Hjaalmarch](Skyrim_Hjaalmarch.md) | [Morthal](Skyrim_Morthal.md), [Highmoon Hall](Skyrim_Highmoon_Hall.md) | [Idgrod the Younger](Skyrim_Idgrod_the_Younger.md) | [Idgrod's Note](Skyrim_Idgrod%27s_Note.md) | "What's wrong with Joric?" | [Whiterun](Skyrim_Whiterun.md), [Danica Pure-Spring](Skyrim_Danica_Pure-Spring.md) |
| [The Pale](Skyrim_The_Pale.md) | [Anga's Mill](Skyrim_Anga%27s_Mill.md), [Aeri's House](Skyrim_Aeri%27s_House.md) | [Aeri](Skyrim_Aeri.md) | [Aeri's Note](Skyrim_Aeri%27s_Note.md) | ""One of the Jarl's men"?" | [Dawnstar](Skyrim_Dawnstar.md), [Skald](Skyrim_Skald.md) |
| [The Reach](Skyrim_The_Reach.md) | [Markarth](Skyrim_Markarth.md), [Markarth Stables](Skyrim_Markarth_Stables.md) | [Banning](Skyrim_Banning.md) | [Spiced Beef](Skyrim_Spiced_Beef.md) | "How long have you been training dogs?" | [Markarth](Skyrim_Markarth.md), [Voada](Skyrim_Voada.md) |

## Quick Walkthrough
1. Talk to any of the six quest givers to start the quest.
2. Accept the quest to be given an item to deliver.
3. Deliver the item to the target and receive your reward.

## Detailed Walkthrough
This quest begins once you have spoken to one of the quest givers listed above. These six people all have something that needs to be delivered but they haven't found the time to do it themselves. Asking how you can help will end with them giving you a unique item or note and telling you to deliver it to a correspondent of theirs (as listed in the Target column). Once you have completed the delivery, the recipient will thank you and reward you with a leveled amount of gold to end the quest.

### Reward
| Levels | Reward |
| --- | --- |
| 1–9 | 250 |
| 10–19 | 400 |
| 20–29 | 500 |
| 30–39 | 600 |
| 40+ | 750 |

## Notes
- Only one radiant quest of this type can be assigned at any given time. You must clear the radiant quest from your miscellaneous quests in order to be eligible to receive another of the same type.
- Because this is a favor quest which affects the quest giver's disposition, it will count towards the "Help the People" part of the [thane](Skyrim_Thane.md) quest for the quest giver's hold.
- Aeri will only give this quest if Skald is Jarl of the Pale.
- Idgrod will only give this quest if she hasn't been exiled to the [Blue Palace](Skyrim_Blue_Palace.md).
- Although the quest data suggests that Giraud/Quintus should have a larger reward, since the related dialogue script fields are named Favor Reward Gold Large, the script properties are both filled with the same value as all the others: Favor Reward Gold Small.

## Bugs
- It is possible to get a quest objective in your journal different from the one you were given by the NPC (e.g., Sondas gives you his note, but your journal guides you to deliver Adonato's book). As a result, you will be unable to resolve either quest, and you will therefore not be able to get any more delivery quests. The only way to resolve this on non-PC versions is to restore from a previous save. <sup>**?**</sup> - [![On PC](https://images.uesp.net/d/d7/Computer.svg)](https://www.wikipedia.org/wiki/PC_game) Alternatively, you can open the console and enter `setstage favor001 20`, which will complete the quest (although you will not get the reward). The NPC from whom you would have gotten the incorrectly-journaled quest will never give you his/her quest (as you just completed it). You *can* go back to the NPC from whom you got the incorrectly-journaled quest and get his/her quest again; note that you will receive another of his/her quest items, so you may need to use the console command `player.removeitem xxxx 1` to remove it from your inventory.

- You may be unable to get Adonato's or Aeri's delivery quests even though you do not have any other delivery quests active. However, their delivery quests may become available later. It is possible that additional, unknown conditions interfere with Adonato's and Aeri's delivery quests, and that these conflicts can be cleared by completing other quests.

## Quest Stages
| Delivery (Favor001) | | |
| --- | --- | --- |
| Stage | Finishes Quest | Journal Entry |
| 10 | | *Objective 10:* Deliver <Alias=Quest Item> to <Alias.Short Name=Target> |
| 20 | Finishes quest <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) | |

- The following empty quest stages were omitted from the table: 0, 200.

Notes - Any text displayed in angle brackets (e.g., `<Alias=Location Hold>`) is dynamically set by the Radiant Quest system, and will be filled in with the appropriate word(s) when seen in game.
- Not all Journal Entries may appear in your journal; which entries appear and which entries do not depends on the manner in which the quest is done.
- Stages are not always in order of progress. This is usually the case with quests that have multiple possible outcomes or quests where certain tasks may be done in any order. Some stages may therefore repeat objectives seen in other stages.
- If an entry is marked as "Finishes Quest" it means the quest disappears from the Active Quest list, but you may still receive new entries for that quest.
- On the PC, it is possible to use the [console](Skyrim_Console.md) to advance through the quest by entering `setstage Favor001 stage`, where `stage` is the number of the stage you wish to complete. It is not possible to un-complete (i.e. go back) quest stages, but it is possible to clear all stages of the quest using `resetquest Favor001`.

![](https://images.uesp.net/thumb/4/45/SR-achievement-Platinum_Trophy.png/32px-SR-achievement-Platinum_Trophy.png)
*This [Skyrim](Skyrim_Skyrim.md) -related article is a [stub](https://en.uesp.net/wiki/UESPWiki:Stub). You can help by [expanding it](https://en.uesp.net/w/index.php?title=Skyrim:Delivery&action=edit).*