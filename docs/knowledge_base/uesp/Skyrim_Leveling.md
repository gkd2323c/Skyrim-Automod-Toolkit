# Leveling

There are two types of **leveling** in Skyrim: character leveling and skill leveling.

Each time your character level increases, you are provided the opportunity to make key choices about your abilities. This means you may choose to increase either [Health](Skyrim_Health.md), [Magicka](Skyrim_Magicka.md) or [Stamina](Skyrim_Stamina.md) by 10 points, and you are also given one new perk point to invest in one of 18 different skills (listed below). Each time you increase any skill's level, you make progress towards gaining a character level. This increases the general effectiveness of that skill, while a minimum skill level is required for most perks to become obtainable.

## Gaining Levels
Leveling your character is not the same as it was in [Oblivion](https://en.uesp.net/wiki/Oblivion:Leveling) - instead, it is based on an experience system related to skills.

As you use a [skill](Skyrim_Skills.md), you automatically gain a small amount of experience in that skill (which we will call "Skill XP"), eventually causing that skill to level up. Skill level-ups can also be acquired instantly from [training](Skyrim_Trainers.md) or by reading [skill books](Skyrim_Skill_Books.md). Every time you level up a skill, you also gain experience toward a character level-up (which we will call "Character XP", or simply "XP"). Furthermore, increasing the levels of your skills is the *only* way you are able to increase your character XP. However, leveling up low-level skills offers only a low amount of character XP toward your next level, while leveling up high-level skills offers more. The required amount of character XP needed to gain a character level-up increases as your character level increases.

Unlike in [Morrowind](https://en.uesp.net/wiki/Morrowind:Level) and Oblivion, attribute bonuses gained at level-up have been simplified, eliminating the need to "budget" one's skillups in effort to achieve maximum attribute increase. Most content is still leveled (primarily enemy gear), and some players may choose their perks and attribute increases unwisely, so it is still possible to create a character too weak to keep up. However, if you have installed the [Dragonborn add-on](Skyrim_Dragonborn.md), you can expend [dragon](Skyrim_Dragon.md) souls to reset perks. See the [Leveling Decisions](#Leveling_Decisions) section below for details.

The amount of skill XP you receive from using a skill in a specific way is constant. However, as you increase in skill level, the amount of skill XP required for the *next* skill level up increases. This is why blocking a few attacks from an [ice wolf](Skyrim_Ice_Wolf.md) may level up your [Block](Skyrim_Block.md) skill at the beginning of the game when your skill level is low, but when your Block skill is higher later in the game, it will take a lot more attacks to level it up. In this instance, your Block skill would level up faster if you blocked an attack from a giant. Keep in mind that some skills are much easier to level up than others. For instance, you may quickly level the [Smithing](Skyrim_Smithing.md) skill to 100 by crafting nothing but jewelry; it will take a very long time, however, to level [One-handed](Skyrim_One-handed.md) to 100 solely by attacking [skeevers](Skyrim_Skeever.md) with a specific one-handed weapon. Further, successfully using your skill yields more skill XP than unsuccessfully using it. For example, successfully picking a lock gives you more [Lockpicking](Skyrim_Lockpicking.md) XP than does breaking your lockpick in the attempt.

Some skills will only increase when there is an active component associated with them:

- [Sneak](Skyrim_Sneak.md) will only increase if you are within range of and are avoiding detection by an entity that would otherwise be aware of your presence, or escaping from one that has detected you. You do not need to move for the skill to increase, though completing actions that are more difficult will increase the skill faster, such as moving and, more notably, completing sneak attacks.
- [Conjuration](Skyrim_Conjuration.md) derived from Raise Zombie or similar spells will only increase if the minion engages in combat, while Conjuring Bound weapons only garners skill XP if you are in combat.
- [Restoration](Skyrim_Restoration.md) will only increase if it is replenishing lost life (with a few exceptions) and will level up faster when in combat.
- [Alteration](Skyrim_Alteration.md) derived from [Detect Life](Skyrim_Detect_Life_(spell).md) will only increase if you are actually detecting life forms with the spell. The more life forms you detect, the faster your skill will go up.
- [Destruction](Skyrim_Destruction.md) from runes will only increase if the runes are triggered. Other Destruction spells require a valid target, either a creature or an NPC.
- [Pickpocketing](Skyrim_Pickpocket.md) increases proportionally to the total value of lifted goods, assuming you are not caught.
- [Lockpicking](Skyrim_Lockpicking.md) will gain a small increase for every broken pick, and a substantial increase that varies based on lock level versus skill and perk level for every successfully-picked lock. However, if you successfully pick a lock that you have picked before, there is no XP reward.
- [Smithing](Skyrim_Smithing.md), [Alchemy](Skyrim_Alchemy.md), and [Enchanting](Skyrim_Enchanting.md) give skill increases based on the results of the crafting.

Experience gain can be increased by the [Rested](Skyrim_Rested.md), [Well Rested](Skyrim_Well_Rested.md), [Lover's Comfort](Skyrim_Lover%27s_Comfort.md), and [Guardian Stones'](Skyrim_Guardian_Stones.md) bonuses. These bonuses stack multiplicatively. For example, with both the Thief Stone(20%) and Well Rested(10%), you will receive 1.20*1.10=1.32 times experience from performing valid stealth skill actions. With the Aetherial Crown you can have Well Rested(10%), Lover's Comfort(15%), and a Guardian Stone(20%) bonus active, providing a 1.10*1.15*1.20=1.518 times experience gain multiplier.

**Note:** Over-training will still grant you level ups even if the progress bar is stuck at 100% (for example: If you start training Illusion from level 1 to Illusion level 44 you will be level 6 once you choose to level up).

## Level and Skill XP Formulae
Level XP is the experience points put towards raising your character's level. Skill XP is the experience points put towards raising your level in a particular skill.

### Level XP
The formula for character leveling is as follows:

```
Character XP gained = Skill level acquired * f XPPer Skill Rank

```
Skyrim Game Setting variable: `f XPPer Skill Rank` (default =1)

Example: Training Alchemy from 20 to 21 gives 21 Character XP points

```
XP required to level up your character = (Current level + 3) * 25

```
Or if using the Skyrim Creation Kit Game Setting values:

```
(f XPLevel Up Base)+(Current Char. Level * f XPLevel Up Mult)

```
Where the default values for Skyrim vanilla (1.9.32.X) are f XPLevel Up Base = 75 and f XPLevel Up Mult = 25.

Example: 100 XP is required to advance from level 1 to level 2, and 1300 XP is required to advance from level 49 to 50. **This is consistent across all levels.** (70→71 follows the same formula as 3→4)

This formula can be extended to find the Character XP needed for multiple levels:

```
XP required to go from level 1 to level N = 12.5 * N2 + 62.5 * N - 75

```
Given a Character XP total, the corresponding Character Level is given by:

```
FLOOR(-2.5 + SQRT(8 * XP + 1225) / 10)

```

### Skill XP
The skill XP needed for the next skill level is almost proportional to the square of the *current* skill level:<sup>[*verification needed — see [talk page](https://en.uesp.net/wiki/Skyrim_talk:Leveling#Skill_XP)*]</sup>

```
Cost(level) = Skill Improve Mult * (level-1)1.95 + Skill Improve Offset, Cost(0) = 0

```
As a result, the *cumulative* skill experience needed to reach a skill level X from a starting skill level Y is:

```
Cumulative(level) = Cost(level) + Cumulative(level-1), Cumulative(0) = 0
Cumulative(level) = Skill Improve Mult * (level-1)1.95 + Skill Improve Offset + Cumulative(level-1), Cumulative(0) = 0
Cumulative(level) = level * Skill Improve Offset + Skill Improve Mult * (sum from n = 1 to n = level of [(level-1)1.95]
Cumulative XP from Y to X = Cumulative(X) - Cumulative(Y)

```
For example, if you want to level Lockpicking (Skill Improve Mult 0.25, Skill Improve Offset 300) from level 15 to 16:

```
0.25 * 151.95 + 300 = 349.1267420446517

```
Same, from 15 to 20:

```
Cumulative(15) = 4725.765429072633
Cumulative(20) = 6541.309853552898
Cumulative(20)-Cumulative(15) = 1815.5444244802648

```
Using a skill grants skill XP according to<sup>[*verification needed — additional verification needed*]</sup>:

```
Skill Use Mult * (base XP * skill specific multipliers) + Skill Use Offset

```
The Skill Improve Mult, Skill Improve Offset, Skill Use Mult, and Skill Use Offset variables can be found under Actor Values for each skill independently. The 1.95 Power variable can be found in the Game Settings variables under f Skill Use Curve and applies globally to all of the skills. Additionally, the base XP granted by specific actions is different for each skill and uses additional multipliers stored in the Game Settings variables. The XP granted by using a skill probably makes use of the console command [Adv Skill](Skyrim_Console.md#Targeted_Commands). This console command requires 2 additional arguments, [the skill](https://en.uesp.net/wiki/Skyrim_Mod:Actor_Value_Indices#Actor_Value_Codes) to which the granted XP should apply and the amount of given XP. The amount of given XP is then multiplied by the Skill Use Multiplier of the selected skill and the result is then added to the Skill Use Offset of the selected skill. For example, if the game wants to award 50 XP to the Lockpicking skill (Skill Use Mult 45 and Skill Use Offset 10), it might use this command:

```
player.Adv Skill Lockpicking 50
This results in: 45*(50)+10=2260 XP.

```
So, sticking with our example of Lockpicking, you would need to break 86 picks to level Lockpicking from 15 to 20: 1815.5444244802648/(45*(.25)+10) = 85 and change, meaning you'd need the 86th pick broken to level up. For comparison, you would need to *successfully* pick 19, 13, 8, 5, and 4 locks of each lock difficulty to do the same thing.

In addition to different skills using different values for both calculating experience needed per level and experience gained per use relative to some base, different skills work differently in terms of how leveling up the skill also speeds up the base. For example, all three crafting skills let you make more expensive things as you level, and gain more experience from more expensive things; by contrast, [Speech](Skyrim_Speech.md) always uses the *base* value of an item, so using better speech to sell an item for more money does *not* gain you more experience.

The Skill XP variables are given in the following table; the required XP from lvl 15 to 100 might not be 100% accurate (decimals): <sup>[*verification needed — this table needs to verified by additional people*]</sup>

[![](https://images.uesp.net/thumb/1/13/SR-graph-Skill_XP_per_Skill_Level.png/350px-SR-graph-Skill_XP_per_Skill_Level.png)](https://en.uesp.net/wiki/File:SR-graph-Skill_XP_per_Skill_Level.png) [](https://en.uesp.net/wiki/File:SR-graph-Skill_XP_per_Skill_Level.png) Graph of the Skill XP required to level the Skill to the next level as function of the current Skill level. Formula followed: Skill Improve Multi * Current Skill Level<sup>1.95</sup> + Skill Improve Offset. The standard skills include: Archery (Marksman), One-Handed, Alteration, Block, Conjuration, Destruction, Heavy Armor, Illusion, Light Armor, Restoration, Speechcraft and Two-Handed. [![](https://images.uesp.net/thumb/c/cc/SR-graph-Total_Skill_XP_per_Skill_Level.png/350px-SR-graph-Total_Skill_XP_per_Skill_Level.png)](https://en.uesp.net/wiki/File:SR-graph-Total_Skill_XP_per_Skill_Level.png) [](https://en.uesp.net/wiki/File:SR-graph-Total_Skill_XP_per_Skill_Level.png) Graph of the total Skill XP accumulated for the current level of the skill as function of the current Skill level. The standard skills include: Archery (Marksman), One-Handed, Alteration, Block, Conjuration, Destruction, Heavy Armor, Illusion, Light Armor, Restoration, Speechcraft and Two-Handed. | Skill | Skill Use Mult | Skill Use Offset | Skill Improve Mult | Skill Improve Offset | Total Skill XP needed for 15 -> 100 | Sources of XP/Notes |
| --- | --- | --- | --- | --- | --- | --- |
| [Alteration](Skyrim_Alteration.md) | 3 | 0 | 2 | 0 | 528804.0234 | - Base Magicka Cost of the Spell. <br> - Additional multipliers may apply. |
| [Conjuration](Skyrim_Conjuration.md) | 2.1 | 0 | 2 | 0 | 528804.0234 | - Base Magicka Cost of the Spell. <br> - Additional multipliers may apply. |
| [Destruction](Skyrim_Destruction.md) | 1.35 | 0 | 2 | 0 | 528804.0234 | - Base Magicka Cost of the Spell. <br> - Damage inflicted <sup>[†](#intnote_destruction)</sup> <br> - Additional multipliers may apply. |
| [Illusion](Skyrim_Illusion.md) | 4.6 | 0 | 2 | 0 | 528804.0234 | - Base Magicka Cost of the Spell. <br> - Additional multipliers may apply. |
| [Restoration](Skyrim_Restoration.md) | 2 | 0 | 2 | 0 | 528804.0234 | - 1 base XP damage healed by healing spells. <br> - 1 base XP per Magicka used on non-healing spells. <br> - Additional multipliers may apply. |
| [Enchanting](Skyrim_Enchanting.md) | 900 | 0 | 1 | 170 | 278852.0117 | - 1 base XP per item enchanted. <br> - 1 base XP per 400 enchantment gold value of items disenchanted. <br> - 0.05(Petty), 0.1(Lesser), 0.2(Common), 0.4(Greater), or 0.6(Grand) base XP for recharging a weapon. <br> - Additional multipliers may apply. |
| [One-Handed](Skyrim_One-handed.md) | 6.3 | 0 | 2 | 0 | 528804.0234 | - Base Weapon Damage <br> - Additional multipliers may apply. |
| [Two-Handed](Skyrim_Two-handed.md) | 5.95 | 0 | 2 | 0 | 528804.0234 | - Base Weapon Damage <br> - Additional multipliers may apply. |
| [Archery (Marksman)](Skyrim_Archery.md) | 9.3 | 0 | 2 | 0 | 528804.0234 | - Base Weapon Damage of the Bow <br> - Additional multipliers may apply. |
| [Block](Skyrim_Block.md) | 8.1 | 0 | 2 | 0 | 528804.0234 | - 1 base XP per raw damage blocked. <br> - 5 base XP for a shield bash. <br> - Additional multipliers may apply. |
| [Smithing](Skyrim_Smithing.md) | 1 | 0 | 0.25 | 300 | 91600.5029 | - item quantity * (25 + (3 * individual item value<sup>0.65</sup>)) base XP for constructing an item. <br> - 3.8 × Δ *item value*<sup>0.5</sup> × Δ *item quality*<sup>0.5</sup> base XP for improving an item. <br> - Additional multipliers may apply. <br> - Note that in the original Skyrim.esm the skill use multiplier is 160. |
| [Heavy Armor](Skyrim_Heavy_Armor.md) | 3.8 | 0 | 2 | 0 | 528804.0234 | - 1 base XP per raw damage received. <br> - Additional multipliers may apply. |
| [Light Armor](Skyrim_Light_Armor.md) | 4 | 0 | 2 | 0 | 528804.0234 | - 1 base XP per raw damage received. <br> - Additional multipliers may apply. |
| [Pickpocket](Skyrim_Pickpocket.md) | 8.1 | 0 | 0.25 | 250 | 87350.5029 | - 1 base XP per gold value stolen. <br> - Additional multipliers may apply. |
| [Lockpicking](Skyrim_Lockpicking.md) | 45 | 10 | 0.25 | 300 | 91600.5029 | - 0.25 base XP for a broken pick. <br> - 2, 3, 5, 8, or 13 base XP for successfully picking a lock. <br> - Additional multipliers may apply. |
| [Sneak](Skyrim_Sneak.md) | 11.25 | 0 | 0.5 | 120 | 142401.0059 | - 2.5 base XP for becoming hidden within ~45 feet. <br> - 0.625 base XP per second hidden within ~45 feet. <br> - 30 base XP for a melee sneak attack. <br> - 2.5 base XP for a ranged sneak attack. <br> - Additional multipliers may apply. |
| [Alchemy](Skyrim_Alchemy.md) | 0.75 | 0 | 1.6 | 65 | 428568.2188 | - 1 base XP per gold value created. <br> - 1 additional base XP for each successfully created potion. |
| [Speech](Skyrim_Speech.md) | 0.36 | 0 | 2 | 0 | 528804.0234 | - 1 base XP per gold used in transactions. <br> - 75 * Speech level base XP for passing Speech checks. <br> - Additional multipliers may apply. |

[†](#note_destruction) Destruction XP gain is reduced at difficulty settings higher than Adept, but not increased at lower ones."Base Magicka" refers to the base cost of the spell. "Raw damage" refers to the damage before armor is taken into account.

## Leveling Decisions
You are notified when you are eligible to level up. When you accept the new level—which updates to the highest level you have currently earned—your character is fully healed, regaining any [Health](Skyrim_Health.md), [Magicka](Skyrim_Magicka.md), and [Stamina](Skyrim_Stamina.md) that was depleted. You can choose whether to do this immediately, or whether to use the level-up strategically to take maximum advantage of the healing bonuses. In addition, in the standard game, you can level up anywhere; unlike in Oblivion or Morrowind, [sleeping](Skyrim_Sleeping.md) is not necessary. However, with [Survival Mode](Skyrim_Survival_Mode.md) enabled, sleep is once more required. Note that when you do choose to level, you will be raised to the highest level earned through skill progression; so if you have progressed four levels since you last chose to level up, you will gain all four of those levels the next time you open the skills tab.

- It is possible, though quite tricky to raise one level at a time when you have more levels "banked". Immediately (as in almost simultaneously), once you confirm your level up attribute bonus, you need to press the exit button (B on Xbox, O on PS). It may take a few tries each time you try it as the window of opportunity is very very small. However, you won't be able to add any perks until you have cleared all "banked" levels.

When leveling up, you are able to make two permanent character changes:

- One [attribute](Skyrim_Attributes.md) ([Health](Skyrim_Health.md), [Magicka](Skyrim_Magicka.md), [Stamina](Skyrim_Stamina.md)) can be increased by 10 points. This choice is prompted for upon going to the perk and skill screen and leveling; if you gained 4 levels you will be prompted to make 4 choices in succession.
- One [perk point](Skyrim_Skills.md#Perks) will be awarded per character level gained. Perk points do NOT need to be used when leveling and may be saved for a later time. This allows you to either utilize perk choices for immediate benefit in skills for which you meet the minimum requirements, or to upgrade other paths once those requirements are met.

It should be emphasized that the attribute choice is permanent, barring use of the developer console on the PC version of the game. Perks can be reset by reaching 100 in the appropriate skill and making it [legendary](Skyrim_Skills.md#Legendary_Skills). Since skill advancement contributes to the earning of perks as general choices, it is possible to utilize a gain in unrelated skills to progress through other perk paths should that be desirable.

- With the [Dragonborn](Skyrim_Dragonborn.md) expansion installed, it is possible to reset your perks after you have completed the main Dragonborn questline. Doing so will consume one dragon soul, and will allow you to clear all perks from one skill tree, refunding the perk points back to you. This process can be repeated as many times as desired, provided you have the dragon souls.

##### Navigating Skills / Adding a Perk (PC only)
Enter the skill screen by pressing Tab and selecting "Skills" (2x Up-Arrow or W-key), or alternately by hitting the ?/-key. Once on the screen, you can navigate through skills either by using the movement keys (A, D, W, S) or clicking with your mouse.

Make sure the skill to which you would like to add a perk is centered on the screen and the constellation is visible. This brings up the perk tree for that skill. Navigate to the perk you wish to add. To add the perk, click directly on the star below the text. This will bring up a pop-up screen that you can answer with "Yes" (Enter) to add the perk or "No" (Tab) to cancel.

## Maximum Level
At higher levels, leveling up happens much more slowly due to exponential formula (detailed above in the [Level and Skill XP Formulae](Skyrim_Leveling.md#Level_and_Skill_XP_Formulae)). Prior to [Patch 1.9](Skyrim_Patch.md#Version_1.9) the maximum level was 81, with 88,085 XP (1,085 XP extra towards level 82), since there was no way to gain any more experience once all 18 skills were mastered.

With Patch 1.9, individual skills can be made "legendary", denoting them with an Imperial symbol. This will reset the skill to 15, and perk points used for that skill may be redistributed. Gaining levels in that skill will affect leveling again, thus effectively removing the level cap of 81. There is no restriction on the number of times that skills can be made legendary. This change makes it theoretically possible to obtain every single perk in the game. You can level up even after reaching level 252, so you can continue to increase magicka, health or stamina, though you will have nothing left to spend the resulting perk points on.

Training one individual skill all the way from 15 to 100, achieving a complete skill mastering cycle (a cycle not influenced by [initial racial bonuses](Skyrim_Races.md)), yields 4,930 XP. This amount of XP is enough to level from level 1 to 17, or from 194 to 195. Leveling up to 252 grants perk points for all 251 perks, which in total requires 809,475 XP. To actually unlock all perks, every skill needs to be 100, requiring an additional 3,320 XP, corresponding to 165 skill mastering cycles. The fastest approach to such a huge task would be to find the easiest skill to raise and exclusively focus on it.

## Effects of Leveling
Various aspects of the game are leveled. This means that as your character increases in level, some enemies become more challenging, but also the quality of the items you find becomes better. However, the leveling system in Skyrim has been altered from that used in [Oblivion](https://en.uesp.net/wiki/Oblivion:Oblivion), in response to criticisms of Oblivion's leveling system.

Different locations in Skyrim have different inherent difficulties. In other words, some dungeons are designed to be too difficult for low-level characters to enter. More challenging dungeons are generally located at higher elevations, meaning that early in the game, players may want to avoid mountainous regions. However, more difficult dungeons contain better rewards. In addition, some high-quality items can be randomly found even early in the game.

In addition, all leveled enemies are generated more like leveled creatures in [Fallout](https://www.wikipedia.org/wiki/Fallout_(series)). For example, Bandit NPCs are always a fixed level for their name (Bandits are level 1, Bandit Thugs are level 9, Bandit Highwaymen are level 14, etc). The player's level affects the range of possible bandit types generated within a bandit dungeon, and probably the frequency, but does not seem to affect the resulting stats except in a few rare cases. Lower variant bandits remain reasonably common even when more dangerous bandits are available.

Enemy types also seem to reach a plateau where they stop getting stronger. The strongest bandits (non-boss) are mid-20s. The strongest generic vampire is 54, and guards seem to stop scaling at 50. This implies that the difficulty of many areas will not increase beyond certain levels, except perhaps in frequency of difficult encounters. In other words, dungeons have a level range, where if you do not meet the level requirement, you will face the lowest range of the dungeon. For instance, if a dungeon is ranged from level 15 to 25, and you are level 10, you will face creatures in the dungeon scaled at level 15. However, at the other end of the scale, most dungeons become relatively trivial after you've played the game for a while and have leveled up enough. The highest random leveled enemies in the original game are [Ancient Dragons](Skyrim_Ancient_Dragon.md) and [Dragon Priests](Skyrim_Dragon_Priest.md), but even these enemies were only meant to fight players around level 50.

## Leveling Exploits

### Essential Combat
All NPCs tagged as [Essential](https://en.uesp.net/wiki/Category:Skyrim-Essential_NPCs) can be used as effective training dummies for combat skills. The best ones to use are those that will not report you for assault, such as Hadvar or Ralof during Unbound, or any of the Greybeards. However, even these examples may sometimes report you, though giving you zero bounty crimes that cannot be cleared, but causing problems with guards and crime-fighting citizens. Committing a crime with a bounty attached and paying it off should clear any zero bounty crimes.

### Infinite Leveling in Helgen
There are multiple opportunities to infinitely level some of your skills during the opening quest, but it is quite easy to break the game by over-leveling. The game-breaking comes because the enemies you face will be far too hard to kill, and can kill you very easily. If you decide to use one of these methods and have a high starting level make sure at least one of your combat skills is leveled appropriately so you can cope in the much more dangerous Skyrim you have created. It is also recommended that you focus your attribute bonuses on health in order to better survive while you find some suitable armor. None of the methods here are unique, but the opportunity at such an early stage is worthy of mention.

The first opportunity to level is during your escape inside the burned-out tavern. In the corner facing the area where Alduin lands in front of Hadvar and Haming you can crouch and hide to level up your Sneak skill. This corner can be tricky to use as you will randomly be spotted by Alduin, and this method is rather slow. This is also the first and only way to level any skill before entering the keep.

Once inside the keep and hands are untied you can use magic. Your range of spells is rather limited and at this point you can only use flames to level at a rate quicker than painfully slowly, but your companion will not move until you arm yourself with a weapon, so you can take as long as you want and burn him to level your Destruction. You can also wait until after the torture room where you can pick up some clothing with magic bonuses and attack your companion at every chance you get.

The next opportunities depend on who you side with (see below). The last opportunity during the quest comes with the bear at the end of the escape tunnel. At this point you are given a bow and some arrows. You can shoot your companion with these and any other arrows you have collected to get some free levels in Archery, but you cannot recover the arrows in order to continually boost your levels. However, you can level your One-handed, Two-handed, Destruction, and Sneak (in conjunction with One-handed) infinitely by attacking your companion (Sneak is leveled by crouching and attacking with either a One-handed weapon or bow). As long as you don't attract the attention of the bear and subsequently kill it your companion will remain by the cart. A final chance comes with the bear. As long as you stay within range without it detecting you your Sneak skill will rise.

Siding with Hadvar

The unique opportunity comes with the friendly Torturer, as long as he survives the fight in the room. You will need to use one of the iron daggers found here as the Torturer is not essential and can die, however he will not turn on you unless you make three quick attacks on him. Equip one of the daggers and then start sneak-attacking him with normal attacks (not power attacks). This levels up both Sneak and One-handed and can be done to level 100 at this point as long as you take no perks affecting damage by the dagger.

You can start to level Pickpocketing here too. Find the few coins in the room and then reverse-pickpocket the coins onto the Torturer. Take the coins back and then place them in his inventory again, and repeat. While this can be done with any other item it is very difficult. You can easily gain a few levels but more than that will take a long time as experience is based on the value of the item(s) moved.

Siding with Ralof

The unique opportunity comes in the kitchen before the Torturer. You must kill the heavily armored Imperial soldier and loot the key from her body before Ralof gets it (you may wish to make a save before entering, in case he gets it). If you obtain the key Ralof will move to the locked door and wait for you to open it. Until you open it you are free to use him to train your Destruction, One-handed, and Sneak skills.

### Trainer Pickpocketing
Train using a [skill trainer](Skyrim_Trainers.md) and then pickpocket your gold back.

Without any pickpocket perks, this only works up to skill level 30 or so. The highest you can go with this "exploit" is level 76. Even with a full complement of Pickpocket perks (Light Fingers 5/5: +100% chance to pickpocket, Night Thief: +25% chance to pickpocket if NPC is asleep, Cut Purse: +50% chance to steal gold), 100 Pickpocket, and Thieves Guild armor (+15% pickpocket), and the NPC sleeping, it is usually impossible (0% chance) to pickpocket back the nearly 4k in gold it costs to train skill level 77. There are a couple of ways to get around this limitation:

- You can use the [Unrelenting Force](Skyrim_Unrelenting_Force.md) shout to knock down the trainer, and then pickpocket them while they are getting back up (even though the menu still displays 0% chance, you cannot fail). However, you should save your game first as sometimes (though not often) this method will cause NPCs to attack you.
- If you have the [Poisoned](Skyrim_Poisoned.md) perk, you can place a paralysis poison in the NPC's inventory and then steal the gold, and they won't attack you.

Keep in mind that only 5 skill points may be trained at a trainer per level across all skills. At higher levels, 5 skill increases will earn only a small portion of the experience needed to level. The remaining skill increases you need to level must still be earned normally. Thus, the spending of 7 perk points in Pickpocket to maximize this method has a fairly poor return when compared to doing a dungeon crawl or two (at higher levels) for the 25,000+ gold you need for 5 training points. However, if you are focused on getting Pickpocket to 100, this method will get you there every few levels, and then if you make Pickpocket legendary, you will get back the perk points and can start to retrain Pickpocket. You should be able to train Pickpocket to 51 using a skill trainer, while pickpocketing your gold back to increase Pickpocket even faster. Be warned that starting this process at lower levels can leave you in great difficulty in combat, if you have not trained any combat skills.

### Trainer Followers
There are several [trainers](Skyrim_Trainers.md) who are also [permanent followers](Skyrim_Followers.md#Permanent_Followers). In this case, you can have them follow you, ask them to train, and then ask them to trade and take your gold back.

Notably, there are 5 trainers (3 expert: [Archery](Skyrim_Archery.md), [Block](Skyrim_Block.md), [One-handed](Skyrim_One-handed.md), 2 master: [Heavy Armor](Skyrim_Heavy_Armor.md), [Two-handed](Skyrim_Two-handed.md)) in the Companions headquarters ([Jorrvaskr](Skyrim_Jorrvaskr.md)) in Whiterun who are eligible to become your follower after you complete the Companions quest line. [Faendal](Skyrim_Faendal.md) in [Riverwood](Skyrim_Riverwood.md) may also be recruited as your follower if you complete [his quest](Skyrim_A_Lovely_Letter.md) in his favor, and he is a common [Archery](Skyrim_Archery.md) trainer.

### Trainer Bartering
There are many [trainers](Skyrim_Trainers.md) who also sell merchandise—the [College of Winterhold](Skyrim_College_of_Winterhold_(place).md), for instance. Without the [Merchant](Skyrim_Merchant_(perk).md) [perk](Skyrim_Perks.md), trainer-merchants will only buy items of a similar type they sell. For instance, trainers at the College of Winterhold will normally only buy or sell [spells](Skyrim_Spells.md), [clothing](Skyrim_Clothing.md) (not [armor](Skyrim_Armor.md)), [jewelry](Skyrim_Jewelry.md), [books](Skyrim_Books.md), [gems](Skyrim_Gems.md), and [staves](Skyrim_Staves.md). Once you have access to an [arcane enchanter](Skyrim_Arcane_Enchanter.md), it is fairly inexpensive to [enchant](Skyrim_Enchanting.md) jewelry with [Waterbreathing](Skyrim_Waterbreathing_(effect).md) for a good profit. Similarly, general merchants, armorers and fences will buy an iron dagger enchanted with [Damage Stamina](Skyrim_Damage_Stamina.md) which sell for a good profit at low levels, whereas [Banish](Skyrim_Banish.md) enchanted items weapons sell for very high profit. Simply make several items like these, ask the trainer to train you as normal, and then ask what they have for sale and get your gold back by selling them the enchanted daggers. You may need to have the Merchant perk in [Speech](Skyrim_Speech.md); most trainers will not normally buy weapons. At higher levels of skill training, this can also help you to train Speech.

### Oghma Infinium
In the switch Version you can hit A, ZL & ZR at the same time to open the Ohgma Infinitum 3 times(make sure to save before).

- **This exploit has been removed by version 1.9.26.0.8 of the [Official Skyrim Patch](Skyrim_Patch.md)**.

Once you have obtained the [Oghma Infinium](Skyrim_Oghma_Infinium.md) **and have not already used it to gain knowledge** (because it normally disappears when you do so), follow these steps to easily gain levels in the 18 [Skills](Skyrim_Skills.md):

1. Activate an empty bookshelf to access the bookshelf menu.
2. Find the Oghma Infinium in your inventory, and open it.
3. Choose any path (*The Path of Might* to level [Combat](Skyrim_Combat.md) skills, *The Path of Shadow* to level [Stealth](Skyrim_Stealth.md) skills, or *The Path of Magic* to level [Magic](Skyrim_Magic.md) skills).
4. Store the Oghma Infinium on the bookshelf.
5. Leave the bookshelf menu.
6. Activate the Oghma Infinium on the bookshelf.
7. Select *(Do Not Read)*.
8. Take the book off the shelf

Repeat the above until you are satisfied with the amount of levels you have gained.

### [Out of Balance](Skyrim_Out_of_Balance.md)
In the course of this quest, when you activate the focal points with the Tuning Gloves, you may be given a potent magicka recovery bonus (paradoxically from what should have been a [Drain Magicka](Skyrim_Drain_Magicka.md) effect) for two hours that lets you cast and recover instantly. This can be used to cast expensive spells over and over to gain levels, if given the appropriate circumstances.

### 100% Magicka Cost Reduction
After getting your [Enchanting](Skyrim_Enchanting.md) skill level to 100 (or close to it, and using a potion of [Fortify Enchanting](Skyrim_Fortify_Enchanting.md)), you can create apparel with 25% cost reduction bonuses for any school of magic. As such, with four items of apparel (head, chest, ring, neck) enchanted thusly, you can gain 100% cost reduction, making casting any spell in that school entirely free. The following methods are high cost, high XP spells for quickly leveling magical skills this way:

- For increasing Alteration, use [Telekinesis](Skyrim_Telekinesis.md) to carry an object in front of you while you walk, or repeatedly cast [Waterbreathing](Skyrim_Waterbreathing_(spell).md) while standing in water at least knee-deep. Casting [Detect Life](Skyrim_Detect_Life_(spell).md) in a crowded city will continuously level Alteration, limited in this circumstance only by your patience. - For even quicker leveling in Alteration, use Telekinesis to carry an object (preferably one of low value such as a tankard or a plate), then fast travel while still holding it. The farther the distance traveled, the higher the skill will increase. The item will be dropped where you fast travel from. - The best locations to use for this are the Forgotten Vale and Fort Dawnguard, as doing so will jump Alteration from level 15 to level 100 instantly.
- For increasing Illusion, [Muffle](Skyrim_Muffle_(spell).md) is consistently great at all levels, while [Harmony](Skyrim_Harmony.md) is better at higher levels, but in limited circumstances.
- For increasing Conjuration, enter combat with anything and repeatedly cast the highest-cost [Bound Weapon](Skyrim_Bound_Weapon.md) spell you can (doing this when detected by an enemy that cannot reach you allows you to choose when to stop the exploit, and a weapon is better than a creature as they will try to kill the enemy). Being outside the locked cage of an angry caged pit wolf (there are a few bandit lairs which have one of these) is a good place to train Conjuration with a bound weapon (or, if you have the spell and the magicka, a Summon Dremora, which has no ranged attacks, so long as you can dismiss and re-summon before he closes to melee range.) You can also use [Soul Trap](Skyrim_Soul_Trap_(spell).md) spell on a dead body continuously to quickly advance in Conjuration. - For grinding character levels after already maxing Conjuration at least once, resetting it to 15 and summoning any [Thrall](Skyrim_Thrall.md) mid-combat earns a huge amount of experience, especially at low Conjuration levels.
- For increasing Restoration, casting [Equilibrium](Skyrim_Equilibrium.md) (to drain health) in one hand and any [healing](Skyrim_Restore_Health.md) spell in your other hand will level it rapidly. Once obtained, repeatedly casting [Circle of Protection](Skyrim_Circle_of_Protection.md) is an even faster method.
- For increasing Destruction, just repeatedly blast away at people and creatures with your most magicka-expensive spell in that school. This can be combined with the [Essential Combat](#Essential_Combat) exploit, as normal enemies will always eventually die.

### Fortify Restoration, Alchemy and Smithing Boosting Enchantments
If you put an Alchemy boosting enchantment on a ring, necklace, gloves, and helmet, craft a [Fortify Restoration](Skyrim_Fortify_Restoration.md) potion, consume it, then unequip and re-equip the gear, this will cause the enchantments to temporarily be effectively better than they were, allowing you to create a stronger potion, which increases the effect even more. After repeating this a number of times, your potions can be boosted to a ridiculous level. If you craft a [Fortify Enchanting](Skyrim_Fortify_Enchanting.md) potion which boosts your Enchanting skill by around 40,000% or more, you can enchant an item to boost alchemy by a ridiculous amount as well. This will allow you to craft potions that increase the skill considerably, even at level 15. This will allow you to boost alchemy from 15 to 100 in a matter of seconds, making it very easy to obtain additional levels. See the [glitches](Skyrim_Glitches.md#Infinitely_Powerful_Items) page for a more detailed description.

You can also use this to exploit the above exploit more easily. With a boosted enchantment skill you can make a single item with more than 100% reduction in spell cost instead of needing four, or add an obscene amount of fortify magicka (e.g. 1m points) so that cost is practically irrelevant.

A boost of the Smithing skill can be achieved the same way: after crafting the Fortify Enchanting potion, put a Smithing enchantment on a piece of gear. Improving a piece of armor or weapon will also boost Smithing from 15 to 100 if you have 4-5 pieces of the tempering material.

Giving one such improved weapon to someone and then goading them into attacking you will level any armor skills to 100 (provided of course that you are wearing some light or heavy armor in the first place). It will also almost certainly kill you, unless you are wearing armor that has been given a high powered [Fortify Health](Skyrim_Fortify_Health.md) enchantment. This trick can also level the block skill to 100 instantly, by blocking when they attack you.

Selling the obscenely expensive items produced by this process can be used to level Speech.

## Gaining Skill XP
- For tips on how to train skills effectively, please refer to the respective section of the individual [Skill](Skyrim_Skills.md) page.
- See the [Free Skill Boosts](Skyrim_Free_Skill_Boosts.md) page for details on free boosts to certain skills.

## Achievements
[Achievements](Skyrim_Achievements.md) related to leveling are:

- [![SR-achievement-Apprentice.png](https://images.uesp.net/thumb/0/0e/SR-achievement-Apprentice.png/30px-SR-achievement-Apprentice.png)](https://en.uesp.net/wiki/File:SR-achievement-Apprentice.png) **Apprentice** (5 points/Bronze) — Reach Level 5
- [![SR-achievement-Adept.png](https://images.uesp.net/thumb/a/a7/SR-achievement-Adept.png/30px-SR-achievement-Adept.png)](https://en.uesp.net/wiki/File:SR-achievement-Adept.png) **Adept** (10 points/Bronze) — Reach Level 10
- [![SR-achievement-Expert.png](https://images.uesp.net/thumb/0/0d/SR-achievement-Expert.png/30px-SR-achievement-Expert.png)](https://en.uesp.net/wiki/File:SR-achievement-Expert.png) **Expert** (25 points/Bronze) — Reach Level 25
- [![SR-achievement-Master.png](https://images.uesp.net/thumb/9/9e/SR-achievement-Master.png/30px-SR-achievement-Master.png)](https://en.uesp.net/wiki/File:SR-achievement-Master.png) **Master** (50 points/Silver) — Reach Level 50