# Slow Time

| --- | --- | --- | --- | --- |
| *Shout at time, and command it to obey, as the world around you stands still.* | | | | |
| Thu'um | \| T3D <br> **Tiid** <br> *Time* \| KLO <br> **Klo** <br> *Sand* \| UL <br> **Ul** <br> *Eternity* \| <br> \| --- \| --- \| --- \| | T3D <br> **Tiid** <br> *Time* | KLO <br> **Klo** <br> *Sand* | UL <br> **Ul** <br> *Eternity* |
| T3D <br> **Tiid** <br> *Time* | KLO <br> **Klo** <br> *Sand* | UL <br> **Ul** <br> *Eternity* | | |
| [ID](Skyrim_Form_ID.md) | \| 00 048aca \| 00 048acb \| 00 048acc \| <br> \| --- \| --- \| --- \| | 00 048aca | 00 048acb | 00 048acc |
| 00 048aca | 00 048acb | 00 048acc | | |
| Effects | Recharge | Spell ID | | |
| Tiid | Slows time to 30% of normal speed for 8 seconds. | 30 | 00 048ad0 | |
| Tiid Klo | Slows time to 20% of normal speed for 12 seconds. | 45 | 00 048ad1 | |
| Tiid Klo Ul | Slows time to 10% of normal speed for 16 seconds. | 60 | 00 048ad2 | |
| Locations | | | | |
| - [Hag's End](Skyrim_Hag%27s_End.md) <br> - [Korvanjund](Skyrim_Korvanjund.md) (quest locked) <br> - [Labyrinthian](Skyrim_Labyrinthian.md) (quest locked) | | | | |

**Slow Time** is a [shout](Skyrim_Shout.md) that slows down time. You are also affected, but not to the same extent. While slow time is active, all creatures and NPCs move much more slowly. This allows you to hit or move faster than normal as you are only slowed down to 70% of normal speed, regardless of how many words are used. A skilled or lucky player can catch incoming arrows while under the effects of Slow Time.

## Related Quests
- **[The Jagged Crown (Imperial)](Skyrim_The_Jagged_Crown_(Imperial).md)**: Find the [Jagged Crown](Skyrim_Jagged_Crown.md) for the [Imperials](Skyrim_Imperial_Legion.md).
- **[The Jagged Crown (Stormcloaks)](Skyrim_The_Jagged_Crown_(Stormcloaks).md)**: Find this [crown](Skyrim_Jagged_Crown.md) for Ulfric Stormcloak.
- **[The Staff of Magnus](Skyrim_The_Staff_of_Magnus.md)**: Retrieve the [Staff of Magnus](Skyrim_Staff_of_Magnus.md).

## Word Wall Translations
| Thu'um | [Word Wall](Skyrim_Word_Wall.md) | Translation |
| --- | --- | --- |
| Transliteration | | |
| **Tiid** | VEGUNTHAR W4L1N QETHSEGOL <br> BORM4IL V4RUKT HUNGUNTHAR <br> T3D N1K KRI1N SE <br> JUNNESEJER KRON3D SE DUNKREATH | Vegunthar raised (this) stone <br> (in his) father's memory, Hungunthar <br> Time -Eater, slayer of <br> (the) Kings of the East, conqueror of Dunkreath. |
| VEGUNTHAR Wah Laa N QETHSEGOL <br> BORMah IL Vah RUKT HUNGUNTHAR <br> Tii D Naa K KRIaa N SE <br> JUNNESEJER KRONii D SE DUNKREATH | | |
| **Klo** | HET M4 S4ROT <br> KON4RIK 1BAN <br> K3N SE KLO SE ALIKR <br> PR1N NU DENEK K2Z1L | Here fell mighty <br> Warlord Aaban <br> Child of (the) sand s of Alik'r; <br> rest now in (the) soil (of) Skyrim. |
| HET Mah Sah ROT <br> KONah RIK aa BAN <br> Kii N SE KLO SE ALIKR <br> PRaa N NU DENEK Kei Zaa L | | |
| **Ul** | QETHSEGOL V4RUKIV <br> KENDOV SE VED RONAX WEN <br> SIL NU YOR3K PIND1R SE SOVNGARDE <br> P4 UL | (This) stone commemorates <br> (the) warriors of the black regiment whose <br> souls now march in the plains of Sovngarde <br> for all eternity. |
| QETHSEGOL Vah RUKIV <br> KENDOV SE VED RONAX WEN <br> SIL NU YORii K PINDaa R SE SOVNGARDE <br> Pah UL | | |

## Notes
- You cannot zoom in while aiming with a bow with the *[Eagle Eye](Skyrim_Eagle_Eye.md)* perk while under the effects of the Slow Time shout.
- The effects of this shout are governed by the [Alteration](Skyrim_Alteration.md) skill and can be extended with the *[Stability](https://en.uesp.net/wiki/Skyrim:Stability)* perk and the *[Fortify Alteration](https://en.uesp.net/wiki/Skyrim:Fortify_Alteration)* alchemy effect.
- This effect extends the duration of potions on the player. This can be useful for [Enchanting](Skyrim_Enchanting.md) or [Smithing](Skyrim_Smithing.md), allowing more items to be crafted before a potion's duration expires.

## Bugs
- After getting the first word of the Slow Time shout from elsewhere, the word wall at Hag's End or Korvanjund may not work properly. The wall's sound effects can be heard but no word is learned when the wall is approached. - [![On PC](https://images.uesp.net/d/d7/Computer.svg)](https://www.wikipedia.org/wiki/PC_game) PC players can learn the missing second word using the following console command: `player.teachword 48ACB` (or `48ACC` for the third word). If you are on Arngeir's miscellaneous quest to "[Find the Word of Power](Skyrim_The_Words_of_Power.md) in Hag's End", you can then use the console command `setstage Freeform High Hrothgar A 20` to mark that as finished. The word wall will remain bugged, though, and continues to play the sound effects. Actually, you may learn the third word, and the quest appear to end normally, but the third word is not visible until you learn the second word.
- [![On PC](https://images.uesp.net/d/d7/Computer.svg)](https://www.wikipedia.org/wiki/PC_game) Using the console to set the global variable `WWSlow Time` to a different value (depending on which word is to be learned) may also work. See [this talk page topic](https://en.uesp.net/wiki/Skyrim:talk_Slow_Time#Second_word_wall_teaching_third_word) for details.
- At times, the Slow Time shout may last much longer than usual.
- When the above-mentioned effect happens, the shout also seems to be more potent than otherwise.
- Even with [Patch 1.9](Skyrim_Patch.md), the effects of this shout may still behave irregularly. - The [Official Skyrim Special Edition Patch](Skyrim_Special_Edition_Patch.md), version 1.3, fixes this bug.