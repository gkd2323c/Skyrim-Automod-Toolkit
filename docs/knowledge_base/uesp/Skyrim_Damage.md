# Damage


## Environmental Damage
Environmental Damage refers to damage caused by the environment, such as falling and drowning.

### Fall Damage
[![](https://images.uesp.net/thumb/a/a3/SR-graph-Falling_Damage.png/200px-SR-graph-Falling_Damage.png)](https://en.uesp.net/wiki/File:SR-graph-Falling_Damage.png) [](https://en.uesp.net/wiki/File:SR-graph-Falling_Damage.png) Graph illustrating falling damage Falling from a high place can damage your health or kill you. By default, the amount of damage caused by falling is calculated as:

```
Player falling damage = ((height - 600) * 0.1)1.45 * modifiers
```
The *[Cushioned](https://en.uesp.net/wiki/Skyrim:Cushioned)* [Heavy Armor](Skyrim_Heavy_Armor.md) perk reduces falling damage by half.

The internal height units are 64 per yard. The second story of a house is about 4 yards up. The graph shows falling damage (without the perk) by height in yards.

A fall of up to about 9 yards will not hurt you; however, the range of heights from which falling will hurt but not kill you is fairly narrow. In general, falling more than three stories is potentially fatal. Falling damage can be avoided by landing in moderately deep water, by using the [Become Ethereal](Skyrim_Become_Ethereal.md) shout before falling, or by being paralyzed on impact (most easily achieved by eating [Netch Jelly](https://en.uesp.net/wiki/Skyrim:Netch_Jelly)<sup>[DB](Skyrim_Dragonborn.md)</sup>, [Corkbulb Root](https://en.uesp.net/wiki/Skyrim:Corkbulb_Root)<sup>[CC](Skyrim_Rare_Curios.md)</sup>, or [Gold Kanet](https://en.uesp.net/wiki/Skyrim:Gold_Kanet)<sup>[CC](Skyrim_Rare_Curios.md)</sup>).

NPCs take more damage from falling than you do:

```
NPC falling damage = ((height - 450) * 0.1)1.65 * modifiers
```
Therefore, using [Unrelenting Force](Skyrim_Unrelenting_Force.md) and other attacks that may push enemies off a significant height can be an effective method of attack.

The formulae given above are based on default settings. The formula using the actual game settings is as follows (adding "NPC" to the end of each setting name when dealing with NPCs):

```
falling damage = ((height - f Jump Fall Height Min) * f Jump Fall Height Mult)f Jump Fall Height Exponent * modifiers
```

### Drowning
If you remain submerged in water for 20 seconds you will begin taking damage at a rate of about 20 damage per second until you surface again for air. This can be avoided by using a potion or enchanted item with the [Waterbreathing](Skyrim_Waterbreathing_(effect).md) effect.

NPCs cannot drown, even if they remain submerged for long enough that they should.

### Traps
While adventuring, you will likely encounter a variety of traps and other hazards that can inflict minor or more severe amounts of damage. A detailed list of traps in Skyrim can be found on [this page](Skyrim_Traps.md).

## Combat Damage
Combat damage refers to damage caused directly by either the player, an NPC, or creature. While there are a number of methods for inflicting damage through [combat](Skyrim_Combat.md), there are certain things not governed by [skills](Skyrim_Skills.md) or [magical effects](Skyrim_Magical_Effects.md) that can alter the amount of damage dealt.

### Power Attacks
Power attacks can be used to deal extra damage or be more effective against an opponent who is blocking. They are performed by holding down, instead of tapping, the attack button. A power attack has a chance of staggering its target and consumes [Stamina](Skyrim_Stamina.md) according to the following formula.

```
power attack stamina cost = (40 + weapon weight * 2) * attack cost multiplier * (1 - perk effect)
```
The amount of Stamina available when you execute a power attack and the amount of Stamina consumed by the attack do not influence how much damage is dealt. However, if you do not have enough stamina to perform a power attack, the stamina bar will flash green and you will perform a regular attack instead.

You can perform several kinds of power attacks depending on which [movement control](Skyrim_Controls.md#Movement) you press as you attack and what weapon you are using. If you push the forward input while performing a power attack, you will execute a dash strike, useful to close distance quickly. Moving backwards will cause you to step back and then strike, useful for avoiding and countering enemy attacks. Left and right inputs can be used to sidestep enemy attacks, and with the [Sweep](Skyrim_Sweep.md#Sweep) perk, a left or right power attack can strike all enemies in a forward arc when using a two-handed weapon. If you are dual wielding, holding down both the left and right attack buttons at the same time results in a fast three-hit power attack that attacks with both weapons. If you are using only your fists, you will perform a similar three punch strike when the same input is used. Both of these attacks count as three separate power attacks and will consume Stamina accordingly.

| Attack Type | Damage | Stagger | Stamina Use |
| --- | --- | --- | --- |
| Single Weapon | x2 | x1 | x1 |
| Dual-Wield (x3 attacks) | x1.5 | x1 | x0.5 |
| Bash | x0.5 | x0.5 | x1 |
| Power Bash | x1.5 | x1.5 | x1 |
| Unarmed | x1 | x0.5 | x1 |

### Critical Strikes
A critical strike provides extra damage which bypasses armor upon a successful blow. All weapons except staves or "other" weapons (such as [forks](Skyrim_Fork_(weapon).md)) can strike a critical with the right perks. Sneak attacks and critical strikes are counted separately. A critical strike is calculated from the critical damage of a weapon; *generally* speaking, this is the floor of half the weapon's base damage, but the value is set independently in the weapon's data, so exceptions exist. The [weapons](Skyrim_Weapons.md) page lists each weapon's base damage value. Tempering, weapon skill level, weapon damage perks(*Armsman*, *Barbarian*, *Overdraw*), *Fortify Skill* enchantments, *Fortify Skill* potions, sneak attacks, power attacks, [Ammunition](Skyrim_Ammunition.md) type for bows and crossbows, and whether or not a bow is fully-drawn *do not* modify the extra damage dealt.

A sprinting power attack with the *Critical Charge* or *Great Critical Charge* perk performs a regular power attack + a double critical strike.

If *Deep Wounds* Rank 1 or *Bladesman* Rank 1 have not been taken, or if using a non-sword, non-greatsword weapon, the double critical strike deals 2 × floor(*base damage* × 0.5) damage 100% of the time. Assuming the weapon's base damage is an even number and its critical damage has been set according to the standard trend, a weapon effectively gets its base damage as extra damage when it scores a double critical strike like this.

If using a sword or greatsword and *Deep Wounds* or *Bladesman* Rank 1, 2, or 3 have been taken, double critical hits will instead deal double the critical damage added by the perk's level and will only occur 10%, 15%, or 20% of the time, respectively, instead of on every attack. If a double critical hit does not occur the attack will instead deal the standard damage of a sprinting power attack, which will happen 90%, 85%, or 80% of the time. This means taking *Deep Wounds* or *Bladesman* results in lower sprinting power attack damage on average, although they may still be worth taking since they enable critical hits on basic attacks.

| Perk | Rank | Typical Value | Chance | Typical Expected Value |
| --- | --- | --- | --- | --- |
| - *Deep Wounds* (Two-handed) <br> - *Bladesman* (One-handed) <br> - *Critical Shot* (Archery) | 1 | floor(*base damage* × 0.5) | 10% | floor(*base damage* × 0.5) × 0.1 = floor(*base damage* × 0.5) x 1/10 |
| 2 | floor(*base damage* × 0.5) × 1.25 | 15% | floor(*base damage* × 0.5) × 0.1875 = floor(*base damage* × 0.5) × 3/16 | |
| 3 | floor(*base damage* × 0.5) × 1.5 | 20% | floor(*base damage* × 0.5) × 0.3 = floor(*base damage* × 0.5) × 3/10 | |
| - *Great Critical Charge* (Two-handed) <br> - *Critical Charge* (One-handed) | floor(*base damage* × 0.5) × 2 | 100% | floor(*base damage* × 0.5) × 2 | |

### Difficulty Level
There are 5 difficulty settings, accessible from the [Journal](Skyrim_Controls.md#Journal) (Journal > System > Settings > Gameplay): Novice (very easy), Apprentice (easy), Adept (normal), Expert (hard), and Master (very hard). [Patch 1.9](Skyrim_Patch.md#Version_1.9) adds a sixth difficulty level: Legendary. Easier settings cause enemies to take more damage and for damage dealt to you to be reduced while harder settings cause enemies to take less damage and you take more. The only other effect it has on the game is on the health costs of the [Equilibrium spell](Skyrim_Equilibrium.md). Fall damage is decreased on difficulties below Adept, but is not increased on difficulties above Adept.

You can change the difficulty level at any time, even in the midst of combat. If you are struggling with a certain enemy or group of enemies, it is possible to adjust to an easier setting, kill the enemy, and then return to your previous difficulty.

Note that the difficulty level does affect [followers](Skyrim_Followers.md) and summons in the same way it affects enemies, making them potentially more valuable as you increase the difficulty level.

| Difficulty | NPC Damage Taken | Player Damage Taken |
| --- | --- | --- |
| Novice | x2 | x0.5 |
| Apprentice | x1.5 | x0.75 |
| Adept | x1 | x1 |
| Expert | x0.75 | x1.5 |
| Master | x0.5 | x2 |
| Legendary | x0.25 | x3 |

## NPC-Only
**Critical Hit** is a Dragonborn NPC-only perk that functions identically to the first level of [Bladesman](https://en.uesp.net/wiki/Skyrim:Bladesman), [Critical Shot](https://en.uesp.net/wiki/Skyrim:Critical_Shot), or [Deep Wounds](https://en.uesp.net/wiki/Skyrim:Deep_Wounds), but is not bound to any particular weapon or skill tree. There is only one version of it:

| Name | Editor ID | [ID](Skyrim_Form_ID.md) | % | NPCs/Creatures |
| --- | --- | --- | --- | --- |
| Critical Hit | DLC2Critical Hit | [xx](Skyrim_Form_ID.md) 03BD06 | 10 | [Rieklings](Skyrim_Riekling.md) |

**Extra Damage** is an NPC-only perk used by many leveled NPCs in Skyrim. There are multiple versions of the perk under the same name, although they all have the same effect — actor with the perk will inflict more physical damage to their target. Some versions of this perk only work when the target being attacked is you, meaning that if you somehow manage to get the perk it won't do anything. Some versions of the perk multiply damage with one-handed weapons and bows by whatever number is in their editor ID, but two-handed melee weapons' damage by a lesser number, which is listed in the table below in "two-handed" column. It isn't known whether the other versions of the perk would work.

Versions | Name | Editor ID | [ID](Skyrim_Form_ID.md) | × | Two handed × | Player level | Special Conditions | NPCs/Creatures |
| --- | --- | --- | --- | --- | --- | --- | --- |
| Extra Damage 1.5 | cr Extra Damage0112 | 00 10d1e1 | 1.12 | 1.00 | | | - [Draugr](Skyrim_Draugr.md) <br> - [Dwarven Ballista Master](https://en.uesp.net/wiki/Skyrim:Dwarven_Ballista_Master)<sup>[DB](Skyrim_Dragonborn.md)</sup> <br> - [Dwarven Centurion Master](https://en.uesp.net/wiki/Skyrim:Dwarven_Centurion_Master) <br> - [Dwarven Sphere Master](https://en.uesp.net/wiki/Skyrim:Dwarven_Sphere_Master)<sup>[DG](Skyrim_Dawnguard.md)</sup> <br> - [The Forgemaster](https://en.uesp.net/wiki/Skyrim:The_Forgemaster)<sup>[DG](Skyrim_Dawnguard.md)</sup> <br> - [Mistman](Skyrim_Mistman.md)<sup>[DG](Skyrim_Dawnguard.md)</sup> |
| Extra Damage 1.5 | cr Extra Damage015 | 00 103a8f | 1.50 | 1.25 | | | - [Ancient Frost Atronach](https://en.uesp.net/wiki/Skyrim:Ancient_Frost_Atronach)<sup>[DG](Skyrim_Dawnguard.md)</sup> <br> - [Ash Spawn](Skyrim_Ash_Spawn.md)<sup>[DB](Skyrim_Dragonborn.md)</sup> <br> - [Bandit](Skyrim_Bandit.md) <br> - [Celann](https://en.uesp.net/wiki/Skyrim:Celann)<sup>[DG](Skyrim_Dawnguard.md)</sup> <br> - [Dawnguard](Skyrim_Dawnguard_(NPC).md)<sup>[DG](Skyrim_Dawnguard.md)</sup> <br> - [Draugr](Skyrim_Draugr.md) <br> - [Durak](https://en.uesp.net/wiki/Skyrim:Durak)<sup>[DG](Skyrim_Dawnguard.md)</sup> <br> - [Dwarven Spider Guardian](https://en.uesp.net/wiki/Skyrim:Dwarven_Spider_Guardian) <br> - [Falmer](Skyrim_Falmer.md) <br> - [Forsworn](Skyrim_Forsworn.md) <br> - [Frozen Chaurus](https://en.uesp.net/wiki/Skyrim:Frozen_Chaurus)<sup>[DG](Skyrim_Dawnguard.md)</sup> <br> - [Lurker Guardian](https://en.uesp.net/wiki/Skyrim:Lurker_Guardian)<sup>[DB](Skyrim_Dragonborn.md)</sup> <br> - [Vampire Mistwalker](https://en.uesp.net/wiki/Skyrim:Vampire_Mistwalker) |
| Extra Damage 1.5 | cr Nerf Damage05 | 00 10c041 | 0.50 | 0.50 | | | - [Adventurer](https://en.uesp.net/wiki/Skyrim:Adventurer) <br> - [Agna](https://en.uesp.net/wiki/Skyrim:Agna) <br> - [Ari](https://en.uesp.net/wiki/Skyrim:Ari) <br> - [Bandit](Skyrim_Bandit.md) <br> - [Bradyn](https://en.uesp.net/wiki/Skyrim:Bradyn)<sup>[DB](Skyrim_Dragonborn.md)</sup> <br> - [Dark Brotherhood Assassin](https://en.uesp.net/wiki/Skyrim:Dark_Brotherhood_Assassin) <br> - [Feran Sadri](https://en.uesp.net/wiki/Skyrim:Feran_Sadri)<sup>[DG](Skyrim_Dawnguard.md)</sup> <br> - [Garan Marethi](https://en.uesp.net/wiki/Skyrim:Garan_Marethi)<sup>[DG](Skyrim_Dawnguard.md)</sup> <br> - [Malkus](https://en.uesp.net/wiki/Skyrim:Malkus)<sup>[DG](Skyrim_Dawnguard.md)</sup> <br> - [Mireli](https://en.uesp.net/wiki/Skyrim:Mireli)<sup>[DB](Skyrim_Dragonborn.md)</sup> <br> - [Namasur](https://en.uesp.net/wiki/Skyrim:Namasur)<sup>[DG](Skyrim_Dawnguard.md)</sup> <br> - [Niels](https://en.uesp.net/wiki/Skyrim:Niels) <br> - [Ra'jirr](https://en.uesp.net/wiki/Skyrim:Ra%27jirr) <br> - [Ronthil](https://en.uesp.net/wiki/Skyrim:Ronthil)<sup>[DG](Skyrim_Dawnguard.md)</sup> <br> - [Stalf](https://en.uesp.net/wiki/Skyrim:Stalf)<sup>[DG](Skyrim_Dawnguard.md)</sup> <br> - [Vald](https://en.uesp.net/wiki/Skyrim:Vald) <br> - [Vingalmo](https://en.uesp.net/wiki/Skyrim:Vingalmo)<sup>[DG](Skyrim_Dawnguard.md)</sup> |
| Extra Damage 1.5<sup>[DG](Skyrim_Dawnguard.md)</sup> | DLC1cr Extra Damage Scales015 | [xx](Skyrim_Form_ID.md) 01a170 | 1.50 | 1.25 | | Only with bows & two-handed weapons | - [Keeper](https://en.uesp.net/wiki/Skyrim:Keeper)<sup>[DG](Skyrim_Dawnguard.md)</sup> |
| Extra Damage 2 | cr Extra Damage02 | 00 101075 | 2.00 | 1.50 | | | - [Arch-Curate Vyrthur](https://en.uesp.net/wiki/Skyrim:Arch-Curate_Vyrthur)<sup>[DG](Skyrim_Dawnguard.md)</sup> <br> - [Bandit](Skyrim_Bandit.md) <br> - [Chaurus Hunter](https://en.uesp.net/wiki/Skyrim:Chaurus_Hunter)<sup>[DG](Skyrim_Dawnguard.md)</sup> <br> - [Forsworn Pillager](https://en.uesp.net/wiki/Skyrim:Forsworn_Pillager) <br> - [Guardian Troll Spirit](https://en.uesp.net/wiki/Skyrim:Guardian_Troll_Spirit) <br> - [Hulking Draugr](https://en.uesp.net/wiki/Skyrim:Hulking_Draugr)<sup>[DB](Skyrim_Dragonborn.md)</sup> <br> - [Isran](https://en.uesp.net/wiki/Skyrim:Isran)<sup>[DG](Skyrim_Dawnguard.md)</sup> <br> - [Karstaag](https://en.uesp.net/wiki/Skyrim:Karstaag)<sup>[DB](Skyrim_Dragonborn.md)</sup> <br> - [Lurker Sentinel](https://en.uesp.net/wiki/Skyrim:Lurker_Sentinel)<sup>[DB](Skyrim_Dragonborn.md)</sup> <br> - [Mudcrab Guardian Spirit](https://en.uesp.net/wiki/Skyrim:Mudcrab_Guardian_Spirit) <br> - [Orchendor](https://en.uesp.net/wiki/Skyrim:Orchendor) <br> - [Skeever Guardian Spirit](https://en.uesp.net/wiki/Skyrim:Skeever_Guardian_Spirit) <br> - [Ralis Sedarys](Skyrim_Ralis_Sedarys.md)<sup>[DB](Skyrim_Dragonborn.md)</sup> <br> - [Riekling](Skyrim_Riekling.md)<sup>[DB](Skyrim_Dragonborn.md)</sup> |
| Extra Damage 2<sup>[DG](Skyrim_Dawnguard.md)</sup> | DLC1cr Extra Damage Scales02 | [xx](Skyrim_Form_ID.md) 01a16f | 2.00 | 1.50 | | Only with bows & two-handed weapons | - [Keeper](https://en.uesp.net/wiki/Skyrim:Keeper)<sup>[DG](Skyrim_Dawnguard.md)</sup> |
| Extra Damage 2.5 | cr Extra Damage025 | 00 103a90 | 2.50 | 1.75 | | | - [Bandit](Skyrim_Bandit.md) <br> - [Forsworn Briarheart](https://en.uesp.net/wiki/Skyrim:Forsworn_Briarheart) <br> - [Forsworn Ravager](https://en.uesp.net/wiki/Skyrim:Forsworn_Ravager) <br> - [J'darr](https://en.uesp.net/wiki/Skyrim:J%27darr) <br> - [Lurker Vindicator](https://en.uesp.net/wiki/Skyrim:Lurker_Vindicator)<sup>[DB](Skyrim_Dragonborn.md)</sup> <br> - [Mounted Riekling](https://en.uesp.net/wiki/Skyrim:Mounted_Riekling)<sup>[DB](Skyrim_Dragonborn.md)</sup> <br> - [Nightlord Vampire](https://en.uesp.net/wiki/Skyrim:Nightlord_Vampire)<sup>[DG](Skyrim_Dawnguard.md)</sup> <br> - [Nightmaster Vampire](https://en.uesp.net/wiki/Skyrim:Nightmaster_Vampire)<sup>[DG](Skyrim_Dawnguard.md)</sup> <br> - [Riekling Chief](https://en.uesp.net/wiki/Skyrim:Riekling_Chief)<sup>[DB](Skyrim_Dragonborn.md)</sup> <br> - [Riekling Hunter](https://en.uesp.net/wiki/Skyrim:Riekling_Hunter)<sup>[DB](Skyrim_Dragonborn.md)</sup> <br> - [Riekling Rider](https://en.uesp.net/wiki/Skyrim:Riekling_Rider)<sup>[DB](Skyrim_Dragonborn.md)</sup> <br> - [Riekling Scout](https://en.uesp.net/wiki/Skyrim:Riekling_Scout)<sup>[DB](Skyrim_Dragonborn.md)</sup> <br> - [Riekling Warrior](https://en.uesp.net/wiki/Skyrim:Riekling_Warrior)<sup>[DB](Skyrim_Dragonborn.md)</sup> |
| Extra Damage 2.5<sup>[DG](Skyrim_Dawnguard.md)</sup> | DLC1cr Extra Damage Scales025 | [xx](Skyrim_Form_ID.md) 01a171 | 2.50 | 1.75 | | Only with bows & two-handed weapons | - [Keeper](https://en.uesp.net/wiki/Skyrim:Keeper)<sup>[DG](Skyrim_Dawnguard.md)</sup> |
| Extra Damage 3 | cr Extra Damage03 | 00 0fa2c5 | 3.00 | 2.00 | | | - [Ebony Warrior](Skyrim_Ebony_Warrior.md)<sup>[DB](Skyrim_Dragonborn.md)</sup> <br> - [Riekling Courser](https://en.uesp.net/wiki/Skyrim:Riekling_Courser)<sup>[DB](Skyrim_Dragonborn.md)</sup> |
| Extra Damage 3<sup>[DG](Skyrim_Dawnguard.md)</sup> | DLC1cr Extra Damage Scales03 | [xx](Skyrim_Form_ID.md) 01a172 | 3.00 | 2.00 | | Only with bows & two-handed weapons | - [Keeper](https://en.uesp.net/wiki/Skyrim:Keeper)<sup>[DG](Skyrim_Dawnguard.md)</sup> |
| Extra Damage 3.5 | cr Extra Damage035 | 00 103a91 | 3.50 | 2.25 | | | - [Riekling Charger](https://en.uesp.net/wiki/Skyrim:Riekling_Charger)<sup>[DB](Skyrim_Dragonborn.md)</sup> |
| Extra Damage 4 | cr Extra Damage04 | 00 0fa2c4 | 4.00 | 2.50 | | | |
| Extra Damage 4.5 | cr Extra Damage045 | 00 103a92 | 4.50 | 3.00 | | | |
| Extra Damage 5 | cr Extra Damage05 | 00 0fa2c6 | 5.00 | 3.50 | | | |
| Extra Damage 6 | cr Extra Damage06 | 00 101076 | 6.00 | 6.00 | | | |
| Extra Damage | CWGuard Extra Damage To Player | 00 10bf7d | 1.25 | 1.25 | | Only against the player | - [Hjaalmarch Guard](https://en.uesp.net/wiki/Skyrim:Hjaalmarch_Guard) <br> - [Imperial Guard Jailor](https://en.uesp.net/wiki/Skyrim:Imperial_Guard_Jailor) <br> - [Pale Hold Guard](https://en.uesp.net/wiki/Skyrim:Pale_Hold_Guard) <br> - [Redoran Guard](Skyrim_Redoran_Guard.md)<sup>[DB](Skyrim_Dragonborn.md)</sup> <br> - [Riften Guard Jailor](https://en.uesp.net/wiki/Skyrim:Riften_Guard_Jailor) <br> - [Roadside Guard](https://en.uesp.net/wiki/Skyrim:Roadside_Guard) |
| Extra Damage | CWSoldier Extra Damage To Player | 00 10b1d9 | 1.50 | 1.50 | 10 ≤ x < 15 | Only against the player | - [Arrald Frozen-Heart](https://en.uesp.net/wiki/Skyrim:Arrald_Frozen-Heart) <br> - [Frorkmar Banner-Torn](Skyrim_Frorkmar_Banner-Torn.md) <br> - [Gonnar Oath-Giver](https://en.uesp.net/wiki/Skyrim:Gonnar_Oath-Giver) <br> - [Hjornskar Head-Smasher](Skyrim_Hjornskar_Head-Smasher.md) <br> - [Imperial Deserter](https://en.uesp.net/wiki/Skyrim:Imperial_Deserter) <br> - [Imperial Officer](https://en.uesp.net/wiki/Skyrim:Imperial_Officer) <br> - [Imperial Quartermaster](https://en.uesp.net/wiki/Skyrim:Imperial_Quartermaster) <br> - [Istar Cairn-Breaker](https://en.uesp.net/wiki/Skyrim:Istar_Cairn-Breaker) <br> - [Kai Wet-Pommel](https://en.uesp.net/wiki/Skyrim:Kai_Wet-Pommel) <br> - [Kottir Red-Shoal](https://en.uesp.net/wiki/Skyrim:Kottir_Red-Shoal) <br> - [Legate Adventus Caesennius](Skyrim_Legate_Adventus_Caesennius.md) <br> - [Legate Constantius Tituleius](https://en.uesp.net/wiki/Skyrim:Legate_Constantius_Tituleius) <br> - [Legate Emmanuel Admand](Skyrim_Legate_Emmanuel_Admand.md) <br> - [Legate Fasendil](Skyrim_Legate_Fasendil.md) <br> - [Legate Hrollod](https://en.uesp.net/wiki/Skyrim:Legate_Hrollod) <br> - [Legate Quentin Cipius](Skyrim_Legate_Quentin_Cipius.md) <br> - [Legate Sevan Telendas](https://en.uesp.net/wiki/Skyrim:Legate_Sevan_Telendas) <br> - [Legate Skulnar](Skyrim_Legate_Skulnar.md) <br> - [Legate Taurinus Duilis](Skyrim_Legate_Taurinus_Duilis.md) <br> - [Stormcloak Quartermaster](https://en.uesp.net/wiki/Skyrim:Stormcloak_Quartermaster) <br> - [Thalmor Prisoner](https://en.uesp.net/wiki/Skyrim:Thalmor_Prisoner) <br> - [Thorygg Sun-Killer](https://en.uesp.net/wiki/Skyrim:Thorygg_Sun-Killer) <br> - [Yrsarald Thrice-Pierced](https://en.uesp.net/wiki/Skyrim:Yrsarald_Thrice-Pierced) |
| 2.00 | 2.00 | 15 ≤ x < 20 | | | | | |
| 2.50 | 2.50 | 20 ≤ x < 25 | | | | | |
| 3.00 | 3.00 | 25 ≤ x < 30 | | | | | |
| 2.00 | 2.00 | 30 ≤ x < 35 | | | | | |

**Reduced Damage** and **Reduce Damage** are perks used by some NPCs in Skyrim. There are multiple versions of the perks, some decrease the damage output of the perk owner while others reduce incoming attack damage by multiplying it by some factor smaller than one.

Versions | Name | Editor ID | [ID](Skyrim_Form_ID.md) | × | Special Conditions | NPCs/Creatures |
| --- | --- | --- | --- | --- | --- |
| Reduced Damage 0.35<sup>[DG](Skyrim_Dawnguard.md)</sup> | cr Reduce Damage035 | [xx](Skyrim_Form_ID.md) 015c62 | 0.35 | | |
| Reduced Damage 0.5 | cr Reduce Damage05 | 00 107e29 | 0.5 | | - [Guardian Troll Spirit](https://en.uesp.net/wiki/Skyrim:Guardian_Troll_Spirit) <br> - [Mudcrab Guardian Spirit](https://en.uesp.net/wiki/Skyrim:Mudcrab_Guardian_Spirit) <br> - [Orchendor](https://en.uesp.net/wiki/Skyrim:Orchendor) <br> - [Queen Potema](https://en.uesp.net/wiki/Skyrim:Queen_Potema) |
| Reduce Damage | MQ101Reduce Damage | 00 05cebe | 0.5 | | |
| Reduce Damage | MQ101Spider Reduce Damage | 00 10e001 | 0.5 | | |
| Reduce Damage | MS02Reduce Damage | 00 1069bb | 0.75 | | |
| Reduced Damage 0.75 | cr Reduce Damage075 | 00 10ec8d | 0.75 | | - [Dwarven Ballista](Skyrim_Dwarven_Ballista.md)<sup>[DB](Skyrim_Dragonborn.md)</sup> |
| Reduce Damage<sup>[DB](Skyrim_Dragonborn.md)</sup> | DLC2MQ06Miraak Extra Damage Dragons Perk | [xx](Skyrim_Form_ID.md) 03d5cd | 1.5 | Only against [Dragons](Skyrim_Dragon.md) | - [Miraak](Skyrim_Miraak_(person).md)<sup>[DB](Skyrim_Dragonborn.md)</sup> |
| Reduce Damage<sup>[DB](Skyrim_Dragonborn.md)</sup> | DLC2MQ06Dragon Nerf Damage Miraak Perk | [xx](Skyrim_Form_ID.md) 03d5b4 | 0.5 | Only against Miraak | - [Kruziikrel](Skyrim_Kruziikrel.md)<sup>[DB](Skyrim_Dragonborn.md)</sup> <br> - [Relonikiv](Skyrim_Relonikiv.md)<sup>[DB](Skyrim_Dragonborn.md)</sup> |
| Reduce Attack Damage | MQ101Reduce Attack Damage | 00 05cec0 | 0.5 | | - [Imperial Captain](https://en.uesp.net/wiki/Skyrim:Imperial_Captain) <br> - [Torturer's Assistant](https://en.uesp.net/wiki/Skyrim:Torturer%27s_Assistant) |
| Reduce Attack Damage | MQ101Bear Reduce Damage | 00 109c1b | 0.8 | | |