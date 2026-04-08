# Health


## Current Health
You may inspect current health in [Skills menu](Skyrim_Controls.md#General_Gameplay).

## Increasing Health
The amount of health you have depends on your character's [level](Skyrim_Leveling.md). Each time you level up, you can choose whether to add ten points to your health or to one of your other [attributes](Skyrim_Attributes.md).

Your health attribute can be increased using [Fortify Health](Skyrim_Fortify_Health.md) effects. [Enchantments](Skyrim_Enchanting.md) are particularly useful, since they have a constant effect. With [spells](Skyrim_Spells.md) and [potions](Skyrim_Potions.md), care is needed when relying on Fortify Health effects in the middle of combat. When the effect expires, you will immediately lose all the bonus health, potentially killing your character.

## Restoring Health
You lose health when taking damage. The red bar in the bottom center of the screen shows you the current status of your health (although this bar will be invisible when health is full). There are many ways to [restore health](Skyrim_Restore_Health.md):

### Passive Regeneration
- Health slowly regenerates over time. You regenerate 0.70% of your maximum health each second outside of combat and 0.49% during combat. Most NPCs do not regenerate health during combat. - As a result, [sleeping](Skyrim_Sleeping.md) or [waiting](https://en.uesp.net/wiki/Skyrim:Waiting) fully restores your health - under normal circumstances, you always need 142.86 seconds (slightly more than 2 1/3 minutes) to heal to full, well under the hour minimum of waiting or sleeping.
- Your health regeneration rate can be increased by [Regenerate Health](Skyrim_Regenerate_Health.md) effects, including potions and enchanted items.
- If [Survival Mode](Skyrim_Survival_Mode.md)<sup>[CC](Skyrim_Creation_Club.md)</sup> is enabled, health will no longer regenerate passively.

| Details |
| --- |
| There are several actor values involved in calculating total health regeneration: - The actor's maximum `Health`. <br> - The `Heal Rate`. This has a value of 0.7 by default, and expresses the percentage of maximum health that is regenerated per second, real time. <br> - The `Heal Rate Mult`. This has a default value of 100.0, and expresses a percentage modifier to the base `Heal Rate`. This is the value modified by e.g. the [Regenerate Health](Skyrim_Regenerate_Health.md) enchantment effect. <br> - The `Combat Health Regen Mult`. This also has a default value of 0.7, and expresses an additional multiplier that is only active while in combat. It modifies `Heal Rate` while in combat; the default lowers in-combat regeneration from 0.7% of total maximum health to 0.49% of total maximum health. There is a single item that modifies this value, [Chrysamere's](Skyrim_Chrysamere_(item).md)<sup>[CC](Skyrim_Chrysamere.md)</sup> unique [Fortified Combat Healing](https://en.uesp.net/wiki/Skyrim:Fortified_Combat_Healing) effect. <br> <br> This equates to this passive health regeneration formula: <br> <br> ``` <br> Health Per Second = Maximum Health * Heal Rate% * Heal Rate Mult% * (Is In Combat ? Combat Health Regen Mult : 1.0) <br> ``` <br> **Examples** <br> <br> - For a target with 100 maximum health, and all other values at their default, this means: - Out of combat: `Health Per Second = 100 * 0.7% * 100% * 1 = 0.7 health per second` <br> - In combat: `Health Per Second = 100 * 0.7% * 100% * 0.7 = 0.49 health per second` <br> - For a more complicated target with 600 maximum health, equipment giving a total bonus of 75% [health regeneration](Skyrim_Regenerate_Health.md): - Out of combat: `Health Per Second = 600 * 0.7% * 175% * 1 = 7.35 health per second` <br> - In combat: `Health Per Second = 600 * 0.7% * 175% * 0.7 = 5.145 health per second` |

### Active Regeneration
- [Restore Health](Skyrim_Restore_Health.md) effects are available in various forms: - From [potions](Skyrim_Potions.md) and [scrolls](Skyrim_Scrolls.md) that can be found or purchased
- From [custom potions](Skyrim_Alchemy.md)
- Using [Restoration spells](https://en.uesp.net/wiki/Skyrim:Restoration_Spells)
- By eating [raw food](Skyrim_Food.md) (small gains)
- By eating [cooked food](Skyrim_Cooking.md) (larger gains)
- Whenever your character [levels up](Skyrim_Leveling.md), your health is fully restored. This only applies to when you enter the level up screen itself (by going into the Skills menu), not when the game informs you that you've leveled up.

## NPC Health
All [NPCs](Skyrim_NPCs.md) and [creatures](Skyrim_Creatures.md) also have health, which is calculated differently than the player's health. Their health is summed from four separate contributions:

- The race provides a starting health. While the playable races all have a starting health of 50, other races have values ranging from 5 to 1000.
- Individual NPCs and creatures can have a fixed health adjustment. This adjustment is zero for most generic enemies, but can be substantial for quest-specific enemies (values range from -200 to 30000).
- Most NPCs and creatures gain additional health per level: - 5 health points per level.
- The [class](Skyrim_Classes.md) provides an additional 0-10 health points per level.

The rate at which enemies regenerate health is determined by their race, and may be supplemented by racial abilities (for example, [trolls](Skyrim_Troll.md) have a racial ability allowing enhanced in-combat health regeneration).

## Bugs
- NPCs of playable races have `Heal Rate=0` and do not regenerate health passively, despite races themselves having `Heal Rate=0,7` and despite NPCs of non-playable races (including Vampires and Afflicted) regenerating normally.