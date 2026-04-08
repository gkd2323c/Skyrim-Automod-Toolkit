# Technical Support


## Crashes

### Crash Types
- The system freezes (i.e. all programs stop) or the screen goes black, and a reboot is required.
- The game crashes and displays an error message detailing the crash.
- The game crashes and unexpectedly exits to the desktop.
- The game screen freezes and the audio goes into a continuous loop. After some time the game may resume. Alt-Tab still allows selection between applications if another one, like Windows Task Manager, is running. (If your particular system is having issues with that when Skyrim crashes, see "[Crash Recovery](#Crash_Recovery)" section, below).
- The operating system reboots itself unexpectedly.
- The operating system stops and shows a blue screen error (Windows) or panic error (Linux mac OS).

### Possible Causes

#### Memory Shortage
You may not have enough system RAM or video RAM.

##### Solutions
1. The obvious solution is to buy more RAM or upgrade your video card.
2. Disable high-def textures if you have less than 4 GB system RAM or 2 GB video RAM. If you crash frequently in busy cells, try doing this at anything less than 4 GB VRAM.

#### Overheating
One possible cause you should eliminate is **overheating**. This is more likely to be the cause if the issue is that the operating system suddenly reboots. Here are some general suggestions that might help regardless of the chip set or a particular computer's configuration out of the myriad of possibilities.

##### Solutions
1. Clean Up: Dust acts as an insulator, like very fine downy feathers, holding in the heat and allowing it to build up. Remove the cover on your computer. Use a soft brush attachment on a vacuum cleaner and gently vacuum the bottom of the case, the main fans and the air intakes and their grids. Follow this with a blow-out of the remaining dust. If you have an air compressor, a shop vac or just a can of compressed air, blow out the interior without making physical contact between boards and air source. You will be amazed at the dust cloud. In fact it is not a bad idea to wear a little dust mask or do this outside. Do not forget to blow air through the vents of the power supply unit (PSU). The interior of this box is often ignored, but it has its own fan that brings dust into it.
2. Clear Out: Remove papers, books, etc. from air intakes and outlets. Make certain your computer is in an area with a supply of fresh cool air, not in a small cabinet.
3. Adjust Down: If the GPU overheats, it may drop out of high performance mode. If it does so, the work will be picked up by the CPU(s) on the mother board. Their temperature will climb. There is no graceful drop out, just a messy crash or hang. Run Windows Task Manager and look at the Performance tab to check on the CPU(s). You really want to average under the fifty percent mark to insure stability. Most GPU's come with some kind of software control package, so run that package (e.g., Catalyst Control Center): - Check the cooling fan settings. Often fans are defaulted to a low and quiet rpm which is adequate for spreadsheets, word processing and surfing the internet but is not sufficient to keep the GPU cool when playing a demanding game, like Skyrim. You want all of the cooling you can get.
- Make certain the overclocking, if selected, is modest - say +40% of what is possible. You can adjust up or down later. The key here is to check your GPU temperature. If you can keep it around body temperature (37 to 41 degrees C) that is usually a very stable situation.
- Decide what is most important to you for the game. Is it frames-per-second or is it really smooth graphics with deep detailed views. You may have to compromise by reducing one to enhance the other in the game settings.
- Consider a lower resolution or running in a windowed mode. The fewer pixels to process, the less work and consequently the cooler the GPU can run.
- Check to make sure the game's frame rate is limited. If the frame rate is unlimited, the game may tax the GPU by using 100% of its processing power all of the time, making the GPU run unnecessarily hot, or causing general stability issues by the GPU not being able to take a break in between frames. Enabling V-Sync is the easiest method to limit the frame rate of the game. Another way is to use an external program such as Rivatuner Statistics Server to limit the frame rate to your preferred value, a recommended limit is 60 FPS, or 30 FPS to not tax your hardware as much.
4. Go low-tech: For many people, simply removing the side of the case and pointing a desktop fan at the internals will provide more than enough cooling. If the noise from the fan is problematic, turn the sound up or wear headphones; it's better than melting your graphics card.

#### Out of Date Software
It is rare that any piece of software is absolutely perfect. Publishers continually seem to find things that need improvement. Consequently you need to make certain you are still up to date.

