# Creation Kit

[![](https://images.uesp.net/thumb/a/ac/SR-cover-Skyrim_Creation_Kit.jpg/200px-SR-cover-Skyrim_Creation_Kit.jpg)](https://en.uesp.net/wiki/File:SR-cover-Skyrim_Creation_Kit.jpg) [](https://en.uesp.net/wiki/File:SR-cover-Skyrim_Creation_Kit.jpg) Creation Kit The **Creation Kit** or **CK** (known in previous *[Elder Scrolls](https://en.uesp.net/wiki/General:The_Elder_Scrolls)* games as the **Construction Set** or **CS**) is a tool that can be used to view and edit the game's data files. The tool was released on 7 February 2012, along with the [High Resolution Texture Pack](Skyrim_High_Resolution_Texture_Pack.md). The Creation Kit is an external program that is run separately from the game of *[Skyrim](Skyrim_Skyrim.md)*. The Creation Kit is available for download through Steam and its current version is **v1.9.36.0**. It can be located on Steam under Library > Tools > Skyrim Creation Kit. However, the download (approximately 81MB in size) is only visible to users who have already bought the game. Moreover, it is only available on the PC, as console manufacturers do not allow third-party content to run on users' systems. As of 2018, you must get into Library > Tools in Steam, then use the search feature for "Creation" in that section; the tool is no longer listed otherwise. Instruction for installing the CK version for the *Skyrim Special Edition* and Creation Club content can be found at the [Creation Kit Wiki](https://en.uesp.net/wiki/Category:Getting_Started#Installing_the_Creation_Kit).

The Creation Kit is a program that can be used to control nearly any aspect of the game or create mods, capable of adding brand new user-created game content, examining the game data and retexturing the game. With the help of third-party engines, it can also change GUI elements such as making a PC-friendly items menu. It also integrates with the Steam Workshop to allow users to share, rate, and download mods.

## Creating Mods
Bethesda has created several tutorials for the Creation Kit. They created a new [wiki](https://en.uesp.net/wiki/Main_Page) with information about the Creation Kit. Video tutorials have been created too. There is an overview of the tool [here](https://en.uesp.net/wiki/Skyrim_Mod:Creation_Kit_Usage) on the wiki.

### Video tutorials
Bethesda has created ten video tutorials which demonstrate how to use the Creation Kit. It first starts with how the Creation Kit is installed. Then it takes the viewer along the creation of [a dungeon](https://en.uesp.net/wiki/Skyrim_Mod:Developer_Mods/Lokir%27s_Tomb) to cover the most important aspects of making an interior space in the Creation Kit. In the final video it is shown how the interior space can be connected to the exterior world.

- - [Episode 1: Introduction to the Kit](http://www.youtube.com/watch?v=g DKivl Gmia4)
- [Episode 2: Basic Layout](http://www.youtube.com/watch?v=SO-OMWk0m Qs)
- [Episode 3: Basic Layout II](http://www.youtube.com/watch?v=p1Twdld0t Lc)
- [Episode 4: Clutter](http://www.youtube.com/watch?v=6Rzx XWiqb8M)
- [Episode 5: Navmesh](http://www.youtube.com/watch?v=ra M9TBZZy QY)
- [Episode 6: Basic Encounters](http://www.youtube.com/watch?v=TAih_jr233I)
- [Episode 7: Traps](http://www.youtube.com/watch?v=PN5v Ctlxvwk)
- [Episode 8: Optimization](http://www.youtube.com/watch?v=acfu Zi Qh83Y)
- [Episode 9: Lighting](http://www.youtube.com/watch?v=5f Zo Ip Kc J6I)
- [Episode 10: World Hookup](http://www.youtube.com/watch?v=k TSQa Ux5e KY)

### Other Information

- - [Creation Kit Wiki](https://en.uesp.net/wiki/Main_Page) -- Official wiki for the Creation Kit where you can find details and tutorials for creating mods.
- [Creation Kit EULA](https://en.uesp.net/wiki/Skyrim_Mod:EULA) -- The end-user license agreement for the software.

## Steam Workshop
Mods can be directly uploaded from the Creation Kit to the Steam Workshop. This allows players to quickly install new mods. Players can directly *subscribe* to the mods from the Steam Workshop. Every time the *Skyrim* launcher is started, it will automatically download the latest version of any subscribed mods.

Unsubscribing from a mod can be done in two ways:

- Go into the Steam client and log into Community. Select *Workshop Files* under *Actions*. There is a link called *Subscribed items*. Selecting *Subscribed items* will display a list of mods you are subscribed to. There you can unsubscribe from them. The files won't be deleted from the data folder, but updates for the mod aren't downloaded anymore. You have to uncheck it manually in the launcher.
- Go into the launcher and uncheck the plugin file of the mod you want to unsubscribe from. The Launcher will first ask if you want to delete the files of the mod that has been unchecked. The Launcher will then ask if you want to unsubscribe.

Mods uploaded to the Workshop were originally restricted to a file size of 100MB, although this limit was removed on March 2, 2015. An optional payment model for mods uploaded to the Workshop was briefly in place from April 23-28, 2015, but was removed due to severe community backlash.

The workshop for *Skyrim* was originally in [closed beta](http://www.cipscis.com/about/) to a [select few](https://web.archive.org/web/20120207084401/http://steamcommunity.com/groups/Creation Kit/members) who were part of the Creation Kit developer club, made up of Bethesda employees and dedicated community members.

### Links

- - [Steam Workshop](http://steamcommunity.com/workshop/browse?appid=72850) -- Contains the mods uploaded by the Creation Kit.
- [Creation Kit Public Group](https://steamcommunity.com/groups/Skyrim CKPublic) — Official Steam group for Creation Kit that anyone can join
- [Creation Kit Group](http://steamcommunity.com/groups/Creation Kit/members) — Exclusive team group for the beta testers of the Creation Kit and Steam Workshop

## Game Data
Prior to the Creation Kit release, many modders were using third-party tools to indirectly extract and then read the game's files. These tools have been developed based on knowledge of the game data format used in [previous Elder Scrolls games](https://en.uesp.net/wiki/General:The_Elder_Scrolls), and are known to provide the same type of game information as the Creation Kit. Despite this, the Creation Kit will likely give more information because it was made to create the game originally. So, more game data (e.g., item statistics) can be extracted with these tools, then will be added to UESP articles. This data is likely to be casually described as "Creation Kit data".

## CK Discrepancies
The information available in the CK generally provides the most accurate data about the game. Almost every *Skyrim* article on this site relies extensively on data taken from the CK.

However, there are a limited number of cases where the data visible in the CK is **not** accurate, i.e., it does not correspond to the values visible in game when using the [Console](Skyrim_Console.md). This generally occurs because the data is overridden by automatically calculated values. For example:

- The gold values of enchanted items as shown in the CK do not include the value added by the enchantment.
- Even when the CK does display auto-calculated values, it does not always round those values the same way as is done in-game. For example, on multiple-effect spell costs, the CK floors each individual effect and then sums them, whereas in-game, the full-precision values are summed, and then the total is floored. A consequence of this are cases of one-off errors of potion gold values in the CK compared to in-game values.
- The CK will use the wrong offset for stats like health, if the race is changed by a template. An example for this is the [Unbound Dremora](Skyrim_Unbound_Dremora.md). In game, the offset provided by the race of the template is used, as can be verified via console. In practice however this is no problem for most cases, since either the race stored in the NPC_ form matches the race of the template, or at least the stat offset is the same.

All of these cases have been verified, for example, by examining statistics in game using the [Console](Skyrim_Console.md). The in-game values are used in preference to CK values when there is a discrepancy between the two (see [the style guide](https://en.uesp.net/wiki/UESPWiki:Style_Guide#Accurate_and_Verifiable)).

## Adding .bsa Files
Whenever you load a mod, you should also tell the Creation Kit to load its associated `.bsa` file, if one exists. To do so, find the `SResource Archive List2` entry in the [Archive] section and add the mod's `.bsa` to the end of the list. For example, `SResource Archive List2=Skyrim - Shaders.bsa, Update.bsa, Dawnguard.bsa, Custom Mod.bsa`. If you're working with scripts, *do not* add .bsa files to this list unless all source code is available or the "Add Script" button may cause the Creation Kit to crash.

## Notes
- The Skyrim Editor.ini file, referred to in several of the notes below, can be found in the main *Skyrim* game folder, usually at C:\Program Files\Steam\steamapps\common\Skyrim. For the Special Edition, this file is called Creation Kit.ini.
- By default, you can only load either Dawnguard, Hearthfire, or Dragonborn data into the CK, but not all at the same time. To load multiple masters, in Skyrim Editor.ini, add `b Allow Multiple Master Loads=1` under the `[General]` heading.
- To set a different language (the GUI will always be in English) you can add `s Language=<LANGUAGE>` under the `[General]` heading in Skyrim Editor.ini (e.g., `s Language=ITALIAN`).
- Add-On scripts are not normally displayed. The sources are kept in separate folders: Data\Scripts\Source\Dawnguard, Data\Scripts\Source\Hearthfire, and Data\Scripts\Source\Dragonborn. Using this information, you can do one of the following in order to view them: - View them in a text editor.
- Set the value for `s Script Source Folder` in Skyrim Editor.ini or Creation Kit.ini to the appropriate sub-folder. If you haven't already done so, you will also need to add the add-on's .bsa file(s), as described [above](#Adding_.bsa_Files).
- Copy them to Data\Scripts\Source, though you may want to make a copy of the original scripts first because some of them will get overridden in the process. Note that the Special Edition versions of the Creation Kit use Data\Source\Scripts. Most major mod authors nevertheless put their code in Data\Scripts\Source for consistency with previous versions and so that compiled code and source code stay in the same directory. You should consider doing the same using the `s Script Source Folder` entry, above, if you intend to release your code publicly.
- Setting relationships with new actors may only work with actors that are set to unique.
- Display of error messages can be suppressed by setting `b Block Message Boxes=1` in the `[MESSAGES]` section of Skyrim Editor.ini.
- Version 1.9.35 will **delete** all the native game script files from your Data\Scripts folder. If you have modified the scripts, you should back them up before updating. If you've already updated, there's nothing you can do unless you have a backup. The default versions of the scripts are available in the Data folder in a Scripts.rar file. You will need something capable of extracting RAR files, like Win RAR, in order to extract them into your Scripts folder.
- Version 1.9.35 also disables version tracking. There is no known workaround short of restoring an older, backed up version of the Creation Kit.
- The Creation Kit counts [Dremora](Skyrim_Dremora.md), [children](Skyrim_Child.md), and [elders](Skyrim_Elder.md) as separate races.

## Bugs

- *See [Bugs](https://en.uesp.net/wiki/Skyrim_Mod:Creation_Kit_Bugs) for more detailed information on critical bugs in the editor.*

- Attempting to load creations or mods crashes the Creation Kit. - Add the add-on's .bsa file to the SResource Archive List2 value, as discussed [above](#Adding_.bsa_Files).
- For Actors, the Character Gen Morphs page doesn't lock when "Use Traits" is selected in the Template Data section, however changes made will not save unless "Use Traits" is unchecked.
- Sometimes tabs on the left of the Quest UI will disappear completely. <sup>**?**</sup> - Click on a tab towards the right-hand side and the full tab strip will reappear.