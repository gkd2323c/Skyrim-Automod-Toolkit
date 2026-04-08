# Light Damage

| --- | --- |
| School | [Destruction](Skyrim_Destruction.md) |
| Type | Offensive |
| [Enchanting](Skyrim_Enchanting_Effects.md) | |
| [ID](Skyrim_Form_ID.md) | 00 03b0b1 |
| Base Cost | 5 |
| Items | Weapons |
| Availability <br> (Click on any item for details) | |
| [Weapons](Skyrim_Leveled_Items.md#Lunar_Weapons) | |

*Enchanting description:* **While the moons are out, burns the target for <mag> points.**

**Light Damage** is the name of the effect used by the **Silent Moons Enchant** enchantment. Light Damage is similar to [Fire Damage](https://en.uesp.net/wiki/Skyrim:Fire_Damage) in that it deals [tapering damage](Skyrim_Magic_Overview.md#Tapering_Durations) for 2 seconds after the main effect ends (usually ~13% of the base damage). But unlike Fire Damage where the main effect is applied instantly, Light Damage is applied over 1 second. Light Damage enchantments can also contain over twice as many charges as Fire Damage enchantments. The downside is that the effect will only work "while the moons are out," or between the hours of 9pm and 5am (see [Bugs](#Bugs)).

## Enchanting
The following items (all found in [Silent Moons Camp](https://en.uesp.net/wiki/Skyrim:Silent_Moons_Camp)) use this effect. You can learn how to enchant custom items with Silent Moons Enchant if you find one of the following items and disenchant it:

- [Lunar Iron Mace](https://en.uesp.net/wiki/Skyrim:Lunar_Iron_Mace)
- [Lunar Iron Sword](https://en.uesp.net/wiki/Skyrim:Lunar_Iron_Sword)
- [Lunar Iron War Axe](https://en.uesp.net/wiki/Skyrim:Lunar_Iron_War_Axe)
- [Lunar Steel Mace](https://en.uesp.net/wiki/Skyrim:Lunar_Steel_Mace)
- [Lunar Steel Sword](https://en.uesp.net/wiki/Skyrim:Lunar_Steel_Sword)
- [Lunar Steel War Axe](https://en.uesp.net/wiki/Skyrim:Lunar_Steel_War_Axe)

## Notes
- Silent Moons Enchant is the only enchantment in *Skyrim* that includes the word "enchant".
- The book *[Notes On The Lunar Forge](Skyrim_Notes_On_The_Lunar_Forge.md)* incorrectly suggests that the Lunar Weapons transfer health to the user, as [Absorb Health](Skyrim_Absorb_Health.md) would.
- Using Silent Moons Enchant during the day will still drain the weapon's charge, even if no effect is produced. In addition, while the hit animation will still occur during the day, analysis of the game files reveals that the enchantment is designed to only deal damage at night regardless of lunar phase, weather, or if you're indoors or outdoors. However, keep in mind that due to the bug listed below, the enchantment may not actually do damage, even during the allotted time frame.
- Silent Moons Enchant is strengthened by the [Fire Enchanter](https://en.uesp.net/wiki/Skyrim:Fire_Enchanter) perk.
- Light Damage is strengthened by the [Augmented Flames](Skyrim_Destruction.md#Augmented_Flames) perk and [Ahzidal](https://en.uesp.net/wiki/Skyrim:Ahzidal)'s [mask](Skyrim_Ahzidal_(item).md)<sup>[DB](Skyrim_Dragonborn.md)</sup>.
- Light Damage may be considered to represent moonlight, with its counterpart being [Sun Damage](https://en.uesp.net/wiki/Skyrim:Sun_Damage)<sup>[DG](Skyrim_Dawnguard.md)</sup>.

## Bugs
- Weapons enchanted with Silent Moons Enchant at an enchanting table will work at any time of the day.
- Light Damage affects the target's Weapon Speed Mult actor value, rather than their health. For most NPCs, this will have no noticeable effect, as a negative Weapon Speed Mult is just treated as normal speed. However, certain enemies such as [Forsworn](Skyrim_Forsworn.md) who have the [Dual Flurry](Skyrim_Dual_Flurry.md) or [Quick Shot](Skyrim_Quick_Shot.md) perks will no longer benefit from these perks if affected by Light Damage. - ![PC Only](https://images.uesp.net/d/d7/Computer.svg)
The [Unofficial Skyrim Patch](https://en.uesp.net/wiki/Skyrim:Mod_Unofficial_Skyrim_Patch), version 1.0, fixes this bug.
- The enchantment on Lunar Forge items is described in detail in an in-game lore book as draining Health at night. The game has instead had the enchantment set to do fire damage, which is incorrect, and has been fixed. - ![PC Only](https://images.uesp.net/d/d7/Computer.svg)
The [Unofficial Skyrim Patch](https://en.uesp.net/wiki/Skyrim:Mod_Unofficial_Skyrim_Patch), version 4.3.1, fixes this bug.

## Related Effects
- [Fire Damage](https://en.uesp.net/wiki/Skyrim:Fire_Damage)
- [Sun Damage](https://en.uesp.net/wiki/Skyrim:Sun_Damage)
- [Damage Health](Skyrim_Damage_Health.md)