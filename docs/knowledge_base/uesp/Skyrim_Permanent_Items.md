# Permanent Items

| --- |

Most items in Skyrim may be easily lost if placed into a respawning container, left on a body of an NPC or sold to a vendor. Still, some rare items persist in the world of Skyrim, and may even prevent corpses from disappearing. The latter quality is actually useful, as it allows you to accumulate corpses for reanimation via [Dead Thrall](Skyrim_Dead_Thrall.md) spell. All persistent items will remain in respawning containers and some of them prevent non-respawning dead bodies from being deleted.

Persistent items are of two distinct types:

Type 1 - **Permanent (fully)**

1. Keep their Ref ID number, when dropped into the world
2. Remain in respawning containers
3. Prevent corpses from disappearing via general 1-day corpse-clearing routine
4. Do not lose any of their persistent traits when dropped into the world

Type 2 - **Permanent (until dropped)**

1. May keep or lose their Ref ID number, when dropped into the world
2. Remain in respawning containers
3. Lose any or all of their persistent traits when first dropped into the world

## Sources of permanent items
Fully permanent items are those filling an alias in an **active** quest in game's quest system.

This includes most (if not all) of the undroppable quest items, and some items which are droppable and are never removed from alias, because they are related to infinitely running (and, most times, hidden from player) quests. Such items are fully permanent forever.

When item's quest ends, it is no longer a fully permanent item. However, it may stay permanent until dropped. Also some items existing at the beginning of the game are permanent until dropped. Furthermore, sometimes seemingly common items gain permanent (until dropped) properties due to undefined circumstances

Permanency is a property of the reference, not of the base item, so giving yourself an item from the list below via console will not give you a permanent copy of the item. You will need to get the item "legitimately" to benefit from its permanent property.

If there is one permanent item in a stack of like items, it will prevent all items of the stack from refreshing when their container refreshes.

## List of items fully permanent forever or with clear moment of losing permanency
The following items were found to be fully permanent:

1. [Aetherial Crown](Skyrim_Aetherial_Crown.md)<sup>[DG](Skyrim_Dawnguard.md)</sup>
2. [Ebony Blade](https://en.uesp.net/wiki/Skyrim:Ebony_Blade) - Only until it is restored to full power
3. [The Gauldur Amulet](https://en.uesp.net/wiki/Skyrim:The_Gauldur_Amulet)
4. [Zephyr](https://en.uesp.net/wiki/Skyrim:Zephyr)<sup>[DG](Skyrim_Dawnguard.md)</sup>
5. [All of the ten **numbered** treasure maps](Skyrim_Treasure_Maps.md)

## When permanent items do **not** prevent corpses from disappearing?
- "Permanent (until dropped)" items, despite remaining in respawning containers, do not reliably prevent corpses from disappearing.
- "Permanent (fully)" items prevent corpses from disappearing due to 1-day corpse cleanup. There are other ways for corpses (and actors in general) to disappear, which are **not** prevented by the actor having a permanent item: - Being respawned when the associated area/dungeon [respawns](Skyrim_Respawning.md) (Hence, only store corpses from the "never resetting" dungeons);
- Being removed, disabled or teleported to inaccessible cells by a script other than 1-day corpse removal: - At the end of associated quest (example: Necromancers in [the Wolfskull Cave](https://en.uesp.net/wiki/Skyrim:Wolfskull_Cave) during [The Man Who Cried Wolf](https://en.uesp.net/wiki/Skyrim:The_Man_Who_Cried_Wolf));
- By special corpse removal script for named NPCs with death containers (e.g. those whose remains are placed in halls of the dead, although there are others, with death containers inaccessible for the Player without console);
- When their home area switches ownership (e.g. inhabitants of military forts change from Bandits to Stormcloacks to Empire depending on circumstances, Bandits get swapped to Linwe's Summerset Shadows at the beginning of corresponding quest);
- On unloading - almost every NPC created as part of a World Interaction (e.g. Revelers, Thalmor Justiciars, Dark Brotherhood Assasins) is removed like this.
- There is a **bug** when game removes references with active aliases via area respawn script, although it should not do so. Most notably, it manifests when [Bloodskal Blade](https://en.uesp.net/wiki/Skyrim:Bloodskal_Blade) loses its abilities, but there is potential for corpses containing permanent items being lost too.

## Losing permanent properties
Fully "permanent" items lose this status when their quest ends. "Permanent until dropped" lose it when dropped into the world, placed on weapon plaque, and sometimes if they are forcibly removed from the player and then returned (such as in Diplomatic Immunity quest).

## Explanation of permanency
<https://www.afkmods.com/index.php?/topic/4250-skyrim-levels-of-persistence/> This post by Arthmoor provides insight into the mystery of permanent items and other references.