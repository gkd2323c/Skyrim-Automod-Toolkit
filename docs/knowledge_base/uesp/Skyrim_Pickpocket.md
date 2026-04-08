# Pickpocket

| --- |
| [![Pickpocket](https://images.uesp.net/0/09/SR-skill-Pickpocket.png)](https://en.uesp.net/wiki/File:SR-skill-Pickpocket.png) |
| Specialization: <br> [Stealth](Skyrim_Stealth.md) |

This article is about the skill. For the NPC added by Pets of Skyrim, see [Pickpocket (person)](Skyrim_Pickpocket_(person).md).

The **Pickpocket** skill allows you to steal items from a person. As perks are gained in this skill, you gain abilities that allow you to make pickpocketing attempts more likely to succeed, silently kill people with poisons, increase your maximum carrying capacity, and the ability to steal equipped items. The Pickpocket skill tree has a total of 8 perks, requiring a total of 12 perk points to fill.

In-game Description: *The stealthy art of picking an unsuspecting target's pockets. A skilled pickpocketer is less likely to be caught and is more likely to loot valuables.*

## Skill Perks
[![Pickpocket Perk Tree](https://images.uesp.net/6/68/SR-perktree-Pickpocket.jpg)](https://en.uesp.net/wiki/File:SR-perktree-Pickpocket.jpg) [![Light Fingers](https://images.uesp.net/thumb/a/a1/Yellow_pog.png/12px-Yellow_pog.png)](https://en.uesp.net/wiki/File:Yellow_pog.png) Light Fingers [![Night Thief](https://images.uesp.net/thumb/a/a1/Yellow_pog.png/12px-Yellow_pog.png)](https://en.uesp.net/wiki/File:Yellow_pog.png) Night Thief [![Cutpurse](https://images.uesp.net/thumb/a/a1/Yellow_pog.png/12px-Yellow_pog.png)](https://en.uesp.net/wiki/File:Yellow_pog.png) Cutpurse [![Keymaster](https://images.uesp.net/thumb/a/a1/Yellow_pog.png/12px-Yellow_pog.png)](https://en.uesp.net/wiki/File:Yellow_pog.png) Keymaster [![Misdirection](https://images.uesp.net/thumb/a/a1/Yellow_pog.png/12px-Yellow_pog.png)](https://en.uesp.net/wiki/File:Yellow_pog.png) Misdirection [![Perfect Touch](https://images.uesp.net/thumb/a/a1/Yellow_pog.png/12px-Yellow_pog.png)](https://en.uesp.net/wiki/File:Yellow_pog.png) Perfect Touch [![Extra Pockets](https://images.uesp.net/thumb/a/a1/Yellow_pog.png/12px-Yellow_pog.png)](https://en.uesp.net/wiki/File:Yellow_pog.png) Extra Pockets [![Poisoned](https://images.uesp.net/thumb/a/a1/Yellow_pog.png/12px-Yellow_pog.png)](https://en.uesp.net/wiki/File:Yellow_pog.png) Poisoned Pickpocket Perk Tree | Perk | Rank | Description | [ID](Skyrim_Form_ID.md) | Skill Req. | Perk Req. |
| --- | --- | --- | --- | --- | --- |
| *Light Fingers* | 1 | Pickpocketing bonus of 20%. Item weight and value reduce pickpocketing odds. | 00 0be124 | | |
| 2 | Pickpocketing bonus of 40%. Item weight and value reduce pickpocketing odds. | 00 018e6a | 20 Pickpocket | | |
| 3 | Pickpocketing bonus of 60%. Item weight and value reduce pickpocketing odds. | 00 018e6b | 40 Pickpocket | | |
| 4 | Pickpocketing bonus of 80%. Item weight and value reduce pickpocketing odds. | 00 018e6c | 60 Pickpocket | | |
| 5 | Pickpocketing bonus of 100%. Item weight and value reduce pickpocketing odds. | 00 018e6d | 80 Pickpocket | | |
| *Night Thief* | | +25% chance to pickpocket if the target is asleep. | 00 058202 | 30 Pickpocket | Light Fingers |
| *Cutpurse* | | Pickpocketing gold is 50% easier. | 00 058204 | 40 Pickpocket | Night Thief |
| *Keymaster* | | Pickpocketing keys almost always works. | 00 0d79a0 | 60 Pickpocket | Cutpurse |
| *Misdirection* | | Can pickpocket equipped weapons. | 00 058201 | 70 Pickpocket | Cutpurse |
| *Perfect Touch* | | Can pickpocket equipped items. | 00 058205 | 100 Pickpocket | Misdirection |
| *Extra Pockets* | | Carrying capacity is increased by 100. | 00 096590 | 50 Pickpocket | Night Thief |
| *Poisoned* | | Silently harm enemies by placing poisons in their pockets. | 00 105f28 | 40 Pickpocket | Night Thief |

## Skill Usage
If you are [sneaking](Skyrim_Sneak.md) when you approach a person, you will be given the option of viewing the person's inventory. Simply viewing an inventory is not considered to be a [crime](Skyrim_Crime.md).

Game Settings affecting Pickpocket:

| f Pick Pocket... | Value |
| --- | --- |
| Actor Skill Base | 20 |
| Actor Skill Mult | 1 |
| Target Skill Base | 20 |
| Target Skill Mult | -0.25 |
| Amount Mult | -0.1 |
| Weight Mult | -4 |
| Max Chance | 90 |
| Min Chance | 0 |
| Detected | 25 |

Base_chance_formula = ( Actor Skill Base + Player_skill ) × Actor Skill Mult + ( Target Skill Base + NPC_skill ) × Target Skill Mult - Detected

- **Base_chance** = 15 + Player_skill - ( NPC_skill / 4 )
- **Detected** = 25 (this penalty applies when the pickpocketer has been detected by the pickpocketee).
- **Light_Fingers** = 20 to 100 [20 × rank in the perk, with rank from 0-5]
- **Night_Thief** = 25
- **Cutpurse** = 50

Without the [Official Skyrim Patch](Skyrim_Patch.md):

- **[Effects_mult](https://en.uesp.net/wiki/Skyrim:Fortify_Pickpocket)** = Potion_mult × ( Boots_mult + Gloves_mult )
- **Stealing Gold or Single Item**: ( Base_chance - Gold_amount / 10 - 4 × Item_weight + Sneak_bonus ) × Effects_mult + Light_Fingers + Night_Thief + (Cutpurse if Gold) - Note that Gold has weight 0.

With the [Official Skyrim Patch](Skyrim_Patch.md):

- **[Effects_bonus](https://en.uesp.net/wiki/Skyrim:Fortify_Pickpocket)** = Potion__bonus + Boots__bonus + Gloves__bonus
- **Stealing Gold or Single Item**: Base_chance - Gold_amount / 10 - 4 × Item_weight + Sneak_bonus + Effects_bonus + Light_Fingers + Night_Thief + (Cutpurse if Gold) - Note that Gold has weight 0.

Applying maximum skill values for the PC, with the patch:

- **[Effects_bonus](https://en.uesp.net/wiki/Skyrim:Fortify_Pickpocket)** = Potion__bonus + Boots__bonus + Gloves__bonus
- **Base_chance** = 115 - ( NPC_skill / 4 ) = 90 to 111.25, depending on target.
- **Stealing Gold or Single Item**: Base_chance - Gold_amount / 10 - 4 × Item_weight + 25 + Effects_bonus + 100 + 25 + (50 if Gold) = 240 to 261.25 + (50 if Gold) + Effects_bonus - Gold_amount / 10 - 4 × Item_weight - Note that Gold has weight 0.

The maximum chance for success is 90%.

When stealing multiple items at once you can only guess the success rate, as only the chance for one item at a time is displayed and it is *easier* to steal more items with smaller weight.

The maximum amount of gold pickpocketable on an *awake* target (no Night Thief bonus) is 2,852 (1% chance on a 15 Pickpocket skill target, with 100 skill, 5 ranks of Light Fingers, and Cutpurse, but no effect bonuses). The most you can steal with the maximum chance (90%) of success is 1,962. If the target has 100 skill, these are 2,640 and 1,750, respectively. There also seems to be a set amount of gold (that the NPC spawns with; added gold for the purposes of stealing it back do not count) that you can pickpocket from someone: pickpocketing a bandit, for instance, shows he has no gold in his inventory, but upon killing him it is shown he had a small amount of it on him. It can also happen that you pickpocket the amount shown in the inventory screen, but when the NPC dies, they still had a small amount left on them. Increasing the Pickpocket skill, addition of perks, and using Fortify Pickpocket apparel and potions will not allow you to take this hidden amount.

In instances of stealing a single item, the weights are 58.8 (1%, target skill 15), 36.5 (90%, target skill 15), 53.5 (1%, target skill 100), and 31.2 (90%, target skill 100).

After investing in the *Poisoned* perk you can reverse-pickpocket poisons onto targets to damage them. Giving multiple poisons to a target will make them "take" the poisons until they are either all gone or the target dies. Remaining poisons will be left on the corpse and are retrievable.

If you fail, the target will detect you and you may receive a [bounty](Skyrim_Crime.md#Bounties), if you are detected by someone that reports crimes. Even if successful, there is also a chance that the target will [hire thugs](Skyrim_Hired_Thug.md) to kill you.

## Skill Increases

### Character Creation
The following [races](Skyrim_Races.md) have an initial skill bonus to Pickpocket:

- +5 bonus: [Argonian](Skyrim_Argonian.md), [Bosmer](Skyrim_Wood_Elf.md), [Khajiit](Skyrim_Khajiit.md)

### [Trainers](Skyrim_Trainers.md)
- [Silda the Unseen](https://en.uesp.net/wiki/Skyrim:Silda_the_Unseen) in [Windhelm](Skyrim_Windhelm.md) (Expert)
- [Vipir the Fleet](Skyrim_Vipir_the_Fleet.md) of the Thieves Guild (Master)

### [Skill Books](Skyrim_Skill_Books.md)
- *[Aevar Stone-Singer](https://en.uesp.net/wiki/Skyrim:Aevar_Stone-Singer)*
- *[Beggar](Skyrim_Beggar_(book).md)*
- *[Guide to Better Thieving](https://en.uesp.net/wiki/Skyrim:Guide_to_Better_Thieving)*
- *[Purloined Shadows](https://en.uesp.net/wiki/Skyrim:Purloined_Shadows)*
- *[Thief](Skyrim_Thief_(book).md)*

### [Free Skill Boosts](Skyrim_Free_Skill_Boosts.md)
- +1 Pickpocket reward (as well as +1 to all other stealth skills) from [Inge Six Fingers](Skyrim_Inge_Six_Fingers.md) ([Bards College](Skyrim_Bards_College.md)) for completing the quest [Finn's Lute](https://en.uesp.net/wiki/Skyrim:Finn%27s_Lute).
- +5 Pickpocket reward (as well as +5 to all other stealth skills) by selecting "The Path of Shadow" from the [Oghma Infinium](Skyrim_Oghma_Infinium.md) after completing the quest [Discerning the Transmundane](https://en.uesp.net/wiki/Skyrim:Discerning_the_Transmundane).

### Gaining Skill XP
- Pickpocket skill gains are based on the *value* of stolen items, while the difficulty is based on *weight*.
- Training Pickpocket must be planned carefully, as it levels *extremely* quickly, potentially advancing your character level too far at low levels.
- Easy ways of training your Pickpocket skill include: - Stealing jewelry and precious gems; high success rate (low weight), big skill gains (high value).
- Reverse pickpocketing: Reverse-pickpocket gold onto someone and steal it back. The bound NPCs found during the quest [With Friends Like These...](Skyrim_With_Friends_Like_These....md) will not report you for any crime for the duration of the quest and are thus excellent targets. This is a good method if your Pickpocket level is over 90. 1500 gold is a good amount to do this with if you have the Cutpurse perk. Store the rest of your gold somewhere before doing this.
- Pickpocketing [bandits](Skyrim_Bandit.md), [necromancers](Skyrim_Necromancer.md), and other hostile NPCs. Since they are already hostile to you, the only consequence for a failed pickpocket attempt is a fight with the NPC, and no chance to earn a bounty.
- During the quest [Blood on the Ice](Skyrim_Blood_on_the_Ice.md), once the player sells the [strange amulet](https://en.uesp.net/wiki/Skyrim:Necromancer_Amulet) to [Calixto Corrium](https://en.uesp.net/wiki/Skyrim:Calixto_Corrium), the amulet can be subsequently pickpocketed and resold to Calixto indefinitely, both skyrocketing the Pickpocket skill and amounting in large sums of money for the player (500 gold for each time the amulet is sold). - ![PC Only](https://images.uesp.net/d/d7/Computer.svg)
The [Unofficial Skyrim Patch](https://en.uesp.net/wiki/Skyrim:Mod_Unofficial_Skyrim_Patch) fixes this bug.
- Trainer pickpocketing: Pay a trainer to train a skill (normally, one other than Pickpocket), steal your gold back, pay again, and repeat for as long as you're able to "buy" new levels of training. This way, you can gain as many levels of the skill as you wish to learn from the trainer, and gain levels of Pickpocket with a net cost of 0 gold. With a high Pickpocket skill, you can train up to level 51 without Pickpocket perks, or to 76 with all of the perks. After this, the gold cost becomes too expensive to pickpocket back. This is an extremely efficient method of leveling Pickpocket to the low 50s; at 15 skill with 1 perk, you have a 51% chance of stealing back your training fee, which goes up to 71% when you reach level 20 and invest another perk, and you will gain several extra levels of pickpocket each time you steal back your fee. Be warned that at low levels this method can cause you to level up repeatedly, making combat more difficult. - ![PC Only](https://images.uesp.net/d/d7/Computer.svg)
The [Unofficial Skyrim Patch](https://en.uesp.net/wiki/Skyrim:Mod_Unofficial_Skyrim_Patch) fixes this bug.
- [Fishing jobs](https://en.uesp.net/wiki/Skyrim:The_Fishing_Job) are an excellent way of consistently leveling up pickpocketing. They target high-value, low-weight items, and immediately remove the item from your inventory.
- The *best* method of power leveling pickpocket by far is using Sibbi Black-Briar as a means of placing and stealing gold from his inventory. For this to work, you need to be arrested. Either punch a guard or otherwise acquire a low bounty. Choose to go to the Riften jail. There, pick the cell door and sneak kill all the jail guards. Approach Sibbi Black-Briar's cell in such a way that the action button to pickpocket him appears. This is easier while he is standing and difficult while he sits; nonetheless, it's possible to place small amounts of gold in his inventory and immediately take them back, which will yield vast amounts of XP. With the Thief and Lover stones, by placing 50 gold and slowly increasing the amount to 200, pickpocketing levels will reach 100 in mere minutes. Provided you were arrested before trying this, Sibbi Black-Briar will not report your crime and will not prevent you from repeatedly opening his inventory, thus making him the perfect target for this exploit. No official or unofficial patches have addressed the issue, active in both versions of the game (LE and SE).

## Achievements
One [achievement](Skyrim_Achievements.md) is related to Pickpocket:

- [![SR-achievement-Thief.png](https://images.uesp.net/thumb/7/73/SR-achievement-Thief.png/30px-SR-achievement-Thief.png)](https://en.uesp.net/wiki/File:SR-achievement-Thief.png) **[Thief](Skyrim_Thief_(achievement).md)** (30 points/Silver) — Pick 50 [locks](Skyrim_Lockpicking.md) and 50 pockets

## Notes
- There is a maximum percentage chance to steal displayed in game of 90%. There is no way to raise this number, either through Fortify Pickpocket potions or enchanted apparel; the chance to successfully take something is always 90% and the chance to fail is always 10%.
- The *Misdirection* and *Perfect Touch* perks will only work if you are attempting to pickpocket while not detected by your target. It is sometimes possible to steal equipped items while still being "detected" by a different NPC.
- After unsuccessfully attempting to pickpocket an NPC, the NPC cannot be pickpocketed again for 2 days. The NPC will not reset if the player waits two days in the same room. This can also be reset if your unsuccessful attempt causes you to be approached by a guard and you are able to make them go away quietly ([Bribe,](Skyrim_Speech.md#Bribe) [announcing your "status",](Skyrim_Thane.md#Benefits_of_Being_a_Thane) or [paying them as "part of the Guild".](Skyrim_Thieves_Guild_(faction).md#Advantages)) A third solution is available to master [Illusionists](Skyrim_Illusion.md); casting [Harmony](Skyrim_Harmony.md) will cause all affected targets to "forget" if they have been pickpocketed recently. This does not work with other [Pacify](Skyrim_Pacify_(effect).md) spells. While repeatedly pickpocketing one of the torture victims in the Dawnstar Sanctuary in order to gain skill levels, if one is caught, they only have to exit the sanctuary and reenter before being allowed to pickpocket the same victim again.
- XP is only granted when pickpocketing items that are marked as stolen and you have not pickpocketed before.
- The Cutpurse perk says "Pickpocketing gold is 50% easier". This can be misleading, as the bonus you gain can be much higher than half of your "chance to steal". What it actually means is that Cutpurse adds 50 to your "chance to steal", although the number will still max out at 90%. At Pickpocketing level 100, trying to steal 1250 gold from an NPC trainer increases from 6% to 56% with the Cutpurse perk. - Note that this does not always mean that your chance to steal any amount of gold will be at least 50%, because your chance to steal before the perk is applied can be negative (although this will still be displayed as a 0% chance).
- Reverse pickpocketing a poison using the *Poisoned* perk does not count as a crime, even if the magical effect of the poison (e.g. "damage health") would otherwise be considered a criminal act if applied any other way. This makes it entirely possible to kill or weaken innocent enemies, right in front of everyone, without incurring a bounty.
- Perfect Touch does not work on NPCs who wear unobtainable clothing or who are marked as essential.
- Using a [Paralysis](Skyrim_Paralysis.md) effect (spell or reverse pickpocketed paralysis poison) on your target and then pickpocketing them as soon as the effect starts to wear off allows you to take any item without being caught, no matter the chance of success. - Using [Ice Form](Skyrim_Ice_Form.md) shout achieves the same effect by using the shout and then pickpocketing when they are about to defrost: despite the chance, it always works.
- Pickpocketing in this way never grants any skill XP, even if the displayed chance is above 0%.
- Though Morrowind/Oblivion have similar mechanics that work through stamina and paralysis - in Skyrim draining an NPC's stamina cannot cause a ragdoll effect and thus it doesn't aid pickpocketing.
- When [Creation Club](Skyrim_Creation_Club.md)'s [Survival Mode](Skyrim_Survival_Mode.md) is active, the Extra Pockets perk only gives an additional 50 carry weight. In addition, higher [Cold](Skyrim_Cold.md) levels will reduce your pickpocketing odds of success. A Cold level of Warm (less than 50) will make pickpocketing 10% easier.
- The posture of the NPC can increase or decrease the chance of successfully picking their pockets. I.e., a Hunter seated and has a Bear Pelt in his inventory, with an 89% chance of it being taken without being detected. When he stands up, examining his inventory again now shows the Bear Pelt with a 90% chance of successfully being pickpocketed.<sup>[*verification needed — see [talk page](https://en.uesp.net/wiki/Skyrim:talk_Pickpocket)*]</sup>
- The Pickpocket skill can be abused to obtain virtually free training from any [Trainer](Skyrim_Trainers.md) in the game. Simply take one level of training and then steal the gold back for a "free" level of training. Note that this will increase the Pickpocket skill extremely quickly, causing the player to over-level and miss some levels of training. At higher levels and with the Cutpurse perk, 2-3 levels worth of gold can be stolen back at a time. Since Pickpocket is completely based on chance with little to no interaction between the player and target, it is advised to save before each attempt at pickpocketing.
- Version 2.0.9 of the [Unofficial Skyrim Patch](https://en.uesp.net/wiki/Skyrim:Mod_Unofficial_Skyrim_Patch) changes the description of each rank of the Light Fingers perk to "Pickpocketing is XX% easier. Item weight and value reduce pickpocketing odds." and changes the description of the Night Thief perk to "Pickpocketing is 25% easier when the target is asleep."

## Bugs
- After taking Rank 5 of the *Light Fingers* perk, instead of raising the stealing chance, this perk can instead drop it to zero when trying to steal large amounts of gold (around 1600-1700). For example, if you use a trainer to train Archery from 57 to 58, you can use Pickpocket to get your money back. When you have Rank 4 of the *Light Fingers* perk, the odds are about 62%, but if you take Rank 5, they suddenly drop to zero. - The [Official Skyrim Patch](Skyrim_Patch.md), version 1.1, fixes this bug.
- [Fortify Pickpocket](https://en.uesp.net/wiki/Skyrim:Fortify_Pickpocket) bonuses from apparel and potions only work to increase the chance of stealing gold successfully, while lowering the chance of taking anything with weight. - ![PC Only](https://images.uesp.net/d/d7/Computer.svg)
The [Unofficial Skyrim Patch](https://en.uesp.net/wiki/Skyrim:Mod_Unofficial_Skyrim_Patch), version 2.0.0, fixes this bug.
- On rare occasions, you may be unable to pickpocket any NPC in an area with no clear cause, instead receiving the message you normally see when trying to pickpocket someone who has already caught you. Waiting 48 hours in a different location seems to fix this issue.
- If you save before pickpocketing, and reload after you are caught, you may continue to hear people yelling at you for pickpocketing, even though they're perfectly friendly when you talk to them. This will continue until you leave the area.
- Sometimes when you are caught pickpocketing the target will attack you but the guards will not attempt to arrest you.
- When getting caught pickpocketing a guard, the 2 day cooldown may be applied to another nearby guard of the same hold, and will continue to be applied to the latter guard each subsequent time you are caught pickpocketing the former. This allows you to keep pickpocketing the former guard with no penalty if caught as long as nearby guards are under a Pacify effect. <sup>**?**</sup>