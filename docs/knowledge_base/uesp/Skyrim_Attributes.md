# Attributes


## Primary Attributes
At the beginning of the game all attributes have 100 points. Each time you [level up](Skyrim_Leveling.md), you can choose to increase one attribute by ten points; doing so fully replenishes all three attributes even during combat. You **must** increase an attribute when you level up, although you may postpone levelling up by avoiding opening the skills menu, or by not sleeping in [Survival Mode](Skyrim_Survival_Mode.md).

All three attributes will regenerate automatically, subject to conditions. Magicka and Stamina cannot passively regenerate when they are actively being consumed.

Without [legendary skills](Skyrim_Skills.md#Legendary_Skills), the highest achievable level in the game is 81, resulting in a total of 80 attribute increases. The maximum value a single attribute can have if it is the only one increased at every level is 900. With legendary skills there is no maximum level cap, and theoretically no limit to the maximum value an attribute can be increased.

#### [Health](Skyrim_Health.md)
Health represents the total damage you can take before dying, which occurs when Health is 0. It is represented by a red bar at the bottom center of the HUD. Health is regenerated at 0.70% of maximum health each second when not engaged in combat and at 0.49% during combat.

#### [Magicka](Skyrim_Magicka.md)
Magicka represents the magical energy used to cast spells; you must have magicka equivalent to a spell's cost in order to cast it. It is represented by a blue bar in the bottom left corner of the HUD. Magicka is regenerated at 3.00% of maximum magicka each second when not engaged in combat and at 0.99% during combat.

[Altmer](Skyrim_High_Elf.md) have an extra 50 magicka and are the only race to have a racial attribute bonus.

#### [Stamina](Skyrim_Stamina.md)
Stamina represents physical energy, used primarily for [sprinting](Skyrim_Transport.md) and performing [power attacks](Skyrim_Combat.md#Power_Attacks). It is represented by a green bar in the bottom right corner of the HUD. Stamina regenerates 5.00% of maximum stamina each second when not engaged in combat and at 1.75% during combat.

Unlike Health and Magicka this is the only attribute of the three which can be depleted to a *negative* value, which will not be displayed in the HUD. Stamina regeneration functions differently when negative; see the main article for details.

### Survival Mode Attributes<sup>[CC](Skyrim_Creation_Club.md)</sup>
[Survival Mode](Skyrim_Survival_Mode.md) is a [Creation](Skyrim_Creation_Club.md) that introduces a new gameplay mode for [Skyrim Special Edition](Skyrim_Special_Edition.md). It introduces three new attributes that are critical to gameplay and are derived from the three primary attributes.

#### [Cold](Skyrim_Cold.md)
Cold represents body temperature, affected by clothing, weather and location. It is represented on the HUD by a dark region within the Health bar. Being severely cold reduces maximum health and incurs a variety of negative effects. At extreme levels it can deplete health and eventually cause death.

#### [Fatigue](Skyrim_Fatigue.md)
Fatigue represents energy level, which is replenished by [sleeping](Skyrim_Sleeping.md) periodically. It is represented on the HUD by a dark region within the Magicka bar. A lack of frequent rest reduces maximum magicka, decreases the rate of magicka regeneration, and reduces the effectiveness of [potions](Skyrim_Potions.md).

#### [Hunger](Skyrim_Hunger.md)
Hunger represents nutrition level and the need for [food](Skyrim_Food.md). It is represented on the HUD by a dark region within the Stamina bar. Without frequent nutrition maximum stamina is reduced, attacks become slower to perform, and using [shields](Skyrim_Shield.md) and [sneaking](Skyrim_Sneak.md) is less effective.

## Derived Attributes
The following values are derived from the three primary attributes, though most of these are not viewable through the game's interface.

- **Health Regeneration**: the rate that Health will regenerate. The rate can be increased by items with a [Regenerate Health](Skyrim_Regenerate_Health.md) effect, and decreased by items with [Damage Health Regeneration](Skyrim_Damage_Health_Regeneration.md) effect.
- **Magicka Regeneration**: the rate that Magicka will regenerate. The rate can be increased by items with a [Regenerate Magicka](Skyrim_Regenerate_Magicka.md) effect, and decreased by items with [Damage Magicka Regeneration](Skyrim_Damage_Magicka_Regeneration.md) effect.
- **Stamina Regeneration**: the rate that Stamina will regenerate. The rate can be increased by items with a [Regenerate Stamina](Skyrim_Regenerate_Stamina.md) effect, and decreased by items with [Damage Stamina Regeneration](Skyrim_Damage_Stamina_Regeneration.md) effect.
- **Speed**: Movement speed. Each race has a different modifier based on their height.
- **[Carry Weight](Skyrim_Carry_Weight.md)**: the total weight of items that you can carry. Choosing to increase stamina upon leveling up will also increase your total carrying capacity by 5. Carry Weight is derived from your base stamina, and as such, anything that *boosts* your stamina will not increase your carry weight. It can be increased by items or potions with a [Fortify Carry Weight](Skyrim_Fortify_Carry_Weight.md) effect.
- **[Critical Strike](Skyrim_Damage.md#Critical_Strikes) Chance**: Determines chances of landing a Critical Strike on an enemy, and is governed by specific [perks](Skyrim_Perk.md).
- **Melee Damage**:
- **Unarmed Damage**:
- **Mass**: how much an actor weighs which affects physics when ragdolled.
- **[Shout](Skyrim_Shouts.md) Regeneration**: the rate that Shouts will regenerate. The rate can be increased by items or blessings with a [Fortify Shouts](Skyrim_Fortify_Shouts.md) effect.

## NPC Attributes
All [NPCs](Skyrim_NPCs.md) have the same basic attributes as the player character, as well as several additional attributes that determine their behavior. NPC attributes are not visible to the player within the game and can only be seen via the [Console](Skyrim_Console.md) or with the [Creation Kit](https://en.uesp.net/wiki/Skyrim:Mod_Creation_Kit).

- **[Disposition](Skyrim_Disposition.md)**: Relationship between an NPC and the player or another NPC.

- **[Aggression](Skyrim_Aggression.md)**: Governs how likely an NPC is to attack you unprovoked.

- **[Confidence](Skyrim_Confidence.md)**: Determines whether an NPC will attack or flee in combat.

- **[Assistance](Skyrim_Assistance.md)**: How likely an NPC is to help others who are engaged in combat nearby. They will either ignore others, help allies, or help allies and friends.

- **Mood**: Determines the facial expressions the NPC will display and affects certain dialogue.

- **Energy Level**: Determines how often the Actor will move to a new location when in a Sandbox Package.

- **[Morality](Skyrim_Morality.md)**: Determines whether or not an NPC will commit crimes and controls whether they will follow certain player commands as a follower.

## Notes
- Unlike Morrowind and Oblivion, the specific skills that you increase to level up will have no effect on attribute increases.
- The regeneration rate of the three attributes is a percentage of your maximum health, magicka or stamina. This means that the amount of health, magicka or stamina that you regenerate per second becomes larger as you increase an attribute. This means boosts to the attribute and fortify attribute regeneration should be equally weighted for maximum absolute rate of regeneration.
- The only [Standing Stone](Skyrim_Standing_Stone.md) that provides an attribute increase is [the Atronach Stone](Skyrim_The_Atronach_Stone.md).