##### Solutions
1. While Steam should regularly provide an updated **game patch**, and the installation included an up to date version of **Microsoft Direct X**, check to make sure both are in fact the latest. You never can tell, they may have corrected something that will help.
2. Consider updating your **graphic card drivers**. Usually the manufacturer's site will have an option to download and install the latest drivers and it is usually free from them.
3. On a deeper level make sure your **operating system** is up to date by running the appropriate update software.
4. Finally, make sure that your **BIOS** and **motherboard chipset** drivers are up to date by visiting their manufacturer sites as well.

#### Changes, Complexity, Interference and Dying Hardware
These require you to play detective by trial and error.

##### Solutions
1. If you have recently updated or changed some settings prior to the start of bad behavior, trace back to when the change was made and roll back drivers and settings to how the system was configured then.
2. Consider running the game in compatibility mode. It sounds strange, but sometimes moving the software environment back to a simpler time can work. If it doesn't help there is nothing lost, you can always turn it off.
3. Consider the possibility of interference from other applications running in the background. You can use programs like Task Manager to temporarily disable non-essential tasks. If it doesn't help, again nothing is lost.
4. Finally, consider that some piece of hardware may be wearing out. It can be anything: sound card, network adapter card, graphics card, etc. One big clue that hardware may be dying is that you get similar crashes running less demanding different applications. It is tough to track this down since it usually requires swapping out the possible offenders on another similar rig, where you look to see if you get similar crashes. Another big clue that it may be a hardware problem for Window's machines is that Error 6008 appears in the Event Viewer's "Summary of Administrative Events" under +ERROR. (START button > Control Panel > Administrative Tools > Event Viewer.) To confirm this suspected hardware problem, look to see if the time of a recent unexpected re-boot matches a recent Error 6008 message: The previous system shutdown at XX:XX:XX PM on MM/DD/YYYY was unexpected.

## Caveats
Given all of the possible motherboards, BIOS's, graphics cards, memory configurations and software on any single computer there are literally billions of possible combinations. So the advice or solutions offered here are in general terms. You apply them at your own risk. One way to reduce that risk is to make back up copies of things like the registry, and to make restore points **before** undertaking any change.

If you are uncomfortable with working on the interior of a computer do not do so until you have had some instruction. It is very easy and expensive to short out CMOS devices with static charges.

## Tweaks
Tweaks are changes to software settings to address problems.

### Resetting
After every patch release, all of the tweaked settings should be returned to a vanilla default status. This is because a new patch can sometimes correct the problem that motivated one tweak, but cause new problems with other tweaks. For example, running on a Vista system in compatibility mode for Windows XP might have reduced crashes for patch 1.4, but turning off that compatibility mode for patch 1.5 could reduce crashes even further.

### Increasing Frame Rates

#### V-sync Tweak
One frequently encountered piece of advice to increase the frame rate is to disable the V-sync within Skyrim. V-sync (vertical synchronization) is designed to allow each frame to start at a consistent position so that each is presented completely and cleanly. Turning it off may result in an increase in the frame rate but there may be a cost in that frames will tear with sudden movements or there may be an odd horizontal ripple on the screen. Since physics calculations in Skyrim are frame-rate-dependent, allowing the frame rate to exceed 60 frames per second can cause numerous, usually minor, issues such as objects falling through the floor and day/night cycles desynchronizing. In rare cases, these issues can also break quests. To turn off V-sync:

1. Make a backup copy of Documents\My Games\Skyrim\Skyrim Prefs.ini and then open it.
2. Search for `i Present Interval`.
3. Change the existing value to zero (`i Present Interval=0`) or add it if it wasn't there.
4. Save.

If it is not the case that the frame presentation is adequate and the frame rate has increased, then it is easy to revert either by reverting to the old version or by making `i Present Interval=1` and saving it.

#### Priority Setting Tweak
Using Task Manager it is possible to set Skyrim to a higher priority. Each time you start the game do the following.

**Windows 8 and earlier:**

1. Simultaneously press Ctrl-Shift-Escape to run Task Manager.
2. Start Skyrim.
3. Alt-Tab out of Skyrim to the Task Manager.
4. Select the Processes tab in Task Manager.
5. Right-click: TESV.exe
6. Choose: Set Priority
7. Select: Above Normal
8. Alt-Tab (or mouse click) back to Skyrim.

