# Form ID


## Base and Reference IDs
Base IDs and reference IDs (Base IDs/Ref IDs) are two types of Form ID that are used to identify the various NPCs, creatures, and items within the game. The Base ID is the unique identifier for a prototype of the object, while the Ref ID denotes a specific copy of an object in the game. For unique [NPCs](Skyrim_NPCs.md) and specifically placed [creatures](Skyrim_Creatures.md) or items, the Base ID and Ref ID are fixed, and are usually noted on relevant pages. Non-unique objects, such as randomly spawned creatures or loot, will usually only have a Base ID, since their Ref IDs will change at each encounter and for each item.

Console commands normally only accept either a Base ID or a Ref ID, not both. For example, the command `player.placeatme <Base ID>` will create a new copy of an object and place it at the player's position. This is fine with most items or generic creatures. With unique NPCs however, a second copy will usually cause problems with quests and such. In that case, one could move the NPC to the player with the command `"<Ref ID>".moveto player` or the command sequence:

- `prid <Ref ID>`
- `moveto player`

For most items, creating extra copies does no harm, so `player.additem <Base ID> <quantity>` can be used to add the desired quantity of items to the player's inventory. Quest-specific items, however, will suffer from the same problems as unique NPCs, since the quest will often be tied to specific Ref IDs for objects, not their Base IDs. Also, Ref IDs can only be used if the object in question is loaded into memory; visiting the cell of the object can assure this. See the [console article](Skyrim_Console.md) for further commands and uses of form IDs for other types of things.

## xx and Add-Ons
The first two digits of form IDs found in .esm and .esp add-ons are given as `xx` because they may vary depending on the number of active add-ons and their load order. Objects from a specific add-on will generally all have the same two leading digits. So, if [Dawnguard](Skyrim_Dawnguard.md) is the only add-on you have, and you're not loading any mods, the `xx` for Dawnguard IDs would be `02`. The specific code is not displayed in the "Data Files" screen, nor in the [Creation Kit](https://en.uesp.net/wiki/Skyrim:Mod_Creation_Kit), but mod managers and other utilities will often show them. From within the game, you can find the correct ID by opening the console and clicking on an object from that add-on, or by using the `[help](Skyrim_Console.md#help)` command with an add-on specific object.

Leading digits which are unique are:

- `00` Those IDs are used by the original Skyrim (Skyrim.esm), the prefix doesn't change
- `01` Those IDs are usually used by the Update module (Update.esm)
- `02` Those IDs are used by the Dawnguard (Dawnguard.esm) in [Skyrim Special Edition](Skyrim_Special_Edition.md)
- `03` Those IDs are used by the Hearthfire (Hearthfires.esm) in Skyrim Special Edition
- `04` Those IDs are used by the Dragonborn (Dragonborn.esm) in Skyrim Special Edition
- `ff` Dynamically allocated IDs use this. Since they depend on a specific playthrough, they should not be documented - they will be different for other players.

## Creation Club<sup>[CC](Skyrim_Creation_Club.md)</sup>
The [Creation Club](Skyrim_Creation_Club.md) introduces the leading digits of `FE` for the .esl creations, which appears as the prefix for all related assets. Due to the nature of Creation Club content being load-order neutral in respect to add-ons and mods, Creations are localized to their own dynamic load order. The position where each Creations appears in this load order is determined alphabetically, and is also fully dependent on how many Creations are installed. The digits appearing after the `FE` prefix are determined by where the respective Creation is placed within this exclusive load order, also note that these intermediary digits are displayed as `xxx` on the Wiki. As mentioned in the previous section, these three intermediary digits can differ between players, and so the exact code for a specific playthrough can be found through the use of the `help` command. Alternatively, the code can also be found by browsing the game files, where the first Creation listed alphabetically in the files will be issued the `000` intermediate in game, increasing by one for subsequent Creations installed. The final three digits of the Form ID are then unique to each individual asset.

For instance, if four Creations are installed: [Divine Crusader](Skyrim_Divine_Crusader.md) (ccmtysse001-knightsofthenine), [Lord's Mail](Skyrim_Lord%27s_Mail.md) (ccbgssse021-lordsmail), [Plague of the Dead](Skyrim_Plague_of_the_Dead.md) (ccbgssse003-zombies), and [Survival Mode](Skyrim_Survival_Mode.md) (ccqdrsse001-survivalmode), they will load in alphabetical order according to their file names. The Form IDs for the included assets would have the following codes:

1. `FE **000** ABC` for assets associated with ccbgssse003-zombies.
2. `FE **001** DEF` for assets associated with ccbgssse021-lordsmail.
3. `FE **002** GHI` for assets associated with ccmtysse001-knightsofthenine.
4. `FE **003** JKL` for assets associated with ccqdrsse001-survivalmode.

But if only Lord's Mail and Survival Mode were installed, then the Form IDs would change to the following:

1. `FE **000** DEF` for assets associated with ccbgssse021-lordsmail.
2. `FE **001** JKL` for assets associated with ccqdrsse001-survivalmode.

## Notes
- IDs are not case sensitive in either the console or the Creation Kit.
- When typing in an ID in the console, you can skip any leading zeroes. For example, the Base ID for gold is `0000000f`, so when you want to add 1000 gold to your inventory, all you need to type is `player.additem f 1000`.
- Searches and filters within the Creation Kit will match partial IDs.