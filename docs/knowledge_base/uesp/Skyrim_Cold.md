# Cold


## Cold
Cold decreases your total available health, represented as a dark region inside the health bar. As you become colder, your movement speed and ability to pick locks and pick pockets will begin to suffer. If you reach the highest level of Cold (1000), your health will be reduced to zero and you will die. You can warm up by standing near a fire, eating [hot soup](https://en.uesp.net/wiki/Skyrim:Hot_Soups), or moving to a warmer location. A sun or snowflake icon will appear near the compass to note whether you are currently getting warmer or colder.

The player's Cold stat is updated every 0.07 in-game hours (12.6 real seconds). The amount the Cold stat changes depends on whether the player is warming-up or cooling-down and the environment's current Cold Level which ranges from 0 to 30 with higher values being colder.

When warming-up, the player's Cold stat will decrease by 40 per update until it reaches equilibrium with the environment. Standing next to a valid heat source like a forge, smelter, sconce, or fire pit will increase this to 75 Cold per update. The Warmth stat has no effect on how quickly the player warms-up. Eating a Hot Soup will instantly reduce the Cold stat by 200 and increase the Warmth stat by 25 for 300 seconds.

When cooling-down, the player's Cold stat will increase depending on their Warmth stat, race, and the Cold Level of the environment. The rate at which it increases is approximately 3.127344*Cold Level*(1-0.85*Warmth/206) per update. If the player is an Argonian this is multiplied by 1.25.

Warmth is internally capped at 206, which reduces the player's rate of cooling by 85%. Higher ratings will not provide further protection.

The environment's Cold Level is determined by location, time of day, and weather. The game classifies locations as being either Warm (Cold Level=0), Cool (3), or Freezing (6). At night, specifically from 7 PM to 7 AM, Warm areas have their Cold Level increased by 1, Cool areas by 2, and Freezing areas by 4. Rain increases Cold Level by 3, snow increases it by 6, and blizzards increase it by 10. Freezing water always has a Cold Level of 30.

The player's Cold stat will either increase or decrease to meet the environment's Cold Level's equilibrium. Cold Level 0's equilibrium is 0 (Warm), 1-4 is 119, 5-6 is 299, 7-9 is 499, 10-12 is 799, and 13-30 is 1000 (death). This means that you can only freeze to death in a blizzard (6+10=16) or in a Freezing area at night while it is raining (6+4+3=13) or snowing (6+4+6=16).

Swimming in freezing water will immediately increase your Cold stat to 300 and you will begin taking 15 health damage per second until you leave the water. Using a [Flame Cloak](https://en.uesp.net/wiki/Skyrim:Flame_Cloak) spell or the [Dunmer](Skyrim_Dark_Elf.md) [Ancestor's Wrath](Skyrim_Ancestor%27s_Wrath.md) ability can make you temporarily immune to the effects of freezing water.

The player's maximum health after the penalty from Cold is (Base Health)*(1000-Cold)/881.

The health penalty from Cold begins once the player becomes Chilly(120 Cold).

## Warmth
| | Cold | Normal | Warm |
| --- | --- | --- | --- |
| Head | 8 | 18 | 29 |
| Body | 17 | 27 | 54 |
| Hands | 7 | 13 | 24 |
| Feet | 7 | 13 | 24 |

The higher your Warmth rating, the more slowly you will feel the effects of cold environments. Most [clothing](Skyrim_Clothing.md) and [armor](Skyrim_Armor.md) provide warmth, displayed on the item's description. Some armor is exceptionally warm, while others are ill-suited to protect their wearer from harsh climates. You can also temporarily increase your warmth rating by eating [hot soup](https://en.uesp.net/wiki/Skyrim:Hot_Soups) (+25) or holding a [torch](https://en.uesp.net/wiki/Skyrim:Torch) (+50).

Warmth reduces the speed at which you get cold in cold environments (normally one point of Cold per second). Your total warmth bonus is clamped between 0 and 206. This is divided by 206 to become a percentage, and multiplied by 0.85. The resulting value is subtracted from the factor at which cold is accumulated. The 206 value, defined in the Survival_Cold Resist Max Value global, corresponds to the normal maximum Warmth rating achieved by wearing a full set of warm clothes or armor pieces, having eaten a hot soup, and holding a torch. A quick approximation of the formula is that your Cold resistance is about 2/5 of your Warmth rating.

| [Argonians](Skyrim_Argonian.md) | Weakness to Cold: Become cold 25% faster. |
| --- | --- |
| [Khajiit](Skyrim_Khajiit.md) | Fortify Warmth 15. Become cold about 6% slower. |
| [Orcs](Skyrim_Orc.md) | Fortify Warmth 10. Become cold about 4% slower. |
| [Nords](Skyrim_Nord.md) | Fortify Warmth 25. Become cold about 10% slower. |

Note that while Khajiit, Orcs, and Nords have a racial Warmth bonus, Argonians do not have a Warmth penalty. Instead they directly increase the cold factor by 0.25. This corresponds effectively to a Warmth penalty of about 61 points: an Argonian with maxed Warmth score (206) will accrue Cold at a rate of 0.4 points per second, about the same rate as any other race with a total Warmth rating of 145.

## Effects of Cold
| Cold <br> Value | Level | Effect |
| --- | --- | --- |
| 0-49 | Warm | Picking locks and picking pockets is 10% easier. You are 10% more resistant to Frost. |
| 50-119 | Comfortable | No effect. |
| 120-299 | Chilly | Total health is reduced. You move 10% slower. Lockpicking and pickpocketing are 30% harder. |
| 300-499 | Very Cold | Total health is reduced. You move 20% slower. Lockpicking and pickpocketing are 50% harder. |
| 500-799 | Freezing | Total health is reduced. You move 30% slower. Lockpicking and pickpocketing are 70% harder. |
| 800-1000 | Numb | Total health is reduced. You move 40% slower. Lockpicking and pickpocketing are 90% harder. |

## Notes
- Moving near a fire will negate the warmth effect, even if you're effectively staying still.
- It is impossible to freeze to death while in either [werewolf form](Skyrim_Lycanthropy.md) or [Vampire Lord](Skyrim_Vampire_Lord.md)<sup>[DG](Skyrim_Dawnguard.md)</sup> form.
- At high levels of cold, the massive reduction to Lockpicking can make it impossible to pick locks as the correct location for the pick becomes so small that it no longer exists.

## Bugs
- Some quest-specific flame objects were never added to the Survival heat source formlist. - The [Unofficial Skyrim Special Edition Patch](https://en.uesp.net/wiki/Skyrim:Mod_Unofficial_Skyrim_Special_Edition_Patch), version 4.3.7, fixes this bug.
- [![Nintendo Switch Logo.svg](https://images.uesp.net/5/5d/Nintendo_Switch_Logo.svg)](Skyrim_Switch.md) If playing on [Nintendo Switch](Skyrim_Switch.md), the game will sometimes crash when you reach freezing status. - This bug is fixed by version 1.1.177.3285177 of the game on Nintendo Switch.

## See Also
- [Fortify Warmth](Skyrim_Fortify_Warmth.md)
- [Restore Cold](https://en.uesp.net/wiki/Skyrim:Restore_Cold)