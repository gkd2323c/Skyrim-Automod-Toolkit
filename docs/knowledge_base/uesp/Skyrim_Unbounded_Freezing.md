# Unbounded Freezing

| [](https://en.uesp.net/wiki/File:SR-icon-spell-Ice.png) | Unbounded Freezing | [](https://en.uesp.net/wiki/File:SR-icon-book-Spell Tome Destruction_02.png) | |
| --- | --- | --- | --- |
| Added by | [Arcane Accessories](Skyrim_Arcane_Accessories.md) | | |
| School | [Destruction](Skyrim_Destruction.md) | Difficulty | Expert |
| Type | Offensive | Casting | Concentration |
| Delivery | Self | Equip | Either Hand |
| [Spell ID](Skyrim_Form_ID.md) | FE [xxx](Skyrim_Form_ID.md#Creation_Club) 80D | Editor ID | cc BGSSSE014_Unbounded Freeze |
| [Base Cost](Skyrim_Magic_Overview.md#Spell_Cost) | 69/s | Charge Time | 0 seconds |
| [Duration](Skyrim_Magic_Overview.md#Duration) | 0 seconds | Range | 36 feet |
| Speed | 46.875 ft/s | Max Life | 0.768 seconds |
| Magnitude | 15 points<sup>[†](#intnote_2)</sup> | Area | 12 feet<sup>[†](#intnote_2)</sup> |
| [Tome ID](Skyrim_Form_ID.md) | FE [xxx](Skyrim_Form_ID.md#Creation_Club) 816 | Tome Value | 950 [![Value](https://images.uesp.net/thumb/5/52/SR-item-Gold-heads.png/22px-SR-item-Gold-heads.png)](https://en.uesp.net/wiki/File:SR-item-Gold-heads.png) |
| Found | | | |
| - [Hob's Fall Cave](Skyrim_Hob%27s_Fall_Cave.md) | | | |
| Purchase from (after [Destruction Ritual Spell](Skyrim_Destruction_Ritual_Spell.md)) | | | |
| - [Faralda](Skyrim_Faralda.md) | | | |

[![](https://images.uesp.net/thumb/5/5e/SR-spell-Unbounded_Freezing.jpg/200px-SR-spell-Unbounded_Freezing.jpg)](https://en.uesp.net/wiki/File:SR-spell-Unbounded_Freezing.jpg) [](https://en.uesp.net/wiki/File:SR-spell-Unbounded_Freezing.jpg) The effect of *Unbounded Freezing* on the caster
- *A freezing wind envelops the caster, knocking down nearby enemies and freezing them for **50** points of damage per second to Health and Stamina.*

**Unbounded Freezing** is an expert level [Destruction](Skyrim_Destruction.md) spell that surrounds the caster in an icy wind, knocks down targets within melee range, and deals 50 points of [Frost Damage](Skyrim_Frost_Damage.md) per second to the [Health](Skyrim_Health.md) and [Stamina](Skyrim_Stamina.md) of targets. Continuing to channel the spell will freeze enemies as they are knocked down, and only when the caster stops channeling within range, will they be thawed and return to a standing position.

## Effects
- *Unbounded Freeze*, determines that damage is dealt and targets are knocked down in 15 feet. - ***Frost Cloak Freeze***<sup>[†](#intnote_1)</sup> (`FE [xxx](Skyrim_Form_ID.md#Creation_Club) 825`; `cc BGSSSE014_Frost Cloak Dmg`). - *Unbounded Frostbite*, deals 50 points of Frost Damage to the Health and Stamina of targets for 1 second.
- *[Deep Freeze Paralyze](Skyrim_Paralyze_(effect).md)*, paralyzes targets (with Health below 20%) for 2 seconds; if the *[Deep Freeze](Skyrim_Deep_Freeze.md)* perk has been unlocked.
- Silent Empty Area Push explosion (`FE [xxx](Skyrim_Form_ID.md#Creation_Club) 81A`; `cc BGSSSE014_Silent Empty Area Push`), knocks down targets.
- *Unbounded Freeze*, paralyzes targets in 12 feet.

[†](#note_1) Note that this asset is a separate spell rather than an effect, which allows for the grouping of the following effects.
## Perks
- *[Expert Destruction](Skyrim_Expert_Destruction.md)*, reduces the spell cost by 50%. This decreases the base cost of the spell to 34.5 points of magicka.
- *[Augmented Frost](Skyrim_Augmented_Frost.md)* (Rank I), increases the damage dealt by the *Unbounded Frostbite* effect to 62.5 points of Frost Damage per second to the Health and Stamina of targets.
- *Augmented Frost* (Rank II), increases the damage dealt by the *Unbounded Frostbite* effect to 75 points of Frost Damage per second to the Health and Stamina of targets.
- *[Deep Freeze](Skyrim_Deep_Freeze.md)*, enables targets (with Health below 20%) to be paralyzed for 2 seconds, when inflicted with Frost Damage from the *Unbounded Frostbite* effect.
- *[Destruction Dual Casting](Skyrim_Destruction_Dual_Casting.md)*, increases the spell effectiveness by 120% and increases the spell cost by 180%; if dual-cast. This expands the area determined by the *Unbounded Freeze* effect to 33 feet, and increases the damage dealt by the *Unbounded Frostbite* effect to 110 points of Frost Damage to Health and Stamina, while increasing the base cost of the spell to 151.8 points of magicka.

## Notes
- Unlike most frost spells, *Unbounded Freezing* does not [slow](Skyrim_Slow.md) enemies when dealing Frost Damage.

[†](#note_2) Because the magic effect archetype associated with this spell is *Cloak*, the magnitude determines the area of effect, rather than the damage dealt. Therefore, while the area value displayed in the [Creation Kit](https://en.uesp.net/wiki/Skyrim_Mod:Creation_Kit) is null, the area of effect is actually 15 feet by means of the magnitude.
## Bugs
- The spell description states that only enemies will be knocked down, and damage will only be dealt by the *Unbounded Frostbite* effect if the target is hostile. However, due to enabled parameters, even friendly NPCs will be paralyzed and knocked down, turning them hostile. Subsequently, the spell will start dealing damage to the affected NPCs, despite the original intention of only affecting enemies. NPCs who are immune to paralysis, such as [Astrid](Skyrim_Astrid.md), are exempt from this. <sup>**?**</sup>
- The spell will sometimes only freeze enemies, knocking them down but not doing any damage. This seems to happen more frequently with higher level enemies.
- Sometimes, after killing an enemy with this spell, they will remain animated despite being dead. <sup>**?**</sup> - [![On PC](https://images.uesp.net/d/d7/Computer.svg)](https://www.wikipedia.org/wiki/PC_game) Using the [Console](Skyrim_Console.md), click on the animated corpse, then type `disable` followed by `enable`. On rare occasions, that may fail, in which case you can also try `resurrect` and `kill`.

## Gallery
- [![](https://images.uesp.net/thumb/1/15/SR-spell-Unbounded_Freezing_02.jpg/200px-SR-spell-Unbounded_Freezing_02.jpg)](https://en.uesp.net/wiki/File:SR-spell-Unbounded_Freezing_02.jpg) The effect of *Unbounded Freezing* on a pair of [Bandits](Skyrim_Bandit.md#One-Handed_Melee)