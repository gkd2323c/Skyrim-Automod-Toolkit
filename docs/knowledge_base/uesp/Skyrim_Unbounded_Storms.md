# Unbounded Storms

| [](https://en.uesp.net/wiki/File:SR-icon-spell-Shock.png) | Unbounded Storms | [](https://en.uesp.net/wiki/File:SR-icon-book-Spell Tome Destruction_02.png) | |
| --- | --- | --- | --- |
| Added by | [Arcane Accessories](Skyrim_Arcane_Accessories.md) | | |
| School | [Destruction](Skyrim_Destruction.md) | Difficulty | Expert |
| Type | Offensive | Casting | Concentration |
| Delivery | Self | Equip | Either Hand |
| [Spell ID](Skyrim_Form_ID.md) | FE [xxx](Skyrim_Form_ID.md#Creation_Club) 808 | Editor ID | cc BGSSSE014_Unbounded Storms |
| [Base Cost](Skyrim_Magic_Overview.md#Spell_Cost) | 69/s | Charge Time | 0.3 seconds |
| [Duration](Skyrim_Magic_Overview.md#Duration) | 2 seconds | Range | 0 |
| Magnitude | 40 | Area | 50 feet |
| [Tome ID](Skyrim_Form_ID.md) | FE [xxx](Skyrim_Form_ID.md#Creation_Club) 817 | Tome Value | 950 [![Value](https://images.uesp.net/thumb/5/52/SR-item-Gold-heads.png/22px-SR-item-Gold-heads.png)](https://en.uesp.net/wiki/File:SR-item-Gold-heads.png) |
| Found | | | |
| - [Hob's Fall Cave](Skyrim_Hob%27s_Fall_Cave.md) | | | |
| Purchase from (after [Destruction Ritual Spell](Skyrim_Destruction_Ritual_Spell.md)) | | | |
| - [Faralda](Skyrim_Faralda.md) | | | |

- *Targets in melee range take **40** shock damage per second to Health, and half that to Magicka. Random lightning strikes deal an additional **30** damage.*

**Unbounded Storms** is an Expert level [Destruction](Skyrim_Destruction.md) spell that surrounds the caster in a stormy cloak, damaging nearby targets for 40 shock damage per second to health, and half that to magicka. A lightning cloud will hang over the caster's head, randomly casting lightning bolts at nearby targets.

## Effects
- *Unbounded Storms*, determines that damage is dealt to nearby targets - ***Lightning Cloak Drain*** (`FE [xxx](Skyrim_Form_ID.md#Creation_Club) 824`; `cc BGSSSE014_Lightning Cloak Dmg`) - *[Sparks](Skyrim_Shock_Damage.md)*, deals 40 points of Shock Damage to Health and Magicka per second in 40 feet for 1 sec
- *[Disintegrate](Skyrim_Disintegrate.md)*, 200 pts for 1 sec; if the *[Disintegrate](Skyrim_Disintegrate.md)* perk has been unlocked
- *Storm Lightning*, randomly casts lightning bolts at nearby targets - ***Storm Call Lightning Bolt*** (`FE [xxx](Skyrim_Form_ID.md#Creation_Club) 808`; `cc BGSSSE014_Shock Bolt Spell`) - *[Shock Bolt Storm](Skyrim_Shock_Damage.md)*, 30 pts in 50 feet for 2 secs

## Perks
- *[Expert Destruction](Skyrim_Expert_Destruction.md)*, reduces the spell cost by 50%.
- *[Disintegrate](Skyrim_Disintegrate.md)*, causes targets hit by this spell to disintegrate if their health is below 15%
- *[Augmented Shock](Skyrim_Augmented_Shock.md)* (Rank I), increases damage by 25%.
- *Augmented Shock* (Rank II), increases damage by 50%
- *[Destruction Dual Casting](Skyrim_Destruction_Dual_Casting.md)*, increases the spell effectiveness by 120% and increases the spell cost by 180%.

## Notes
- The damage caused by this spell passes through walls and doors, as well as targeting draugr still in their crypts.
- The random lightning strikes can target friendly NPCs, turning them hostile.

## Bugs
- Despite the spell description's statement that targets will take damage in melee range, the range of the cloak surrounding the caster is actually much larger than any other cloak, as cloak range is determined by the spell's magnitude, with this spell having a much higher magnitude than any other cloak spells. When dual cast, the radius increases instead of the damage, allowing it to cover almost as much area as a Fire Storm.
- The radius of the spell is affected by the player's magic resistance. The higher the resistance, the lower the radius. <sup>**?**</sup>
- The lightning emitter does not move with the caster but remains in the spot where you first cast the spell.
- The spell will sometimes stop doing damage per second and only do damage upon lightning strikes.