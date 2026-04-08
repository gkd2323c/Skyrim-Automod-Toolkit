# Bounty Collector

| --- | --- | --- | --- |
| Race | [Nord](Skyrim_Nord.md) | Gender | Male |
| Level | Radiant (6-28) | Class | [Bandit](Skyrim_Bandit_(class).md) |
| [Ref ID](Skyrim_NPCs.md#Console_IDs) | N/A | [Base ID](Skyrim_NPCs.md#Console_IDs) | 00 0F812A |
| Other Information | | | |
| [Health](Skyrim_Health.md) | Radiant (155-497) | | |
| [Magicka](Skyrim_Magicka.md) | Radiant (25-40) | | |
| [Stamina](Skyrim_Stamina.md) | Radiant (95-258) | | |
| [Morality](Skyrim_Morality.md) | No Crime | [Aggression](Skyrim_Aggression.md) | Very Aggressive |
| Voice Type | [Male Nord](https://en.uesp.net/wiki/Category:Skyrim-Voice-Male Nord) | | |
| [Faction(s)](Skyrim_Factions.md) | [WEBounty Hunter](https://en.uesp.net/wiki/Skyrim:WEBounty Hunter) | | |

[![](https://images.uesp.net/thumb/0/0a/SR-npc-Bounty_Collector.jpg/200px-SR-npc-Bounty_Collector.jpg)](https://en.uesp.net/wiki/File:SR-npc-Bounty_Collector.jpg) [](https://en.uesp.net/wiki/File:SR-npc-Bounty_Collector.jpg) Bounty Collector A **Bounty Collector** can be [randomly encountered](Skyrim_World_Interactions.md#Bounty_Collector) in the wilderness if you have accumulated a [bounty](Skyrim_Crime.md#Bounties) of more than 1000 gold in any [hold](Skyrim_Holds.md). Unlike city [guards](Skyrim_Guards.md), he will ignore the distinction between holds and will attempt to track you down regardless of which hold you are in. He will demand from you payment equal to 1.2× your current bounty. If you refuse, he will attack.

He wears a set of leveled [heavy armor](Skyrim_Heavy_Armor_(item).md) (up to [steel plate](https://en.uesp.net/wiki/Skyrim:Steel_Plate) in quality), including the boots, gauntlets, and helmet. He always carries at least one leveled [heavy shield](Skyrim_Armor.md#Shields_2) (up to [ebony](Skyrim_Ebony.md) in quality), a [dagger](https://en.uesp.net/wiki/Skyrim:Dagger) (up to [elven](Skyrim_Elven.md) in quality), and 50-250 gold, dependent on his level. He will also carry either a leveled [one-handed weapon](Skyrim_One-Handed_Weapons.md) or a leveled [two-handed weapon](Skyrim_Two-Handed_Weapons.md) (up to [ebony](Skyrim_Ebony.md) in quality).

## Dialogue
When he sees you in the wilderness, he will approach you and will tell you not to move:

*"Stop right there."* **What do you want?** *"You have quite the bounty on your head in [hold]. You pay me, and I see that your name is cleared."* **I don't have the gold.** *"Then you are worth more to me dead!"* **(Becomes hostile)** **Pay (Gold).** *"I will make sure this gets back to the Jarl. Minus my cut, of course. Consider your name cleared, for now."* If you speak to him after handing over the gold, he will tell you:

*"I have no more business with you."* *"People think they can run away from their crimes, but I will always catch up with them and make them pay."*
## Notes
- If you have the [Dragonborn](Skyrim_Dragonborn.md) add-on installed, the bounty collector, like other high-level NPCs that use the same template, may be wearing [Nordic carved armor](https://en.uesp.net/wiki/Skyrim:Nordic_Carved_Armor).

## Bugs
- Paying the bounty collector may fail to clear your bounty. - [![On PC](https://images.uesp.net/d/d7/Computer.svg)](https://www.wikipedia.org/wiki/PC_game) Find a guard for the hold you have the bounty in, open the [console](Skyrim_Console.md), click on the guard, and use the command `paycrimegold 0 0` to pay off your bounty. Make sure you are close enough to the guard that his proper [Ref ID](Skyrim_Form_ID.md#Ref ID.2C_Base ID) appears when you click on him, or else the command won't work.
- Rather than approach you and demand payment, the bounty collector may simply attack you instead. - [![On PC](https://images.uesp.net/d/d7/Computer.svg)](https://www.wikipedia.org/wiki/PC_game) Open the console, click on the bounty collector (his Ref ID will appear, with 'ff' as the first two digits), then type `scaonactor` followed by <enter>. This will remove his aggression towards you and start his normal dialogue about clearing your bounty.
- The bounty collector may charge you 0 gold in Falkreath Hold due to a typo in the script. - The [Unofficial Skyrim Special Edition Patch](https://en.uesp.net/wiki/Skyrim:Mod_Unofficial_Skyrim_Special_Edition_Patch), version 4.1.5, fixes this bug.