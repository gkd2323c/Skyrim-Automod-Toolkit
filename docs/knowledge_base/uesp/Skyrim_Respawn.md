# Respawning

Most locations in the game are **respawning**. This happens, depending on the location, at scheduled times. When a game location respawns, its enemies and loot are usually reset. This allows revisiting previously visited locations, which will have their contents reset. Specifically:

- New versions are generated of creatures and NPCs whose corpses were left in the location if they are flagged as respawnable (some are not, usually those who have proper names), though they may not behave the same way as before (e.g., scripted conversations will usually not fire again).
- The contents of any respawning [containers](Skyrim_Containers.md), such as sacks and chests, are reset. Any items previously stored in the respawned container are permanently deleted from the game. Often, however, there will be some exceptional containers in an area that are marked *not* to respawn. In these cases, the exceptional containers will always be safe for storage, even if the remainder of the area is unsafe. Exceptional safe containers include coffins, cupboards, side tables, wardrobes, and those labeled specifically as just "Sack". These are commonly located in NPC houses and stores. There is no reliable way to determine from their appearance which containers are exceptions; you must test each by depositing something odd and returning later. See the containers page for more specifics.
- New copies are generated for most items sitting out in the open (ingredients, books, clutter, etc.). If the previous copy is still in the game location, it is first removed.
- [Plants](Skyrim_Ingredients.md) are reset, allowing new ingredients to be harvested.
- All activators are reset. Certain doors will re-lock, and any "quick exit" doors that were "barred from the other side" will be re-barred. However, already opened dragon claw [puzzle doors](Skyrim_Traps.md#Puzzle_Door) will not re-lock, and any keys you may have picked up the first time will still work.

The level of the location is set at the first visit, based on your current level. This means that the level of the enemies and the loot will be the same when you return to that location. When an area is too difficult to complete at the current level, you can try again when you're better able to handle it.

## Schedule
There are three different schedules that can be used for respawning a game location:

- **Never**. [Some dungeons](https://en.uesp.net/wiki/Category:Skyrim-Places-Safe) are flagged as "Never Resets", which means that no matter how long you wait the contents are never altered. All containers in such locations are [safe](Skyrim_Containers.md#Safe_Locations) for long-term storage. This setting only applies to interior areas; any exterior areas associated with a never-respawning dungeon will respawn after 10 days. Examples of the areas that don't respawn are the [houses](Skyrim_Houses.md) that you can buy.
- **10 days** (240 hours) of in-game time. This is the default time period used before a dungeon or any other game location respawns.
- **30 days** (720 hours) of in-game time. This is the time period used if a dungeon has been [cleared](Skyrim_Dungeons.md#Clearing).

For any area to respawn, you must not enter the area during the specified time period. Each time you enter the area, the respawn clock is reset. Conversely, you can intentionally re-enter an area frequently to prevent storage containers from resetting (although you run the risk of losing everything if you forget to return in time).

### Merchant Chests
[Merchant Chests](Skyrim_Merchant_Chest.md) respawn every two days (48 hours) of in-game time, independent of whether the store or cell containing the chest has respawned.

### Ore Veins
Ore veins (all types) sometimes do not respawn normally. See [Mining (Bugs)](Skyrim_Mining.md#Bugs) and elsewhere on that article and its talk page.

### Notes
- Some quests (more with [USSEP](https://en.uesp.net/wiki/Skyrim_Mod:Unofficial_Skyrim_Patch)), scripts, and one console command may "force" an interior cell to respawn disregarding any schedule it may have. Such "forced" respawn, unlike scheduled ones, wipes any player-dropped items (and other references created during playtime) from the cell.
- Respawned NPCs will be (most of the time) generated in their original cell, even if their respawning is triggered by another cell (where their corpse was left.)
- It is possible to bring corpses of killed "respawnable" NPCs from a respawning cell to a non-respawning cell, and they will **never** respawn (but they will still disappear). The reverse is also true: it is possible to bring corpses of killed "respawnable" NPCs from a non-respawning cell to a respawning cell, and have them respawn. A different version of this is bringing a [dead thrall](Skyrim_Dead_Thrall.md) to your house (including any added by *Hearthfire*) and killing them: even if they were a respawning NPC (such as a Bandit Chief), they will never vanish. The reverse is also true: bandits (and/or Dawnguard, Vampires) that glitch into your *Hearthfire* house during an attack and killed there will vanish when the cell is reloaded. Enemies that are reanimated with spells (but not dead thralls) and crumble to dust will also disappear later on.
- Some places flagged as non-respawning (specifically *Hearthfire* homes) will respawn certain elements of their decorations: jugs of milk on shelves, mammoth tusks on cabinets and herbs on hanging racks (just to name a few) can respawn after a time, leading to more samples being able to be acquired. This only applies to items that are provided by the game as part of an item's creation (such as a shelf which comes with a bottle of wine and a goblet; both items respawn some time after they are taken), not any that you might place as personal decorations. This can also lead to items you placed being under/inside an item when it respawns, such as a Statue of Dibella now being inside a bowl, or a plate over a sword.
- Deleted or despawned bodies still have their inventories, you can even use the console command 'additem' and 'removeitem' to manipulate deleted bodies' inventory, and the data is recorded in the save file, that means, if you don't loot all items from all dead enemies, it could slightly increase the save file's size.
- Any item dropped by the player anywhere can stay there permanently and thus increase the save file's size, so the best treatment of junks is either selling to a merchant or putting them into a respawning container. However arrows shot by a bow can disappear automatically and perfectly(can't use 'prid refid' to find it anymore) even if in a never respawn dungeon.

## See Also
- [Cell Reset](https://en.uesp.net/wiki/Cell_Reset) on the Creation Kit wiki.

## Bugs
- Harvested plants and other flora objects do not carry "I have respawned and ready to be harvested again" state between reloadings of the cell, so after a cell respawns, they will be harvestable only until the player goes away; upon next visit, even if departure was just going into another interior cell and right back (or saving-loading the game), the plants will be in "harvested" state again.
- Dead bodies (such as bandits) in tombs or ruins (that were already there, not that you have killed) may respawn the next time around as ash piles, which may or may not be able to be looted. <sup>**?**</sup>
- Several dungeons that don't reset may still respawn their exterior enemies, items, and containers. - ![PC Only](https://images.uesp.net/d/d7/Computer.svg)
The [Unofficial Skyrim Patch](https://en.uesp.net/wiki/Skyrim_Mod:Unofficial_Skyrim_Patch), version 2.1.2, fixes this bug. ([details](https://afktrack.afkmods.com/index.php?a=issues&i=19112))