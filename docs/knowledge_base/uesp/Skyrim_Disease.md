# Disease

Contracting a **disease** weakens specific [skills](Skyrim_Skills.md) or [attributes](Skyrim_Attributes.md) of your character. Disease effects remain active until [cured](Skyrim_Cure_Disease.md) with a [potion](Skyrim_Potions.md#Cure_Disease), [garlic bread](Skyrim_Garlic_Bread.md)<sup>[HF](Skyrim_Hearthfire.md)</sup>, or at a [shrine](Skyrim_Shrines.md), which can be found in most hold capitals. Unlike in *[Oblivion](https://en.uesp.net/wiki/Oblivion:Oblivion)*, there is no Cure Disease spell, and it is not possible to contract diseases from [beggars](https://en.uesp.net/wiki/Category:Skyrim-Beggar). One particularly notable and somewhat unique disease is *Sanguinare Vampiris*, which transforms your character into a [vampire](Skyrim_Vampirism.md) three days after contracting it if left untreated. Multiple disease effects stack together. Carrying a disease may cause NPCs to say that you look sickly or should go to bed, although [Arcadia](Skyrim_Arcadia.md) in [Whiterun](Skyrim_Whiterun.md) will say things like this even if you are healthy.

There are a number of ways to contract diseases in *Skyrim*. Most diseases can be contracted through contact with creatures, animals, or even some NPCs. Many diseases can also be contracted through traps found outside or in dungeons. For those diseases, the first ID in the following table is for the disease when caught from a creature, and the second ID is the trap-specific version. Although the physical effects of the two versions of the disease are the same, the descriptions are often slightly different.

## Diseases
| Disease | [ID](Skyrim_Form_ID.md) | Description | Source |
| --- | --- | --- | --- |
| Ataxia | 00 0b877c | Picking locks and picking pockets is 25% harder. | [Skeevers](Skyrim_Skeever.md) |
| 00 10a24a | Picking locks and picking pockets is 25% harder. | [Traps](Skyrim_Traps.md) | |
| Black Heart Blight<sup>[DB](Skyrim_Dragonborn.md)</sup> | [xx](Skyrim_Form_ID.md) 01ff2e | Drains 10 points from Carry Weight. | None<sup>[†](#intnote_BHblight)</sup> |
| Bone Break Fever | 00 0b877e | Drains 25 points from Stamina. | [Bears](Skyrim_Bear.md) |
| 00 10a24c | Drains 25 points of Stamina. | [Traps](Skyrim_Traps.md) | |
| Brain Rot | 00 0b877f | Drains 25 points from Magicka. | [Hagravens](Skyrim_Hagraven.md) |
| 00 10a24d | Drains 25 points of Magicka. | [Traps](Skyrim_Traps.md) | |
| fe [xxx](Skyrim_Form_ID.md#Creation_Club) 872 | Drains 25 points of Magicka. | [Zombies](Skyrim_Zombie.md)<sup>[CC](Skyrim_Plague_of_the_Dead.md)</sup> | |
| Droops<sup>[DB](Skyrim_Dragonborn.md)</sup> | [xx](Skyrim_Form_ID.md) 0285c1 | One-handed and two-handed weapon damage is 15% lower. | [Ash Hoppers](Skyrim_Ash_Hopper.md) |
| Rattles | 00 0b8781 | Stamina regenerates 50% more slowly. | [Chaurus](Skyrim_Chaurus.md) |
| 00 10a24e | Stamina regenerates 50% more slowly. | [Traps](Skyrim_Traps.md) | |
| Rockjoint | 00 0b8782 | You are 25% less effective with melee weapons. | [Fox](Skyrim_Fox.md), [Wolves](Skyrim_Wolf.md)<sup>[‡](#intnote_RJFamiliar)</sup> |
| 00 10a24f | You are 25% less effective with melee weapons. | [Traps](Skyrim_Traps.md) | |
| Sanguinare Vampiris | 00 0b8780/[xx](Skyrim_Form_ID.md) 0037e9<sup>[DG](Skyrim_Dawnguard.md)</sup> | Reduces Health by 25. Progresses to [Vampirism](Skyrim_Vampirism.md). | [Vampires](Skyrim_Vampire.md) |
| Witbane | 00 0b8783 | Magicka regenerates 50% more slowly. | [Sabre Cats](Skyrim_Sabre_Cat.md) |
| 00 10a250 | Magicka regenerates 50% more slowly. | [Traps](Skyrim_Traps.md) | |

[†](#note_BHblight) Black Heart Blight is not possible to contract in the game. [‡](#note_RJFamiliar) The [conjured Familiar](Skyrim_Conjure_Familiar.md) inherits some of the properties of wolves, including the ability to transmit Rockjoint.
## Survival Mode<sup>[CC](Skyrim_Survival_Mode.md)</sup>
The [Survival Mode](Skyrim_Survival_Mode.md) [Creation](Skyrim_Creation_Club.md) adds new and modifies existing diseases. They can be contracted through contact with creatures, animals, and NPCs. Left untreated, most diseases will progress from their base form to a Severe or Crippling form after 24 hours. Each form is associated with more severe symptoms.

### Advanced Diseases
| Disease | [ID](Skyrim_Form_ID.md) <br> (Normal, Severe, Crippling) | Description | Severe Description | Crippling Description | Source |
| --- | --- | --- | --- | --- | --- |
| Ataxia | 00 0b877c, <br> fe [xxx](Skyrim_Form_ID.md#Creation_Club) 992, <br> fe [xxx](Skyrim_Form_ID.md#Creation_Club) 993 | Picking locks and picking pockets is 25% harder. Progresses to Severe Ataxia. | Picking locks and picking pockets is 50% harder. Progresses to Crippling Ataxia. | Picking locks and picking pockets is 75% harder. | [Skeevers](Skyrim_Skeever.md) |
| Bone Break Fever | fe [xxx](Skyrim_Form_ID.md#Creation_Club) 830, <br> fe [xxx](Skyrim_Form_ID.md#Creation_Club) 984, <br> fe [xxx](Skyrim_Form_ID.md#Creation_Club) 985 | Stamina is drained 25 points. Progresses to Severe Bone Break Fever. | Stamina is drained 50 points. Progresses to Crippling Bone Break Fever. | Stamina is drained 75 points. | [Black, Brown, and Snow Bears](Skyrim_Bear.md) |
| Brain Rot | fe [xxx](Skyrim_Form_ID.md#Creation_Club) 82e, <br> fe [xxx](Skyrim_Form_ID.md#Creation_Club) 990, <br> fe [xxx](Skyrim_Form_ID.md#Creation_Club) 991 | Magicka is drained 25 points. Progresses to Severe Brain Rot. | Magicka is drained 50 points. Progresses to Crippling Brain Rot. | Magicka is drained 75 points. | [Hagravens](Skyrim_Hagraven.md) |
| Brown Rot | fe [xxx](Skyrim_Form_ID.md#Creation_Club) 914, <br> fe [xxx](Skyrim_Form_ID.md#Creation_Club) 98b, <br> fe [xxx](Skyrim_Form_ID.md#Creation_Club) 986 | Light and Heavy Armor prevents 25% less damage. Sleeping is 25% less restful. Progresses to Severe Brown Rot. | Light and Heavy Armor prevents 50% less damage. Sleeping is 50% less restful. Progresses to Crippling Brown Rot. | Light and Heavy Armor prevents 75% less damage. Sleeping is 75% less restful. | [Draugr](Skyrim_Draugr.md) of all varieties. |
| Droops | [xx](Skyrim_Form_ID.md) 0285c1,<sup>[DB](Skyrim_Dragonborn.md)</sup> <br> fe [xxx](Skyrim_Form_ID.md#Creation_Club) 996, <br> fe [xxx](Skyrim_Form_ID.md#Creation_Club) 997 | One-handed and two-handed weapon damage is 15% lower. | One-handed and two-handed weapon damage is 30% lower. | One-handed and two-handed weapon damage is 45% lower. | [Ash Hoppers](Skyrim_Ash_Hopper.md)<sup>[DB](Skyrim_Dragonborn.md)</sup> |
| Food Poisoning | fe [xxx](Skyrim_Form_ID.md#Creation_Club) 918 | Magicka and Stamina recover 50% slower, and food no longer restores Health for 3 days. <br> [Argonians](Skyrim_Argonian.md) and [Khajiit](Skyrim_Khajiit.md) are immune to this disease. | [Raw Meat](Skyrim_Food.md#Raw_Meat) | | |
| Greenspore | fe [xxx](Skyrim_Form_ID.md#Creation_Club) 912, <br> fe [xxx](Skyrim_Form_ID.md#Creation_Club) 987, <br> fe [xxx](Skyrim_Form_ID.md#Creation_Club) 988 | Prices are 25% worse. Persuasion and intimidation is 25% harder. Progresses to Severe Greenspore. | Prices are 50% worse. Persuasion and intimidation is 50% harder. Progresses to Crippling Greenspore. | Prices are 75% worse. Persuasion and intimidation is 75% harder. | [Slaughterfish](Skyrim_Slaughterfish.md) |
| Gutworm | fe [xxx](Skyrim_Form_ID.md#Creation_Club) 915, <br> fe [xxx](Skyrim_Form_ID.md#Creation_Club) 989, <br> fe [xxx](Skyrim_Form_ID.md#Creation_Club) 98a | Stamina regeneration is decreased by 25%. Food restores 25% less hunger. | Stamina regeneration is decreased by 50%. Food restores 50% less hunger. | Stamina regeneration is decreased by 75%. Food restores 75% less hunger. | [Standard and Frost Trolls](Skyrim_Troll.md) |
| Rattles | 00 0b8781, <br> fe [xxx](Skyrim_Form_ID.md#Creation_Club) 98c, <br> fe [xxx](Skyrim_Form_ID.md#Creation_Club) 98d | Stamina recovers half as fast. Progresses to Severe Rattles. | Stamina recovers 75% slower. Progresses to Crippling Rattles. | Stamina no longer recovers. | [Chaurus, Chaurus Hunters, and Chaurus Reapers](Skyrim_Chaurus.md) |
| Rockjoint | 00 0b8782, <br> fe [xxx](Skyrim_Form_ID.md#Creation_Club) 98e, <br> fe [xxx](Skyrim_Form_ID.md#Creation_Club) 98f | One-handed and two-handed weapon damage is 25% less effective. Progresses to Severe Rockjoint. | One-handed and two-handed weapon damage is 50% less effective. Progresses to Crippling Rockjoint. | One-handed and two-handed weapon damage is 75% less effective. | [Foxes](Skyrim_Fox.md) and [Wolves](Skyrim_Wolf.md) |
| Sanguinare Vampiris | 00 0b8780/[xx](Skyrim_Form_ID.md) 0037e9<sup>[DG](Skyrim_Dawnguard.md)</sup> | Health is reduced by 25. Progresses to [Vampirism](Skyrim_Vampirism.md). | [Vampires](Skyrim_Vampire.md) | | |
| Witbane | 00 0b8783, <br> fe [xxx](Skyrim_Form_ID.md#Creation_Club) 994, <br> fe [xxx](Skyrim_Form_ID.md#Creation_Club) 995 | Magicka recovers half as fast. Progresses to Severe Witbane. | Magicka recovers 25% as fast. | Magicka no longer recovers. | [Standard, Snowy, and Vale Sabre Cats](Skyrim_Sabre_Cat.md) |

### Afflictions
| Affliction | [ID](Skyrim_Form_ID.md) | Description | Source |
| --- | --- | --- | --- |
| Addled | fe [xxx](Skyrim_Form_ID.md#Creation_Club) 911 | Magicka and stamina regenerate 30% slower for 24 hours. | Can be caused by [lack of sleep](Skyrim_Fatigue.md). |
| Frostbitten | fe [xxx](Skyrim_Form_ID.md#Creation_Club) 913 | Lockpicking and pickpocketing is 30% harder, and bows do 30% less damage for 24 hours. | Can be caused by excessive [cold](Skyrim_Cold.md). |
| Weakened | fe [xxx](Skyrim_Form_ID.md#Creation_Club) 910 | You are 30% less effective with melee weapons and blocking damage with your shield for 24 hours. | Can be caused by [hunger](Skyrim_Hunger.md). |

## Notes
- The [Necklace of Disease Immunity](Skyrim_Necklace_of_Disease_Immunity.md), [Necklace of Disease Resistance](Skyrim_Necklace_of_Disease_Resistance.md), and the [dragon priest mask](Skyrim_Dragon_Priest_Mask.md) [Hevnoraak](Skyrim_Hevnoraak_(item).md) all provide a constant [Resist Disease](Skyrim_Resist_Disease.md) ability.
- [Argonians](Skyrim_Argonian.md) and [Bosmer](Skyrim_Wood_Elf.md) both have a constant Resist Disease 50% ability.
- Becoming a [werewolf](Skyrim_Lycanthropy.md) or a [vampire](Skyrim_Vampirism.md) gives you a constant Resist Disease 100% ability. Thus, a werewolf can never become a vampire and vice versa. However, in Survival mode, werewolves are not immune to diseases, except *Sanguinare Vampiris* and vice versa (see [bugs](#Bugs)).
- [Spell Absorption](Skyrim_Spell_Absorption.md) provides protection against disease.
- [Shrines](Skyrim_Shrines.md) will cure diseases and confer a specific blessing.
- Eating a single [Hawk Feather](Skyrim_Hawk_Feathers.md) has the same effect as drinking a Cure Disease potion since the 1st effect is Cure Disease. These are lighter and cheaper than potions.
- [Vigilants of Stendarr](Skyrim_Vigil_of_Stendarr.md#Vigilant_of_Stendarr) will cure diseases if asked to do so.
- If [Survival Mode](Skyrim_Survival_Mode.md) is active, higher [Fatigue](Skyrim_Fatigue.md) levels will reduce resistance to diseases.
- In real life, Ataxia affects victims' muscle coordination, balance, and visual focus. The in-game effect of Ataxia affects lockpicking and pickpocketing, which is consistent with its real-life effect.

## Bugs
- Resist Disease 100% does not prevent diseases from traps due to scripting oversights. - The [Unofficial Skyrim Special Edition Patch](https://en.uesp.net/wiki/Skyrim_Mod:Unofficial_Skyrim_Special_Edition_Patch), version 4.2.5, fixes this bug.
- Rarely, Bone Break Fever drains 0 points from stamina instead of 25 points.
- Witbane acquired from traps isn't set to the correct magnitude to cut magicka regeneration speed in half. - ![PC Only](https://images.uesp.net/d/d7/Computer.svg)
The [Unofficial Skyrim Patch](https://en.uesp.net/wiki/Skyrim_Mod:Unofficial_Skyrim_Patch), version 1.3.2, fixes this bug.
- In Survival Mode, werewolves and vampires are still immune from becoming each other, but are not immune to the new diseases added by the CC. - The [Unofficial Skyrim Special Edition Patch](https://en.uesp.net/wiki/Skyrim_Mod:Unofficial_Skyrim_Special_Edition_Patch), version 4.2.7, fixes this bug.
- In Survival mode, Spell Absorption has a chance of curing a disease when it progresses to a more severe form. - The [Unofficial Skyrim Special Edition Patch](https://en.uesp.net/wiki/Skyrim_Mod:Unofficial_Skyrim_Special_Edition_Patch), version 4.2.7, fixes this bug.
- In Survival Mode, when a disease proceeds to the next stage it can be absorbed, but the effects of the disease may still be present even though it isn't shown in the Active Effects menu. - A possible fix is to contract the disease again and let it proceed to the next stage and only then use a potion or shrine to cure it and its effects.<sup>[*verification needed*]</sup>