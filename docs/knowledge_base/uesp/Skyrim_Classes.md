# Classes

In Skyrim, a **class** cannot be chosen by the player character, but is instead used by [NPCs](Skyrim_NPCs.md). There may be some classes that appear identical to each other. The difference between such classes are the [services](Skyrim_Services.md) offered, which are not listed here.

## Skill and Attribute Weights
The numbers in the table are the weights assigned by the classes to each [skill](Skyrim_Skills.md) and each [attribute](Skyrim_Attributes.md) (empty cells have a weight of zero). These weights determine how many of 8 skill points and 10 attribute points per level are added to each value. Note that 5 points per gained level are always added to [Health](Skyrim_Health.md), *in addition to* any health points from the shared set of 10 attribute points; this means NPCs gain 15 attributes per level, in addition to *approximately* 8 skill points per level (see below).

Unlike the PC, there is no intrinsic mechanism for an NPC to gain *perks* as they level; a stock leveled NPC has the same perks at any level. This is one of the reasons [leveled lists](Skyrim_Leveled_Lists.md) exist. For example, a [Bandit](Skyrim_Bandit.md) Thug and a Bandit Highwayman are fundamentally the same NPC at levels 9 and 14, respectively (they are both members of the Bandit Archer class, below), but the former has the [Extra Damage 1.5](Skyrim_Extra_Damage_1.5.md) perk, while the latter has [Extra Damage 2](Skyrim_Extra_Damage_2.md). Because perks are manually assigned to an NPC independently of its level or class (and hence independently of its skill expertise and attributes), mismatches exist; this is particularly noticeable among [followers](Skyrim_Followers.md).

Class and perks are also not automatically tied to equipment or spells in any way, leading to the same mismatches; while the aforementioned Thug and Highwayman share the same leveled lists for equipment, and their level is used to determine what they have, these lists were assigned manually, not by the class (or [race](Skyrim_Races.md)). Typically, these mismatches are less obviously unintentional, particularly when an NPC lacks *any* equipment, but still sometimes leads to followers carrying weapons they do not know how to use.

### Attribute Weights
The game ensures attribute points are not lost or gained due to rounding, but it is easy for an NPC's number of attribute points to not be an integer multiple of a weight (for example, Imperial Soldiers have a Stamina weight of 7, but can be level 37). Attribute points are actually assigned as follows:

1. Calculate the total number of points available (10 * (level - 1))
2. Calculate the result for the attribute with the highest weight, rounded down, and subtract that from the total. - In the event of a tie, choose Health over Magicka or Stamina, and Magicka over Stamina.
3. Repeat for the next-highest result, remembering to use the ratio of only the two remaining attributes.
4. Any remaining points go to the last attribute.

This means there is a weighting bias in favor of Stamina over Magicka and Magicka over Health, because Stamina is intrinsically chosen last and gets anything the others lost due to rounding, but Health gets 1/3 of each level's attribute points before assignment. For example:

- A beggar has weights 1, 1, 1 - all equal. A beggar at level 8 (70 attribute points, plus 35 mandatory health points) calculates as follows: 1. Health is assigned 23 points (70/3, rounded down), then adds 35: Health +58.
2. Magicka is assigned 23 points ((70-23)/2, rounded down): Magicka +23.
3. Stamina is assigned 24 points (70-23-23): Stamina +24.

### Skill Weights
In the "Primary Skills" summary on individual NPC pages, skills with values of 3 or greater are normally emphasized in **bold** face, skills with a value of 2 are shown in normal font, and skills with a value of 1 or 0 are not listed. However, on NPCs with a fixed low level, the displayed skills are adjusted taking into account racial skill bonuses, with only skills greater than 25 being shown.

Unlike with Attributes, an NPC is capable of "losing" or "gaining" skill points due to rounding; a skill gains skill points in accordance with:

```
This Skill Points = round(Total Skill Points * (This Skill Weight / Sum of Skill Weights))

```
Where Total Skill Points = (Level-1)*8; an NPC's skill points at level 1 are 15 (a game-wide constant) base, then modified by its race.