**Windows 10:**

1. Simultaneously press Ctrl-Shift-Escape to run Task Manager.
2. Start Skyrim.
3. Alt-Tab out of Skyrim to the Task Manager.
4. Select the Processes tab in Task Manager.
5. Right-click: Skyrim (32-bit)
6. Choose: Go to detail (or just go directly to the Details tab and skip Processes)
7. Right-click: TESV.exe
8. Choose: Set Priority
9. Select: Above Normal (or High)
10. Click: Change priority
11. Alt-Tab (or mouse click) back to Skyrim.

Unfortunately this tweak reverts naturally and must be done every time you run Skyrim.

Instructions for doing this sort of thing with a `start` command in a batch file are not going to work, because they apply at the per-application level, but Skyrim (TESV.exe) is started by a loader program (Skyrim Launcher.exe, or an alternative such as skse_loader.exe) which checks some things, starts Skyrim from inside it, then exits. One would be setting the temporary loader's priority high without affecting the priority of Skyrim itself.

## Repeatables
If you have a crash that occurs **every** time a given event occurs please note the game version, operating environment, circumstances, nature of the crash and any attempted corrections in the talk section. We cannot promise a solution but will attempt to duplicate the crash and contact Bethesda or Steam as seems warranted.

## Crash Recovery
First, **save often**. Second, do not use Quicksave and Quickload; they are notoriously unreliable. Either use the Save option available in the menus, or (better yet) use the [Console](Skyrim_Console.md) save method (example: `save "Whiterun-Go See Farkas"`). Console-created saves are the cleanest; if you crash frequently, you may wish to do *all* of your saves this way.

If you've crashed to desktop, just try restarting the game and loading your most recent save. Give the game some time to load and catch up on any still-in-progress scripts. If your last save causes a crash on load, try loading a previous one, then loading the one you intend. If it still crashes, that save is probably corrupt. In the worst cases, you may have to go back several saves before you get one with which you can proceed (but see the note below on persistent crashes). When you get one that will work, immediately create a new save with the Console, and save extra-often until you get past the problem area (often a specific cell has too many large textures, too many active NPCs, or some other pile-up of resources that is causing your game to run out of memory frequently).

If you've had a lock-up crash, and you can't use Ctrl-Shift-Esc to visibly get the Task Manager (or Alt-Tab, if the TM was already running), do Ctrl-Alt-Delete, then pick Task Manger from it. If you still can't see the Task Manager, hold the Alt key for a second then press Tab, to bring up the zoomed version of the Task Switcher. You should be able to see Skyrim in the Task Manager snapshot. Tab to Task Manager, release Tab; next, press the Down-arrow (↓) key one time if Skyrim was the top item in the list, two times if it was the second, and so on; then press Alt-E to force-exit the crashed app and get back to the desktop.

If you get persistent crashes after a crash (e.g., Skyrim dies on startup or immediately after loading any save), your system memory is likely corrupt and you should reboot the PC and operating system. If the issues continue immediately after a reboot, this may be caused by the game data being corrupted. If issues such as other applications crashing or the system rebooting randomly occur along with the Skyrim crashes, check your OS and computer hardware for potential issues.

## Glitch Recovery (Game Behaviors Stuck)
You can also get a "behavioral crash", in which some aspect of the game play becomes broken but the game continues anyway

- If you are stuck at sneak speed or over-encumbered speed even though you are not sneaking or over-encumbered (and you're certain of the latter – check for any negative magic effects suppressing your speed or carry weight): Save the game, then try loading your last save before that one; if speed is normal, try your most recent save again. If this does not fix the problem, try an earlier save. If the problem persists, the game's memory is corrupted. Do not save again, but simply restart the game app and load your last save.
- If sound is stuck in a loop, try the above steps, too.
- If stations (crafting, alchemy, enchanting, etc.) are not working, and you just enter the station animation then immediately exit it, the fix is strange: Enter third-person mode (if not already in it), unequip both hands of any gear or spells, ready your hands as if to fist fight, then "sheath" them; ready and "sheath" them again for good measure. You can now re-enter first-person mode if you like, and the stations should work normally in either view.