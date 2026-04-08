# Stamina


| Action | Base Stamina Use | Modifiers |
| --- | --- | --- |
| Sprint | 7/s | +2% per worn weight |
| [Power attack](Skyrim_Combat.md#Power_Attacks), single | (40 + 2 * weapon weight) | Reduced by some perks |
| [Power attack](Skyrim_Combat.md#Power_Attacks), dual | 3 * (40 + 2 * weapon weight) * 0.5 | Reduced by some perks |
| [Shield bash](Skyrim_Block.md) | 35 | |
| [Power bash](Skyrim_Block.md) | 55 | |
| [Bow zoom](Skyrim_Archery.md#Eagle_Eye_and_Steady_Hand) | 10/s | |

Some [dragon shouts](Skyrim_Dragon_Shouts.md) such as [Whirlwind Sprint](Skyrim_Whirlwind_Sprint.md) also use a small amount of stamina. However, this usually isn't a problem, since by the time you are able to shout again, your stamina will have fully restored.

## Current Stamina
You may inspect your current stamina in the [Skills menu](Skyrim_Controls.md#General_Gameplay).

## Increasing Stamina
The amount of stamina you have depends on your character's [level](Skyrim_Leveling.md). Each time you level up, you can choose to add ten points to your stamina, or to another [attribute](Skyrim_Attributes.md). Adding to your base stamina when you level up increases your [carry weight](Skyrim_Carry_Weight.md) by 5. You can temporarily fortify your stamina using magical effects as detailed [here](https://en.uesp.net/wiki/Skyrim:Fortify_Stamina). Temporary changes to your stamina (such as damage, drain, or fortify) do not affect your carry weight.

## Restoring Stamina
The green bar in the bottom right of the screen shows you the current status of your stamina (although this bar will be invisible when stamina is full). Stamina can be [restored](Skyrim_Restore_Stamina.md) in several ways:

- Stamina regenerates whenever you are not performing an action that uses stamina. You regenerate 5.00% of your maximum stamina per second outside of combat and 1.75% inside combat. - As a result, [sleeping](Skyrim_Sleeping.md) or [waiting](https://en.uesp.net/wiki/Skyrim:Waiting) fully restores your stamina.
- [Restore Stamina](Skyrim_Restore_Stamina.md) effects are available in various forms: - From [potions](Skyrim_Potions.md) that can be found or purchased
- From [custom potions](Skyrim_Alchemy.md)
- From some types of [food](Skyrim_Food.md)
- From [spells](https://en.uesp.net/wiki/Skyrim:Restoration_Spells) that [restore health](Skyrim_Restore_Health.md), which restore stamina with the [Respite](https://en.uesp.net/wiki/Skyrim:Respite) perk
- Whenever your character [levels up](Skyrim_Leveling.md), your stamina is fully restored, though this only applies to when you actively level up (by going into the Skills menu), not when the game informs you that you've gained a level.

## Unlimited Stamina
Unlike spells, which cannot be cast if you do not have sufficient magicka, Skyrim allows you to perform actions that require more stamina than you currently have. When you perform an action under such circumstances, a timer is set based on your stamina deficit and your stamina regeneration rate at the moment you perform the action. When the timer reaches 0, your stamina will start to regenerate again. However, Skyrim has a maximum amount of time coded into the game before the timer immediately resets. This is governed by the f Stamina Regen Delay Max game setting in the [Creation Kit](https://en.uesp.net/wiki/Skyrim:Mod_Creation_Kit), which is set to 5 (seconds) by default. Items such as potions or food that restore stamina by an absolute amount immediately reset the timer then restore the specified amount. If they instead increase regeneration rate by a percent, they will reduce the timer only if used before actions, but will increase the regeneration rate after the timer reaches 0 regardless of the timing. This effectively means items with a continuous restore stamina effect will grant you unlimited stamina during their duration.

A few simple examples illustrate the above mechanics. Consider a case where you regenerate 10 stamina per second and your power attack consumes 80 stamina.

- Case 1: You are at 80 stamina. You perform a power attack which depletes your stamina. Your stamina bar immediately begins to fill.
- Case 2: You are at 50 stamina. You perform a power attack which depletes your stamina and sets the timer to 3 seconds. After 3 seconds, your stamina bar begins to fill.
- Case 3: You are at 10 stamina. You perform a power attack which depletes your stamina and sets the timer to 7 seconds. After 5 seconds, the timer reaches 2 seconds, but due to f Stamina Regen Delay Max = 5, the timer immediately resets and your stamina bar begins to fill.
- Case 4: You are at 10 stamina. You perform a power attack which depletes your stamina and sets the timer to 7 seconds. You immediately drink a potion that restores your stamina by 15 per second for 5 seconds. The timer immediately resets the moment you drink the potion and your stamina bar begins to fill. For the next 5 seconds, you can perform as many power attacks as you want, since every time the potion effect ticks, the timer is reset and you will have positive stamina.

## NPC Stamina
All [NPCs](Skyrim_NPCs.md) and [creatures](Skyrim_Creatures.md) also have stamina, which is calculated differently than the player's stamina. Their stamina is summed from three separate contributions:

- The race provides a starting stamina.
- Individual NPCs and creatures can have a fixed stamina adjustment.
- For most NPCs and creatures the [class](Skyrim_Classes.md) provides an additional 0-10 stamina points per level.

The rate at which enemies regenerate stamina is determined by their race.

## Notes
- [Frost damage](https://en.uesp.net/wiki/Skyrim:Frost_Damage) drains stamina.
- Unlike in previous Elder Scrolls games, jumping **does not** reduce your stamina, nor does walking or running affect the rate of regeneration.
- When your stamina reaches zero, the stamina bar will flash green. It will never take more than 5 seconds before it starts to refill again.
- As you sprint and your stamina bar depletes, your character will start to breathe more deeply and when it's almost gone, they start to pant. If you sprint until all your stamina is gone, your character will go back to jogging and let out deep, tired gasps. These sound effects don't play if you instead use up the stamina bar in combat; different sounds of exhaustion are used when you run out of stamina in that situation.