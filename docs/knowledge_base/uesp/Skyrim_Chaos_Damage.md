# Chaos Damage

| [](https://en.uesp.net/wiki/File:SR-icon-spell-Magic_Hat.png) | Chaos Damage |
| --- | --- |
| School | [Destruction](Skyrim_Destruction.md) |
| Type | Offensive |
| [Enchanting](Skyrim_Enchanting_Effects.md) | |
| [ID](Skyrim_Form_ID.md) | [xx](Skyrim_Form_ID.md) 02c46c |
| Base Cost | 19 |
| Items | Weapons |
| Availability <br> (Click on any item for details) | |
| [Weapons](Skyrim_Generic_Magic_Weapons.md#Chaos_Damage) | |

*Enchanting description:* **50% chance for each element of fire, frost, and shock to do <mag> points of damage.**

**Chaos Damage** is an enchantment.

## Effects
- [Fire Damage](Skyrim_Fire_Damage.md), <mag> pts for 1 sec (50% chance)
- [Frost Damage](Skyrim_Frost_Damage.md), <mag> pts for 1 sec (50% chance)
- [Shock Damage](https://en.uesp.net/wiki/Skyrim:Shock_Damage), <mag> pts for 1 sec (50% chance)

## Enchanting
The following items use this enchantment. You can learn how to enchant custom items with chaos damage if you find one of the following items and disenchant it:

- All weapons *[of Chaos](Skyrim_Generic_Magic_Weapons.md#Chaos_Damage)*, *of Extreme Chaos*, *of High Chaos* and *of Ultimate Chaos*
- [Champion's Cudgel](Skyrim_Champion%27s_Cudgel.md)

## Notes
- The enchantment benefits from all the Augmented elemental perks. Additionally, if you have more than one of these perks, the damage multipliers are compounded on each other. For example, if you have two levels of all three perks, the base damage for Chaos enchantments becomes `<mag> x 1.5 x 1.5 x 1.5` for a total of `<mag> x 3.375`. This is on top of the average damage mentioned below.
- Chaos Damage enchantments are 25% stronger when applied to [stalhrim](Skyrim_Stalhrim.md)<sup>[DB](Skyrim_Dragonborn.md)</sup> weapons.
- The average damage done by this enchantment (assuming no perks and against enemies without any resistance) is `1.5 × <mag>`. To calculate this, consider that each element fires half of the time. Each of 3 elements does `<mag>` damage half of the time. On average each element does `0.5 × <mag>` damage. Thus, the average damage of the total enchantment is `3 × 0.5 × <mag>` or 1.5 × <mag>. Similarly, for an enemy immune to an element, you only have to consider 2 of 3 elements so, the average damage is `2 × 0.5 × <mag>` or `<mag>`.

For single-wielded weapons:

- The enchantment triggering probabilities are as follows<sup>[[1]](#cite_note-Binomial-1)</sup>: - 7 in 8 chance (87.5%): At least one enchantment triggers. `<mag>` damage to `3x<mag>` damage.
- 4 in 8 chance (50.0%): At least two enchantments trigger. `2x<mag>` damage to `3x<mag>` damage.
- 3 in 8 chance (37.5%): Exactly one enchantment triggers. `<mag>` damage.
- 3 in 8 chance (37.5%): Exactly two enchantments trigger. `2×<mag>` damage.
- 1 in 8 chance (12.5%): All three enchantments trigger. `3×<mag>` damage.
- 1 in 8 chance (12.5%): None of the enchantments trigger. `0` damage.

- For an enemy immune to one element (but with no resistances in the other two), the damage is just `<mag>`: - 4 in 8 chance (50%): One non-immune element or one non-immune + immune triggers. `<mag>` damage.
- 2 in 8 chance (25%): Nothing or only immune element triggers. `0` damage.
- 2 in 8 chance (25%): Both non-immune elements trigger, or all three trigger. `2×<mag>` damage.

For dual-wielded weapons up to `6x<mag>` damage is possible (chaos damage must be applied to both weapons):

- The enchantment triggering probabilities are as follows<sup>[[1]](#cite_note-Binomial-1)</sup>: - 63 in 64 chance (98.44%): At least one enchantment triggers. `<mag>` damage to `6x<mag>` damage.
- 57 in 64 chance (89.06%): At least two enchantments trigger. `2x<mag>` damage to `6x<mag>` damage.
- 42 in 64 chance (65.62%): At least three enchantments trigger. `3x<mag>` damage to `6x<mag>` damage.
- 22 in 64 chance (34.37%): At least four enchantments trigger. `4x<mag>` damage to `6x<mag>` damage.
- 20 in 64 chance (31.25%): Exactly three enchantments trigger. `3×<mag>` damage.
- 15 in 64 chance (23.44%): Exactly two enchantments trigger. `2×<mag>` damage.
- 15 in 64 chance (23.44%): Exactly four enchantments trigger. `4×<mag>` damage.
- 7 in 64 chance (10.94%): At least five enchantments trigger. `5x<mag>` damage to `6x<mag>` damage.
- 6 in 64 chance (9.37%) : Exactly five enchantments trigger. `5×<mag>` damage.
- 6 in 64 chance (9.37%) : Exactly one enchantment triggers. `1×<mag>` damage.
- 1 in 64 chance (1.56%) : All six enchantments trigger. `6×<mag>` damage.
- 1 in 64 chance (1.56%) : None of the enchantments trigger. `0` damage.

## Bugs
- For custom enchantments, the damage value shown in the enchantment description is correct only for the shock damage. The magnitudes of the fire and frost damage effects stored in any custom enchantment are always 10, regardless of enchantment strength bonuses, Enchanting skill, soul gem size, or strength slider setting. (Post-enchantment modifiers such as *[Augmented Flames](Skyrim_Augmented_Flames.md)* can still apply.) <sup>**?**</sup> **Mod Notes**: It looks like the highest-cost effect in any custom enchantment is the only effect that can be variable; all other effects are fixed.
- You might get a warning at the top left of the screen when using a weapon with Chaos Damage, stating "[enemy] resisted [element]", even if they aren't resistant or immune to the element in the first place (such as an Imperial bandit resisting the element of fire). This seems to be random in occurrence and there's seemingly no way to stop it from happening. <sup>**?**</sup>

## See Also
This effect is related to:

- [Fire Damage](Skyrim_Fire_Damage.md), [Frost Damage](Skyrim_Frost_Damage.md), [Shock Damage](https://en.uesp.net/wiki/Skyrim:Shock_Damage)

## References
1. ^ <sup>***[a](#cite_ref-Binomial_1-0)***</sup><sup>***[b](#cite_ref-Binomial_1-1)***</sup> [Binomial Distribution](https://www.wikipedia.org/wiki/Binomial_distribution)