# Unbounded Flames

| [](https://en.uesp.net/wiki/File:SR-icon-spell-Fire.png) | Unbounded Flames | [](https://en.uesp.net/wiki/File:SR-icon-book-Spell Tome Destruction_02.png) | |
| --- | --- | --- | --- |
| Added by | [Arcane Accessories](Skyrim_Arcane_Accessories.md) | | |
| School | [Destruction](Skyrim_Destruction.md) | Difficulty | Expert |
| Type | Offensive | Casting | Concentration |
| Delivery | Aimed | Equip | Either Hand |
| [Spell ID](Skyrim_Form_ID.md) | FE [xxx](Skyrim_Form_ID.md#Creation_Club) 80E | Editor ID | cc BGSSSE014_Unbounded Flames |
| [Base Cost](Skyrim_Magic_Overview.md#Spell_Cost) | 78/s | Charge Time | 0.25 seconds |
| [Duration](Skyrim_Magic_Overview.md#Duration) | 1+2 seconds<sup>[†](#intnote_1)</sup> | Range | 468.75 feet |
| Speed | 117.1875 ft/s | Max Life | 4 seconds |
| Magnitude | 8 points<sup>[†](#intnote_1)</sup> | Area | 6 feet<sup>[†](#intnote_1)</sup> |
| [Tome ID](Skyrim_Form_ID.md) | FE [xxx](Skyrim_Form_ID.md#Creation_Club) 815 | Tome Value | 950 [![Value](https://images.uesp.net/thumb/5/52/SR-item-Gold-heads.png/22px-SR-item-Gold-heads.png)](https://en.uesp.net/wiki/File:SR-item-Gold-heads.png) |
| Found | | | |
| - [Hob's Fall Cave](Skyrim_Hob%27s_Fall_Cave.md) | | | |
| Purchase from (after [Destruction Ritual Spell](Skyrim_Destruction_Ritual_Spell.md)) | | | |
| - [Faralda](Skyrim_Faralda.md) | | | |

[![](https://images.uesp.net/thumb/a/a8/SR-spell-Unbounded_Flames.jpg/200px-SR-spell-Unbounded_Flames.jpg)](https://en.uesp.net/wiki/File:SR-spell-Unbounded_Flames.jpg) [](https://en.uesp.net/wiki/File:SR-spell-Unbounded_Flames.jpg) The fireball arc, subsequent explosion, and wall of fire of Unbounded Flames
- *Casts a stream of long-distance fireballs in an arc. Impact creates a wall of fire that does **50** points of fire damage per second.*

**Unbounded Flames** is an expert level [Destruction](Skyrim_Destruction.md) spell that hurls a series of fireballs in an arc formation, dealing a total of 10.67 points of [fire](Skyrim_Fire_Damage.md) damage over 3 seconds to targets within 6 feet, upon explosion. After the explosion, a wall of fire remains for 30 seconds, dealing a total of 20.67 points of fire damage every 2 seconds to hostile targets, while they are within 3 feet of where the fireball landed.

## Effects
- *Unbounded Flames*, deals 8 points of fire damage for 1 second in 6 feet; targets receive a burning effect that lingers, dealing an additional 2.67 points of fire damage for 2 seconds. - *Fire* (`00 08F3EE`; `Fire Barrier Hazard`) **or** *Fire* (`00 0590FB`; `Fire Barrier Hazard Drop`), determines that damage is dealt in 3 feet for 30 seconds. - ***Fire*** (`00 08F3F1`; `Hazard Wallof Fire Spell`). (Note that this is a separate spell linked with the above hazards, which allows for the grouping of the following effect.) - *Fire hazard*, deals 20 points of fire damage for 1 second; targets receive a burning effect that lingers, dealing an additional 0.67 points of fire damage for 1 second.
- *[Intense Flames Fear](Skyrim_Fear_(effect).md)*, demoralizes targets up to level 99, with health below 20%, for 15 seconds; if the *[Intense Flames](Skyrim_Intense_Flames.md)* perk has been unlocked.

## Perks
- *[Expert Destruction](Skyrim_Expert_Destruction.md)*, reduces the spell cost by 50%.
- *[Aspect of Terror](Skyrim_Aspect_of_Terror.md)*, increases the damage dealt by the *Unbounded Flames* effect to 18 points of fire damage, with 6 points of fire damage being dealt as additional damage. This perk also raises the level that targets can be demoralized by the *Intense Flames Fear* effect to level 109; if both the *Aspect of Terror* and *Intense Flames* perks have been unlocked.
- *[Augmented Flames](Skyrim_Augmented_Flames.md)* (Rank I), increases the damage dealt by the *Unbounded Flames* effect to 10 points of fire damage, with 3.3 points of fire damage being dealt as additional damage. This perk also increases the damage dealt by the *Fire hazard* effect to 25 points of fire damage, with 0.83 points of fire damage being dealt as additional damage. Moreover, it raises the level that targets can be demoralized by the *Intense Flames Fear* effect to level 123; if both the *Augmented Flames* (Rank I) and *Intense Flames* perks have been unlocked.
- *Augmented Flames* (Rank II), increases the damage dealt by the *Unbounded Flames* effect to 12 points of fire damage, with 4 points of fire damage being dealt as additional damage. This perk also increases the damage dealt by the *Fire hazard* effect to 30 points of fire damage, with 1 point of fire damage being dealt as additional damage. Moreover, it raises the level that targets can be demoralized by the *Intense Flames Fear* effect to level 148; if both the *Augmented Flames* (Rank II) and *Intense Flames* perks have been unlocked.
- *[Destruction Dual Casting](Skyrim_Destruction_Dual_Casting.md)*, increases the spell effectiveness by 120% and increases the spell cost by 180%; if dual-cast. This increases the damage dealt by the *Unbounded Flames* effect to 17.6 points of fire damage, with 5.86 points of fire damage being dealt as additional damage. This perk also extends the duration that targets can be demoralized by the *Intense Flames Fear* effect to 33 seconds; if both the *Destruction Dual Casting* and *Intense Flames* perks have been unlocked.

## Notes
- For *Intense Flames Fear* to take effect, the spell projectile must hit the target, not just the explosion or wall of fire alone.
- Like most Destruction spells, Unbounded Flames can be used to detonate [runes](Skyrim_Rune_(effect).md) or [oil slicks](Skyrim_Oil_Slicks.md) from a safe distance. Also, casting the spell, or merely having it ready to cast in an area with [flammable gas](Skyrim_Flammable_Gas.md) will result in the ignition of the gas and a subsequent explosion.
- Note that a maximum of 11 walls of fire can be placed at any one time. This means that if more than 11 are placed, then it will cancel out the first to place the new one, and then the second, etc.
- The damage dealt by one instance of the *Fire hazard* effect occurs every 2 seconds within the 30 second duration. This means that those 2 seconds must expire before the next instance of damage is dealt.
- The wall of fire will not damage the caster or friendly NPCs if they travel through it. However, friendly NPCs are still susceptible to the fireball explosions, provided they are within the area of effect.

[†](#note_1) These values of area, duration, and magnitude apply to the fireball effect of Unbounded Flames, since this is what the parent spell determines. Not featured here is the wall of fire effect, which has an area of 3 feet, with a magnitude of 20 points, and a duration of 1+1 seconds.
## Bugs
- The damage dealt by this spell does not match the damage that is stated in the description. <sup>**?**</sup>
- The spell sometimes only does damage for the first second. <sup>**?**</sup>

## Gallery
- [![](https://images.uesp.net/thumb/3/35/SR-spell-Unbounded_Flames_02.jpg/200px-SR-spell-Unbounded_Flames_02.jpg)](https://en.uesp.net/wiki/File:SR-spell-Unbounded_Flames_02.jpg) The arc of fireball projectiles
- [![](https://images.uesp.net/thumb/1/16/SR-spell-Unbounded_Flames_03.jpg/200px-SR-spell-Unbounded_Flames_03.jpg)](https://en.uesp.net/wiki/File:SR-spell-Unbounded_Flames_03.jpg) The effect of Unbounded Flames on a [Bandit Thug](Skyrim_Bandit.md#Two-Handed_Melee_Bandit_Chiefs)