Note the *drastic* difference between NPCs and the PC: for the PC, each [level](Skyrim_Leveling.md) takes more skill ranks than the level before did, while NPCs gain a linear (aside from rounding errors) number of skill points per level. On the other hand, the PC needs less than 8 skill points to level initially (only 4 are needed in the skill the PC's race is best at to level) and that number depends on which skill is being leveled (since the 100th rank in a skill counts for more than the 16th); assuming the PC is leveling as quickly as possible, their skill ranks per level will only *exceed* 8 (meaning the NPCs have begun "winning") at level 33.

Because NPCs face the same skill maximum of 100 ranks as the PC, however, and unlike the PC, will *not* resort to putting skill points into non-preferential (0 weight, below) skills - the formula above *always* holds true - past a certain point, which depends on the NPC's class, they will cease to gain *any* skill points per level, and will only gain attributes. An excellent example of this is [Arngeir](Skyrim_Arngeir.md), who is level 150, but stopped gaining skill points at level 139 (which is when he reached 100 ranks in Enchanting). In addition, none of his leveled skills *do* anything - he has no weapons or armor to smith or enchant (nor would he, if he did have them - NPCs with crafting skills do not automatically craft anything), no potions indicative of his alchemy, no spells to cast with conjuration or restoration (he only has shouts), and no way to use the speech skill. This is indicative of how the game usually works - there is simply no framework in place allowing NPCs to "automatically" employ their skills, so it has to be assigned manually. This is why you routinely see NPCs like Arngeir, with magic skills but no spells to cast with them, crafting skills but nothing crafted to show for it (which is why the PC is the only source of smithed gear in the game - NPCs *never* carry Fine or better gear), speech without relatively increased money or gear quality (as is found on the PC), etc.

#### Mismatch Examples
As the table below shows, many physical-combat-oriented classes such as [Stormcloak](Skyrim_Stormcloaks.md) ("Sons of Skyrim") Guards and Soldiers (Class IDs Guard Sons Skyrim and Soldier Sons Skyrim Not Guard respectively) and [Orc](Skyrim_Orc.md) Warriors (Guard Orc1H and Guard Orc2H) have no magic skills, yet are weighted toward [Magicka](Skyrim_Magicka.md) as well as [Health](Skyrim_Health.md) as their levels increase, leaving them with stunted [Stamina](Skyrim_Stamina.md). Consequently, if you keep them in melee range but avoid or [Block](Skyrim_Block.md) (or simply withstand) their swings, they rapidly become less dangerous than they should be, from exhaustion. They are also an unexpectedly good source of unused Magicka to [Absorb](Skyrim_Absorb_Magicka.md) from them during the fight.

Numerous NPCs likewise come with gear that is not suited at all to their specializations (e.g. [Light Armor](Skyrim_Light_Armor.md) when they should have [Heavy](Skyrim_Heavy_Armor.md), or [One-handed](Skyrim_One-handed.md) weapons when they should have [Two-handed](Skyrim_Two-handed.md)). If gear they should prefer is dropped near them, they will not pick it up and switch. Even using the [Console](Skyrim_Console.md) to give them armor they should like will not make them auto-equip any of it in most cases, due to the game's pre-set Outfits system; they typically must be forced to equip it with `[Equip Item](Skyrim_Console.md#equipitem) <Base ID>`. (This does not apply to long-term followers, who provide inventory access, though you sometimes have to take things away from them to get them to use what you want.)

A more specific example of how the lack of automatic perks and gear can lead to apparent absurdity is provided by the three [Dawnguard](Skyrim_Dawnguard.md) followers that have no maximum level: [Celann](Skyrim_Celann.md), [Durak](Skyrim_Durak.md), and [Ingjard](Skyrim_Ingjard.md), particularly without the [Unofficial Skyrim Patch](https://en.uesp.net/wiki/Skyrim_Mod:Unofficial_Skyrim_Patch).

Ingjard has no perks at all, but is a [Nord](Skyrim_Nord.md) Combat Warrior2H, meaning she reaches 100 skill in Two-handed very quickly (at level 36), then stops getting any better at it. [Celann](Skyrim_Celann.md) is a [Breton](Skyrim_Breton.md) Combat Warrior1H, meaning he reaches 100 in the same skill *much* slower (level 118), but he has the [Extra Damage 1.5](Skyrim_Extra_Damage_1.5.md) perk, meaning he will do the same damage as Ingjard once he reaches skill 80 at level 90, and then continue on to surpass her; in addition, he inexplicably has [Champion's Stance](Skyrim_Champion%27s_Stance.md), letting him power attack more often than she does right from the start, with the same Two-handed weapons he does not have any skill with yet.

Meanwhile, both Celann and Durak have [Custom Fit](Skyrim_Custom_Fit.md), even though Celann has *zero* skill weight on Light Armor (Durak does have skill weight on Light Armor); *both* wear Light Armor stock, so Durak will be drastically more durable if you do not issue Celann new gear, and even if you do give him some heavy armor, he will be at a constant disadvantage.

None of the three has access to any sort of leveled lists for gear, so they will carry the same gear at any level unless you give them something better to carry.

## List of Classes
| Name | Editor ID | [Form ID](Skyrim_Form_ID.md) | [Combat](Skyrim_Combat.md) | | [Magic](Skyrim_Magic.md) | | [Stealth](Skyrim_Stealth.md) | | [Attributes](Skyrim_Attributes.md) | | | | | | | | | | | | | | | | | |
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| [ARC](Skyrim_Archery.md) | [BLO](Skyrim_Block.md) | [HVA](Skyrim_Heavy_Armor.md) | [1HD](Skyrim_One-handed.md) | [SMI](Skyrim_Smithing.md) | [2HD](Skyrim_Two-handed.md) | | [ALT](Skyrim_Alteration.md) | [CON](Skyrim_Conjuration.md) | [DES](Skyrim_Destruction.md) | [ENC](Skyrim_Enchanting.md) | [ILU](Skyrim_Illusion.md) | [RES](Skyrim_Restoration.md) | | [ALC](Skyrim_Alchemy.md) | [LTA](Skyrim_Light_Armor.md) | [LOC](Skyrim_Lockpicking.md) | [PIC](Skyrim_Pickpocket.md) | [SNK](Skyrim_Sneak.md) | [SPE](Skyrim_Speech.md) | | [Hea](Skyrim_Health.md) | [Mag](Skyrim_Magicka.md) | [Sta](Skyrim_Stamina.md) | | | |
| Alik'r Archer | Enc Class Alikr Missile | 00 06766c | 3 | 1 | 1 | 2 | | | | | | | | | | | | 2 | | | 2 | | | 3 | | 2 |
| Alik'r Warrior | Enc Class Alikr Melee | 00 06766b | | 2 | 1 | 3 | | 3 | | | | | | | | | | 2 | | | | | | 3 | | 2 |
| Alik'r Wizard | Enc Class Alikr Wizard | 00 06766d | | | | | | | | | 2 | 3 | | 2 | 2 | | | 1 | | | 1 | | | 2 | 3 | |
| Apothecary | Trainer Alchemy Expert | 00 0e3a6e | | | | | | | | 1 | | | | | | | 4 | | | 2 | 2 | 3 | | 1 | 1 | 1 |
| Apothecary | Trainer Alchemy Journeyman | 00 0e3a5d | | | | | | | | 1 | | | | | | | 3 | | | 2 | 2 | 3 | | 1 | 1 | 1 |
| Apothecary | Vendor Apothecary | 00 013258 | | | | | | | | 1 | | | | | | | 3 | | | 2 | 2 | 3 | | 1 | 1 | 1 |
| Ash Guardian<sup>[DB](Skyrim_Dragonborn.md)</sup> | DLC2Enc Class Ash Guardian | [xx](Skyrim_Form_ID.md) 03cf6a | | 1 | | 2 | | 1 | | | | 3 | | | | | | | | | 2 | | | 2 | 2 | 2 |
| Ash Hopper<sup>[DB](Skyrim_Dragonborn.md)</sup> | DLC2Enc Class Ash Hopper | [xx](Skyrim_Form_ID.md) 020e8a | 3 | 1 | | 3 | | | | | | | | | | | | | | | 3 | | | 4 | | 2 |
| Assassin | Combat Assassin | 00 01317f | 2 | | | 3 | | | | 1 | | | | | | | | 2 | | | 3 | | | 2 | 1 | 3 |
| Assassin | Trainer Alchemy Master | 00 0e3a67 | 4 | | | 3 | | | | 1 | | | | | | | | 2 | | | 3 | | | 2 | 1 | 3 |
| Assassin | Trainer Light Armor Master | 00 0e3a68 | 2 | | | 3 | | | | 1 | | | | | | | | 4 | | | 3 | | | 2 | 1 | 3 |
| Atronach | Enc Class Atronach Flame | 00 0ad235 | 2 | 1 | | 3 | | | | | | 3 | | | | | | | | | 2 | | | 2 | 3 | 1 |
| Atronach | Enc Class Atronach Frost | 00 0ad236 | 1 | 3 | | 2 | | | | | | 3 | | | | | | | | | 2 | | | 3 | 1 | 2 |
| Atronach | Enc Class Atronach Storm | 00 0ad237 | | 1 | | 2 | | 1 | | | | 3 | | | | | | | | | 2 | | | 2 | 2 | 2 |
| Bandit | Enc Class Bandit Melee | 00 01ce17 | | 2 | 1 | 3 | | 3 | | | | | | | | | | 2 | | | | | | 3 | | 2 |
| Bandit<sup>[DB](Skyrim_Dragonborn.md)</sup> | DLC2Enc Class Bandit Boss | [xx](Skyrim_Form_ID.md) 01e8ac | | | 2 | 3 | | | | 2 | | 3 | | | 1 | | | | | | 1 | | | 3 | 2 | |
| Bandit Archer | Enc Class Bandit Missile | 00 015be7 | 3 | 1 | 1 | 2 | | | | | | | | | | | | 2 | | | 2 | | | 3 | | 2 |
| Bandit Archer<sup>[DB](Skyrim_Dragonborn.md)</sup> | DLC2Enc Class Riekling | [xx](Skyrim_Form_ID.md) 03bd08 | 3 | 1 | | 1 | | 2 | | | | | | | | | | 2 | | | 2 | | | 3 | | 2 |
| Bandit Wizard | Enc Class Bandit Wizard | 00 039d30 | | | | 1 | | | | 2 | | 3 | | | 2 | | | 1 | | | 2 | | | 2 | 3 | |
| Barbarian | Combat Barbarian | 00 01ce16 | 2 | 2 | | 1 | | 3 | | | | | | | | | | 3 | | | | | | 4 | | 2 |
| Name | Editor ID | [Form ID](Skyrim_Form_ID.md) | [ARC](Skyrim_Archery.md) | [BLO](Skyrim_Block.md) | [HVA](Skyrim_Heavy_Armor.md) | [1HD](Skyrim_One-handed.md) | [SMI](Skyrim_Smithing.md) | [2HD](Skyrim_Two-handed.md) | | [ALT](Skyrim_Alteration.md) | [CON](Skyrim_Conjuration.md) | [DES](Skyrim_Destruction.md) | [ENC](Skyrim_Enchanting.md) | [ILU](Skyrim_Illusion.md) | [RES](Skyrim_Restoration.md) | | [ALC](Skyrim_Alchemy.md) | [LTA](Skyrim_Light_Armor.md) | [LOC](Skyrim_Lockpicking.md) | [PIC](Skyrim_Pickpocket.md) | [SNK](Skyrim_Sneak.md) | [SPE](Skyrim_Speech.md) | | [Hea](Skyrim_Health.md) | [Mag](Skyrim_Magicka.md) | [Sta](Skyrim_Stamina.md) |
| Bard | Bard | 00 01325d | 1 | | | 1 | | | | 2 | | | | 2 | | | | | | 2 | | 4 | | 2 | 3 | 2 |
| Bard | Trainer Speechcraft Expert | 00 0e3a70 | 1 | | | 1 | | | | 2 | | | | 2 | | | | | | 2 | | 4 | | 2 | 3 | 2 |
| Beggar | Beggar | 00 01327b | 1 | 1 | | 1 | 1 | | | 1 | | | 1 | | | | 1 | | 1 | 3 | 2 | 4 | | 1 | 1 | 1 |
| Blacksmith | Trainer Heavy Armor Expert | 00 0e3a60 | 2 | 3 | | 3 | | 2 | | | | | | | | | | | | | 1 | | | 2 | 2 | 1 |
| Blacksmith | Trainer Heavy Armor Master | 00 0e7f45 | | | | 2 | 3 | | | | | | | | | | | | | 2 | 1 | 3 | | 3 | | 3 |
| Blacksmith | Trainer Light Armor Expert | 00 0e3a61 | 2 | | | 2 | 3 | | | | | | | | | | | 3 | | 2 | 1 | 3 | | 2 | 2 | 1 |
| Blacksmith | Trainer Light Armor Journeyman | 00 0b8340 | 2 | | | 2 | 2 | | | | | | | | | | | 3 | | 2 | 1 | 3 | | 2 | 2 | 1 |
| Blacksmith | Trainer Smithing Expert | 00 0e3a5f | | | | 2 | 3 | | | | | | | | | | | | | 2 | 1 | 3 | | 2 | 2 | 1 |
| Blacksmith | Trainer Smithing Journeyman | 00 0aedd2 | | | | 2 | 3 | | | | | | | | | | | | | 2 | 1 | 3 | | 2 | 2 | 1 |
| Blacksmith | Trainer Smithing Master | 00 042dc1 | | | | 2 | 4 | | | | | | | | | | | | | 2 | 1 | 3 | | 2 | 2 | 1 |
| Blacksmith | Vendor Blacksmith | 00 013257 | | 2 | | 2 | 3 | | | | | | | | | | | | | | 1 | 3 | | 2 | 1 | 2 |
| Blade | Blade | 00 021a74 | 3 | 2 | | 2 | | | | | | | | | | | | 1 | | | 3 | | | 3 | 3 | |
| Chaurus | Enc Class Chaurus | 00 044cca | 3 | 1 | | 3 | | | | | | | | | | | | | | | 3 | | | 4 | | 2 |
| Chaurus Flyer<sup>[DG](Skyrim_Dawnguard.md)</sup> | DLC1_Enc Class Chaurus Flyer | [xx](Skyrim_Form_ID.md) 005206 | 3 | 1 | | 3 | | | | | | | | | | | | | | | 3 | | | 4 | | 2 |
| Child | Child | 00 013279 | | | | | 4 | | | | | | 4 | | | | 4 | | | 1 | 2 | 1 | | | | 1 |
| Citizen | Citizen | 00 01326b | 2 | | | 2 | 3 | | | | | | 3 | | | | 3 | 2 | | | 2 | 2 | | 1 | 1 | 1 |
| Conjurer | Combat Mage Conjurer | 00 01ce14 | | | | | | | | 2 | 3 | 2 | | | 3 | | | | | | 1 | | | 2 | 4 | |
| Conjurer | Combat Mage Necro | 00 0c969f | | | | 2 | | | | 2 | 3 | | | | 3 | | | | | | 1 | | | 2 | 4 | |
| Conjurer | Trainer Conjuration Expert | 00 0e3a78 | | | | | | | | 2 | 3 | 2 | | | 3 | | | | | | 1 | | | 2 | 4 | |
| Conjurer | Trainer Conjuration Master | 00 0e3a6a | | | | | | | | 2 | 4 | 2 | | | 3 | | | | | | 1 | | | 2 | 4 | |
| Name | Editor ID | [Form ID](Skyrim_Form_ID.md) | [ARC](Skyrim_Archery.md) | [BLO](Skyrim_Block.md) | [HVA](Skyrim_Heavy_Armor.md) | [1HD](Skyrim_One-handed.md) | [SMI](Skyrim_Smithing.md) | [2HD](Skyrim_Two-handed.md) | | [ALT](Skyrim_Alteration.md) | [CON](Skyrim_Conjuration.md) | [DES](Skyrim_Destruction.md) | [ENC](Skyrim_Enchanting.md) | [ILU](Skyrim_Illusion.md) | [RES](Skyrim_Restoration.md) | | [ALC](Skyrim_Alchemy.md) | [LTA](Skyrim_Light_Armor.md) | [LOC](Skyrim_Lockpicking.md) | [PIC](Skyrim_Pickpocket.md) | [SNK](Skyrim_Sneak.md) | [SPE](Skyrim_Speech.md) | | [Hea](Skyrim_Health.md) | [Mag](Skyrim_Magicka.md) | [Sta](Skyrim_Stamina.md) |
| Death Hound<sup>[DG](Skyrim_Dawnguard.md)</sup> | DLC1Enc Class Deathhound | [xx](Skyrim_Form_ID.md) 0145dc | 2 | 2 | | 3 | | | | | | | | | | | | 1 | | | 3 | | | 4 | | 2 |
| Destruction Mage | Combat Mage Destruction | 00 01e7d0 | | | | | | | | 2 | 1 | 3 | | | 3 | | | | | | 2 | | | 2 | 4 | |
| Destruction Mage | Trainer Destruction Expert | 00 0e3a5c | | | | | | | | 2 | 1 | 3 | | | 3 | | | | | | 2 | | | 2 | 4 | |
| DLC2Ralis | DLC2dun Kolbjorn Ralis Class | [xx](Skyrim_Form_ID.md) 0179c6 | | 2 | | 3 | | | | | | | | | | | | 3 | | | 2 | | | 2 | 2 | 1 |
| Dragon | Enc Class Dragon | 00 02f201 | 3 | 3 | | 3 | | | | | | | | | | | | | | | 5 | | | 4 | | 2 |
| Dragon Priest | Enc Class Dragon Priest | 00 01ce1c | | | | | | | | 3 | 5 | 6 | | | 5 | | | | | | | | | 3 | 3 | |
| Draugr Melee | Enc Class Draugr Melee | 00 023c0c | | 2 | 2 | 3 | | 3 | | | | | | | | | | | | | 1 | | | 3 | | 3 |
| Draugr Missile | Enc Class Draugr Missile | 00 023c0d | 3 | | 2 | 3 | | 2 | | | | | | | | | | | | | 2 | | | 3 | | 3 |
| Draugr Warlock | Enc Class Draugr Magic | 00 023c0e | | | | 2 | | | | | 3 | 3 | | | 2 | | | | | | 2 | | | 3 | 3 | |
| Dremora | Enc Class Dremora Melee | 00 017008 | | 2 | 2 | 3 | | 3 | | | | | | | | | | | | | 1 | | | 3 | | 2 |
| Dwarven Centurion | Enc Class Dwarven Centurion | 00 090356 | | 2 | | 3 | | 3 | | | | 1 | | | | | | | | | 2 | | | 3 | | 2 |
| Dwarven Sphere | Enc Class Dwarven Sphere | 00 090358 | 3 | 2 | | 3 | | | | | | 1 | | | | | | | | | 2 | | | 3 | | 2 |
| Dwarven Sphere *[[sic](https://en.uesp.net/wiki/UESPWiki:Spelling#Books_and_Direct_Quotes)]* | Enc Class Dwarven Spider | 00 090359 | 1 | 2 | | 3 | | | | | | 3 | | | | | | | | | 2 | | | 3 | | 2 |
| Ebony Warrior Class<sup>[DB](Skyrim_Dragonborn.md)</sup> | DLC2Ebony Warrior Class | [xx](Skyrim_Form_ID.md) 0285c2 | 9 | 9 | 9 | 9 | | | | 6 | 7 | 3 | | | 3 | | | | | | 8 | | | 4 | | 2 |
| Enchanter<sup>[DB](Skyrim_Dragonborn.md)</sup> | DLC2Neloth Class Trainer | [xx](Skyrim_Form_ID.md) 017774 | | | | | | | | 2 | 2 | 3 | | | 3 | | | | | | 1 | | | 2 | 4 | |
| Falmer | Enc Class Falmer | 00 01ce1e | 3 | 2 | | 3 | | | | | | 2 | | | | | | | | | 2 | | | 3 | 2 | 1 |
| Falmer Shaman | Enc Class Falmer Shaman | 00 01ce1f | | | | 1 | | | | 2 | 1 | 3 | | | 3 | | | | | | 1 | | | 2 | 3 | 1 |
| Farmer | Farmer | 00 01326c | 2 | | | 2 | 3 | 2 | | | | | 3 | | | | 3 | 1 | | | 1 | 1 | | 1 | 1 | 1 |
| Fire/Frost/Shock Mage | Combat Mage Elemental | 00 01317a | | | | | | | | 2 | 2 | 3 | | | 3 | | | | | | 1 | | | 2 | 4 | |
| Fire/Frost/Shock Mage | Trainer Alteration Expert | 00 0e3a71 | | | | | | | | 4 | 3 | 3 | | | 2 | | | | | | 1 | | | 2 | 4 | |
| Name | Editor ID | [Form ID](Skyrim_Form_ID.md) | [ARC](Skyrim_Archery.md) | [BLO](Skyrim_Block.md) | [HVA](Skyrim_Heavy_Armor.md) | [1HD](Skyrim_One-handed.md) | [SMI](Skyrim_Smithing.md) | [2HD](Skyrim_Two-handed.md) | | [ALT](Skyrim_Alteration.md) | [CON](Skyrim_Conjuration.md) | [DES](Skyrim_Destruction.md) | [ENC](Skyrim_Enchanting.md) | [ILU](Skyrim_Illusion.md) | [RES](Skyrim_Restoration.md) | | [ALC](Skyrim_Alchemy.md) | [LTA](Skyrim_Light_Armor.md) | [LOC](Skyrim_Lockpicking.md) | [PIC](Skyrim_Pickpocket.md) | [SNK](Skyrim_Sneak.md) | [SPE](Skyrim_Speech.md) | | [Hea](Skyrim_Health.md) | [Mag](Skyrim_Magicka.md) | [Sta](Skyrim_Stamina.md) |
| Fletcher | Vendor Fletcher | 00 013259 | 3 | | | | 2 | | | | | | | | | | | | | 1 | 2 | 3 | | 1 | 2 | 1 |
| Food Vendor | Vendor Food | 00 013256 | | 1 | | 2 | | | | | | | | | | | | | | 3 | 2 | 3 | | 1 | 1 | 1 |
| Forsworn | Enc Class Forsworn | 00 043bcb | | | | 3 | | | | 1 | | 2 | | | 1 | | | 2 | | | 2 | | | 2 | 2 | 1 |
| Forsworn Missile | Enc Class Forsworn Missile | 00 043bcd | 3 | | | 1 | | | | 2 | | | | | 1 | | | 2 | | | 2 | | | 2 | 1 | 2 |
| Forsworn Shaman | Enc Class Forsworn Shaman | 00 043bcc | | | | | | | | 1 | 2 | 3 | | | 2 | | | 1 | | | 2 | | | 2 | 3 | |
| Frea Combat Style<sup>[DB](Skyrim_Dragonborn.md)</sup> | DLC2cs Frea | [xx](Skyrim_Form_ID.md) 030cca | 1 | | | 3 | | | | 3 | | | | | 2 | | | 2 | | | | | | 3 | 1 | 2 |
| Frostbite Spider | Enc Class Frostbite Spider | 00 044ccb | 3 | 2 | | 3 | | | | | | | | | | | | | | | 3 | | | 3 | | 3 |
| Gargoyle<sup>[DG](Skyrim_Dawnguard.md)</sup> | DLC1Enc Class Gargoyle | [xx](Skyrim_Form_ID.md) 00d6f6 | 2 | 2 | | 3 | | | | | | | | | | | | 1 | | | 3 | | | 4 | | 2 |
| Giant | Enc Class Giant | 00 0abb44 | | 2 | 1 | 3 | | 3 | | | | | | | | | | 2 | | | | | | 3 | | 2 |
| Guard | Guard Imperial | 00 0253f2 | 1 | 2 | 2 | 3 | | | | | | | | | | | | 2 | | | 2 | | | 4 | | 2 |
| Guard | Guard Sons Skyrim | 00 0253f3 | 1 | 2 | 2 | | | 3 | | | | | | | | | | 2 | | | 2 | | | 4 | 2 | |
| Hagraven | Enc Class Hagraven | 00 0a93b3 | | | | | | | | 2 | | 3 | | | 3 | | | | | | 3 | | | 2 | 3 | |
| Haknir Death-Brand<sup>[DB](Skyrim_Dragonborn.md)</sup> | DLC2dun Haknir Class | [xx](Skyrim_Form_ID.md) 037feb | | | 4 | 5 | | | | | | | | | | | | | | | | | | 3 | | 2 |
| Horker | Enc Class Horker | 00 0edd36 | 3 | 2 | | 3 | | | | | | | | | | | | | | | 3 | | | 5 | | 3 |
| Horse | Enc Class Horse | 00 10f71e | 3 | 2 | | 3 | | | | | | | | | | | | | | | 3 | | | 4 | | 1 |
| Ice Wraith | Enc Class Ice Wraith | 00 073f1f | 2 | 1 | | 2 | | | | | | 3 | | | | | | | | | 2 | | | 4 | | 2 |
| Imperial Soldier | Soldier Imperial Not Guard | 00 01327f | 3 | 3 | 3 | 3 | | 3 | | | | | | | | | | 3 | | | | | | 3 | | 7 |
| Jailor | Jailor | 00 01325e | | 2 | | 3 | | | | | | | | | | | | 3 | 2 | 2 | 2 | | | 3 | | 2 |
| Karstaag<sup>[DB](Skyrim_Dragonborn.md)</sup> | DLC2dun Karstaag Class | [xx](Skyrim_Form_ID.md) 028213 | 1 | 5 | 3 | 1 | 1 | 7 | | 1 | 1 | 3 | 1 | 1 | 1 | | 1 | 3 | 1 | 1 | 5 | 1 | | 3 | | 1 |
| Katria<sup>[DG](Skyrim_Dawnguard.md)</sup> | DLC1Enc Class Katria | [xx](Skyrim_Form_ID.md) 004d0e | 3 | 1 | 1 | 2 | | | | | | | | | | | | 2 | | | 2 | | | 2 | 1 | 3 |
| Name | Editor ID | [Form ID](Skyrim_Form_ID.md) | [ARC](Skyrim_Archery.md) | [BLO](Skyrim_Block.md) | [HVA](Skyrim_Heavy_Armor.md) | [1HD](Skyrim_One-handed.md) | [SMI](Skyrim_Smithing.md) | [2HD](Skyrim_Two-handed.md) | | [ALT](Skyrim_Alteration.md) | [CON](Skyrim_Conjuration.md) | [DES](Skyrim_Destruction.md) | [ENC](Skyrim_Enchanting.md) | [ILU](Skyrim_Illusion.md) | [RES](Skyrim_Restoration.md) | | [ALC](Skyrim_Alchemy.md) | [LTA](Skyrim_Light_Armor.md) | [LOC](Skyrim_Lockpicking.md) | [PIC](Skyrim_Pickpocket.md) | [SNK](Skyrim_Sneak.md) | [SPE](Skyrim_Speech.md) | | [Hea](Skyrim_Health.md) | [Mag](Skyrim_Magicka.md) | [Sta](Skyrim_Stamina.md) |
| Lumberjack | Lumberjack | 00 01326e | 2 | | | 2 | 3 | 2 | | | | | 3 | | | | 3 | 1 | | | 1 | 1 | | 1 | 1 | 1 |
| Lurker<sup>[DB](Skyrim_Dragonborn.md)</sup> | DLC2Enc Class Lurker | [xx](Skyrim_Form_ID.md) 03183a | | 2 | 9 | | | | | 1 | | 3 | | | 2 | | | | | | 3 | | | 4 | | 2 |
| Mammoth | Enc Class Mammoth | 00 0f2594 | 2 | 3 | | 2 | | | | | | | | | | | | | | | 3 | | | 4 | | 2 |
| Miner | Miner | 00 01326d | 2 | | | 2 | 3 | 2 | | | | | 3 | | | | 3 | 1 | | | 1 | 1 | | 1 | 1 | 1 |
| Miraak<sup>[DB](Skyrim_Dragonborn.md)</sup> | DLC2Enc Class Miraak | [xx](Skyrim_Form_ID.md) 023f78 | | 1 | 2 | 2 | | | | 2 | | 2 | | | 2 | | | | | | | 8 | | 3 | 3 | 2 |
| Monk | Combat Monk | 00 013182 | 2 | | | 2 | | | | 2 | | | | | 2 | | | 1 | | | 2 | | | 2 | 2 | 2 |
| Monk | Trainer Restoration Expert | 00 0e3a74 | | | | | | | | 3 | 1 | | | | 3 | | | | | | 2 | | | 2 | 3 | 1 |
| Mud Crab | Enc Class Mud Crab | 00 0bb4b0 | 3 | 2 | | 3 | | | | | | | | | | | | | | | 3 | | | 3 | | 3 |
| Mystic | Combat Mystic | 00 01317b | | | | | | | | 3 | 2 | | | 3 | 1 | | | | | | 2 | | | 2 | 3 | 1 |
| Nightblade | Combat Nightblade | 00 01317c | | | | 2 | | | | 2 | | 3 | | | | | | 1 | | | 3 | | | 2 | 2 | 2 |
| Nord Hero | MQAncient Nord | 00 04fa49 | 2 | 2 | | 1 | | 3 | | | | | | | | | | 3 | | | | | | 4 | | 2 |
| Orc Warrior | Guard Orc1H | 00 02a477 | 2 | 1 | 3 | 3 | | | | | | | | | | | | | | | 2 | | | 4 | 2 | |
| Orc Warrior | Guard Orc2H | 00 10e714 | 2 | 1 | 3 | | | 3 | | | | | | | | | | | | | 2 | | | 4 | 2 | |
| Pawnbroker | Vendor Pawnbroker | 00 01325b | | | | 1 | | | | | | | | | | | | | 2 | 2 | 3 | 3 | | 1 | 1 | 1 |
| Penitus Oculatus | Enc Class Penitus Oculatus | 00 07d98d | | 1 | 2 | 3 | | | | | | 2 | | | | | | | | | 1 | | | 2 | 2 | 2 |
| Player Spellsword Class | AAAPlayer Spellsword Class | 00 02f202 | 3 | 1 | | 2 | | | | | | 3 | | | 3 | | | | | | | | | 2 | 2 | 2 |
| Predator | Enc Class Animal Predator | 00 0131e6 | 2 | 3 | | 2 | | | | | | | | | | | | | | | 3 | | | 3 | | 3 |
| Predator | Enc Class Bear | 00 106aed | 2 | 3 | | 2 | | | | | | | | | | | | | | | 3 | | | 3 | | 3 |
| Prey | Enc Class Animal Prey | 00 01ce1d | 3 | 2 | | 3 | | | | | | | | | | | | | | | 3 | | | 3 | | 3 |
| Priest | Priest | 00 013276 | | | | | 2 | | | | 2 | | 1 | | 3 | | 2 | | | | | 3 | | 1 | | 2 |
| Name | Editor ID | [Form ID](Skyrim_Form_ID.md) | [ARC](Skyrim_Archery.md) | [BLO](Skyrim_Block.md) | [HVA](Skyrim_Heavy_Armor.md) | [1HD](Skyrim_One-handed.md) | [SMI](Skyrim_Smithing.md) | [2HD](Skyrim_Two-handed.md) | | [ALT](Skyrim_Alteration.md) | [CON](Skyrim_Conjuration.md) | [DES](Skyrim_Destruction.md) | [ENC](Skyrim_Enchanting.md) | [ILU](Skyrim_Illusion.md) | [RES](Skyrim_Restoration.md) | | [ALC](Skyrim_Alchemy.md) | [LTA](Skyrim_Light_Armor.md) | [LOC](Skyrim_Lockpicking.md) | [PIC](Skyrim_Pickpocket.md) | [SNK](Skyrim_Sneak.md) | [SPE](Skyrim_Speech.md) | | [Hea](Skyrim_Health.md) | [Mag](Skyrim_Magicka.md) | [Sta](Skyrim_Stamina.md) |
| Priest | Trainer Conjuration Journeyman | 00 0e3a72 | | | | | 2 | | | | 4 | | 2 | 2 | 3 | | 2 | | | | | 3 | | 1 | | 2 |
| Priest | Trainer Enchanting Master | 00 0e3a77 | | | | | 2 | | | | | 2 | 1 | | 3 | | 2 | | | | | 3 | | 1 | | 2 |
| Priest | Trainer Restoration Journeyman | 00 0c2914 | | | | | 2 | | | | | | 2 | 2 | 3 | | 2 | | | | | 3 | | 1 | | 2 |
| Priest | Trainer Restoration Master | 00 0e3a75 | | | | | 2 | | | | | | 2 | 2 | 4 | | 2 | | | | | 3 | | 1 | | 2 |
| Prisoner | Prisoner | 00 013263 | | | | 1 | 3 | | | | | | 3 | | | | 3 | | 1 | 1 | 1 | 1 | | 1 | 1 | 1 |
| Ranger | Combat Ranger | 00 013181 | 3 | 2 | | 2 | | | | | | | | | | | | 3 | | | 1 | | | 3 | | 3 |
| Rogue | Combat Rogue | 00 013180 | 1 | 2 | | 3 | | | | | | | | | | | | 2 | | | 3 | | | 3 | | 3 |
| Scout | Combat Scout | 00 01317d | 3 | | | | | | | 1 | | | | | 2 | | | 2 | | | 3 | | | 2 | 2 | 2 |
| Scout | Trainer Sneak Expert | 00 0e3a6c | 3 | | | | | | | 1 | | | | | 2 | | | 2 | | | 4 | | | 2 | 2 | 2 |
| Soldier | CWSoldier Class | 00 10b1d8 | 2 | 2 | 1 | 2 | | 2 | | | | | | | | | | 1 | | | | | | 3 | | 7 |
| Sons of Skyrim Soldier | Soldier Sons Skyrim Not Guard | 00 013280 | 3 | 3 | 3 | 3 | | 3 | | | | | | | | | | 3 | | | | | | 1 | 1 | |
| Sorcerer | Combat Sorcerer | 00 013179 | | | 2 | 2 | | | | | | 3 | | 3 | 1 | | | | | | | | | 2 | 3 | 1 |
| Sorcerer | Trainer Destruction Journeyman | 00 0e2fcd | | | | | | | | 1 | 1 | 3 | | 3 | 1 | | | | | | 1 | | | 2 | 4 | 1 |
| Sorcerer | Trainer Destruction Master | 00 0e3a73 | | | 2 | 2 | | | | 1 | | 3 | | | 3 | | | | | | | | | 3 | 3 | |
| Sorcerer | Trainer Illusion Expert | 00 0b812c | | | | 1 | | | | 2 | | 3 | | 3 | | | | | | | 2 | | | 2 | 3 | 1 |
| Sorcerer | Trainer Illusion Master | 00 042dc6 | | | 2 | 2 | | | | | | 3 | | 4 | 1 | | | | | | | | | 2 | 3 | 1 |
| Sorcerer<sup>[HF](Skyrim_Hearthfire.md)</sup> | BYOHHousecarl Hjaalmarch Class | [xx](Skyrim_Form_ID.md) 019636 | | | 2 | 2 | | | | 2 | | 2 | | | 2 | | | | | | | | | 2 | 2 | 2 |
| Spell Vendor | Trainer Alteration Master | 00 0e3a69 | | | | | | | | 4 | | 1 | | 2 | 1 | | | | | | 2 | 2 | | 1 | 1 | 1 |
| Spell Vendor | Trainer Enchanting Expert | 00 0e3a76 | | | | | | | | 3 | | 1 | 4 | 2 | 1 | | | | | | 2 | 2 | | 1 | 1 | 1 |
| Spell Vendor | Vendor Spells | 00 01325a | | | | | | | | 3 | | 1 | | 2 | 1 | | | | | | 2 | 2 | | 1 | 1 | 1 |
| Name | Editor ID | [Form ID](Skyrim_Form_ID.md) | [ARC](Skyrim_Archery.md) | [BLO](Skyrim_Block.md) | [HVA](Skyrim_Heavy_Armor.md) | [1HD](Skyrim_One-handed.md) | [SMI](Skyrim_Smithing.md) | [2HD](Skyrim_Two-handed.md) | | [ALT](Skyrim_Alteration.md) | [CON](Skyrim_Conjuration.md) | [DES](Skyrim_Destruction.md) | [ENC](Skyrim_Enchanting.md) | [ILU](Skyrim_Illusion.md) | [RES](Skyrim_Restoration.md) | | [ALC](Skyrim_Alchemy.md) | [LTA](Skyrim_Light_Armor.md) | [LOC](Skyrim_Lockpicking.md) | [PIC](Skyrim_Pickpocket.md) | [SNK](Skyrim_Sneak.md) | [SPE](Skyrim_Speech.md) | | [Hea](Skyrim_Health.md) | [Mag](Skyrim_Magicka.md) | [Sta](Skyrim_Stamina.md) |
| Spellsword | Combat Spellsword | 00 013177 | | | 3 | 3 | | | | | | 3 | | | 2 | | | | | | | | | 2 | 2 | 2 |
| Spellsword | NPCclass Belrand | 00 10f7f9 | | | | 3 | | | | | | 3 | | | 2 | | | 3 | | | | | | 2 | 2 | 2 |
| Spellsword<sup>[DB](Skyrim_Dragonborn.md)</sup> | DLC2NPCClass Teldryn | [xx](Skyrim_Form_ID.md) 038561 | | | | 3 | | | | | 2 | 3 | | | 1 | | | 3 | | | | | | 2 | 2 | 2 |
| Tailor | Vendor Tailor | 00 013270 | | | | | 2 | | | | | | | | | | | 1 | | 2 | 3 | 3 | | 1 | 1 | 1 |
| Thalmor Archer | Enc Class Thalmor Missile | 00 072891 | 3 | | | 1 | | | | | | | | | 1 | | | 2 | | | 2 | | | 2 | 1 | 2 |
| Thalmor Warrior | Enc Class Thalmor Melee | 00 07289d | | 2 | | 3 | | | | | | | | | 1 | | | 2 | | | 1 | | | 2 | 1 | 2 |
| Thalmor Wizard | Enc Class Thalmor Wizard | 00 072887 | | | | | | | | 1 | 3 | 3 | | | 1 | | | | | | 1 | | | 2 | 3 | |
| Thief | Combat Thief | 00 01317e | 2 | 1 | | 2 | | | | | | | | | | | | 3 | | | 3 | | | 2 | | 4 |
| Thief | Trainer Lockpick Master | 00 0e3a65 | 2 | 1 | | 2 | | | | | | | | | | | | 3 | 4 | | 3 | | | 2 | | 4 |
| Thief | Trainer Marksman Expert | 00 042dc2 | 4 | 1 | | 2 | | | | | | | | | | | | 3 | | | 3 | 2 | | 2 | | 4 |
| Thief | Trainer Marksman Journeyman | 00 10fc39 | 4 | 1 | | 2 | | | | | | | | | | | | 3 | | | 3 | 2 | | 2 | | 4 |
| Thief | Trainer Marksman Master | 00 0e3a66 | 4 | 1 | | 2 | | | | | | | | | | | | 3 | | | 3 | 2 | | 2 | | 4 |
| Thief | Trainer Pickpocket Expert | 00 0c6fb6 | 2 | 1 | | 2 | | | | | | | | | | | | 3 | | 3 | 3 | | | 2 | | 4 |
| Thief | Trainer Pickpocket Master | 00 0e3a62 | 2 | 1 | | 2 | | | | | | | | | | | | 3 | | | 3 | | | 2 | | 4 |
| Thief | Trainer Sneak Master | 00 0e3a63 | 2 | 1 | | 2 | | | | | | | | | | | | 3 | | | 3 | | | 2 | | 4 |
| Thief | Trainer Speechcraft Master | 00 0e3a64 | 2 | 1 | | 2 | | | | | | | | | | | | 3 | | | 3 | 4 | | 2 | | 4 |
| Vampire | Enc Class Vampire | 00 02e00f | | | | 2 | | | | 1 | 2 | 1 | | | | | | 2 | | | 3 | | | 2 | 2 | 1 |
| Vigilant | Vigilant1h Melee Class | 00 10bfef | | 2 | 2 | 2 | | | | 2 | | | | | 2 | | | 2 | | | 1 | | | 3 | 1 | 2 |
| Vigilant | Vigilant2h Melee Class | 00 10bff0 | | 3 | 3 | | | 3 | | 1 | | | | | | | | 2 | | | 1 | | | 3 | 1 | 2 |
| Vyrthur<sup>[DG](Skyrim_Dawnguard.md)</sup> | DLC1CClass Vyrthur | [xx](Skyrim_Form_ID.md) 0126b3 | | | | 1 | | | | | 2 | 3 | | | | | | 2 | | | 3 | | | 3 | 3 | |
| Name | Editor ID | [Form ID](Skyrim_Form_ID.md) | [ARC](Skyrim_Archery.md) | [BLO](Skyrim_Block.md) | [HVA](Skyrim_Heavy_Armor.md) | [1HD](Skyrim_One-handed.md) | [SMI](Skyrim_Smithing.md) | [2HD](Skyrim_Two-handed.md) | | [ALT](Skyrim_Alteration.md) | [CON](Skyrim_Conjuration.md) | [DES](Skyrim_Destruction.md) | [ENC](Skyrim_Enchanting.md) | [ILU](Skyrim_Illusion.md) | [RES](Skyrim_Restoration.md) | | [ALC](Skyrim_Alchemy.md) | [LTA](Skyrim_Light_Armor.md) | [LOC](Skyrim_Lockpicking.md) | [PIC](Skyrim_Pickpocket.md) | [SNK](Skyrim_Sneak.md) | [SPE](Skyrim_Speech.md) | | [Hea](Skyrim_Health.md) | [Mag](Skyrim_Magicka.md) | [Sta](Skyrim_Stamina.md) |
| Warrior | Combat Nightingale | 00 0fb0da | 3 | | | 3 | | | | | | 2 | | | | | | 1 | | | 2 | | | 4 | | 2 |
| Warrior | Combat Warrior1H | 00 013176 | 2 | 2 | 3 | 3 | | 1 | | | | | | | | | | | | | | | | 4 | | 2 |
| Warrior | Combat Warrior2H | 00 01ce15 | 2 | 2 | 3 | 1 | | 3 | | | | | | | | | | | | | | | | 4 | | 2 |
| Warrior | Trainer Block Expert | 00 042dc7 | | 3 | | 3 | 1 | | | | | | | | | | | | | 2 | 1 | 3 | | 2 | 2 | 1 |
| Warrior | Trainer Block Master | 00 0b5fb4 | 1 | 3 | 2 | 3 | | | | | | | | | | | | | | | 2 | | | 4 | 2 | 1 |
| Warrior | Trainer Lockpick Expert | 00 0e3a6b | 2 | 2 | 3 | 3 | | 1 | | | | | | | | | | | 4 | | | | | 4 | | 2 |
| Warrior | Trainer One Handed Expert | 00 042dc3 | 2 | 2 | 3 | 3 | | 1 | | | | | | | | | | | | | | | | 4 | | 2 |
| Warrior | Trainer One Handed Journeyman | 00 0e3a5e | 2 | 2 | 3 | 3 | | 1 | | | | | | | | | | | | | | | | 4 | | 2 |
| Warrior | Trainer One Handed Master | 00 0b5fb5 | | 2 | 3 | 3 | | 1 | | | | | | | | | | | | | 2 | | | 4 | | 2 |
| Warrior | Trainer Sneak Journeyman | 00 0e3a6d | 2 | 2 | 3 | 3 | | 1 | | | | | | | | | | | | | 3 | | | 4 | | 2 |
| Warrior | Trainer Speechcraft Journeyman | 00 0e3a6f | 2 | 2 | 3 | 3 | | 1 | | | | | | | | | | | | | | 3 | | 4 | | 2 |
| Warrior | Trainer Two Handed Expert | 00 042dc5 | 2 | 2 | 3 | 1 | | 3 | | | | | | | | | | | | | | | | 4 | | 2 |
| Warrior | Trainer Two Handed Master | 00 042dc4 | 2 | 2 | 3 | 1 | | 4 | | | | | | | | | | | | | | | | 4 | | 2 |
| Warrior<sup>[DB](Skyrim_Dragonborn.md)</sup> | dlc2DBAncient Dragonborn Class | [xx](Skyrim_Form_ID.md) 0265af | | 2 | 3 | 3 | | 3 | | | 9 | | | | | | | | | | 1 | | | 4 | 2 | 3 |
| Warrior<sup>[CC](Skyrim_Ghosts_of_the_Tribunal.md)</sup> | cc ASVSSE001_Blade Binder | [xx](Skyrim_Form_ID.md) 052276 | | | | 3 | | | | | 3 | 2 | | | | | | 1 | | | 2 | | | 2 | 2 | 2 |
| Werewolf | Enc Class Werewolf | 00 0a1993 | 2 | 2 | | 3 | | | | | | | | | | | | 1 | | | 3 | | | 3 | | 3 |
| Werewolf | Enc Class Werewolf Boss | 00 0a1995 | 1 | 2 | 2 | 3 | | | | | | | | | | | | | | | 3 | | | 3 | | 3 |
| Werewolf | Enc Class Werewolf Mage | 00 0a1994 | | 2 | | 3 | | | | | | 2 | | | | | | | | | 3 | | | 3 | 3 | |
| Witchblade | Combat Witchblade | 00 013178 | | 2 | | 3 | | | | | | 3 | | 2 | 1 | | | | | | | | | 3 | 3 | |
| Name | Editor ID | [Form ID](Skyrim_Form_ID.md) | [ARC](Skyrim_Archery.md) | [BLO](Skyrim_Block.md) | [HVA](Skyrim_Heavy_Armor.md) | [1HD](Skyrim_One-handed.md) | [SMI](Skyrim_Smithing.md) | [2HD](Skyrim_Two-handed.md) | | [ALT](Skyrim_Alteration.md) | [CON](Skyrim_Conjuration.md) | [DES](Skyrim_Destruction.md) | [ENC](Skyrim_Enchanting.md) | [ILU](Skyrim_Illusion.md) | [RES](Skyrim_Restoration.md) | | [ALC](Skyrim_Alchemy.md) | [LTA](Skyrim_Light_Armor.md) | [LOC](Skyrim_Lockpicking.md) | [PIC](Skyrim_Pickpocket.md) | [SNK](Skyrim_Sneak.md) | [SPE](Skyrim_Speech.md) | | [Hea](Skyrim_Health.md) | [Mag](Skyrim_Magicka.md) | [Sta](Skyrim_Stamina.md) |