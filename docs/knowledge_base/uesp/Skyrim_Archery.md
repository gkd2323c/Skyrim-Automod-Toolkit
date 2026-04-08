# Archery

| --- |
| [![Archery](https://images.uesp.net/e/e9/SR-skill-Archery.png)](https://en.uesp.net/wiki/File:SR-skill-Archery.png) |
| Specialization: <br> [Combat](Skyrim_Combat.md) |

**Archery** (also referred to as **Marksman**) is the skill governing the use of [bows](Skyrim_Bow.md) and [crossbows](Skyrim_Crossbow.md)<sup>[DG](Skyrim_Dawnguard.md)</sup>. Each skill point grants a +0.5% bonus to the damage dealt with bows and crossbows. The Archery tree has a total of 9 perks, requiring 16 perk points to fill.

In-game Description: *An archer is trained in the use of bows and arrows. The greater the skill, the deadlier the shot.*

## Skill Perks
[![Archery Perk Tree](https://images.uesp.net/9/9d/SR-perktree-Archery.jpg)](https://en.uesp.net/wiki/File:SR-perktree-Archery.jpg) [![Overdraw (5 ranks): 0/20/40/60/80 Archery. Archery is 20/40/60/80/twice as effective.](https://images.uesp.net/thumb/a/a1/Yellow_pog.png/12px-Yellow_pog.png)](https://en.uesp.net/wiki/File:Yellow_pog.png) Overdraw [![Critical Shot (3 ranks): 30/60/90 Archery. Rank 1 has a 10% chance of doing a critical hit. Rank 2 has a 15% chance of doing a critical hit for 25% more critical damage. Rank 3 has a 20% chance of doing a critical hit that does 50% more critical damage.](https://images.uesp.net/thumb/a/a1/Yellow_pog.png/12px-Yellow_pog.png)](https://en.uesp.net/wiki/File:Yellow_pog.png) Critical Shot [![Eagle Eye: 30 Archery. Pressing Block while aiming will zoom in your view.](https://images.uesp.net/thumb/a/a1/Yellow_pog.png/12px-Yellow_pog.png)](https://en.uesp.net/wiki/File:Yellow_pog.png) Eagle Eye [![Steady Hand (2 ranks): 40/60 Archery. Zooming in with a bow slows time by 25%. The second rank doubles the effect.](https://images.uesp.net/thumb/a/a1/Yellow_pog.png/12px-Yellow_pog.png)](https://en.uesp.net/wiki/File:Yellow_pog.png) Steady Hand [![Power Shot: 50 Archery. Arrows stagger all but the largest opponents 50% of the time](https://images.uesp.net/thumb/a/a1/Yellow_pog.png/12px-Yellow_pog.png)](https://en.uesp.net/wiki/File:Yellow_pog.png) Power Shot [![Hunter's Discipline: 50 Archery. Recover twice as many arrows from dead bodies.](https://images.uesp.net/thumb/a/a1/Yellow_pog.png/12px-Yellow_pog.png)](https://en.uesp.net/wiki/File:Yellow_pog.png) Hunter's Discipline [![Ranger: 60 Archery. Able to move faster with a drawn bow.](https://images.uesp.net/thumb/a/a1/Yellow_pog.png/12px-Yellow_pog.png)](https://en.uesp.net/wiki/File:Yellow_pog.png) Ranger [![Quick Shot: 70 Archery. Can draw a bow 30% faster.](https://images.uesp.net/thumb/a/a1/Yellow_pog.png/12px-Yellow_pog.png)](https://en.uesp.net/wiki/File:Yellow_pog.png) Quick Shot [![Bullseye: 100 Archery. 15% chance of paralyzing the target for a few seconds.](https://images.uesp.net/thumb/a/a1/Yellow_pog.png/12px-Yellow_pog.png)](https://en.uesp.net/wiki/File:Yellow_pog.png) Bullseye Archery Perk Tree | Perk | Rank | Description | [ID](Skyrim_Form_ID.md) | Skill Req. | Perk Req. |
| --- | --- | --- | --- | --- | --- |
| *Overdraw* | 1 | Bows do 20% more damage. | 00 0babed | | |
| 2 | Bows do 40% more damage. | 00 07934a | 20 Archery | | |
| 3 | Bows do 60% more damage. | 00 07934b | 40 Archery | | |
| 4 | Bows do 80% more damage. | 00 07934d | 60 Archery | | |
| 5 | Bows do twice as much damage. | 00 079354 | 80 Archery | | |
| *Critical Shot* | 1 | 10% chance of a critical hit that does extra damage. | 00 105f1c | 30 Archery | Overdraw |
| 2 | 15% chance of a critical hit that does 25% more critical damage. | 00 105f1e | 60 Archery | | |
| 3 | 20% chance of a critical hit that does 50% more critical damage. | 00 105f1f | 90 Archery | | |
| *Hunter's Discipline* | | Recover twice as many arrows from dead bodies. | 00 051b12 | 50 Archery | Critical Shot |
| *Ranger* | | Able to move faster with a drawn bow. | 00 058f63 | 60 Archery | Hunter's Discipline |
| *Eagle Eye* | | Pressing Block while aiming will zoom in your view. | 00 058f61 | 30 Archery | Overdraw |
| *Power Shot* | | Arrows stagger all but the largest opponents 50% of the time. | 00 058f62 | 50 Archery | Eagle Eye |
| *Quick Shot* | | Can draw a bow 30% faster.* | 00 105f19 | 70 Archery | Power Shot |
| *Steady Hand* | 1 | Zooming in with a bow slows time by 25%. | 00 103ada | 40 Archery | Eagle Eye |
| 2 | Zooming in with a bow slows time by 50%. | 00 103adb | 60 Archery | | |
| *Bullseye* | | 15% chance of paralyzing the target for a few seconds.<sup>[†](#intnote_1)</sup> | 00 058f64 | 100 Archery | Ranger *or* Quick Shot |

* Quick Shot also increases arrow nock speed by 92%.

[†](#note_1) The paralysis lasts 10 seconds. This effect is affected by any [Alteration](Skyrim_Alteration.md) modifiers, such as the [Stability](https://en.uesp.net/wiki/Skyrim:Stability) perk. Due to a [bug](#Bugs), triggering the paralysis effect may cause the projectile to miss the target at longer ranges.
## Skill Usage
Arrow damage is the sum of the quality and material of the bow and the arrow being used, augmented by the bow's draw length. Firing an arrow before fully drawing the bow results in a damage penalty of up to 65% when an arrow is minimally drawn. Drawn arrows can be cancelled by pressing the '[Sheath Weapon](Skyrim_Controls.md#Sheath_Weapon)' button.

The trajectory and speed of arrows are independent of a character's skill level in Archery; only damage increases with skill level. When shooting an arrow, you will discover that arrows have significant 'loft', or upwards movement, particularly at medium ranges (See [Notes](#Notes)). To compensate, you should aim just below the intended target. If the target is moving, aim where they are going to be, as arrows are a rather slow projectile. The [Steady Hand](Skyrim_Steady_Hand.md) perk affects neither the speed of the arrow, nor the enemy, so lead your target the same as if time was not slowed. If the target is farther away, then aim slightly above it, as gravity has an influence on trajectory. The [Eagle Eye](Skyrim_Eagle_Eye.md) perk decreases the influence of gravity, so do not aim as high as you would normally. Since there is no hit location recognition in Skyrim, trying to achieve headshots will not cause increased damage, but rather may cause your shot to miss if you do not properly account for the arrow's trajectory.

While you have a bow equipped you cannot block attacks; however, you can perform a melee strike with the bow by pressing the '[Block](Skyrim_Controls.md#Block)' button. Doing so costs 35 [Stamina](Skyrim_Stamina.md) but will stagger the foe, giving you time to set up a shot, flee to a safer distance, or switch to a melee weapon. Additionally, having high skill in Block and the [Deadly Bash](https://en.uesp.net/wiki/Skyrim:Deadly_Bash) perk will cause the strike to inflict significant damage. (5.5 * 5 = 27.5 at 100 skill and Deadly Bash 5x damage perk.)

Most bows and crossbows can be upgraded at a [grindstone](Skyrim_Grindstone.md) based on perks invested in [Smithing](Skyrim_Smithing.md). Arrows and bolts can be crafted if you have the [Dawnguard add-on](Skyrim_Dawnguard.md). You should always be on the lookout for better arrows, as the damage difference between iron and Daedric arrows is significantly larger than between any other iron and Daedric weapon.

There are places where NPCs can sometimes be found doing target practice, and their arrows and/or bolts may be retrieved from the target dummy; for example in [Dragonsreach, Great Porch](Skyrim_Dragonsreach.md), in the courtyard of [Castle Dour](Skyrim_Castle_Dour.md), and in [the cistern area of The Ragged Flagon](Skyrim_The_Ragged_Flagon_-_Cistern.md), or for bolts, [Dayspring Canyon](Skyrim_Dayspring_Canyon.md)<sup>[DG](Skyrim_Dawnguard.md)</sup>.

Arrows and bolts that hit an enemy have a 33% chance of entering their inventory; the [Hunter's Discipline](https://en.uesp.net/wiki/Skyrim:Hunter%27s_Discipline) perk increases this chance of recovery to 66%. Enemy missiles that strike you may also be added to your inventory. If an arrow or bolt fired by you or an enemy misses its intended target, it can almost always be recovered from the ground or a nearby object, if you can find it. Only 15 missed arrows or bolts can be present at once, once a 16th has been fired the first one fired will despawn. Missiles that strike non-flesh enemies, such as skeletons and mudcrabs, will often bounce back toward you. Enemies that break apart upon death (such as skeletons) will drop all the arrows you have shot them with when they die.

### Eagle Eye and Steady Hand
With the [Eagle Eye](Skyrim_Eagle_Eye.md) perk, you can press the [Block](Skyrim_Controls.md#Block) control to zoom in on your target. However, doing so drains your [Stamina](Skyrim_Stamina.md) at a rate of 10 per second, and cannot be maintained indefinitely. With the [Steady Hand](Skyrim_Steady_Hand.md) perk, using Eagle Eye also slows time by a 25% (50% with the second rank), making everything appear to move in slow-motion. This effect allows you more time to think through and set up the shot. Although the action of drawing the bow will occur in slow-motion if you have not nocked the arrow before pressing the Block control, there is an exploit around this that can significantly increase DPS (See [Bugs](#Bugs)). You cannot zoom in while under the effect of the [Slow Time](Skyrim_Slow_Time.md) dragon shout, regardless of whether you have perks in Steady Hand or not.

For differences in [Skyrim VR](Skyrim_Skyrim_VR.md), see the Skyrim VR [section](Skyrim_Archery.md#Skyrim_VR) of this article.

### Draw Speed
Firing a bow has 5 stages:

1. **Nock** the arrow.
2. **Draw** the bow.
3. **Idle** with a fully-drawn bow.
4. **Release** the arrow.
5. Returning to the **Resting** animation.

1. At 60 fps, regardless of bow Speed, nocking an arrow takes 48 frames(0.8 seconds) or 25 frames(0.417 seconds) with Quick Shot.*

2. After the arrow is nocked the drawing stage begins. The duration of the drawing stage is divided by 1.3 if the Quick Shot perk is unlocked. The drawing stage is composed of two parts: the initial/minimal draw and the full draw. The initial draw is the minimum amount of time after nocking an arrow before it can actually be released, and lasts 12 frames(0.2 seconds) by default. If the attack button is not held roughly until this stage ends it will deal 35% damage. After the initial draw, the full draw stage begins and the damage of the attack jumps to 50% then increases linearly to 100% throughout its duration, which lasts 40 frames(0.667 seconds) by default.

3. Once the drawing stage is complete the player will enter an idle animation from which they can release the arrow at any time.

4. The animation for releasing the arrow lasts 38 frames(0.633 seconds), after which the player can either begin to nock another arrow or do nothing and return to their character's resting animation.

5. The time between the end of the release phase and the resting animation is 22 frames(0.367 seconds).

The Speed stat of a bow only affects the drawing stage. The base duration of the drawing stage(0.2 seconds + 0.667 seconds = 0.867 seconds) is divided by the Speed stat of the bow to determine the actual draw duration for the bow.

When repeatedly fully-drawing a bow the total time per shot is:

```
Full Draw Time = Nock + Draw + Release = 0.8 + 0.867/Speed + 0.633 = 1.433 + 0.867/Speed seconds.

```
If the Quick Shot perk is unlocked, the time per shot is:

```
Full Draw Time(Quick Shot) = 0.417 + 0.867/(1.3 * Speed) + 0.633 = 1.05 + 0.667/Speed seconds.

```
If the player is a Necromage Vampire and unlocks Quick Shot, the time per shot is:

```
Full Draw Time(NV Quick Shot) = 0.417 + 0.867/(1.625 * Speed) + 0.633 = 1.05 + 0.533/Speed seconds.

```
Quick Shot works by modifying Weapon Speed Mult, and other sources that modify it will generally also increase draw speed. This includes [Survival Mode's](Skyrim_Survival_Mode.md) [Hunger](Skyrim_Hunger.md) penalties and the [Bow of Shadows'](Skyrim_Bow_of_Shadows_(item).md) Quick Shot enchantment.

Weapon Speed Mult=0 by default, however Weapon Speed Mult=0, 1, or a negative number are identical under normal circumstances: affected animations will play at 100% speed. Otherwise, weapon swing and draw animations are slowed-down or sped-up. For example, a value of 0.9 will result in affected animations playing at 90% speed and a value of 1.3 will result in animations playing at 130% speed.

Due to an oversight, Weapon Speed Mult modifiers typically stack improperly, enabling higher draw and swing speeds than intended. In nearly all cases, modifiers add to the Weapon Speed Mult value instead of multiplying it. For example, Quick Shot adds 1.3, Survival Mode's Peckish effect adds 0.9, and Bow of Shadows' perk adds 1.2. When all three of these are simultaneously active:

```
Weapon Speed Mult = 1.3 + 0.9 + 1.2 = 3.4

```
resulting in a bow's draw animation playing at 340% speed instead of the intuitively expected:

```
100% + 30% - 10% + 20% = 140%

```
* The speed-up of the Nock stage from Quick Shot is effectively "hard-coded" and doesn't benefit from things like Necromage Vampirism.

### Detailed Bow Comparison
| Name | Base Damage | Weight | Speed | Time (s) | DPS | QS Time (s) | QS DPS | Best Base DPS |
| --- | --- | --- | --- | --- | --- | --- | --- | --- |
| [Amber Bow](https://en.uesp.net/wiki/Skyrim:Amber_Bow)<sup>[CC](Skyrim_Saints_%26_Seducers.md)</sup> | 20 | 14 | 0.5 | 3.17 | 6.32 | 2.38 | 8.39 | 18.88 |
| [Ancient Nord Bow](https://en.uesp.net/wiki/Skyrim:Ancient_Nord_Bow) <br> (includes [Gauldur Blackbow](https://en.uesp.net/wiki/Skyrim:Gauldur_Blackbow) levels 1-18) | 8 | 12 | 0.875 | 2.42 | 3.30 | 1.81 | 4.42 | 18.21 |
| [Auriel's Bow](Skyrim_Auriel%27s_Bow.md)<sup>[DG](Skyrim_Dawnguard.md)</sup> | 13 | 11 | 1 | 2.3 | 5.65 | 1.72 | 7.57 | 22.14 |
| [Bound Bow](Skyrim_Bound_Weapon.md) | 18 | 0 | 0.875 | 2.42 | 7.43 | 1.81 | 9.93 | 23.73 |
| [Bound Bow <sup>(Mystic)</sup>](Skyrim_Bound_Weapon.md) | 24 | 0 | 0.875 | 2.42 | 9.90 | 1.81 | 13.25 | 27.04 |
| [Bow of Shadows](Skyrim_Bow_of_Shadows_(item).md)<sup>[CC](Skyrim_Bow_of_Shadows.md)</sup> | 19 | 18 | 0.9375 | 1.82* | 10.44* | 1.42* | 13.38* | 30.99* |
| [Bow of the Hunt](https://en.uesp.net/wiki/Skyrim:Bow_of_the_Hunt) | 10 | 7 | 0.9375 | 2.36 | 4.24 | 1.76 | 5.68 | 19.87 |
| [Daedric Bow](https://en.uesp.net/wiki/Skyrim:Daedric_Bow) | 19 | 18 | 0.5 | 3.17 | 6.00 | 2.38 | 7.97 | 18.46 |
| [Dark Bow](https://en.uesp.net/wiki/Skyrim:Dark_Bow)<sup>[CC](Skyrim_Saints_%26_Seducers.md)</sup> | 13 | 10 | 0.5 | 3.17 | 4.11 | 2.38 | 5.45 | 15.94 |
| [Dragonbone Bow](https://en.uesp.net/wiki/Skyrim:Dragonbone_Bow)<sup>[DG](Skyrim_Dawnguard.md)</sup> | 20 | 20 | 0.75 | 2.59 | 7.73 | 1.94 | 10.32 | 23.21 |
| [Drainspell Bow](https://en.uesp.net/wiki/Skyrim:Drainspell_Bow) | 14 | 6 | 0.875 | 2.42 | 5.78 | 1.81 | 7.73 | 21.52 |
| [Dwarven Bow](https://en.uesp.net/wiki/Skyrim:Dwarven_Bow) | 12 | 10 | 0.75 | 2.59 | 4.64 | 1.94 | 6.19 | 19.08 |
| [Dwarven Black Bow of Fate](https://en.uesp.net/wiki/Skyrim:Dwarven_Black_Bow_of_Fate)<sup>[DB](Skyrim_Dragonborn.md)</sup> | 13 | 10 | 0.75 | 2.59 | 5.02 | 1.94 | 6.70 | 19.60 |
| [Ebony Bow](https://en.uesp.net/wiki/Skyrim:Ebony_Bow) | 17 | 16 | 0.5625 | 2.97 | 5.72 | 2.24 | 7.61 | 18.79 |
| [Elven Bow](https://en.uesp.net/wiki/Skyrim:Elven_Bow) (includes [Firiniel's End](https://en.uesp.net/wiki/Skyrim:Firiniel%27s_End)) | 13 | 12 | 0.6875 | 2.69 | 4.83 | 2.02 | 6.44 | 18.81 |
| [Falmer Bow](https://en.uesp.net/wiki/Skyrim:Falmer_Bow) | 12 | 15 | 0.75 | 2.59 | 4.64 | 1.94 | 6.19 | 19.08 |
| [Falmer Supple Bow](https://en.uesp.net/wiki/Skyrim:Falmer_Supple_Bow) | 15 | 20 | 0.75 | 2.59 | 5.79 | 1.94 | 7.74 | 20.63 |
| [Forsworn Bow](https://en.uesp.net/wiki/Skyrim:Forsworn_Bow) | 12 | 11 | 0.875 | 2.42 | 4.95 | 1.81 | 6.62 | 20.42 |
| [Glass Bow](https://en.uesp.net/wiki/Skyrim:Glass_Bow) | 15 | 14 | 0.625 | 2.82 | 5.32 | 2.12 | 7.09 | 18.90 |
| [Glass Bow of the Stag Prince](https://en.uesp.net/wiki/Skyrim:Glass_Bow_of_the_Stag_Prince)<sup>[DB](Skyrim_Dragonborn.md)</sup> | 16 | 14 | 0.625 | 2.82 | 5.67 | 2.12 | 7.56 | 19.37 |
| [Golden Bow](https://en.uesp.net/wiki/Skyrim:Golden_Bow)<sup>[CC](Skyrim_Saints_%26_Seducers.md)</sup> | 11 | 10 | 0.5 | 3.17 | 3.47 | 2.38 | 4.62 | 15.10 |
| [Hunting Bow](https://en.uesp.net/wiki/Skyrim:Hunting_Bow) (includes [Angi's Bow](https://en.uesp.net/wiki/Skyrim:Angi%27s_Bow) and [Dravin's Bow](https://en.uesp.net/wiki/Skyrim:Dravin%27s_Bow)) | 7 | 7 | 0.9375 | 2.36 | 2.97 | 1.76 | 3.97 | 18.17 |
| [Imperial Bow](https://en.uesp.net/wiki/Skyrim:Imperial_Bow) | 9 | 8 | 0.875 | 2.42 | 3.71 | 1.81 | 4.97 | 18.76 |
| [Karliah's Bow](https://en.uesp.net/wiki/Skyrim:Karliah%27s_Bow) | 25 | 9 | 0.625 | 2.82 | 8.87 | 2.12 | 11.81 | 23.62 |
| [Long Bow](https://en.uesp.net/wiki/Skyrim:Long_Bow) (includes [Froki's Bow](https://en.uesp.net/wiki/Skyrim:Froki%27s_Bow)) | 6 | 5 | 1 | 2.3 | 2.61 | 1.72 | 3.50 | 18.06 |
| [Madness Bow](https://en.uesp.net/wiki/Skyrim:Madness_Bow)<sup>[CC](Skyrim_Saints_%26_Seducers.md)</sup> | 21 | 21 | 0.5 | 3.17 | 6.63 | 2.38 | 8.81 | 19.30 |
| [Nightingale Bow](https://en.uesp.net/wiki/Skyrim:Nightingale_Bow)<sup>levels 1-18</sup> | 12 | 9 | 0.5 | 3.17 | 3.79 | 2.38 | 5.03 | 15.52 |
| [Nightingale Bow](https://en.uesp.net/wiki/Skyrim:Nightingale_Bow)<sup>levels 19-26</sup> | 13 | 11 | 0.5 | 3.17 | 4.11 | 2.38 | 5.45 | 15.94 |
| [Nightingale Bow](https://en.uesp.net/wiki/Skyrim:Nightingale_Bow)<sup>levels 27-35</sup> | 15 | 13 | 0.5 | 3.17 | 4.74 | 2.38 | 6.29 | 16.78 |
| [Nightingale Bow](https://en.uesp.net/wiki/Skyrim:Nightingale_Bow)<sup>levels 36-45</sup> | 17 | 15 | 0.5 | 3.17 | 5.37 | 2.38 | 7.13 | 17.62 |
| [Nightingale Bow](https://en.uesp.net/wiki/Skyrim:Nightingale_Bow)<sup>levels 46+</sup> | 19 | 18 | 0.5 | 3.17 | 6 | 2.38 | 7.97 | 18.46 |
| [Nord Hero Bow](https://en.uesp.net/wiki/Skyrim:Nord_Hero_Bow) | 11 | 7 | 0.875 | 2.42 | 4.54 | 1.81 | 6.07 | 19.87 |
| [Nordic Bow](https://en.uesp.net/wiki/Skyrim:Nordic_Bow)<sup>[DB](Skyrim_Dragonborn.md)</sup> | 13 | 11 | 0.6875 | 2.69 | 4.83 | 2.02 | 6.44 | 18.81 |
| [Orcish Bow](https://en.uesp.net/wiki/Skyrim:Orcish_Bow) | 10 | 9 | 0.8126 | 2.50 | 4.00 | 1.87 | 5.35 | 18.71 |
| [Ruin's Edge](Skyrim_Ruin%27s_Edge_(item).md)<sup>[CC](Skyrim_Ruin%27s_Edge.md)</sup> | 12 | 7 | 0.875 | 2.42 | 4.95 | 1.81 | 6.62 | 20.42 |
| [Stalhrim Bow](https://en.uesp.net/wiki/Skyrim:Stalhrim_Bow)<sup>[DB](Skyrim_Dragonborn.md)</sup> | 17 | 15 | 0.5625 | 2.97 | 5.72 | 2.24 | 7.61 | 18.79 |
| [Supple Ancient Nord Bow](https://en.uesp.net/wiki/Skyrim:Supple_Ancient_Nord_Bow) <br> (includes [Gauldur Blackbow](https://en.uesp.net/wiki/Skyrim:Gauldur_Blackbow) levels 19+) | 14 | 18 | 0.875 | 2.42 | 5.78 | 1.81 | 7.73 | 21.52 |
| [Zephyr](https://en.uesp.net/wiki/Skyrim:Zephyr)<sup>[DG](Skyrim_Dawnguard.md)</sup> | 12 | 10 | 1 | 2.3 | 5.22 | 1.72 | 6.99 | 21.55 |

- Bow of Shadows' Quick Shot enchantment gives it a 1.2 Speed multiplier without Archery's Quick Shot perk and a 2.5 multiplier with it.

Note that the base damage and DPS *does not* include any damage added from the enchantments that exist on some of the unique bows listed.

The equation to easily work out your potential dps is

```
(bow damage + arrow damage) / time

```
As you can see above, bound bows have some of the highest dps in the game, but because they cannot be tempered other bows will eventually out-damage them with higher levels of Smithing. When using low damage arrows such as iron, bows with higher base damage typically deal more DPS, however when using high damage arrows like dragonbone, Speed becomes more important. As seen above, with dragonbone arrows an imperial bow deals higher dps than a daedric bow because despite having 10 less base damage it attacks about 1.3 times as fast.

A tempered hunting bow will eventually do more dps than all other bows except Angi's Bow, Dravin's Bow, Bow of the Hunt, Zephyr, and Auriel's Bow, due to their high draw speeds and benefiting from Smithing perks. Bow of Shadows' dps is heavily restricted later in the game due to it not benefiting from a Smithing double-improvement perk. Despite the daedric bow's high damage, its low draw speed limits its dps. Auriel's Bow ends up the best bow in the game for physical dps, though potentially weaker than a hunting bow with powerful custom enchantments. Karliah's Bow has the highest base damage of any bow, however it cannot be obtained through normal gameplay and is not visible in the player's inventory even if obtained through console commands. The dragonbone bow is a good compromise between speed and damage, and it is more than sufficient at higher levels. It has the high base damage that is used for sneak attack calculations (the low base damage of Auriel's may not be enough to one-shot-kill many enemies). The dragonbone bow has the added benefit over Zephyr and Auriel's Bow of being enchantable, allowing you your own custom enchantments that, with sufficient skill in enchanting, can push its dps well above the others.

### Draw Time and Damage Dealt
The damage an attack deals depends on how long the attack button is held before the arrow is released. An arrow can deal 35%, between 50% and 100% damage(non-inclusive), or 100% damage.

With t = the time the attack button is held in frames(1/60 of a second) the % damage dealt is approximately*:

```
35% if t<50+12/(Speed*Weapon Speed Mult)

```

```
100% if t>50+52/(Speed*Weapon Speed Mult)

```

```
(100/80)*(28+Speed*Weapon Speed Mult*(t-50))% otherwise

```
To calculate using seconds, replace t by 60t in the formula.

Comparing this formula and the Draw Time formula in the Draw Speed section shows that there is actually a desync between the damage build-up and the actual animation of drawing a bow. Without Quick Shot, the attack button must be held an additional 2 frames(0.033 seconds) after the drawing animation completes to deal 100% damage, which is insignificant and isn't likely to be noticed or cause confusion. With Quick Shot however, the attack button must be held for 25 frames(0.417 seconds) after the drawing animation ends in order to deal full damage.

So to deal full damage simply hold the attack button until you enter the Idle animation or hold it for an extra 0.4 seconds if you've unlocked the Quick Shot perk.

* The non-35%/100% formula's error is typically between -0.1% and +0.2%. This may be due to floor functions or rounding errors.

### Range and Trajectory
The primary factor affecting your *maximum* range is the global game setting `f Visible Navmesh Move Dist`; past this distance, your arrows will "phase through" targets without doing any damage. The default value is 4096 distance units (for reference, a weapon with a reach of "1" has a reach of 141 distance units, by default). This issue has been addressed by the [Unofficial Skyrim Patch](https://en.uesp.net/wiki/Skyrim:Mod_Unofficial_Skyrim_Patch); it triples the default, to 12288, which should always be enough that the arrow will always impact anything it can reach. The second most important factor is the [projectile](Skyrim_Ammunition.md); it has a maximum range (which is typically not relevant, but can matter for the Riekling Spear<sup>[DB](Skyrim_Dragonborn.md)</sup>, which has a maximum range of 4000 - most projectiles have ranges measured in the tens of thousands), a speed, which determines how quickly the projectile travels, and a gravity value, which determines how quickly the projectile drops (higher is faster, for both). Gravity tends to be the same for all of your arrows and bolts, but bolts travel *significantly* faster - the [ammunition](Skyrim_Ammunition.md) page covers these values.

The primary factor affecting your trajectory is the set of global game settings:

- `f1PArrow Tilt Up Angle`; default `2`.
- `f3PArrow Tilt Up Angle`; default `2.5`.
- `f1PBolt Tilt Up Angle`; default `1`.
- `f3PBolt Tilt Up Angle`.

These set the angle your projectiles fire at from bows (the `Arrow` settings) and crossbows<sup>[DG](Skyrim_Dawnguard.md)</sup> (`Bolt`) in the first-person (`1P`) and third-person (`3P`) perspectives. A value of `0` is initially flat, along the *bottom* of the targeting reticle. Positive values tilt the projectile up. See the Notes section below for optimization.

Range and Trajectory are also affected by bow speed. On a full draw, slower bows will shoot arrows higher and with less drop, while faster bows will shoot arrows lower with more drop. This means that at short ranges, arrows shot from faster bows will be more accurate to the crosshairs, while slower bows will shoot high. At long ranges, arrows shot from faster bows will drop considerably, requiring you to aim higher to compensate. Slower bows will hit the target much closer to the crosshairs—though you may still need to compensate for drop depending on the range. Also, slower bows have a flatter ballistic trajectory, which means they will travel further than arrows shot from a faster bow. This effect comes solely from weapon speed—other factors such as weight and damage do not play a role. You can see a comparison of the weapon speeds of many bows [here](Skyrim_Bow.md). Of further note, the perk [Quick Shot](Skyrim_Quick_Shot.md) has no effect on range and trajectory, but [Eagle Eye](Skyrim_Eagle_Eye.md) *does*, as it effectively decreases the gravity value of the projectile.

## [Skyrim VR](Skyrim_Skyrim_VR.md)
[![](https://images.uesp.net/thumb/a/af/SR-place-VR_Playroom_Archery.jpg/200px-SR-place-VR_Playroom_Archery.jpg)](https://en.uesp.net/wiki/File:SR-place-VR_Playroom_Archery.jpg) [](https://en.uesp.net/wiki/File:SR-place-VR_Playroom_Archery.jpg) VR Archery In Skyrim VR, equipping a bow will place the bow in the off-hand and the weakest available arrows in the main hand, though a different set of arrows can be selected. Bring the arrow to the bow string, then press and hold Right Attack/Block on the controller to nock the arrow. Draw the bow back and release Right Attack/Block to fire. To cancel a shot, bring the arrow back to its original position and release Right Attack/Block.

In VR Settings you can choose Realistic Bow Aiming. With this option turned on, you can aim with both hands instead of just one. After you've nocked your arrow you can move it around with your arrow hand to change the direction the arrow will fire. When you do, this will rotate the bow as well. You can also still position your bow by moving your bow hand, but your arrow hand will ultimately determine the direction the arrow flies when you release Right Attack/Block. With Realistic Bow Aiming turned off, your arrow will shoot straight forward in the direction you're aiming with your bow hand.

You can perform a weak bash attack by punching the target with the equipped bow. Like in non-VR versions of the game, a partially drawn bow does less damage and doesn't travel as far.

Crossbows are held in the main hand, and are fired by pressing Right Attack/Block. Unlike bows, bolts cannot be held in the off-hand and are reloaded automatically once fired.

The [Eagle Eye](Skyrim_Eagle_Eye.md) perk behaves differently in VR. Its description is changed to read "Pressing Block (or Trigger on your offhand Motion Controller) while aiming will activate Eagle Eye." Activating Eagle Eye displays a trajectory line and crosshair, showing you precisely where your arrow will land. Note that crossbows will need the fire button to be held down as well before Eagle Eye will trigger for them.

An archery range is present in the main menu [Playroom](https://en.uesp.net/wiki/Skyrim:Playroom) area for practicing VR archery before starting the game.

## Skill Increases

### Character Creation
The following [races](Skyrim_Races.md) have an initial skill bonus to Archery:

- +10 bonus: [Bosmer](Skyrim_Wood_Elf.md)
- +5 bonus: [Khajiit](Skyrim_Khajiit.md), [Redguard](Skyrim_Redguard.md)

### Trainers
- [Faendal](Skyrim_Faendal.md) in [Riverwood](Skyrim_Riverwood.md) (Common)
- [Aela the Huntress](Skyrim_Aela_the_Huntress.md) of the [Companions](Skyrim_Companions.md) in [Whiterun](Skyrim_Whiterun.md) (Expert)
- [Niruin](Skyrim_Niruin.md) of the [Thieves Guild](Skyrim_Thieves_Guild_(faction).md) in [Riften](Skyrim_Riften.md) (Master)
- [Sorine Jurard](https://en.uesp.net/wiki/Skyrim:Sorine_Jurard)<sup>[DG](Skyrim_Dawnguard.md)</sup> in [Fort Dawnguard](Skyrim_Fort_Dawnguard.md)<sup>[DG](Skyrim_Dawnguard.md)</sup> (Master)

### Skill Books
- *[The Black Arrow, v2](https://en.uesp.net/wiki/Skyrim:The_Black_Arrow,_v2)*
- *[Father Of The Niben](https://en.uesp.net/wiki/Skyrim:Father_Of_The_Niben)*
- *[The Gold Ribbon of Merit](https://en.uesp.net/wiki/Skyrim:The_Gold_Ribbon_of_Merit)*
- *[The Marksmanship Lesson](https://en.uesp.net/wiki/Skyrim:The_Marksmanship_Lesson)*
- *[Vernaccus and Bourlor](https://en.uesp.net/wiki/Skyrim:Vernaccus_and_Bourlor)*

### [Free Skill Boosts](Skyrim_Free_Skill_Boosts.md)
- +1 Archery (and other combat skills) from [Giraud Gemane](Skyrim_Giraud_Gemane.md) ([Bards College](Skyrim_Bards_College.md)) for completing the quest [Rjorn's Drum](https://en.uesp.net/wiki/Skyrim:Rjorn%27s_Drum).
- +1 Archery (and Block, Heavy Armor, and One-handed) from [Wulf Wild-Blood](https://en.uesp.net/wiki/Skyrim:Wulf_Wild-Blood)<sup>[DB](Skyrim_Dragonborn.md)</sup> for finding his brother during [Filial Bonds](https://en.uesp.net/wiki/Skyrim:Filial_Bonds)<sup>[DB](Skyrim_Dragonborn.md)</sup>.
- +5 Archery (and other combat skills) by selecting "The Path of Might" from the [Oghma Infinium](Skyrim_Oghma_Infinium.md) after completing the quest [Discerning the Transmundane](https://en.uesp.net/wiki/Skyrim:Discerning_the_Transmundane).
- +6 Archery in total from [Angi](https://en.uesp.net/wiki/Skyrim:Angi) for completing a series of archery challenges. There are four challenges; the first one gives three points and all the others one point each.

### Gaining Skill Experience
- Experience gain in weapon skills are determined by the base damage of the equipped weapon and whether or not the attack dealt damage. You can increase your skill level faster by choosing the bow with the highest dps available to you according to the above chart. Archery level, Archery perks, Fortify Archery enchantments, Fortify Marksman potions, arrows, fully drawing an arrow, sneak attack modifiers, weapon tempering, and difficulty settings have no effect on the XP gained per hit.

The equation governing skill gain in Archery is thought to resemble something like this:

Bwd = Base weapon damage

lm = Leveling Multiplier (rest, stone, etc.)

x = Damage Translator

bool(Damaging Hit) = 1 or 0, true or false

skill XP += bool(Damaging Hit) * (lm(Bwd) / x)

## Dialogue
- If your Archery skill is over level 30, guards will occasionally say: *"Favor the bow, eh? I'm a sword man myself..."*
- If you have a bow and arrows equipped, guards may also say *"Keep your arrows in your quiver, archer"*.

## Notes
- Despite being classified as a combat skill, Archery receives skill gain boosts from the [Thief Stone](Skyrim_Standing_Stones.md) rather than the Warrior Stone. - ![PC Only](https://images.uesp.net/d/d7/Computer.svg)
The [Unofficial Skyrim Patch](https://en.uesp.net/wiki/Skyrim:Mod_Unofficial_Skyrim_Patch), version 1.2, addresses this issue. It is now boosted by the Warrior Stone perk.
- The movement speed with a drawn bow (shot ready) is reduced in comparison to Oblivion, making archers less mobile. The [Ranger](Skyrim_Ranger_(perk).md) perk is available to compensate for this. Note that this perk only increases running speed; walking speed is unaffected.
- Unlike in Morrowind and Oblivion, you can now put an arrow back into its quiver by holding the attack button and pressing the draw/sheath button. - If you have *Dawnguard* installed and have a crossbow equipped, you can do the same with your crossbow bolts.
- Arrows will remain equipped (and appear on the back of your character accordingly) even if you have unequipped the bow. This will enable you to pin your bow of choice and melee weapon or spell of choice to your favorites menu, and swap between them on the fly, without having to re-equip your arrows. - If you have *Dawnguard* installed and unequip a crossbow, your crossbow bolts will be treated the same way.
- When you equip a bow, the weakest arrows in your inventory will automatically equip themselves by default. You can either go into your inventory and select stronger arrows manually, or assign them to your favorites menu, and equip them from there. - If you have *Dawnguard* installed and equip a crossbow, your weakest crossbow bolts will also auto-equip themselves, though you can change them with the same methods listed above.
- Arrows are not accurate to the center pointer. The arrow shoots slightly above the crosshair. Use the archery practice targets to see the exact dynamics for different ranges. By comparison, crossbow bolts<sup>[DG](Skyrim_Dawnguard.md)</sup> are much more precise. - [![On PC](https://images.uesp.net/d/d7/Computer.svg)](https://www.wikipedia.org/wiki/PC_game) Arrows can be forced to shoot through the center point by modifying (or adding, if they don't exist) a few lines in **Skyrim.ini**, in the My Documents folder. Also, setting `f Visible Navmesh Move Dist` to a high value (above ~10000) allows you to hit targets with arrows as far as the arrow can fly, rather than passing through targets (without causing damage) at long distances:

**Skyrim.ini** `[Combat]` `f1PArrow Tilt Up Angle=0.7` `f3PArrow Tilt Up Angle=0.7` `[Actor]` `f Visible Navmesh Move Dist=14000.0000` - [![On PC](https://images.uesp.net/d/d7/Computer.svg)](https://www.wikipedia.org/wiki/PC_game) Alternatively, if Dawnguard is installed:

**Skyrim.ini** `[Combat]` `f1PArrow Tilt Up Angle=0.7` `f3PArrow Tilt Up Angle=0.7` `f1PBolt Tilt Up Angle=0.7` `f3PBolt Tilt Up Angle=0.7` `[Actor]` `f Visible Navmesh Move Dist=14000.0000` - Note: apparently the draw distance of the game is initialized badly, because if you keep it at the default from the very start of the game of a fresh install, then setting `f Visible Navmesh Move Dist` to a higher value doesn't have any effect. If you max out the draw distances, then it will have an effect. If afterwards you move draw distance to minimum again, `f Visible Navmesh Move Dist` will continue to have an effect.
- Arrows can be used as distractions. If you have not been spotted by an enemy, shooting an arrow will make them investigate the point of impact. Be aware, however, that after checking out where the arrow hit they may investigate where it was shot from. Make sure to either kill them quickly, distract them again, or move to safety.
- Archery is one of two skills which has a different Console ID than the name, the other being [Speech](Skyrim_Speech.md). The actual Console ID for Archery is `Marksman`. For example, the Console code for improving Archery is `Advance PCskill Marksman <#>`. The term "Marksman" also appears in a few other contexts, e.g. [Fortify Marksman](https://en.uesp.net/wiki/Skyrim:Fortify_Marksman).
- Having high skill in Block in conjunction with the Deadly Bash perk can be useful for an archer. At 0 Block skill, bow bashing only does 1.1 damage, but at 100 Block skill a bow bash does 5.5 damage. With Deadly Bash perk, the 5x damage multiplier brings the bash damage up to 27.5. Bow type does not affect the damage magnitude.
- Another perk exists in the [Creation Kit](https://en.uesp.net/wiki/Skyrim:Mod_Creation_Kit) but was removed from the game before release. It is called "Trick Shot", and would have been available at 80 Archery skill if the "Quick Shot" perk has already been unlocked. The description for Trick Shot is: "25% chance to disarm an opponent." - [![On PC](https://images.uesp.net/d/d7/Computer.svg)](https://www.wikipedia.org/wiki/PC_game) You can give yourself the perk using the Console command `Add Perk 105f1a`. It won't appear in your skills menu, but it does work.
- Using the [Secret of Strength](https://en.uesp.net/wiki/Skyrim:Secret_of_Strength)<sup>[DB](Skyrim_Dragonborn.md)</sup> power will allow you to be able to use the zoom and slow time abilities gained from their respective Eagle Eye and Steady Hand perks, without using your stamina, for the duration of the power's effect.
- Crossbows<sup>[DG](Skyrim_Dawnguard.md)</sup> are deadlier than most bows, as the standard Crossbow has the same base damage as a Daedric Bow. However, they fire 25% more slowly.
- If you have *Dawnguard* installed, the Quick Shot perk will allow you to reload your crossbows faster.
- The Power Shot perk description is misleading. While it claims that arrows will stagger "all but the biggest targets 50% of the time", it actually staggers *all* targets (including [Dwarven Centurions](Skyrim_Dwarven_Centurion.md), [Mammoths](Skyrim_Mammoth.md) and even [Dragons](Skyrim_Dragon.md)) 50% of the time. - Crossbows<sup>[DG](Skyrim_Dawnguard.md)</sup> have a built-in 50% chance to stagger enemies. The Power Shot perk raises the probability to 75%.
- If [Survival Mode](Skyrim_Survival_Mode.md) is active, higher [Hunger](Skyrim_Hunger.md) levels will cause you to shoot bows and crossbows<sup>[DG](Skyrim_Dawnguard.md)</sup> more slowly if you do not have the Quick Shot perk unlocked, and more quickly with it.

## Bugs
- If you equip a greatsword and crossbow bolts together, your greatsword will cut through the quiver.
- The *Damage* stat in the *Weapons* menu is inaccurate when arrows are equipped and Fortify Archery enchantments are in effect. Arrows actually benefit from Fortify Archery enchantments, and all other Archery buffs, despite what the *Damage* stat would indicate. <sup>**?**</sup>
- While drawing the bow from its starting point under the slow time effect of *Steady Hand*, the damage modifier of the bow will increase in real time if you release the block command simultaneously with the attack command. Thus, if you learn the maximum draw time in real time, this allows you to use Steady Hand while you draw and release the arrow "early", which deals full damage with full trajectory. Note that the bow will behave as intended if you release the arrow while still holding the block command. <sup>**?**</sup>
- *Bullseye*'s chance to activate is actually 16%. - ![PC Only](https://images.uesp.net/d/d7/Computer.svg)
The [Unofficial Skyrim Patch](https://en.uesp.net/wiki/Skyrim:Mod_Unofficial_Skyrim_Patch), version 1.1, fixes this bug.
- The *Bullseye* perk actually works by sending out an instant Paralyze spell which strikes the target when an arrow is fired from a bow rather than when the arrow strikes the target. The negative effect of this is that if the bow is fired from a large enough distance, the target will instantly become paralyzed and fall to the ground before the arrow reaches them, causing the arrow to miss the target it supposedly paralyzed. - The [Unofficial Skyrim Special Edition Patch](https://en.uesp.net/wiki/Skyrim:Mod_Unofficial_Skyrim_Special_Edition_Patch), version 4.3.2, fixes this bug.
- If you quickload while zooming with a bow, it will cause time in the loaded game to pass at the same rate as if you were zooming. This can sometimes continue even when you run out of stamina. Zooming again turns it back to normal.
- Sometimes while nocking an arrow, the arrow may not appear.
- Occasionally the perk *Ranger* will not seem to function if you unlock it while crouching. Be sure to be in a standing position when unlocking this perk.
- The cinematic kill camera causes a wrong starting position for the bow/arrow. If you are shooting from the rim of a ledge, the kill camera effect will start but then immediately end with the arrow striking the ledge even though a normal shot without kill camera would not be blocked.
- In close range with an enemy, right after firing an arrow that was fully drawn, you can make a bash attack which is treated as a fully drawn arrow attack. This applies the paralysis effect, any enchantments on the bow, and also raises the Archery skill rather than the Block skill. Note that you have approximately 0.5 seconds after releasing the arrow to perform the bash for the extra damage.
- The range of Archery is internally broken, stopping at what seems to be long range, where the arrow will still appear, but cannot hit any entities. - ![PC Only](https://images.uesp.net/d/d7/Computer.svg)
The [Unofficial Skyrim Patch](https://en.uesp.net/wiki/Skyrim:Mod_Unofficial_Skyrim_Patch), version 2.0.5, fixes this bug.

- [![On PC](https://images.uesp.net/d/d7/Computer.svg)](https://www.wikipedia.org/wiki/PC_game) Apply the changes to Skyrim.ini mentioned in the Notes section.
- [![On Xbox](https://images.uesp.net/3/33/Xbox.svg)](Skyrim_Xbox.md) If you press (RT then release, hold RT, tap X) for crossbows, it will completely ignore reload and shoot up to around 2 bolts a second.
- Occasionally, when you perform a sneak-attack cinematic kill shot while zooming in with the Eagle Eye perk, your Stamina will be completely drained after the cinematic finishes.
- Making the Archery skill legendary does not actually remove the Ranger or Quick Shot perk effects.
- If you tap the attack button after releasing an arrow, but before the bow returns to the rest position, the bow will draw an arrow to full draw and stop. Tapping the attack button again will release the arrow.
- Occasionally, an arrow that misses its target and falls into water will rest on the surface of the water as if it were a solid surface, rather than bobbing on top of the water or flowing downstream with the current. <sup>**?**</sup> - Saving and reloading the game will cause the arrow to behave normally.
- The in-game descriptions for Steady Hand ranks 1 and 2 say that zooming slows time by 25% and 50%, respectively, but the actual magnitudes are 50% and 75%. **Mod Notes**: Ranks 1 and 2 correspond to abilities Perk Steady Hand Time Slowdown01 and Perk Steady Hand Time Slowdown02, which decrease actor value Bow Speed Bonus by 0.5 and 0.25, respectively. At rank 2, both abilities are in effect. Bow Speed Bonus changes can be confirmed in-game on PC with console command "player.getav Bow Speed Bonus". This bug entry merely notes the discrepancy and makes no claim as which set of magnitudes was intended. - ![PC Only](https://images.uesp.net/d/d7/Computer.svg)
The [Unofficial Skyrim Patch](https://en.uesp.net/wiki/Skyrim:Mod_Unofficial_Skyrim_Patch), version 2.1.2, addresses this issue. ([details](https://afktrack.afkmods.com/index.php?a=issues&i=18969)) The text was changed to reflect the actual magnitudes.
- [![Flag Germany.png](https://images.uesp.net/thumb/9/90/Flag_Germany.png/22px-Flag_Germany.png)](https://en.uesp.net/wiki/File:Flag_Germany.png) [![Flag France.png](https://images.uesp.net/thumb/c/c0/Flag_France.png/22px-Flag_France.png)](https://en.uesp.net/wiki/File:Flag_France.png) The German and French translations of Steady Hand incorrectly indicate that either half (level 1) or no (level 2) Stamina will be drained while using it.
- After saving and then reloading, arrows that have been fired at missed targets will be standing upright. This makes arrow retrieval much easier compared to ones normally lying about in the terrain.
- If you start the game or reload with a crossbow equipped, a third-person camera error may cause one to appear between the middle and ring finger of your right hand. - Draw and sheath your crossbow, change weapons, or go airborne. The stray bolt should disappear.