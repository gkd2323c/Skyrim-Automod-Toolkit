# Vampire's Bane

| [](https://en.uesp.net/wiki/File:SR-icon-spell-Vampire_Bane.png) | Vampire's Bane | [](https://en.uesp.net/wiki/File:SR-icon-book-Spell Tome Destruction.png) | |
| --- | --- | --- | --- |
| Added by | [Dawnguard](Skyrim_Dawnguard.md) | | |
| School | [Restoration](Skyrim_Restoration.md) | Difficulty | Adept |
| Type | Offensive | Casting | Fire and Forget |
| Delivery | Aimed | Equip | Either Hand |
| [Spell ID](Skyrim_Form_ID.md) | [xx](Skyrim_Form_ID.md) 0038b6 | Editor ID | DLC1Vampires Bane |
| [Base Cost](Skyrim_Magic_Overview.md#Spell_Cost) | 72 | Charge Time | 0.5 |
| [Duration](Skyrim_Magic_Overview.md#Duration) | 2 | Range | 469 ft |
| Speed | 75 ft/s | Max Life | ~6.3 sec |
| Magnitude | 40 | Area | 15 ft |
| [Tome ID](Skyrim_Form_ID.md) | [xx](Skyrim_Form_ID.md) 003f4d | Tome Value | 340 |
| Purchase from | | | |
| - [Florentius Baenius](Skyrim_Florentius_Baenius.md) | | | |

- *Sunlight explosion that does 40 points of damage in a 15 foot radius to undead.*

**Vampire's Bane** is an adept level [Restoration](Skyrim_Restoration.md) spell added by [Dawnguard](Skyrim_Dawnguard.md), which will do 40 damage to any [Undead](Skyrim_Undead.md) targets within 15 feet over 2 seconds. It has no effect on non-undead.

## Effects
- [Sun Bane](Skyrim_Sun_Damage.md), 40 pts in 15 ft

## Perks
- [Necromage](Skyrim_Necromage_(perk).md) increases magnitude by 25% and duration by 50%.
- [Restoration Dual Casting](Skyrim_Restoration_Dual_Casting.md) increases duration by 120%, but does **not** increase effect level.

## Notes
- This spell is normally unavailable if you join the vampires, as [Florentius Baenius](Skyrim_Florentius_Baenius.md) will be hostile to you. However, if you use a [Pacify](Skyrim_Pacify_(effect).md) spell or item, you can calm him down so that he'll sell it to you. You must do this before you get quest [Destroying the Dawnguard](Skyrim_Destroying_the_Dawnguard.md) by [Garan Marethi](Skyrim_Garan_Marethi.md) or [Fura Bloodmouth](Skyrim_Fura_Bloodmouth.md).
- This spell can essentially be considered an undead-specific version of [fireball](Skyrim_Fireball.md), as it has the same range and explosive effect (though not strictly fire damage) but it is entirely harmless against non-undead. As such, it can be used against vampires that might attack cities during an eclipse caused by bloodcursed arrows shot by [Auriel's bow](Skyrim_Auriel%27s_Bow.md), and not have to worry about collateral damage or bounties. However, unlike fireball (with the specific perk), you cannot inflict stagger by dual casting the spell at a target.

## Bugs
- The spell tome for this spell looks like a [Destruction](Skyrim_Destruction.md) book, but it is actually Restoration. - ![PC Only](https://images.uesp.net/d/d7/Computer.svg)
The [Unofficial Dawnguard Patch](https://en.uesp.net/wiki/Skyrim_Mod:Unofficial_Dawnguard_Patch), version 1.2.1, fixes this bug.
- This spell will not damage reanimated enemies unless they were classed as undead *before* being killed. This is due to a missing condition check in the spell's settings (the spell only checks for the Actor Type Undead keyword instead of also checking the Is Undead condition). - ![PC Only](https://images.uesp.net/d/d7/Computer.svg)
The [Unofficial Dawnguard Patch](https://en.uesp.net/wiki/Skyrim_Mod:Unofficial_Dawnguard_Patch), version 2.0.3, fixes this bug.