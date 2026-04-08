# Merchants


The amount listed under "Gold" is the base amount of gold that the merchant has available to purchase items from the player. Merchants will generally have 3-40 gold more than listed, because their personal pocket change is added to the merchant-specific gold. Gold is reset each time the merchant's inventory is reset or every 48 hours. Merchant gold can be increased in several ways:

- The [Master Trader](Skyrim_Master_Trader.md) perk increases nearly all merchants' gold by 1000. The merchants who have more gold are all identified in the notes of the following tables.
- The [Investor](Skyrim_Investor.md) perk allows you to invest 500 gold in certain merchants, after which that merchant will permanently have 500 more gold available. Some merchants are bugged -- they have the dialogue allowing you to pay them 500 gold, but doing so does not result in any permanent change in the merchant's available gold. These merchants are *not* checked in the "Invest" column in the following tables, but instead the bug is noted on the individual merchant page. Investing in a merchant improves that merchant's disposition towards you, which can count towards becoming a Thane in the relevant Hold, if you are on the appropriate quest to help members of that Hold.

Likewise, you can improve prices in several ways as well:

- Each rank of the [Haggling](https://en.uesp.net/wiki/Skyrim:Haggling) perk improves prices by 5%, beginning at 10%.
- The [Allure](Skyrim_Allure.md) perk improves prices by 10% with merchants of the opposite gender.
- The [Lover's Insight](https://en.uesp.net/wiki/Skyrim:Lover%27s_Insight)<sup>[DB](Skyrim_Dragonborn.md)</sup> bonus from [Black Book: The Winds of Change](Skyrim_Black_Book__The_Winds_of_Change_(quest).md)<sup>[DB](Skyrim_Dragonborn.md)</sup> gives 10% better prices from people of the opposite sex.
- [Fortify Barter](Skyrim_Fortify_Barter.md) potions and enchantments improve prices by the specified amount, and potions for the specified amount of time.
- The [Blessings](Skyrim_Blessings.md) of Zenithar and Mephala<sup>[DB](Skyrim_Dragonborn.md)</sup> improve prices by 10% for 8 hours.
- The Blessing of Vivec<sup>[CC](Skyrim_Creation_Club.md)</sup> improves prices by 5% for 8 hours.
- Leveling up your [Speech](Skyrim_Speech.md) skill slowly makes prices better.

The pricing formula is determined by several factors, including these:

The Base Price Factor is calculated by your Speech skill level; each skill rank reduces the price factor by .013 by default, and skill levels over 100 have no effect:

```
price factor = f Barter Max - (f Barter Max - f Barter Min) * min(skill,100)/100
price factor = 3.3 - 1.3*min(skill,100)/100
price factor = 3.3 - .013*min(skill,100)

```
- f Barter Max default is 3.3, f Barter Min default is 2.0 (defines a base vendor-selling-range of 200% to 330% of an item's base value, and a vendor-buying-range of 30% to 50%).
- the function min(x,y) return the smallest of two or more arguments (here, [skill-level] or [100]).

The modified Price Factor depends on perks and Fortify Barter bonus:

```
sell price modifier = Haggling S * Allure S * (1 + Fortify Barter from potion) * (1 + the sum of Fortify Barter from equipment + Fortify Barter from Blessing of Zenithar)
buy price modifier = Haggling B * Allure B * (1 - Fortify Barter from potion) * (1 - the sum of Fortify Barter from equipment - Fortify Barter from Blessing of Zenithar)

```
The final price combines the two Price Factors and rounds to the nearest whole number:

```
sell price = round(value of item * sell price modifier / base price factor)
buy price = round(value of item * buy price modifier * base price factor)

```
- Haggling S = 1.10 at Rank 1, 1.15 at Rank 2, 1.20 at Rank 3, 1.25 at Rank 4, 1.30 at Rank 5. Allure S = 1.10

- Haggling B = 0.91 at Rank 1, 0.87 at Rank 2, 0.83 at Rank 3, 0.80 at Rank 4, 0.77 at Rank 5. Allure B = 0.91

Buying multipliers are the reciprocal of the respective selling multiplier, but rounded to two decimal places (a percentile). Do not use unrounded (untruncated) values, as it will yield incorrect results. (For example, at rank 2, Haggling B is 0.87. 1/1.15 is actually slightly less than 0.87, so using the full (untruncated) value may get you a lower-than-actual buying multiplier.)

- At 0 skill and no perks, the final price factor is 3.3 for buying and 0.303 for selling.
- At 15 skill and no perks, the final price factor is 3.10 for buying and 0.322 for selling.
- At 100 skill and no perks, the final price factor is 2 for buying and 0.5 for selling.
- At 100 skill and all haggling perks, the final price factor is 1.54 for buying and 0.65 for selling.
- At 100 skill and all perks, including Allure, the final price factor is 1.4014 for buying and 0.715 for selling.
- Trade price cap: (max sell price = value * 1.00), (min buy price = value * 1.05). - Skill levels over 100 have no effect.

The merchandise column provides information on what type of merchandise each merchant will buy and sell. In those cases where merchants are not in a typical category, full details are provided on the specific item types they will buy and sell. However, for most merchants, one of the following categories is provided:

| Merchant Type | Buys and Sells | Notes |
| --- | --- | --- |
| Apothecaries | [Alchemy](Skyrim_Alchemy.md) -related merchandise: [Animal Parts](https://en.uesp.net/wiki/Skyrim:Animal_Parts), [Food](Skyrim_Food.md), [Ingredients](Skyrim_Ingredients.md), [Poisons](Skyrim_Poisons.md), [Potions](Skyrim_Potions.md), [Raw Food](https://en.uesp.net/wiki/Skyrim:Raw_Food), [Recipes](Skyrim_Recipes.md) | |
| [Blacksmiths](Skyrim_Blacksmith.md) | [Animal Hides](https://en.uesp.net/wiki/Skyrim:Animal_Hides), [Armor](Skyrim_Armor.md), [Arrows](Skyrim_Ammunition.md), [Ore](https://en.uesp.net/wiki/Skyrim:Ore)/[Ingots](https://en.uesp.net/wiki/Skyrim:Ingots), [Tools](https://en.uesp.net/wiki/Skyrim:Tools), [Weapons](Skyrim_Weapons.md) | |
| [Fences](Skyrim_Fence_(merchant).md) | Any items | These are only available to people who have joined the [Thieves Guild](Skyrim_Thieves_Guild_(faction).md). Each Fence has a particular [quest](Skyrim_Thieves_Guild_(faction).md#Fences) that must be completed to make them available. Fences originally only have 1000 merchant gold, but that can be increased to 1500, 2250, 3000, and then ultimately 4000 gold by [upgrading the guild](Skyrim_Thieves_Guild_(faction).md#Upgrading_the_Thieves_Guild). They are the only merchants who will purchase stolen goods, unless the [Fence](Skyrim_Fence_(perk).md) perk is unlocked. *Note:* Fences cannot be invested in, but are affected by the Master Trader perk |
| General Goods | Will buy any items and sell a variety of items, usually of lower value than more specific merchant types. | |
| [Hunters](Skyrim_Hunter.md) | [Food](Skyrim_Food.md), [Ingredients](Skyrim_Ingredients.md) | |
| Innkeepers | [Food](Skyrim_Food.md), [Raw Food](https://en.uesp.net/wiki/Skyrim:Raw_Food) | Innkeepers can never be invested in. |
| Jewelers | [Gems](Skyrim_Gems.md); [Jewelry](Skyrim_Jewelry.md); [Ore](https://en.uesp.net/wiki/Skyrim:Ore)/[Ingots](https://en.uesp.net/wiki/Skyrim:Ingots); [Tools](https://en.uesp.net/wiki/Skyrim:Tools) | Jewelers can never be invested in, and the Master Trader perk does not affect their gold amount. |
| Spell vendors | They will both buy and sell [magic](Skyrim_Magic.md) -related merchandise, including [spell tomes](Skyrim_Spell_Tomes.md), [soul gems](Skyrim_Soul_Gems.md), enchanted [clothing](Skyrim_Clothing.md), and the like. Additionally, they will buy [jewelry](Skyrim_Jewelry.md), regular clothing (but not armor), [books](Skyrim_Books.md), [scrolls](Skyrim_Scrolls.md), [staves](Skyrim_Staves.md), and [Daedric artifacts](Skyrim_Artifacts.md). | |

If the [Merchant perk](Skyrim_Merchant_(perk).md) is unlocked, all merchants will purchase all types of items. The perk also makes some additional items available for purchase. All vendors will sell you items from their personal inventory, possibly including food, lockpicks, and gems. They will also sell you any bugged items that are in their merchant chests. Most notably, apothecary merchants will sell a dozen ingredients that normally they are unable to sell.

Note that outside of [Hunters](Skyrim_Hunter.md), [Peddlers](Skyrim_Peddler.md), and [Skooma Dealers](Skyrim_Skooma_Dealer_(NPC).md), merchants rely on [merchant chests](https://en.uesp.net/wiki/Skyrim:Merchant_Chest) for their merchandise, and the *chest* contains whatever [Leveled_Lists](https://en.uesp.net/wiki/Skyrim:Leveled_Lists) it was assigned; this is the primary reason [Investor](Skyrim_Investor.md) and [Master Trader](Skyrim_Master_Trader.md) only sometimes work, because both rely on the relevant chest containing Perk-based gold. Hence, while the merchant types listed here can be generally relied upon to determine what a merchant will buy from you, they should be regarded as guidelines, not rules, for what the merchant will sell you - for example, this is why the [Skyforge](Skyrim_Skyforge.md) chest contains unique items for sale no other merchant sells, even though it is listed as a "Blacksmith" below.

Whenever two merchants are listed together in the following tables, it means that the two merchants share the same [merchant chest](https://en.uesp.net/wiki/Skyrim:Merchant_Chest). Therefore, the merchants will always provide the exact same list of items, and share the same merchant gold. If one of the people is listed in parentheses, that person only takes over the store if the first person dies. Investing in a store with two merchants, or with successive merchants, will increase the available amount of gold for all merchants, but may only improve the disposition of one (this is particularly noticeable at Radiant Raiment with the Altmer sisters Endarie and Taarie.)

Most merchants are open from around 8am to 8pm, but some are open all day. For instance, most blacksmiths are only open during the day, whereas innkeepers are always open.

You can also ask four [children](Skyrim_Child.md) what they have for sale. None of them can be invested in, though, and Babette is the only one whose shop benefits from the Master Trader perk.

A merchant's inventory will be determined by an item generator; such that each separate save or character created from that save will yield completely different results every time. If you have the [Special Edition](Skyrim_Special_Edition.md), quicksaving before entering a shop will do the same.

If you are [married](Skyrim_Marriage.md) then your spouse will open a store, whose merchant chest is located inside the home where your spouse lives. If your spouse is on the list below, then they will continue to sell the same type of items. Otherwise, your spouse will become a general goods trader.

## [Eastmarch](Skyrim_Eastmarch.md)

### [Windhelm](Skyrim_Windhelm.md)
| Merchant Name | Store Name | Merchandise | Gold | [Invest](Skyrim_Investor.md) | [Master](Skyrim_Master_Trader.md) |
| --- | --- | --- | --- | --- | --- |
| [Ambarys Rendar](https://en.uesp.net/wiki/Skyrim:Ambarys_Rendar) | [New Gnisis Cornerclub](https://en.uesp.net/wiki/Skyrim:New_Gnisis_Cornerclub) | Innkeeper | **100** | No <br> ![☒](https://images.uesp.net/7/7d/Red_Cross.svg) | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) |
| [Aval Atheron](https://en.uesp.net/wiki/Skyrim:Aval_Atheron) | Marketplace Stall | General | **750** | No <br> ![☒](https://images.uesp.net/7/7d/Red_Cross.svg) | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) |
| [Elda Early-Dawn](Skyrim_Elda_Early-Dawn.md) ([Nils](https://en.uesp.net/wiki/Skyrim:Nils)) | [Candlehearth Hall](Skyrim_Candlehearth_Hall.md) | Innkeeper | **100** | No <br> ![☒](https://images.uesp.net/7/7d/Red_Cross.svg) | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) |
| [Hillevi Cruel-Sea](https://en.uesp.net/wiki/Skyrim:Hillevi_Cruel-Sea) | Marketplace Stall | Innkeeper | **50** | No <br> ![☒](https://images.uesp.net/7/7d/Red_Cross.svg) | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) |
| [Niranye](https://en.uesp.net/wiki/Skyrim:Niranye) | [Niranye's House](https://en.uesp.net/wiki/Skyrim:Niranye%27s_House) | Fence | **1000** - **4000** | No <br> ![☒](https://images.uesp.net/7/7d/Red_Cross.svg) | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) |
| Marketplace Stall | General | **750** | | | |
| [Nurelion](https://en.uesp.net/wiki/Skyrim:Nurelion) ([Quintus Navale](Skyrim_Quintus_Navale.md)) | [The White Phial](Skyrim_The_White_Phial_(place).md) | Apothecary | **500** | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) |
| [Oengul War-Anvil](Skyrim_Oengul_War-Anvil.md) ([Hermir Strong-Heart](https://en.uesp.net/wiki/Skyrim:Hermir_Strong-Heart)) | [Blacksmith Quarters](https://en.uesp.net/wiki/Skyrim:Blacksmith_Quarters) | Blacksmith | **1000** | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) |
| [Revyn Sadri](Skyrim_Revyn_Sadri.md) | [Sadri's Used Wares](https://en.uesp.net/wiki/Skyrim:Sadri%27s_Used_Wares) | General | **750** | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) |
| [Sofie](https://en.uesp.net/wiki/Skyrim:Sofie)<sup>[HF](Skyrim_Hearthfire.md)</sup> | Windhelm Gate | Flowers (also sells [flower baskets](https://en.uesp.net/wiki/Skyrim:Flower_Basket)) | **50** | No <br> ![☒](https://images.uesp.net/7/7d/Red_Cross.svg) | No <br> ![☒](https://images.uesp.net/7/7d/Red_Cross.svg) |
| [Ulundil](https://en.uesp.net/wiki/Skyrim:Ulundil) ([Arivanya](https://en.uesp.net/wiki/Skyrim:Arivanya)) | [Windhelm Stables](Skyrim_Windhelm_Stables.md) | [Horses](Skyrim_Horses.md) | | No <br> ![☒](https://images.uesp.net/7/7d/Red_Cross.svg) | |
| [Wuunferth the Unliving](https://en.uesp.net/wiki/Skyrim:Wuunferth_the_Unliving) | [Palace of the Kings](Skyrim_Palace_of_the_Kings.md) | Spells | **500** | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) |

- Sofie will stop selling flowers and flower baskets if you [adopt](Skyrim_Adoption.md) her.

#### Bugs
- [Dravynea the Stoneweaver](Skyrim_Dravynea_the_Stoneweaver.md) was supposed to be the backup vendor for Wuunferth if he died, but the vendor data was not set up correctly. - ![PC Only](https://images.uesp.net/d/d7/Computer.svg)
The [Unofficial Skyrim Patch](https://en.uesp.net/wiki/Skyrim:Mod_Unofficial_Skyrim_Patch), version 1.2.2, fixes this bug.
- [Malthyr Elenil](https://en.uesp.net/wiki/Skyrim:Malthyr_Elenil) is set up to sell drinks at New Gnisis Cornerclub if Ambrys Rendar dies, but cannot due to a developer oversight. - ![PC Only](https://images.uesp.net/d/d7/Computer.svg)
The [Unofficial Skyrim Patch](https://en.uesp.net/wiki/Skyrim:Mod_Unofficial_Skyrim_Patch), version 1.2.2, addresses this issue. Malthyr will now be able to sell drinks there.
- [Susanna the Wicked](https://en.uesp.net/wiki/Skyrim:Susanna_the_Wicked) is set up to sell drinks at Candlehearth Hall, but doesn't because she was never added to the appropriate faction. - ![PC Only](https://images.uesp.net/d/d7/Computer.svg)
The [Unofficial Skyrim Patch](https://en.uesp.net/wiki/Skyrim:Mod_Unofficial_Skyrim_Patch), version 2.0.2, addresses this issue. Susanna will now be able to sell drinks there.

- Be warned, however, that once [Blood on the Ice](Skyrim_Blood_on_the_Ice.md) has begun, Susanna's services will be permanently unavailable, regardless if you have the Unofficial Patch or not.
- If Revyn Sadri dies, Aval Atheron is supposed to take over as the new shopkeeper at Sadri's Used Wares. Unfortunately, Aval has his own market stall and therefore cannot actually take over the shop. - ![PC Only](https://images.uesp.net/d/d7/Computer.svg)
The [Unofficial Skyrim Patch](https://en.uesp.net/wiki/Skyrim:Mod_Unofficial_Skyrim_Patch), version 2.0.4, addresses this issue. [Idesa Sadri](https://en.uesp.net/wiki/Skyrim:Idesa_Sadri) has been selected to fill the backup alias and will now take over if Revyn is dead.
- Due to a scripting error, Sofie would end up overloading her merchant inventory with flower baskets. This script polled every 10 seconds while she was loaded and could in theory result in her having enough baskets to overflow the reference counts. - ![PC Only](https://images.uesp.net/d/d7/Computer.svg)
The [Unofficial Skyrim Legendary Edition Patch](https://en.uesp.net/wiki/Skyrim:Mod_Unofficial_Skyrim_Legendary_Edition_Patch), version 3.0.1, addresses this issue. This script has now been removed, and her AI package has been modified to instead play the idle continuously. In addition, the AI pack script will slowly remove the baskets over time as they are not needed for her schedule to function.
- Despite only having meat on display at his stall, Aval Atheron actually deals in miscellaneous goods, similar to pawnbrokers. - ![PC Only](https://images.uesp.net/d/d7/Computer.svg)
The [Unofficial Skyrim Patch](https://en.uesp.net/wiki/Skyrim:Mod_Unofficial_Skyrim_Patch), version 2.0.9, addresses this issue. He will now only sell goods similar to those on display.
- Aval Atheron's line about his "fresh fruits and vegetables" makes little sense in accordance with his actual merchandise. - The [Unofficial Skyrim Special Edition Patch](https://en.uesp.net/wiki/Skyrim:Mod_Unofficial_Skyrim_Special_Edition_Patch), version 4.2.6, addresses this issue. The line has now been completely blocked from playing.

### Outside Towns
| Merchant Name | Store Name | Town | Merchandise | Gold | [Invest](Skyrim_Investor.md) | [Master](Skyrim_Master_Trader.md) | Notes |
| --- | --- | --- | --- | --- | --- | --- | --- |
| [Bolar](https://en.uesp.net/wiki/Skyrim:Bolar) | at [Mauhulakh's Longhouse](https://en.uesp.net/wiki/Skyrim:Mauhulakh%27s_Longhouse) | [Narzulbur](Skyrim_Narzulbur.md) | Apothecary | **500** | | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) | Only available if you are [Blood-Kin](Skyrim_Blood-Kin.md) |
| [Dushnamub](https://en.uesp.net/wiki/Skyrim:Dushnamub) | at [Mauhulakh's Longhouse](https://en.uesp.net/wiki/Skyrim:Mauhulakh%27s_Longhouse) | [Narzulbur](Skyrim_Narzulbur.md) | Blacksmith | **400** | | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) | Only available if you are [Blood-Kin](Skyrim_Blood-Kin.md) |
| [Iddra](https://en.uesp.net/wiki/Skyrim:Iddra) | [Braidwood Inn](https://en.uesp.net/wiki/Skyrim:Braidwood_Inn) | [Kynesgrove](Skyrim_Kynesgrove.md) | Innkeeper | **100** | No <br> ![☒](https://images.uesp.net/7/7d/Red_Cross.svg) | | |
| [Gilfre](Skyrim_Gilfre.md) | | [Mixwater Mill](https://en.uesp.net/wiki/Skyrim:Mixwater_Mill) | [Lumber](Skyrim_Sawn_Log.md)<sup>[HF](Skyrim_Hearthfire.md)</sup> | | No <br> ![☒](https://images.uesp.net/7/7d/Red_Cross.svg) | | |

#### Bugs
- If anything happens to Iddra, [Kjeld](https://en.uesp.net/wiki/Skyrim:Kjeld) will take over room rentals, but not merchant services. In the absence of Iddra, it is impossible to buy or sell things in Kynesgrove. - ![PC Only](https://images.uesp.net/d/d7/Computer.svg)
The [Unofficial Skyrim Patch](https://en.uesp.net/wiki/Skyrim:Mod_Unofficial_Skyrim_Patch), version 1.2.4, addresses this issue. Kjeld can now sell innkeeper merchandise as well if he takes over as the publican of Braidwood Inn.

## [Falkreath Hold](Skyrim_Falkreath_Hold.md)

### [Falkreath](Skyrim_Falkreath.md)
| Merchant Name | Store Name | Merchandise | Gold | [Invest](Skyrim_Investor.md) | [Master](Skyrim_Master_Trader.md) |
| --- | --- | --- | --- | --- | --- |
| [Babette](Skyrim_Babette.md) | in the [Dark Brotherhood Sanctuary](Skyrim_Dark_Brotherhood_Sanctuary.md) (see note below) | Apothecary (also sells [Tools](https://en.uesp.net/wiki/Skyrim:Tools)) | **500** | No <br> ![☒](https://images.uesp.net/7/7d/Red_Cross.svg) | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) |
| [Bolund](Skyrim_Bolund.md) | Falkreath sawmill | [Lumber](Skyrim_Sawn_Log.md)<sup>[HF](Skyrim_Hearthfire.md)</sup> | | No <br> ![☒](https://images.uesp.net/7/7d/Red_Cross.svg) | |
| [Solaf](Skyrim_Solaf.md) | [Gray Pine Goods](Skyrim_Gray_Pine_Goods.md) | General; sells [Blue Mage Robes](https://en.uesp.net/wiki/Skyrim:Blue_Mage_Robes) | **750** | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) |
| [Lod](Skyrim_Lod.md) | [Lod's House](Skyrim_Lod%27s_House.md) | Blacksmith | **1000** | No <br> ![☒](https://images.uesp.net/7/7d/Red_Cross.svg) <br> (Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) <br> ) | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) |
| [Valga Vinicia](Skyrim_Valga_Vinicia.md) | [Dead Man's Drink](Skyrim_Dead_Man%27s_Drink.md) | Innkeeper | **100** | No <br> ![☒](https://images.uesp.net/7/7d/Red_Cross.svg) | |
| [Zaria](Skyrim_Zaria.md) | [Grave Concoctions](Skyrim_Grave_Concoctions.md) | Apothecary | **500** | No <br> ![☒](https://images.uesp.net/7/7d/Red_Cross.svg) <br> (Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) <br> ) | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) |

- Babette will no longer be present in the Dark Brotherhood Sanctuary if you finish the [Dark Brotherhood](Skyrim_Dark_Brotherhood.md) questline, as it will eventually be destroyed. - If you start [Destroy the Dark Brotherhood!](Skyrim_Destroy_the_Dark_Brotherhood!.md) instead, she won't be there at all.
- Lod and Zaria are investable now with the Unofficial Skyrim Special Edition Patch. Please check whether they are investable in Legendary Edition or with no patch.

### Other Locations
| Merchant Name | Store Name | Town | Merchandise | Gold | [Invest](Skyrim_Investor.md) | [Master](Skyrim_Master_Trader.md) |
| --- | --- | --- | --- | --- | --- | --- |
| [Hert](https://en.uesp.net/wiki/Skyrim:Hert) | | [Half-Moon Mill](https://en.uesp.net/wiki/Skyrim:Half-Moon_Mill) | [Lumber](Skyrim_Sawn_Log.md)<sup>[HF](Skyrim_Hearthfire.md)</sup> | | No <br> ![☒](https://images.uesp.net/7/7d/Red_Cross.svg) | |

### Bugs
- [Narri](Skyrim_Narri.md), as part of the [Server](https://en.uesp.net/wiki/Skyrim:Server) faction, is supposed to trigger the option to buy food from her menu when you take a seat inside Dead Man's Drink; however, due to her not being in the correct factions, no such option is available, so she'll keep asking you if you would like something to eat, with no possibility to reply. - ![PC Only](https://images.uesp.net/d/d7/Computer.svg)
The [Unofficial Skyrim Patch](https://en.uesp.net/wiki/Skyrim:Mod_Unofficial_Skyrim_Patch), version 1.2.1, fixes this bug.

- [![On PC](https://images.uesp.net/d/d7/Computer.svg)](https://www.wikipedia.org/wiki/PC_game) To fix this, add her to the Dead Man's Drink faction by targeting her and using the console command `[addtofaction](Skyrim_Console.md#addtofaction) 000a6bfb 1`.
- Narri was meant to take over Dead Man's Drink in case something happened to Valga Vinicia, but she can't due to a backup alias not being defined properly. - ![PC Only](https://images.uesp.net/d/d7/Computer.svg)
The [Unofficial Skyrim Patch](https://en.uesp.net/wiki/Skyrim:Mod_Unofficial_Skyrim_Patch), version 1.2.2, fixes this bug.

## [Haafingar](Skyrim_Haafingar.md)

### [Solitude](Skyrim_Solitude.md)
| Merchant Name | Store Name | Merchandise | Gold | [Invest](Skyrim_Investor.md) | [Master](Skyrim_Master_Trader.md) |
| --- | --- | --- | --- | --- | --- |
| [Addvar](Skyrim_Addvar.md) ([Greta](Skyrim_Greta.md)) | Marketplace Stall | Innkeeper | **50** | No <br> ![☒](https://images.uesp.net/7/7d/Red_Cross.svg) | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) |
| [Angeline Morrard](Skyrim_Angeline_Morrard.md) ([Vivienne Onis](Skyrim_Vivienne_Onis.md)) | [Angeline's Aromatics](Skyrim_Angeline%27s_Aromatics.md) | Apothecary | **500** | No <br> ![☒](https://images.uesp.net/7/7d/Red_Cross.svg) <br> (Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) <br> )<sup>[†](#intnote_Angeline)</sup> | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) |
| [Beirand](Skyrim_Beirand.md) | [Solitude Blacksmith](Skyrim_Solitude_Blacksmith.md) | Blacksmith | **1000** | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) |
| [Corpulus Vinius](Skyrim_Corpulus_Vinius.md) | [The Winking Skeever](Skyrim_The_Winking_Skeever.md) | Innkeeper | **100** | No <br> ![☒](https://images.uesp.net/7/7d/Red_Cross.svg) | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) |
| [Endarie](Skyrim_Endarie.md); [Taarie](Skyrim_Taarie.md) | [Radiant Raiment](Skyrim_Radiant_Raiment.md) | [Clothing](Skyrim_Clothing.md), [Jewelry](Skyrim_Jewelry.md) | **750** | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) |
| [Evette San](Skyrim_Evette_San.md) | Marketplace Stall | Innkeeper | **50** | No <br> ![☒](https://images.uesp.net/7/7d/Red_Cross.svg) | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) |
| [Fihada](Skyrim_Fihada.md) ([Jawanan](Skyrim_Jawanan.md)) | [Fletcher](Skyrim_Fletcher_(place).md) | [Armor](Skyrim_Armor.md), [Arrows](https://en.uesp.net/wiki/Skyrim:Arrows), [Tools](https://en.uesp.net/wiki/Skyrim:Tools), [Weapons](Skyrim_Weapons.md) | **750** | No <br> ![☒](https://images.uesp.net/7/7d/Red_Cross.svg) <br> (Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) <br> )<sup>[†](#intnote_Fihada)</sup> | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) |
| [Geimund](Skyrim_Geimund.md) ([Horm](Skyrim_Horm.md)) | [Solitude Stables](Skyrim_Solitude_Stables.md) (via [Katla's Farm](Skyrim_Katla%27s_Farm.md)) | [Horses](Skyrim_Horses.md) | | No <br> ![☒](https://images.uesp.net/7/7d/Red_Cross.svg) | |
| [Gulum-Ei](Skyrim_Gulum-Ei.md) | [The Winking Skeever](Skyrim_The_Winking_Skeever.md) | Fence | **1000** - **4000** | No <br> ![☒](https://images.uesp.net/7/7d/Red_Cross.svg) | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) |
| [Jala](Skyrim_Jala.md) | Marketplace Stall | Innkeeper | **50** | No <br> ![☒](https://images.uesp.net/7/7d/Red_Cross.svg) | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) |
| [Sayma](Skyrim_Sayma.md) | [Bits and Pieces](Skyrim_Bits_and_Pieces.md) | General | **750** | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) |
| [Sybille Stentor](Skyrim_Sybille_Stentor.md) ([Melaran](Skyrim_Melaran.md)) | [Blue Palace](Skyrim_Blue_Palace.md) | Spells | **500** | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) |

[†](#note_Angeline) It is possible to invest endlessly with [Angeline](Skyrim_Angeline_Morrard.md). She never loses the dialogue option to invest, but her permanent base gold cannot increase, due to a [bug](Skyrim_Angeline_Morrard.md#Bugs). - This is fixed by the Unofficial Skyrim Patch (both Legendary and Special Edition versions).
- You can use the console command `set Perk Investor Solitude Apothecary to 0` to invest in Angeline's store.

[†](#note_Fihada) A similar bug prevents investing with [Fihada](Skyrim_Fihada.md). - This is fixed by the Unofficial Skyrim Patch (both Legendary and Special Edition versions).
- No easy fix from the console exists.<sup>[*verification needed — but maybe there's a combination of commands that works?*]</sup>

#### Bugs
- Despite supposedly being Sybille Stentor's replacement as Court Wizard in the event of her death, Melaran will not change his routine or sell anything to reflect this. - ![PC Only](https://images.uesp.net/d/d7/Computer.svg)
The [Unofficial Skyrim Patch](https://en.uesp.net/wiki/Skyrim:Mod_Unofficial_Skyrim_Patch), version 1.2, fixes this bug.
- After [Scoundrel's Folly](https://en.uesp.net/wiki/Skyrim:Scoundrel%27s_Folly), Gulum-Ei is supposed to begin fencing goods but is unable to do so because his chest's enable parent setup is wrong. - ![PC Only](https://images.uesp.net/d/d7/Computer.svg)
The [Unofficial Skyrim Patch](https://en.uesp.net/wiki/Skyrim:Mod_Unofficial_Skyrim_Patch), version 1.2.3, fixes this bug.
- [Vittoria Vici](Skyrim_Vittoria_Vici.md) was supposed to offer services as a general merchant when down at the docks, but she instead just stands there without the option to trade with her. - ![PC Only](https://images.uesp.net/d/d7/Computer.svg)
The [Unofficial Skyrim Patch](https://en.uesp.net/wiki/Skyrim:Mod_Unofficial_Skyrim_Patch), version 1.2.4, fixes this bug.
- If you buy a horse from Katla's Farm and the horse is killed, attempting to purchase a new horse from the same stable results in 1000 gold being deducted, and Geimund stating that your horse is "the one with the saddle", despite no saddled horse appearing at the stables there. Instead, the new horse spawns at the [Riften Stables](Skyrim_Riften_Stables.md). - ![PC Only](https://images.uesp.net/d/d7/Computer.svg)
The [Unofficial Skyrim Patch](https://en.uesp.net/wiki/Skyrim:Mod_Unofficial_Skyrim_Patch), version 2.0.5, fixes this bug.
- Selling crops to [Katla](Skyrim_Katla.md) will allow you to ride the horses at Solitude Stables for free, due to her being in the same ownership faction as the stablemaster. The problem is that horses cost 1,000 gold, making them way too valuable to let stablemasters let you ride them for free after completing a small favor. - ![PC Only](https://images.uesp.net/d/d7/Computer.svg)
The [Unofficial Skyrim Patch](https://en.uesp.net/wiki/Skyrim:Mod_Unofficial_Skyrim_Patch), version 2.1.2, addresses this issue. ([details](https://afktrack.afkmods.com/index.php?a=issues&i=19062)) The ownership of the horses was changed to just Geimund, rather than the faction, preventing this issue.

### Other Locations
| Merchant Name | Store Name | Town | Merchandise | Gold | [Invest](Skyrim_Investor.md) | [Master](Skyrim_Master_Trader.md) | Notes |
| --- | --- | --- | --- | --- | --- | --- | --- |
| [Faida](https://en.uesp.net/wiki/Skyrim:Faida) | [Four Shields Tavern](https://en.uesp.net/wiki/Skyrim:Four_Shields_Tavern) | [Dragon Bridge](Skyrim_Dragon_Bridge.md) | Innkeeper | **100** | No <br> ![☒](https://images.uesp.net/7/7d/Red_Cross.svg) | | |
| [Kharag gro-Shurkul](Skyrim_Kharag_gro-Shurkul.md) | | [Solitude Sawmill](Skyrim_Solitude_Sawmill.md) | [Lumber](Skyrim_Sawn_Log.md)<sup>[HF](Skyrim_Hearthfire.md)</sup> | | No <br> ![☒](https://images.uesp.net/7/7d/Red_Cross.svg) | | |
| [Feran Sadri](https://en.uesp.net/wiki/Skyrim:Feran_Sadri)<sup>[DG](Skyrim_Dawnguard.md)</sup> | | [Volkihar Keep](Skyrim_Volkihar_Keep.md)<sup>[DG](Skyrim_Dawnguard.md)</sup> | Apothecary | **500** | No <br> ![☒](https://images.uesp.net/7/7d/Red_Cross.svg) | No <br> ![☒](https://images.uesp.net/7/7d/Red_Cross.svg) | Hostile to non-vampires |
| [Hestla](https://en.uesp.net/wiki/Skyrim:Hestla)<sup>[DG](Skyrim_Dawnguard.md)</sup> | | [Volkihar Keep](Skyrim_Volkihar_Keep.md)<sup>[DG](Skyrim_Dawnguard.md)</sup> | Blacksmith | **1000** | No <br> ![☒](https://images.uesp.net/7/7d/Red_Cross.svg) | No <br> ![☒](https://images.uesp.net/7/7d/Red_Cross.svg) | Hostile to non-vampires |
| [Ronthil](https://en.uesp.net/wiki/Skyrim:Ronthil)<sup>[DG](Skyrim_Dawnguard.md)</sup> | | [Volkihar Keep](Skyrim_Volkihar_Keep.md)<sup>[DG](Skyrim_Dawnguard.md)</sup> | General | **750** | No <br> ![☒](https://images.uesp.net/7/7d/Red_Cross.svg) | No <br> ![☒](https://images.uesp.net/7/7d/Red_Cross.svg) | Hostile to non-vampires |

#### Bugs
- [Julienne Lylvieve](Skyrim_Julienne_Lylvieve.md) was meant to be Faida's backup for the Four Shields Tavern, but isn't because there is no backup alias. - ![PC Only](https://images.uesp.net/d/d7/Computer.svg)
The [Unofficial Skyrim Patch](https://en.uesp.net/wiki/Skyrim:Mod_Unofficial_Skyrim_Patch), version 1.2.2, fixes this bug.

## [Hjaalmarch](Skyrim_Hjaalmarch.md)

### [Morthal](Skyrim_Morthal.md)
| Merchant Name | Store Name | Merchandise | Gold | [Invest](Skyrim_Investor.md) | [Master](Skyrim_Master_Trader.md) | Notes |
| --- | --- | --- | --- | --- | --- | --- |
| [Falion](Skyrim_Falion.md) | [Falion's House](Skyrim_Falion%27s_House.md) | Spells; sells 1 [Black Soul Gem](Skyrim_Black_Soul_Gem.md) | **500** | No <br> ![☒](https://images.uesp.net/7/7d/Red_Cross.svg) <br> (Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) <br> ) | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) | [Cures vampirism](Skyrim_Rising_at_Dawn.md) |
| [Jonna](Skyrim_Jonna.md) | [Moorside Inn](Skyrim_Moorside_Inn.md) | Innkeeper | **100** | No <br> ![☒](https://images.uesp.net/7/7d/Red_Cross.svg) | | |
| [Lami](Skyrim_Lami.md) | [Thaumaturgist's Hut](Skyrim_Thaumaturgist%27s_Hut.md) | Apothecary | **500** | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) | |
| [Thonnir](Skyrim_Thonnir.md) | Morthal sawmill | [Lumber](Skyrim_Sawn_Log.md)<sup>[HF](Skyrim_Hearthfire.md)</sup> | | No <br> ![☒](https://images.uesp.net/7/7d/Red_Cross.svg) | | |

- Falion is investable with the most recent Unofficial Skyrim Special Edition Patch.

## [The Pale](Skyrim_The_Pale.md)

### [Dawnstar](Skyrim_Dawnstar.md)
| Merchant Name | Store Name | Merchandise | Gold | [Invest](Skyrim_Investor.md) | [Master](Skyrim_Master_Trader.md) |
| --- | --- | --- | --- | --- | --- |
| [Babette](Skyrim_Babette.md) | in the [Dawnstar Sanctuary](Skyrim_Dawnstar_Sanctuary.md) (see note below) | Apothecary (also sells [Tools](https://en.uesp.net/wiki/Skyrim:Tools)) | **500** | No <br> ![☒](https://images.uesp.net/7/7d/Red_Cross.svg) | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) |
| [Frida](Skyrim_Frida.md) | [The Mortar and Pestle](Skyrim_The_Mortar_and_Pestle.md) | Apothecary | **500** | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) |
| [Thoring](Skyrim_Thoring.md) ([Karita](Skyrim_Karita_(bard).md)) | [Windpeak Inn](Skyrim_Windpeak_Inn.md) | Innkeeper | **100** | No <br> ![☒](https://images.uesp.net/7/7d/Red_Cross.svg) | |
| [Madena](Skyrim_Madena.md) | [The White Hall](Skyrim_The_White_Hall.md) | Spells | **500** | | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) |
| [Rustleif](Skyrim_Rustleif.md); [Seren](Skyrim_Seren.md) | [Rustleif's House](Skyrim_Rustleif%27s_House.md) | Blacksmith | **1000** | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) |

- Babette is only available in the Dawnstar Sanctuary if you finish the [Dark Brotherhood](Skyrim_Dark_Brotherhood.md) questline.

### Other Locations
| Merchant Name | Store Name | Town | Merchandise | Gold | [Invest](Skyrim_Investor.md) | [Master](Skyrim_Master_Trader.md) |
| --- | --- | --- | --- | --- | --- | --- |
| [Aeri](Skyrim_Aeri.md) | | [Anga's Mill](https://en.uesp.net/wiki/Skyrim:Anga%27s_Mill) | [Lumber](Skyrim_Sawn_Log.md)<sup>[HF](Skyrim_Hearthfire.md)</sup> | | No <br> ![☒](https://images.uesp.net/7/7d/Red_Cross.svg) | |
| [Agrane Peryval](https://en.uesp.net/wiki/Skyrim:Agrane_Peryval)<sup>[CC](Skyrim_Saturalia_Holiday_Pack.md)</sup> | | Camp north of [Windward Ruins](https://en.uesp.net/wiki/Skyrim:Windward_Ruins) | Unique holiday gear | **750** | | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) |
| [Hadring](https://en.uesp.net/wiki/Skyrim:Hadring) | | [Nightgate Inn](Skyrim_Nightgate_Inn.md) | Innkeeper | **100** | No <br> ![☒](https://images.uesp.net/7/7d/Red_Cross.svg) | |

## [The Reach](Skyrim_The_Reach.md)

### [Markarth](Skyrim_Markarth.md)
| Merchant Name | Store Name | Merchandise | Gold | [Invest](Skyrim_Investor.md) | [Master](Skyrim_Master_Trader.md) |
| --- | --- | --- | --- | --- | --- |
| [Anton Virane](Skyrim_Anton_Virane.md) | in [Understone Keep](Skyrim_Understone_Keep.md) | Innkeeper | **100** | No <br> ![☒](https://images.uesp.net/7/7d/Red_Cross.svg) | |
| [Bothela](Skyrim_Bothela.md) ([Muiri](Skyrim_Muiri.md)) | [The Hag's Cure](Skyrim_The_Hag%27s_Cure.md) | Apothecary | **500** | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) |
| [Calcelmo](Skyrim_Calcelmo.md) | in [Understone Keep](Skyrim_Understone_Keep.md) | Spells | **500** | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) |
| [Cedran](Skyrim_Cedran.md); [Banning](Skyrim_Banning.md) | [Markarth Stables](Skyrim_Markarth_Stables.md) | [Horses](Skyrim_Horses.md) (Cedran) <br> War Dogs (Banning) | | No <br> ![☒](https://images.uesp.net/7/7d/Red_Cross.svg) | |
| [Kleppr](Skyrim_Kleppr.md) ([Frabbi](Skyrim_Frabbi.md)) | [Silver-Blood Inn](Skyrim_Silver-Blood_Inn.md) | Innkeeper | **100** | No <br> ![☒](https://images.uesp.net/7/7d/Red_Cross.svg) | |
| [Endon](Skyrim_Endon.md) | [Endon's House](Skyrim_Endon%27s_House.md) <br> or in [Silver-Blood Inn](Skyrim_Silver-Blood_Inn.md) | Fence | **1000** - **4000** | No <br> ![☒](https://images.uesp.net/7/7d/Red_Cross.svg) | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) |
| [Ghorza gra-Bagol](Skyrim_Ghorza_gra-Bagol.md) ([Tacitus Sallustius](Skyrim_Tacitus_Sallustius.md)) | at the forge near [The Hag's Cure](Skyrim_The_Hag%27s_Cure.md) <br> or in [Understone Keep](Skyrim_Understone_Keep.md) | Blacksmith | **1000** | No <br> ![☒](https://images.uesp.net/7/7d/Red_Cross.svg) <br> (Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) <br> )<sup>[†](#intnote_Ghorza Moth)</sup> | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) |
| [Hogni Red-Arm](Skyrim_Hogni_Red-Arm.md) | Marketplace Stall | Innkeeper | **50** | No <br> ![☒](https://images.uesp.net/7/7d/Red_Cross.svg) | |
| [Kerah](Skyrim_Kerah.md) | Marketplace Stall | Jeweler | **50** | No <br> ![☒](https://images.uesp.net/7/7d/Red_Cross.svg) | No <br> ![☒](https://images.uesp.net/7/7d/Red_Cross.svg) |
| [Lisbet](Skyrim_Lisbet.md) ([Imedhnain](Skyrim_Imedhnain.md)) | [Arnleif and Sons Trading Company](Skyrim_Arnleif_and_Sons_Trading_Company.md) | General | **750** | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) |
| [Moth gro-Bagol](Skyrim_Moth_gro-Bagol.md) | in [Understone Keep](Skyrim_Understone_Keep.md) | Blacksmith | **500** | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) <br> <sup>[†](#intnote_Ghorza Moth)</sup> | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) |

- If either Cedran or Banning dies, then the survivor will NOT take over his mate's services: you cannot end up buying a dog from Cedran or a horse from Banning.

[†](#note_Ghorza Moth) Ghorza gra-Bagol will have the dialogue option to invest in her store, but the only option is to decline, due to a [bug](Skyrim_Ghorza_gra-Bagol.md#Bugs). If she dies, however, you can invest in her successor, Tacitus Sallustius. Investing in either one (after having fixed the bug mentioned above) also invests 500 gold in [Moth gro-Bagol](Skyrim_Moth_gro-Bagol.md), due to [another bug](Skyrim_Ghorza_gra-Bagol.md#Bugs). [![On PC](https://images.uesp.net/d/d7/Computer.svg)](https://www.wikipedia.org/wiki/PC_game) Both bugs are fixed by the current version of the [Unofficial Skyrim Legendary Edition Patch](https://en.uesp.net/wiki/Skyrim:Mod_Unofficial_Skyrim_Legendary_Edition_Patch). - You can use the console command `set Perk Investor Markarth Blacksmith to 0` to invest in both blacksmiths.

### Other Locations
| Merchant Name | Store Place | Town | Merchandise | Gold | [Invest](Skyrim_Investor.md) | [Master](Skyrim_Master_Trader.md) | Notes |
| --- | --- | --- | --- | --- | --- | --- | --- |
| [Gharol](https://en.uesp.net/wiki/Skyrim:Gharol) | at [Burguk's Longhouse](https://en.uesp.net/wiki/Skyrim:Burguk%27s_Longhouse) | [Dushnikh Yal](Skyrim_Dushnikh_Yal.md) | Blacksmith | **400** | | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) | Only available if you are [Blood-Kin](Skyrim_Blood-Kin.md) |
| [Murbul](https://en.uesp.net/wiki/Skyrim:Murbul) | at [Burguk's Longhouse](https://en.uesp.net/wiki/Skyrim:Burguk%27s_Longhouse) | [Dushnikh Yal](Skyrim_Dushnikh_Yal.md) | Apothecary | **500** | | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) | Only available if you are [Blood-Kin](Skyrim_Blood-Kin.md) |
| [Sharamph](https://en.uesp.net/wiki/Skyrim:Sharamph) | at [Larak's Longhouse](https://en.uesp.net/wiki/Skyrim:Larak%27s_Longhouse) | [Mor Khazgur](Skyrim_Mor_Khazgur.md) | Apothecary | **500** | | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) | Only available if you are [Blood-Kin](Skyrim_Blood-Kin.md) |
| [Shuftharz](https://en.uesp.net/wiki/Skyrim:Shuftharz) | at [Larak's Longhouse](https://en.uesp.net/wiki/Skyrim:Larak%27s_Longhouse) | [Mor Khazgur](Skyrim_Mor_Khazgur.md) | Blacksmith | **400** | | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) | Only available if you are [Blood-Kin](Skyrim_Blood-Kin.md) |
| [Eydis](https://en.uesp.net/wiki/Skyrim:Eydis); [Skuli](https://en.uesp.net/wiki/Skyrim:Skuli) ([Leontius Salvius](https://en.uesp.net/wiki/Skyrim:Leontius_Salvius)) | | [Old Hroldan Inn](Skyrim_Old_Hroldan_Inn.md) | Innkeeper | **100** | No <br> ![☒](https://images.uesp.net/7/7d/Red_Cross.svg) | | |

## [The Rift](Skyrim_The_Rift.md)

### [Riften](Skyrim_Riften.md)
| Merchant Name | Store Name | Merchandise | Gold | [Invest](Skyrim_Investor.md) | [Master](Skyrim_Master_Trader.md) |
| --- | --- | --- | --- | --- | --- |
| [Arnskar Ember-Master](Skyrim_Arnskar_Ember-Master.md) | [The Ragged Flagon](Skyrim_The_Ragged_Flagon.md) | Blacksmith | **1000** | No <br> ![☒](https://images.uesp.net/7/7d/Red_Cross.svg) | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) |
| [Balimund](Skyrim_Balimund.md) ([Asbjorn Fire-Tamer](Skyrim_Asbjorn_Fire-Tamer.md)) | [The Scorched Hammer](Skyrim_The_Scorched_Hammer.md) | Blacksmith | **1000** | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) |
| [Bersi Honey-Hand](Skyrim_Bersi_Honey-Hand.md) ([Drifa](Skyrim_Drifa.md)) | [Pawned Prawn](Skyrim_Pawned_Prawn.md) | General | **750** | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) |
| [Brand-Shei](Skyrim_Brand-Shei.md) | Marketplace Stall | General | **750** | No <br> ![☒](https://images.uesp.net/7/7d/Red_Cross.svg) <br> (Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) <br> <sup>[†](#intnote_Brand-Shei Grelka Madesi Marise)</sup>) | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) |
| [Vekel the Man](Skyrim_Vekel_the_Man.md) ([Dirge](Skyrim_Dirge.md)) | [The Ragged Flagon](Skyrim_The_Ragged_Flagon.md) | Innkeeper | **100** | No <br> ![☒](https://images.uesp.net/7/7d/Red_Cross.svg) | No <br> ![☒](https://images.uesp.net/7/7d/Red_Cross.svg) |
| [Elgrim](Skyrim_Elgrim.md); [Hafjorg](Skyrim_Hafjorg.md) | [Elgrim's Elixirs](Skyrim_Elgrim%27s_Elixirs.md) | Apothecary | **500** | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) |
| [Galathil](Skyrim_Galathil.md)<sup>[DG](Skyrim_Dawnguard.md)</sup> | [The Ragged Flagon](Skyrim_The_Ragged_Flagon.md) | Facial Reconstruction | **N/A** | No <br> ![☒](https://images.uesp.net/7/7d/Red_Cross.svg) | No <br> ![☒](https://images.uesp.net/7/7d/Red_Cross.svg) |
| [Grelka](Skyrim_Grelka.md) | Marketplace Stall | General | **750** | No <br> ![☒](https://images.uesp.net/7/7d/Red_Cross.svg) <br> (Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) <br> <sup>[†](#intnote_Brand-Shei Grelka Madesi Marise)</sup>) | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) |
| [Herluin Lothaire](Skyrim_Herluin_Lothaire.md) | [The Ragged Flagon](Skyrim_The_Ragged_Flagon.md) | Apothecary | **500** | No <br> ![☒](https://images.uesp.net/7/7d/Red_Cross.svg) | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) |
| [Hofgrir Horse-Crusher](Skyrim_Hofgrir_Horse-Crusher.md) ([Shadr)](Skyrim_Shadr.md) | [Riften Stables](Skyrim_Riften_Stables.md) | [Horses](Skyrim_Horses.md) | | No <br> ![☒](https://images.uesp.net/7/7d/Red_Cross.svg) | |
| [Ungrien](Skyrim_Ungrien.md) | [Black-Briar Meadery](Skyrim_Black-Briar_Meadery.md) | Innkeeper | **100** | No <br> ![☒](https://images.uesp.net/7/7d/Red_Cross.svg) | |
| [Romlyn Dreth](Skyrim_Romlyn_Dreth.md) | [Black-Briar Meadery](Skyrim_Black-Briar_Meadery.md) | [Black-Briar Mead](https://en.uesp.net/wiki/Skyrim:Black-Briar_Mead) | | No <br> ![☒](https://images.uesp.net/7/7d/Red_Cross.svg) | |
| [Keerava](Skyrim_Keerava.md); [Talen-Jei](Skyrim_Talen-Jei.md) | [The Bee and Barb](Skyrim_The_Bee_and_Barb.md) | Innkeeper | **100** | No <br> ![☒](https://images.uesp.net/7/7d/Red_Cross.svg) | |
| [Viriya](Skyrim_Viriya.md)<sup>[CC](Skyrim_Fishing.md)</sup> | Marketplace Stall | Crab-based items | **150** | No <br> ![☒](https://images.uesp.net/7/7d/Red_Cross.svg) | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) |
| [Madesi](Skyrim_Madesi.md) | Marketplace Stall | Jeweler | **750** | No <br> ![☒](https://images.uesp.net/7/7d/Red_Cross.svg) <br> (Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) <br> <sup>[†](#intnote_Brand-Shei Grelka Madesi Marise)</sup>) | |
| [Marise Aravel](Skyrim_Marise_Aravel.md) | Marketplace Stall | General | **50** | No <br> ![☒](https://images.uesp.net/7/7d/Red_Cross.svg) <br> (Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) <br> <sup>[†](#intnote_Brand-Shei Grelka Madesi Marise)</sup>) | |
| [Syndus](Skyrim_Syndus.md) | [The Ragged Flagon](Skyrim_The_Ragged_Flagon.md) | Blacksmith | **1000** | No <br> ![☒](https://images.uesp.net/7/7d/Red_Cross.svg) | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) |
| [Tonilia](Skyrim_Tonilia.md) | [The Ragged Flagon](Skyrim_The_Ragged_Flagon.md) | Fence | **1000** - **4000** | No <br> ![☒](https://images.uesp.net/7/7d/Red_Cross.svg) | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) |
| [Vanryth Gatharian](Skyrim_Vanryth_Gatharian.md) | [The Ragged Flagon](Skyrim_The_Ragged_Flagon.md) | Blacksmith | **1000** | No <br> ![☒](https://images.uesp.net/7/7d/Red_Cross.svg) | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) |
| [Wylandriah](Skyrim_Wylandriah.md) | in [Mistveil Keep](Skyrim_Mistveil_Keep.md) | Spells | **1000** | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) |

- Galathil won't change your face if you are a [vampire](Skyrim_Vampirism.md) or a [Vampire Lord](Skyrim_Vampire_Lord.md)<sup>[DG](Skyrim_Dawnguard.md)</sup>.
- Viriya's stall becomes available once [End of the Line](Skyrim_End_of_the_Line.md)<sup>[CC](Skyrim_Fishing.md)</sup> is finished.
- Tonilia sometimes has the "What'll you give me for these?" dialogue option, and other times has the "What have you got for sale?" dialogue option.
- Syndus, Herluin Lothaire, Arnskar Ember-Master, and Vanryth Gatharian are added to the Ragged Flagon (in that order) during [Under New Management](Skyrim_Under_New_Management.md).
- All merchants in the Ragged Flagon are part of the Thieves Guild Faction, and will jump to the Guild's defense if hostilities erupt down there.

[†](#note_Grelka Brand-Shei Madesi Marise) Version 2.1.3 of the [Unofficial Skyrim Patch](https://en.uesp.net/wiki/Skyrim:Mod_Unofficial_Skyrim_Patch) makes it possible to invest with Brand-Shei, Grelka, Madesi, and Marise. [‡](#note_Grelka Brand-Shei Madesi Marise) Be warned, however, that version 3.0.1 of the [Unofficial Skyrim Legendary Edition Patch](https://en.uesp.net/wiki/Skyrim:Mod_Unofficial_Skyrim_Legendary_Edition_Patch) reverses that, and they cannot be invested with anymore.
#### Bugs
- Despite being a fence, there is a chance that Tonilia may eventually stop accepting stolen goods. - The [Official Skyrim Patch](Skyrim_Patch.md), version 1.4, fixes this bug.
- If you turn Romlyn in to [Indaryn](Skyrim_Indaryn.md) during [Under the Table](https://en.uesp.net/wiki/Skyrim:Under_the_Table), he will keep working at the meadery and continue to sell his under-the-table Black-Briar Mead, despite saying *"A Dreth never forgets a traitor."* each time you talk to him. - ![PC Only](https://images.uesp.net/d/d7/Computer.svg)
The [Unofficial Skyrim Patch](https://en.uesp.net/wiki/Skyrim:Mod_Unofficial_Skyrim_Patch), version 1.2.4, addresses this issue. Romlyn will be jailed if you turn him in and he will no longer offer to sell you any mead.
- Helping Shadr will allow you to ride the horses at Riften Stables for free, due to him being in the same ownership faction as the stablemaster. The problem is that horses cost 1,000 gold, making them way too valuable to let stablemasters let you ride them for free after completing a small favor. - ![PC Only](https://images.uesp.net/d/d7/Computer.svg)
The [Unofficial Skyrim Patch](https://en.uesp.net/wiki/Skyrim:Mod_Unofficial_Skyrim_Patch), version 2.1.2, addresses this issue. ([details](https://afktrack.afkmods.com/index.php?a=issues&i=19062)) The ownership of the horses was changed to just Hofgrir, rather than the faction, preventing this issue.

### Other Locations
| Merchant Name | Store Place | Town | Merchandise | Gold | [Invest](Skyrim_Investor.md) | [Master](Skyrim_Master_Trader.md) | Notes |
| --- | --- | --- | --- | --- | --- | --- | --- |
| [Filnjar](Skyrim_Filnjar.md) | [Filnjar's House](https://en.uesp.net/wiki/Skyrim:Filnjar%27s_House) | [Shor's Stone](Skyrim_Shor%27s_Stone.md) | Blacksmith | **500** | No <br> ![☒](https://images.uesp.net/7/7d/Red_Cross.svg) <br> (Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) <br> ) | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) | |
| [Grosta](https://en.uesp.net/wiki/Skyrim:Grosta) | | [Heartwood Mill](https://en.uesp.net/wiki/Skyrim:Heartwood_Mill) | [Lumber](Skyrim_Sawn_Log.md)<sup>[HF](Skyrim_Hearthfire.md)</sup> | | No <br> ![☒](https://images.uesp.net/7/7d/Red_Cross.svg) | | |
| [Wilhelm](Skyrim_Wilhelm.md) ([Lynly Star-Sung](https://en.uesp.net/wiki/Skyrim:Lynly_Star-Sung)) | [Vilemyr Inn](https://en.uesp.net/wiki/Skyrim:Vilemyr_Inn) | [Ivarstead](Skyrim_Ivarstead.md) | Innkeeper | **100** | No <br> ![☒](https://images.uesp.net/7/7d/Red_Cross.svg) | | |
| [Dealer](https://en.uesp.net/wiki/Skyrim:Dealer)<sup>[DG](Skyrim_Dawnguard.md)</sup> | | [Redwater Den](Skyrim_Redwater_Den.md)<sup>[DG](Skyrim_Dawnguard.md)</sup> | Innkeeper (also sells [Redwater Skooma](https://en.uesp.net/wiki/Skyrim:Redwater_Skooma)<sup>[DG](Skyrim_Dawnguard.md)</sup>) | **100** | No <br> ![☒](https://images.uesp.net/7/7d/Red_Cross.svg) | | Hostile if you attempt to halt the Redwater Skooma operation |
| [Florentius Baenius](https://en.uesp.net/wiki/Skyrim:Florentius_Baenius)<sup>[DG](Skyrim_Dawnguard.md)</sup> | | [Fort Dawnguard](Skyrim_Fort_Dawnguard.md)<sup>[DG](Skyrim_Dawnguard.md)</sup> | Apothecary, Spells | **500** | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) | Hostile to vampires |
| [Gunmar](https://en.uesp.net/wiki/Skyrim:Gunmar)<sup>[DG](Skyrim_Dawnguard.md)</sup> | | [Fort Dawnguard](Skyrim_Fort_Dawnguard.md)<sup>[DG](Skyrim_Dawnguard.md)</sup> | Blacksmith | **1000** | | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) | Hostile to vampires |
| [Sorine Jurard](https://en.uesp.net/wiki/Skyrim:Sorine_Jurard)<sup>[DG](Skyrim_Dawnguard.md)</sup> | | [Fort Dawnguard](Skyrim_Fort_Dawnguard.md)<sup>[DG](Skyrim_Dawnguard.md)</sup> | General | **750** | | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) | Hostile to vampires |

- Filnjar in Shor's Stone can be invested, with the most recent versions of Skyrim and the Unofficial Skyrim Special Edition Patch (please check if he can be invested with the Legendary version, or without the Unofficial Patches at all)

#### Bugs
- [Atub](https://en.uesp.net/wiki/Skyrim:Atub) and [Garakh](https://en.uesp.net/wiki/Skyrim:Garakh) at [Largashbur](Skyrim_Largashbur.md) were apparently intended to be merchants (apothecary and blacksmith respectively), but do not function as merchants themselves. - ![PC Only](https://images.uesp.net/d/d7/Computer.svg)
The [Unofficial Skyrim Patch](https://en.uesp.net/wiki/Skyrim:Mod_Unofficial_Skyrim_Patch), version 1.2.5, addresses this issue. They were assigned the wrong settings. Once fixed, they will be affected by [Master Trader](Skyrim_Master_Trader.md), but not [Investor](Skyrim_Investor.md).

## [Solstheim](Skyrim_Solstheim.md)<sup>[DB](Skyrim_Dragonborn.md)</sup>

### [Raven Rock](Skyrim_Raven_Rock.md)
| Merchant Name | Store Name | Merchandise | Gold | [Invest](Skyrim_Investor.md) | [Master](Skyrim_Master_Trader.md) | Notes |
| --- | --- | --- | --- | --- | --- | --- |
| [Fethis Alor](Skyrim_Fethis_Alor.md) | [Alor House](Skyrim_Alor_House.md) | General | **1500** | | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) | |
| [Garyn Ienth](Skyrim_Garyn_Ienth.md) | [Ienth Farm](Skyrim_Ienth_Farm.md) | Innkeeper | **50** | No <br> ![☒](https://images.uesp.net/7/7d/Red_Cross.svg) | | |
| [Geldis Sadri](Skyrim_Geldis_Sadri.md) | [The Retching Netch](Skyrim_The_Retching_Netch.md) | Innkeeper | **100** | No <br> ![☒](https://images.uesp.net/7/7d/Red_Cross.svg) | | |
| [Glover Mallory](Skyrim_Glover_Mallory.md) | [Glover Mallory's House](Skyrim_Glover_Mallory%27s_House.md) | Blacksmith | **2000** | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) | |
| [Milore Ienth](Skyrim_Milore_Ienth.md) | [Ienth Farm](Skyrim_Ienth_Farm.md) | Apothecary | **1000** | | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) | |

### [Tel Mithryn](Skyrim_Tel_Mithryn_(settlement).md)
| Merchant Name | Store Name | Merchandise | Gold | [Invest](Skyrim_Investor.md) | [Master](Skyrim_Master_Trader.md) | Notes |
| --- | --- | --- | --- | --- | --- | --- |
| [Elynea Mothren](Skyrim_Elynea_Mothren.md) | [Tel Mithryn Apothecary](Skyrim_Tel_Mithryn_Apothecary.md) | Apothecary | **1000** | | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) | |
| [Neloth](Skyrim_Neloth.md) | [Tel Mithryn](Skyrim_Tel_Mithryn_(tower).md) | Staves & Spells | **1000** | | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) | |
| [Talvas Fathryon](Skyrim_Talvas_Fathryon.md) | [Tel Mithryn](Skyrim_Tel_Mithryn_(tower).md) | Spells | **500** | | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) | |
| [Revus Sarvani](https://en.uesp.net/wiki/Skyrim:Revus_Sarvani) | [Tel Mithryn](Skyrim_Tel_Mithryn_(tower).md) | General | **500** | No <br> ![☒](https://images.uesp.net/7/7d/Red_Cross.svg) | | Found on outskirts of the town with his silt strider |

### Others
| Merchant Name | Store Name | Merchandise | Gold | [Invest](Skyrim_Investor.md) | [Master](Skyrim_Master_Trader.md) | Notes |
| --- | --- | --- | --- | --- | --- | --- |
| [Edla](https://en.uesp.net/wiki/Skyrim:Edla) | [Edla's House](Skyrim_Edla%27s_House.md) in [Skaal Village](Skyrim_Skaal_Village.md) | Apothecary | **50** | No <br> ![☒](https://images.uesp.net/7/7d/Red_Cross.svg) | | |
| [Baldor Iron-Shaper](Skyrim_Baldor_Iron-Shaper.md) | [Baldor Iron-Shaper's House](Skyrim_Baldor_Iron-Shaper%27s_House.md) in [Skaal Village](Skyrim_Skaal_Village.md) | Blacksmith | **1000** | | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) | |
| [Blacksmith](Skyrim_Blacksmith_(NPC).md)<sup>[CC](Skyrim_Ghosts_of_the_Tribunal.md)</sup> | [Ashfall's Tear](Skyrim_Ashfall%27s_Tear.md)<sup>[CC](Skyrim_Ghosts_of_the_Tribunal.md)</sup> | Blacksmith | **2130** | [<sup>(?)</sup>](https://en.uesp.net/wiki/Category:Pages_Missing_Data) | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) | Only appears if you side with the [Tribunal Temple](Skyrim_Tribunal_Temple.md) during [Her Word Against Theirs](https://en.uesp.net/wiki/Skyrim:Her_Word_Against_Theirs) |
| [Caretaker Ineril](https://en.uesp.net/wiki/Skyrim:Caretaker_Ineril)<sup>[CC](Skyrim_Ghosts_of_the_Tribunal.md)</sup> | [Ashfall's Tear](Skyrim_Ashfall%27s_Tear.md)<sup>[CC](Skyrim_Ghosts_of_the_Tribunal.md)</sup> | General | **1500** | [<sup>(?)</sup>](https://en.uesp.net/wiki/Category:Pages_Missing_Data) | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) | Only appears after you give one of the translated [Propaganda Letters](https://en.uesp.net/wiki/Skyrim:Propaganda_Letter) to [Geldis Sadri](Skyrim_Geldis_Sadri.md) during [Her Word Against Theirs](https://en.uesp.net/wiki/Skyrim:Her_Word_Against_Theirs) |
| [Curate Melita](https://en.uesp.net/wiki/Skyrim:Curate_Melita)<sup>[CC](Skyrim_Ghosts_of_the_Tribunal.md)</sup> | [Ashfall's Tear](Skyrim_Ashfall%27s_Tear.md)<sup>[CC](Skyrim_Ghosts_of_the_Tribunal.md)</sup> | Apothecary | **2000** | [<sup>(?)</sup>](https://en.uesp.net/wiki/Category:Pages_Missing_Data) | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) | Only available if you set her free during [Careless Curation](https://en.uesp.net/wiki/Skyrim:Careless_Curation) |
| [Priest Drureth](https://en.uesp.net/wiki/Skyrim:Priest_Drureth)<sup>[CC](Skyrim_Ghosts_of_the_Tribunal.md)</sup> | [Ashfall's Tear](Skyrim_Ashfall%27s_Tear.md)<sup>[CC](Skyrim_Ghosts_of_the_Tribunal.md)</sup> | Apothecary | **2000** | [<sup>(?)</sup>](https://en.uesp.net/wiki/Category:Pages_Missing_Data) | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) | |
| [Falas Selvayn](https://en.uesp.net/wiki/Skyrim:Falas_Selvayn) | [Ramshackle Trading Post](Skyrim_Ramshackle_Trading_Post.md) | General | **750** | No <br> ![☒](https://images.uesp.net/7/7d/Red_Cross.svg) | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) | Only appears if you visit the trading post at night |
| [Halbarn Iron-Fur](https://en.uesp.net/wiki/Skyrim:Halbarn_Iron-Fur) | [Bujold's Retreat](Skyrim_Bujold%27s_Retreat.md) / <br> [Thirsk Mead Hall](Skyrim_Thirsk_Mead_Hall.md) | Blacksmith | **1000** | | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) | Only available at Thirsk Mead Hall if you finish [Retaking Thirsk](Skyrim_Retaking_Thirsk.md) |
| [Elmus](https://en.uesp.net/wiki/Skyrim:Elmus) | [Bujold's Retreat](Skyrim_Bujold%27s_Retreat.md) / <br> [Thirsk Mead Hall](Skyrim_Thirsk_Mead_Hall.md) | Food and Drink | **100** | No <br> ![☒](https://images.uesp.net/7/7d/Red_Cross.svg) | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) | Only available at Thirsk Mead Hall if you finish [Retaking Thirsk](Skyrim_Retaking_Thirsk.md) |
| [Ancarion](Skyrim_Ancarion.md) | [Northshore Landing](Skyrim_Northshore_Landing.md) | Stalhrim equipment | **1000** | No <br> ![☒](https://images.uesp.net/7/7d/Red_Cross.svg) | No <br> ![☒](https://images.uesp.net/7/7d/Red_Cross.svg) <br> (Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) <br> )<sup>[†](#intnote_Ancarion)</sup> | Only available if you successfully negotiate with him during [A New Source of Stalhrim](Skyrim_A_New_Source_of_Stalhrim.md) |
| [Majni](https://en.uesp.net/wiki/Skyrim:Majni) | [Frostmoon Crag](Skyrim_Frostmoon_Crag.md) | General, Werewolf rings | **25** - **125** | | | Only available at the camp if you are a werewolf |

- If you want to convince Ancarion to let you sell Stalhrim equipment to him, your [Speech](Skyrim_Speech.md) skill must be 75 or better.

[†](#note_Ancarion) Ancarion's shop benefits from the Master Trader perk with version 2.0.3 of the [Unofficial Dragonborn Patch](https://en.uesp.net/wiki/Skyrim:Mod_Unofficial_Dragonborn_Patch).
#### Bugs
- Despite being a blacksmith, Baldor Iron-Shaper is incorrectly configured to buy any type of item regardless if you have the Merchant perk active or not. - ![PC Only](https://images.uesp.net/d/d7/Computer.svg)
The [Unofficial Dragonborn Patch](https://en.uesp.net/wiki/Skyrim:Mod_Unofficial_Dragonborn_Patch), version 2.0.8, addresses this issue. You now need to have the Merchant perk active to sell him anything else.
- Some merchants on Solstheim can incorrectly prompt you with dialogue that's used by Fences. There are no Fences on the island, unless you invest in Glover with the Fence perk active. - ![PC Only](https://images.uesp.net/d/d7/Computer.svg)
The [Unofficial Dragonborn Patch](https://en.uesp.net/wiki/Skyrim:Mod_Unofficial_Dragonborn_Patch), version 2.0.8, fixes this bug.

## [Whiterun Hold](Skyrim_Whiterun_Hold.md)

### [Riverwood](Skyrim_Riverwood.md)
| Merchant Name | Store Name | Merchandise | Gold | [Invest](Skyrim_Investor.md) | [Master](Skyrim_Master_Trader.md) |
| --- | --- | --- | --- | --- | --- |
| [Alvor](https://en.uesp.net/wiki/Skyrim:Alvor) | [Alvor and Sigrid's House](https://en.uesp.net/wiki/Skyrim:Alvor_and_Sigrid%27s_House) | Blacksmith | **500** | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) |
| [Hod](Skyrim_Hod.md) | Riverwood sawmill | [Lumber](Skyrim_Sawn_Log.md)<sup>[HF](Skyrim_Hearthfire.md)</sup> | | No <br> ![☒](https://images.uesp.net/7/7d/Red_Cross.svg) | |
| [Orgnar](https://en.uesp.net/wiki/Skyrim:Orgnar) | [Sleeping Giant Inn](Skyrim_Sleeping_Giant_Inn.md) | Innkeeper (also sells [Ingredients](Skyrim_Ingredients.md)) | **100** | No <br> ![☒](https://images.uesp.net/7/7d/Red_Cross.svg) | |
| [Lucan Valerius](Skyrim_Lucan_Valerius.md) ([Camilla Valerius](Skyrim_Camilla_Valerius.md)) | [Riverwood Trader](Skyrim_Riverwood_Trader.md) | General; sells [Blue Mage Robes](https://en.uesp.net/wiki/Skyrim:Blue_Mage_Robes), several Spell Tomes | **750** | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) |

- If you place items in the cupboard behind Lucan's counter, they will show up in his inventory. Purchasing stolen items you place in there will remove their stolen tags. Don't put torches in there, though, as they won't add to what Lucan has for sale.

### Bugs
- If you invest 500 gold into the Riverwood Trader (using the [Investor](Skyrim_Investor.md) perk), regardless of if it's operated by Lucan or Camilla, it adds 10,000 gold instead of 500 gold to their inventory. - The [Official Skyrim Patch](Skyrim_Patch.md), version 1.9, fixes this bug.

### [Whiterun](Skyrim_Whiterun.md)
| Merchant Name | Store Name | Merchandise | Gold | [Invest](Skyrim_Investor.md) | [Master](Skyrim_Master_Trader.md) |
| --- | --- | --- | --- | --- | --- |
| [Adrianne Avenicci](https://en.uesp.net/wiki/Skyrim:Adrianne_Avenicci) (Outside) | [Warmaiden's](Skyrim_Warmaiden%27s.md) | Blacksmith | **1000** | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) |
| [Adrianne Avenicci](https://en.uesp.net/wiki/Skyrim:Adrianne_Avenicci); [Ulfberth War-Bear](https://en.uesp.net/wiki/Skyrim:Ulfberth_War-Bear) | [Warmaiden's](Skyrim_Warmaiden%27s.md) | Blacksmith | **1000** | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) |
| [Anoriath](https://en.uesp.net/wiki/Skyrim:Anoriath) | Marketplace Stall | Innkeeper | **50** | No <br> ![☒](https://images.uesp.net/7/7d/Red_Cross.svg) <br> (Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) <br> ) | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) |
| [Arcadia](Skyrim_Arcadia.md) | [Arcadia's Cauldron](Skyrim_Arcadia%27s_Cauldron.md) | Apothecary | **500** | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) |
| [Belethor](Skyrim_Belethor.md) | [Belethor's General Goods](Skyrim_Belethor%27s_General_Goods.md) | General | **750** | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) |
| [Carlotta Valentia](Skyrim_Carlotta_Valentia.md) | Marketplace Stall | Innkeeper | **50** | No <br> ![☒](https://images.uesp.net/7/7d/Red_Cross.svg) | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) |
| [Elrindir](https://en.uesp.net/wiki/Skyrim:Elrindir) | [The Drunken Huntsman](https://en.uesp.net/wiki/Skyrim:The_Drunken_Huntsman) | [Armor](Skyrim_Armor.md), [Arrows](https://en.uesp.net/wiki/Skyrim:Arrows), [Food](Skyrim_Food.md), [Tools](https://en.uesp.net/wiki/Skyrim:Tools), [Weapons](Skyrim_Weapons.md) | **750** | No <br> ![☒](https://images.uesp.net/7/7d/Red_Cross.svg) <br> (Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) <br> ) | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) |
| [Eorlund Gray-Mane](Skyrim_Eorlund_Gray-Mane.md) | [Skyforge](Skyrim_Skyforge.md) | Blacksmith | **1000** - **2500** | | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) |
| [Farengar Secret-Fire](Skyrim_Farengar_Secret-Fire.md) | [Dragonsreach](Skyrim_Dragonsreach.md) | Spells | **500** | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) |
| [Fralia Gray-Mane](Skyrim_Fralia_Gray-Mane.md) | Marketplace Stall | Jeweler | **50** | No <br> ![☒](https://images.uesp.net/7/7d/Red_Cross.svg) | No <br> ![☒](https://images.uesp.net/7/7d/Red_Cross.svg) |
| [Hulda](https://en.uesp.net/wiki/Skyrim:Hulda); [Saadia](https://en.uesp.net/wiki/Skyrim:Saadia) ([Ysolda](Skyrim_Ysolda.md)) | [The Bannered Mare](https://en.uesp.net/wiki/Skyrim:The_Bannered_Mare) | Innkeeper | **100** | No <br> ![☒](https://images.uesp.net/7/7d/Red_Cross.svg) | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) |
| [Mallus Maccius](Skyrim_Mallus_Maccius.md) | [Honningbrew Meadery](Skyrim_Honningbrew_Meadery.md) | Fence | **1000** - **4000** | No <br> ![☒](https://images.uesp.net/7/7d/Red_Cross.svg) | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) |
| [Sabjorn](Skyrim_Sabjorn.md) | [Honningbrew Meadery](Skyrim_Honningbrew_Meadery.md) | Innkeeper | **100** | No <br> ![☒](https://images.uesp.net/7/7d/Red_Cross.svg) | |
| [Skulvar Sable-Hilt](https://en.uesp.net/wiki/Skyrim:Skulvar_Sable-Hilt) ([Jervar](https://en.uesp.net/wiki/Skyrim:Jervar)) | [Whiterun Stables](https://en.uesp.net/wiki/Skyrim:Whiterun_Stables) | [Horses](Skyrim_Horses.md) | | No <br> ![☒](https://images.uesp.net/7/7d/Red_Cross.svg) | |

- Adrianne Avenicci, Arcadia, Belethor, and Ulfberth War-Bear may have [Do Not Delete](https://en.uesp.net/wiki/Skyrim:Do_Not_Delete) chests for sale. - ![PC Only](https://images.uesp.net/d/d7/Computer.svg)
The [Unofficial Skyrim Patch](https://en.uesp.net/wiki/Skyrim:Mod_Unofficial_Skyrim_Patch), version 2.0.4, fixes this bug. ([details](https://afktrack.afkmods.com/index.php?a=issues&i=8125))
- Anoriath will allow you to invest in his store, but his available gold will not increase due to a [bug](https://en.uesp.net/wiki/Skyrim:Anoriath#Bugs). - ![PC Only](https://images.uesp.net/d/d7/Computer.svg)
The [Unofficial Skyrim Patch](https://en.uesp.net/wiki/Skyrim:Mod_Unofficial_Skyrim_Patch), version 2.0.4, fixes this bug.
- Anoriath owns Fralia Gray-Mane's merchant chest when it doesn't belong to him. - ![PC Only](https://images.uesp.net/d/d7/Computer.svg)
The [Unofficial Skyrim Patch](https://en.uesp.net/wiki/Skyrim:Mod_Unofficial_Skyrim_Patch), version 2.0.4, fixes this bug.
- Due to dialogue condition errors, you cannot invest in The Drunken Huntsman by talking to Elrindir. - ![PC Only](https://images.uesp.net/d/d7/Computer.svg)
The [Unofficial Skyrim Patch](https://en.uesp.net/wiki/Skyrim:Mod_Unofficial_Skyrim_Patch), version 2.0.6, fixes this bug.
- Despite the fact that [Olfina Gray-Mane](Skyrim_Olfina_Gray-Mane.md) is part of the "food vendor" class, she isn't actually a food merchant herself.
- Adrianne Avenicci is unique in having access to two merchant chests; when she is outside during the day, she sells items from a separate chest. When she is inside and the store is open, she uses the same chest as Ulfberth War-Bear. The two chests are counted as separate stores for the purpose of investing. However, you can only invest once.

### Other Locations
| Merchant Name | Store Name | Town | Merchandise | Gold | [Invest](Skyrim_Investor.md) | [Master](Skyrim_Master_Trader.md) |
| --- | --- | --- | --- | --- | --- | --- |
| [Mralki](https://en.uesp.net/wiki/Skyrim:Mralki) | [Frostfruit Inn](https://en.uesp.net/wiki/Skyrim:Frostfruit_Inn) | [Rorikstead](Skyrim_Rorikstead.md) | Innkeeper | **100** | No <br> ![☒](https://images.uesp.net/7/7d/Red_Cross.svg) | |

## [Winterhold](Skyrim_Winterhold_(region).md)

### [Winterhold](Skyrim_Winterhold.md)
| Merchant Name | Store Name | Merchandise | Gold | [Invest](Skyrim_Investor.md) | [Master](Skyrim_Master_Trader.md) |
| --- | --- | --- | --- | --- | --- |
| [Birna](https://en.uesp.net/wiki/Skyrim:Birna) | [Birna's Oddments](https://en.uesp.net/wiki/Skyrim:Birna%27s_Oddments) | General | **750** | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) |
| [Dagur](https://en.uesp.net/wiki/Skyrim:Dagur); [Haran](https://en.uesp.net/wiki/Skyrim:Haran) | [The Frozen Hearth](https://en.uesp.net/wiki/Skyrim:The_Frozen_Hearth) | Innkeeper | **100** | No <br> ![☒](https://images.uesp.net/7/7d/Red_Cross.svg) | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) |
| [Nelacar](https://en.uesp.net/wiki/Skyrim:Nelacar) | [The Frozen Hearth](https://en.uesp.net/wiki/Skyrim:The_Frozen_Hearth) | Spells | **500** | | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) |

### [College of Winterhold](Skyrim_College_of_Winterhold_(place).md)
| Merchant Name | Store Location | Merchandise | Gold | [Invest](Skyrim_Investor.md) | [Master](Skyrim_Master_Trader.md) | Notes |
| --- | --- | --- | --- | --- | --- | --- |
| [Colette Marence](https://en.uesp.net/wiki/Skyrim:Colette_Marence) | [Hall of Countenance](https://en.uesp.net/wiki/Skyrim:Hall_of_Countenance) | Spells ([Restoration](Skyrim_Restoration.md)) | **500** | | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) | |
| [Drevis Neloren](https://en.uesp.net/wiki/Skyrim:Drevis_Neloren) | [Hall of Countenance](https://en.uesp.net/wiki/Skyrim:Hall_of_Countenance) | Spells ([Illusion](Skyrim_Illusion.md)) | **500** | | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) | |
| [Enthir](https://en.uesp.net/wiki/Skyrim:Enthir) | [Hall of Attainment](Skyrim_Hall_of_Attainment.md) | General | **500** | No <br> ![☒](https://images.uesp.net/7/7d/Red_Cross.svg) | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) | Stocks a [Black Soul Gem](Skyrim_Black_Soul_Gem.md) and 2 [Daedra Hearts](Skyrim_Daedra_Heart.md) |
| Fence | **1000** - **4000** | | | | | |
| [Faralda](https://en.uesp.net/wiki/Skyrim:Faralda) | [Hall of Countenance](https://en.uesp.net/wiki/Skyrim:Hall_of_Countenance) | Spells ([Destruction](Skyrim_Destruction.md)) | **500** | | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) | |
| [Phinis Gestor](https://en.uesp.net/wiki/Skyrim:Phinis_Gestor) | [Hall of Countenance](https://en.uesp.net/wiki/Skyrim:Hall_of_Countenance) | Spells ([Conjuration](Skyrim_Conjuration.md)) | **500** | | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) | |
| [Tolfdir](https://en.uesp.net/wiki/Skyrim:Tolfdir) | [Hall of Attainment](Skyrim_Hall_of_Attainment.md) | Spells ([Alteration](Skyrim_Alteration.md)) | **500** | | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) | |
| [Urag gro-Shub](Skyrim_Urag_gro-Shub.md) | [The Arcanaeum](https://en.uesp.net/wiki/Skyrim:The_Arcanaeum) | [Books](Skyrim_Books.md) | **500** | | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) | |

#### Bugs
- Enthir may only be available as a fence when he isn't in the Hall of Attainment. - ![PC Only](https://images.uesp.net/d/d7/Computer.svg)
The [Unofficial Skyrim Patch](https://en.uesp.net/wiki/Skyrim:Mod_Unofficial_Skyrim_Patch), version 1.2.2, addresses this issue. Enthir will now for fencing at all times once his fence setup quest is finished.
- After completing the Thieves Guild quests and joining the College, Enthir may lose his status as a fence. Despite having two separate dialogue options (one for his old retail mode and another for his fence mode), he will only buy non-stolen goods, and will be limited to the original 500 gold. - ![PC Only](https://images.uesp.net/d/d7/Computer.svg)
The [Unofficial Skyrim Patch](https://en.uesp.net/wiki/Skyrim:Mod_Unofficial_Skyrim_Patch), version 1.2.3, fixes this bug.
- Urag gro-Shub has no scrolls in his vendor inventory despite clearly stating he sells them when asked about it. - The [Unofficial Skyrim Special Edition Patch](https://en.uesp.net/wiki/Skyrim:Mod_Unofficial_Skyrim_Special_Edition_Patch), version 4.2.4, fixes this bug.

## Not Specific to One Hold

### [Khajiit Traders](Skyrim_Khajiit_Traders.md)
| Merchant Name | Store Location | Merchandise | Gold | [Invest](Skyrim_Investor.md) | [Master](Skyrim_Master_Trader.md) |
| --- | --- | --- | --- | --- | --- |
| [Ahkari](https://en.uesp.net/wiki/Skyrim:Ahkari) | [Dawnstar](Skyrim_Dawnstar.md) or [Riften](Skyrim_Riften.md) | General; Sells [Moon Sugar](https://en.uesp.net/wiki/Skyrim:Moon_Sugar) and [Skooma](https://en.uesp.net/wiki/Skyrim:Skooma) | **750** | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) |
| [Atahbah](https://en.uesp.net/wiki/Skyrim:Atahbah) | [Markarth](Skyrim_Markarth.md) or [Whiterun](Skyrim_Whiterun.md) | [Fence](Skyrim_Fence_(merchant).md) | **1000** - **4000** | No <br> ![☒](https://images.uesp.net/7/7d/Red_Cross.svg) | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) |
| [Ma'dran](https://en.uesp.net/wiki/Skyrim:Ma%27dran) | [Solitude](Skyrim_Solitude.md) or [Windhelm](Skyrim_Windhelm.md) | General; Sells [Moon Sugar](https://en.uesp.net/wiki/Skyrim:Moon_Sugar) and [Skooma](https://en.uesp.net/wiki/Skyrim:Skooma) | **750** | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) |
| [Ma'jhad](https://en.uesp.net/wiki/Skyrim:Ma%27jhad) | [Solitude](Skyrim_Solitude.md) or [Windhelm](Skyrim_Windhelm.md) | [Fence](Skyrim_Fence_(merchant).md) | **1000** - **4000** | No <br> ![☒](https://images.uesp.net/7/7d/Red_Cross.svg) | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) |
| [Ri'saad](https://en.uesp.net/wiki/Skyrim:Ri%27saad) | [Markarth](Skyrim_Markarth.md) or [Whiterun](Skyrim_Whiterun.md) | General; Sells [Moon Sugar](https://en.uesp.net/wiki/Skyrim:Moon_Sugar) and [Skooma](https://en.uesp.net/wiki/Skyrim:Skooma) | **750** | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) |
| [Zaynabi](https://en.uesp.net/wiki/Skyrim:Zaynabi) | [Dawnstar](Skyrim_Dawnstar.md) or [Riften](Skyrim_Riften.md) | [Fence](Skyrim_Fence_(merchant).md) | **1000** - **4000** | No <br> ![☒](https://images.uesp.net/7/7d/Red_Cross.svg) | Yes <br> ![☑](https://images.uesp.net/4/4d/Green_Tick.svg) |

### Other
| Merchant Name | Store Location | Merchandise | Gold | [Invest](Skyrim_Investor.md) | [Master](Skyrim_Master_Trader.md) | Notes |
| --- | --- | --- | --- | --- | --- | --- |
| [Imperial Quartermaster](https://en.uesp.net/wiki/Skyrim:Imperial_Quartermaster) | Most [Imperial](Skyrim_Imperial.md) [camps](Skyrim_Military_Camps.md) | Blacksmith | **1000** | No <br> ![☒](https://images.uesp.net/7/7d/Red_Cross.svg) | No <br> ![☒](https://images.uesp.net/7/7d/Red_Cross.svg) | Hostile if you have [joined the Stormcloaks](Skyrim_Joining_the_Stormcloaks.md) |
| [Stormcloak Quartermaster](https://en.uesp.net/wiki/Skyrim:Stormcloak_Quartermaster) | Most [Stormcloak](Skyrim_Stormcloaks.md) [camps](Skyrim_Military_Camps.md) | Blacksmith | **1000** | No <br> ![☒](https://images.uesp.net/7/7d/Red_Cross.svg) | No <br> ![☒](https://images.uesp.net/7/7d/Red_Cross.svg) | Hostile if you have [joined the Imperials](Skyrim_Joining_the_Legion.md) |
| [Hunter](Skyrim_Hunter.md) | [Randomly anywhere](Skyrim_World_Interactions.md) in the wilderness; some [unmarked places](Skyrim_Unmarked_Places.md) | Meat, Hides | **3** - **36**<sup>[*](#intnote_Hunters)</sup> | No <br> ![☒](https://images.uesp.net/7/7d/Red_Cross.svg) | No <br> ![☒](https://images.uesp.net/7/7d/Red_Cross.svg) | May occasionally have a [dog](Skyrim_Dog.md) present with them |
| [Hunter](Skyrim_Hunter.md)<sup>[DG](Skyrim_Dawnguard.md)</sup> | [Randomly anywhere](Skyrim_World_Interactions.md) in the wilderness | Meat, Hides | **3** - **36**<sup>[*](#intnote_Hunters)</sup> | No <br> ![☒](https://images.uesp.net/7/7d/Red_Cross.svg) | No <br> ![☒](https://images.uesp.net/7/7d/Red_Cross.svg) | This hunter may be infected with [Sanginare Vampiris](Skyrim_Sanguinare_Vampiris.md); if so, you must give him a [Cure Disease](Skyrim_Cure_Disease.md) potion to be able to trade with him once again. You'll also gain 100 gold and the location of a vampire lair as a reward. Only a found or purchased potion will work; one created using [Alchemy](Skyrim_Alchemy.md) won't. If you cannot, the hunter will flee in terror. |
| [Orc Hunter](Skyrim_Orc_Hunter.md) | [Randomly anywhere](Skyrim_World_Interactions.md) in the wilderness | Meat, Hides | **10** - **50** | No <br> ![☒](https://images.uesp.net/7/7d/Red_Cross.svg) | No <br> ![☒](https://images.uesp.net/7/7d/Red_Cross.svg) | May be hostile towards each other (or you) or have nothing for sale |
| [Peddler](Skyrim_Peddler.md) | [Randomly anywhere](Skyrim_World_Interactions.md) in the wilderness <br> (being attacked by [bandits](Skyrim_Bandit.md) or [Forsworn](Skyrim_Forsworn.md)) | General Goods | **50** - **77** | No <br> ![☒](https://images.uesp.net/7/7d/Red_Cross.svg) | No <br> ![☒](https://images.uesp.net/7/7d/Red_Cross.svg) | May sometimes appear dead by the time of your arrival |
| [Skooma Dealer](Skyrim_Skooma_Dealer_(NPC).md) | [Randomly anywhere](Skyrim_World_Interactions.md) in the wilderness | [Moon Sugar](https://en.uesp.net/wiki/Skyrim:Moon_Sugar), [Skooma](https://en.uesp.net/wiki/Skyrim:Skooma), [Sleeping Tree Sap](https://en.uesp.net/wiki/Skyrim:Sleeping_Tree_Sap) | **20** - **56** | No <br> ![☒](https://images.uesp.net/7/7d/Red_Cross.svg) | No <br> ![☒](https://images.uesp.net/7/7d/Red_Cross.svg) | Hostile if you fail to intimidate them or if you tell them what they're doing is illegal |
| [Sond](Skyrim_Sond_(child).md) | [Randomly anywhere](Skyrim_World_Interactions.md) in the wilderness | Miscellaneous Dwemer equipment | **20** | No <br> ![☒](https://images.uesp.net/7/7d/Red_Cross.svg) | No <br> ![☒](https://images.uesp.net/7/7d/Red_Cross.svg) | Will add [Deep Folk Crossing](https://en.uesp.net/wiki/Skyrim:Deep_Folk_Crossing) to your map for 1 gold |
| [Spouses](Skyrim_Marriage.md) | Wherever you and your spouse live | General by default<sup>[†](#intnote_Marriage)</sup> | **100** - **1000** | unknown | unknown | Will give you a cumulative 100 gold a day or more |
| [Personal Stewards](Skyrim_Personal_Steward.md)<sup>[HF](Skyrim_Hearthfire.md)</sup> | Wherever your [player-built home](Skyrim_Construction.md)<sup>[HF](Skyrim_Hearthfire.md)</sup> is | Improvements to your property<sup>[†](#intnote_Personal Steward)</sup> | | | | Can also be assigned to [Goldenhills Plantation](Skyrim_Goldenhills_Plantation.md)<sup>[CC](Skyrim_Farming.md)</sup> |
| [Morven Stroud](https://en.uesp.net/wiki/Skyrim:Morven_Stroud)<sup>[DG](Skyrim_Dawnguard.md)</sup> | [Soul Cairn](Skyrim_Soul_Cairn.md)<sup>[DG](Skyrim_Dawnguard.md)</sup> | Swords, Battleaxes, Armor, Spell Tomes | **N/A** | No <br> ![☒](https://images.uesp.net/7/7d/Red_Cross.svg) | No <br> ![☒](https://images.uesp.net/7/7d/Red_Cross.svg) | Weapons and armor may be [enchanted](Skyrim_Enchanting.md); may offer Expert-level [Spell Tomes](Skyrim_Spell_Tomes.md)<sup>[†](#intnote_Morven Stroud)</sup> |
| [Dremora Merchant](https://en.uesp.net/wiki/Skyrim:Dremora_Merchant)<sup>[DB](Skyrim_Dragonborn.md)</sup> | Summoned to your location | [Heavy armor](Skyrim_Heavy_Armor.md), [Weapons](Skyrim_Weapons.md) | **2000** | No <br> ![☒](https://images.uesp.net/7/7d/Red_Cross.svg) | No <br> ![☒](https://images.uesp.net/7/7d/Red_Cross.svg) | Items are [enchanted](Skyrim_Enchanting.md); may sell [Dragon items](Skyrim_Dragon_Items.md)<sup>[†](#intnote_Dremora Merchant)</sup> |

[*](#note_Hunters) Hunters will not dissipate their wealth when you sell them things. They have theoretically unlimited wealth. It is just that they will only pay up to a certain amount of gold for a single item, or a single stack of items. [†](#note_Marriage) The merchandise your spouse sells depends on whether or not he or she was a merchant beforehand. If so, it will reflect on what type of merchandise they originally sold. If not, they will sell general merchandise. [†](#note_Personal Steward) The available improvements your Personal Steward sells at Goldenhills Plantation are different from the ones available at your player-built houses. [†](#note_Morven Stroud) Morven Stroud will tell you that gold isn't valuable in the Soul Cairn. Instead, he will give you a random item of your choosing for 25 [soul husks](https://en.uesp.net/wiki/Skyrim:Soul_Husk) apiece. You can get up to Expert-level Spell Tomes from him, whether you know their spells or not. [†](#note_Dremora Merchant) Choosing the [Black Market](https://en.uesp.net/wiki/Skyrim:Black_Market) power at the end of the [Black Book: Untold Legends](Skyrim_Black_Book__Untold_Legends_(quest).md)<sup>[DB](Skyrim_Dragonborn.md)</sup> quest makes the [Dremora Merchant](https://en.uesp.net/wiki/Skyrim:Dremora_Merchant) available. You can then summon him to your location, regardless of whether you are in Solstheim or Skyrim.
## Merchant Trainers
You can ask these merchants for training.

[](https://en.uesp.net/wiki/File:SR-icon-Basic_Trainer.png) - Common (0-50), [](https://en.uesp.net/wiki/File:SR-icon-Advanced_Trainer.png) - Expert (0-75), [](https://en.uesp.net/wiki/File:SR-icon-Master_Trainer.png) - Master (0-90)

| Merchant Name | Store Location | Skill |
| --- | --- | --- |
| [Arcadia](Skyrim_Arcadia.md) | [Arcadia's Cauldron](Skyrim_Arcadia%27s_Cauldron.md) | [](Skyrim_Trainers.md) [![Alchemy (Expert)](https://images.uesp.net/thumb/9/9f/SR-skill-Alchemy_bw.png/22px-SR-skill-Alchemy_bw.png)](Skyrim_Alchemy.md) |
| [Babette](Skyrim_Babette.md) | [Dark Brotherhood Sanctuary](Skyrim_Dark_Brotherhood_Sanctuary.md) or [Dawnstar Sanctuary](Skyrim_Dawnstar_Sanctuary.md) | [](Skyrim_Trainers.md) [![Alchemy (Master)](https://images.uesp.net/thumb/9/9f/SR-skill-Alchemy_bw.png/22px-SR-skill-Alchemy_bw.png)](Skyrim_Alchemy.md) |
| [Balimund](Skyrim_Balimund.md) | [The Scorched Hammer](Skyrim_The_Scorched_Hammer.md) | [](Skyrim_Trainers.md) [![Smithing (Expert)](https://images.uesp.net/thumb/a/a8/SR-skill-Smithing_bw.png/22px-SR-skill-Smithing_bw.png)](Skyrim_Smithing.md) |
| [Curate Melita](https://en.uesp.net/wiki/Skyrim:Curate_Melita)<sup>[CC](Skyrim_Ghosts_of_the_Tribunal.md)</sup> | [Ashfall's Tear](Skyrim_Ashfall%27s_Tear.md)<sup>[CC](Skyrim_Ghosts_of_the_Tribunal.md)</sup> | [](Skyrim_Trainers.md) [![Alchemy (??)](https://images.uesp.net/thumb/9/9f/SR-skill-Alchemy_bw.png/22px-SR-skill-Alchemy_bw.png)](Skyrim_Alchemy.md) |
| [Colette Marence](https://en.uesp.net/wiki/Skyrim:Colette_Marence) | [College of Winterhold](Skyrim_College_of_Winterhold_(place).md) | [](Skyrim_Trainers.md) [![Restoration (Expert)](https://images.uesp.net/thumb/0/06/SR-skill-Restoration_bw.png/22px-SR-skill-Restoration_bw.png)](Skyrim_Restoration.md) |
| [Drevis Neloren](https://en.uesp.net/wiki/Skyrim:Drevis_Neloren) | [College of Winterhold](Skyrim_College_of_Winterhold_(place).md) | [](Skyrim_Trainers.md) [![Illusion (Master)](https://images.uesp.net/thumb/2/29/SR-skill-Illusion_bw.png/22px-SR-skill-Illusion_bw.png)](Skyrim_Illusion.md) |
| [Eorlund Gray-Mane](Skyrim_Eorlund_Gray-Mane.md) | [Skyforge](Skyrim_Skyforge.md) | [](Skyrim_Trainers.md) [![Smithing (Master)](https://images.uesp.net/thumb/a/a8/SR-skill-Smithing_bw.png/22px-SR-skill-Smithing_bw.png)](Skyrim_Smithing.md) |
| [Falion](Skyrim_Falion.md) | [Falion's House](Skyrim_Falion%27s_House.md) | [](Skyrim_Trainers.md) [![Conjuration (Master)](https://images.uesp.net/thumb/b/b1/SR-skill-Conjuration_bw.png/22px-SR-skill-Conjuration_bw.png)](Skyrim_Conjuration.md) |
| [Faralda](https://en.uesp.net/wiki/Skyrim:Faralda) | [College of Winterhold](Skyrim_College_of_Winterhold_(place).md) | [](Skyrim_Trainers.md) [![Destruction (Master)](https://images.uesp.net/thumb/a/af/SR-skill-Destruction_bw.png/22px-SR-skill-Destruction_bw.png)](Skyrim_Destruction.md) |
| [Florentius Baenius](https://en.uesp.net/wiki/Skyrim:Florentius_Baenius)<sup>[DG](Skyrim_Dawnguard.md)</sup> | [Fort Dawnguard](Skyrim_Fort_Dawnguard.md)<sup>[DG](Skyrim_Dawnguard.md)</sup> | [](Skyrim_Trainers.md) [![Restoration (Master)](https://images.uesp.net/thumb/0/06/SR-skill-Restoration_bw.png/22px-SR-skill-Restoration_bw.png)](Skyrim_Restoration.md) |
| [Gharol](https://en.uesp.net/wiki/Skyrim:Gharol) | [Dushnikh Yal](Skyrim_Dushnikh_Yal.md) | [](Skyrim_Trainers.md) [![Heavy Armor (Expert)](https://images.uesp.net/thumb/7/7f/SR-skill-Heavy_Armor_bw.png/22px-SR-skill-Heavy_Armor_bw.png)](Skyrim_Heavy_Armor.md) |
| [Ghorza gra-Bagol](Skyrim_Ghorza_gra-Bagol.md) | [Markarth](Skyrim_Markarth.md) | [](Skyrim_Trainers.md) [![Smithing (Common)](https://images.uesp.net/thumb/a/a8/SR-skill-Smithing_bw.png/22px-SR-skill-Smithing_bw.png)](Skyrim_Smithing.md) |
| [Grelka](Skyrim_Grelka.md) | [Riften](Skyrim_Riften.md) marketplace | [](Skyrim_Trainers.md) [![Light Armor (Expert)](https://images.uesp.net/thumb/0/02/SR-skill-Light_Armor_bw.png/22px-SR-skill-Light_Armor_bw.png)](Skyrim_Light_Armor.md) |
| [Gunmar](https://en.uesp.net/wiki/Skyrim:Gunmar)<sup>[DG](Skyrim_Dawnguard.md)</sup> | [Fort Dawnguard](Skyrim_Fort_Dawnguard.md)<sup>[DG](Skyrim_Dawnguard.md)</sup> | [](Skyrim_Trainers.md) [![Smithing (Master)](https://images.uesp.net/thumb/a/a8/SR-skill-Smithing_bw.png/22px-SR-skill-Smithing_bw.png)](Skyrim_Smithing.md) |
| [Lami](Skyrim_Lami.md) | [Thaumaturgist's Hut](Skyrim_Thaumaturgist%27s_Hut.md) | [](Skyrim_Trainers.md) [![Alchemy (Common)](https://images.uesp.net/thumb/9/9f/SR-skill-Alchemy_bw.png/22px-SR-skill-Alchemy_bw.png)](Skyrim_Alchemy.md) |
| [Ma'jhad](https://en.uesp.net/wiki/Skyrim:Ma%27jhad) | [Ma'dran](https://en.uesp.net/wiki/Skyrim:Ma%27dran)'s [Khajiit caravan](Skyrim_Khajiit_Traders.md) | [](Skyrim_Trainers.md) [![Lockpicking (Expert)](https://images.uesp.net/thumb/a/aa/SR-skill-Lockpicking_bw.png/22px-SR-skill-Lockpicking_bw.png)](Skyrim_Lockpicking.md) |
| [Milore Ienth](Skyrim_Milore_Ienth.md)<sup>[DB](Skyrim_Dragonborn.md)</sup> | [Raven Rock](Skyrim_Raven_Rock.md)<sup>[DB](Skyrim_Dragonborn.md)</sup> | [](Skyrim_Trainers.md) [![Alchemy (Expert)](https://images.uesp.net/thumb/9/9f/SR-skill-Alchemy_bw.png/22px-SR-skill-Alchemy_bw.png)](Skyrim_Alchemy.md) |
| [Neloth](Skyrim_Neloth.md)<sup>[DB](Skyrim_Dragonborn.md)</sup> | [Tel Mithryn](Skyrim_Tel_Mithryn_(tower).md)<sup>[DB](Skyrim_Dragonborn.md)</sup> | [](Skyrim_Trainers.md) [![Enchanting (Master)](https://images.uesp.net/thumb/d/dc/SR-skill-Enchanting_bw.png/22px-SR-skill-Enchanting_bw.png)](Skyrim_Enchanting.md) |
| [Phinis Gestor](https://en.uesp.net/wiki/Skyrim:Phinis_Gestor) | [College of Winterhold](Skyrim_College_of_Winterhold_(place).md) | [](Skyrim_Trainers.md) [![Conjuration (Expert)](https://images.uesp.net/thumb/b/b1/SR-skill-Conjuration_bw.png/22px-SR-skill-Conjuration_bw.png)](Skyrim_Conjuration.md) |
| [Revyn Sadri](Skyrim_Revyn_Sadri.md) | [Sadri's Used Wares](https://en.uesp.net/wiki/Skyrim:Sadri%27s_Used_Wares) | [](Skyrim_Trainers.md) [![Speech (Common)](https://images.uesp.net/thumb/7/7f/SR-skill-Speech_bw.png/22px-SR-skill-Speech_bw.png)](Skyrim_Speech.md) |
| [Ronthil](https://en.uesp.net/wiki/Skyrim:Ronthil)<sup>[DG](Skyrim_Dawnguard.md)</sup> | [Volkihar Keep](Skyrim_Volkihar_Keep.md)<sup>[DG](Skyrim_Dawnguard.md)</sup> | [](Skyrim_Trainers.md) [![Speech (Expert)](https://images.uesp.net/thumb/7/7f/SR-skill-Speech_bw.png/22px-SR-skill-Speech_bw.png)](Skyrim_Speech.md) |
| [Sorine Jurard](https://en.uesp.net/wiki/Skyrim:Sorine_Jurard)<sup>[DG](Skyrim_Dawnguard.md)</sup> | [Fort Dawnguard](Skyrim_Fort_Dawnguard.md)<sup>[DG](Skyrim_Dawnguard.md)</sup> | [](Skyrim_Trainers.md) [![Archery (Master)](https://images.uesp.net/thumb/4/44/SR-skill-Archery_bw.png/22px-SR-skill-Archery_bw.png)](Skyrim_Archery.md) |
| [Sybille Stentor](Skyrim_Sybille_Stentor.md) | [Blue Palace](Skyrim_Blue_Palace.md) | [](Skyrim_Trainers.md) [![Destruction (Expert)](https://images.uesp.net/thumb/a/af/SR-skill-Destruction_bw.png/22px-SR-skill-Destruction_bw.png)](Skyrim_Destruction.md) |
| [Talvas Fathryon](Skyrim_Talvas_Fathryon.md)<sup>[DB](Skyrim_Dragonborn.md)</sup> | [Tel Mithryn](Skyrim_Tel_Mithryn_(tower).md)<sup>[DB](Skyrim_Dragonborn.md)</sup> | [](Skyrim_Trainers.md) [![Conjuration (Master)](https://images.uesp.net/thumb/b/b1/SR-skill-Conjuration_bw.png/22px-SR-skill-Conjuration_bw.png)](Skyrim_Conjuration.md) |
| [Tolfdir](https://en.uesp.net/wiki/Skyrim:Tolfdir) | [College of Winterhold](Skyrim_College_of_Winterhold_(place).md) | [](Skyrim_Trainers.md) [![Alteration (Master)](https://images.uesp.net/thumb/4/4c/SR-skill-Alteration_bw.png/22px-SR-skill-Alteration_bw.png)](Skyrim_Alteration.md) |
| [Wuunferth the Unliving](https://en.uesp.net/wiki/Skyrim:Wuunferth_the_Unliving) | [Palace of the Kings](Skyrim_Palace_of_the_Kings.md) | [](Skyrim_Trainers.md) [![Destruction (Common)](https://images.uesp.net/thumb/a/af/SR-skill-Destruction_bw.png/22px-SR-skill-Destruction_bw.png)](Skyrim_Destruction.md) |

## Notes
- If you steal enough of a merchant's possessions, they may send [Hired Thugs](Skyrim_Hired_Thug.md) after you. Some may also view knocking display items down and [shouting](Skyrim_Shouts.md) in their shop as reason enough.
- If a merchant lives in his or her shop and you go beyond the counter to their room, they will follow you around.
- [Torches](https://en.uesp.net/wiki/Skyrim:Torch) cannot be bought from merchants or sold to them, no matter how high your [Speech](Skyrim_Speech.md) skill is or how many perks related to merchants are active.
- Your spouse can start handing out profits before ever moving to your house and informing you they're opening a store.
- Merchants who are also [Trainers](Skyrim_Trainers.md) add the gold that you pay them for training to the gold they carry in their personal inventory. As such, it then becomes available to be used for bartering as all personal items not equipped can be purchased from a merchant.
- Resetting the [Speech](Skyrim_Speech.md) perk tree using the Black Book [Waking Dreams](Skyrim_Black_Book__Waking_Dreams_(book).md)<sup>[DB](Skyrim_Dragonborn.md)</sup> does not affect investments that you may have previously made with merchants.
- If you side with the [Dawnguard](Skyrim_Dawnguard_(faction).md) and become a vampire later, the Fort Dawnguard merchants won't sell anything until you [cure yourself](Skyrim_Rising_at_Dawn.md). Likewise, if you side with the [Volkihar family](Skyrim_Volkihar_Vampire_Clan.md) and [cure yourself](Skyrim_Rising_at_Dawn.md) later, the Volkihar Keep merchants won't sell anything until your vampirism is restored.
- If you move your spouse to one of the [homesteads](Skyrim_Houses.md#Hearthfire_Houses HF) added by the [Hearthfire](Skyrim_Hearthfire.md) add-on, they will often wander around outside the house where their merchant chest will not be available. To engage in trade with your spouse, wait until they go inside, or if they are a follower you can ask them to follow you and lead them inside.
- Because merchant inventory is not written to the save file, a merchant is more-or-less guaranteed to have a different inventory and a different amount of gold each time you load a save. The exception is that if you quick-save, and then quick-load while the in-memory merchant data is still valid, the merchant inventory will be the same as before the quick-load. However, if you take an action that invalidates the merchant's in-memory data, such as attacking the merchant, the subsequent quick-load will have a regenerated inventory, the same as if you had shut down and then restarted the game.

## Bugs
- If a merchant is talking to you as you are leaving their store, they will exit along with you, re-enter their store, lock the doors and close for the day.
- If you attack a merchant and reload immediately before the attack occurs, or if you save, then attack a merchant and reload, their inventory should reset. <sup>**?**</sup> - This method won't work with your spouse.
- Don't attack a merchant and use a [Calm](Skyrim_Calm.md) spell on them, or their inventory won't reset.
- Selecting the *Fence* perk may allow you to sell stolen goods to any merchant, not just those you have invested in as the perk description states. <sup>**?**</sup>
- When resetting your [Speech](Skyrim_Speech.md) skill, you still retain your ability to invest in merchants, without having to have that perk or having a speech skill high enough to be able to get this perk. This is also true for *Master Trader* —all related merchants will still have 1000 more gold even after you lose the perk. <sup>**?**</sup>
- The Investor perk may prevent merchants you invest with from receiving the extra gold properly. - The [Official Skyrim Patch](Skyrim_Patch.md), version 1.9, fixes this bug.
- You can buy from hunters, your money will be reduced normally and you will get the item, but when selling to them your item will disappear and you will get no money. - The [Official Skyrim Special Edition Patch](Skyrim_Special_Edition_Patch.md), version 1.6.1130.0, fixes this bug.
- Some of the merchants may "forget" that you invested in their shop and lose the option for having extra buying gold. This appears to affect female alchemy merchants much more than male merchants or merchants of general goods stores (e.g. Angeline's Aromatics in Solitude will never remember an investment). - ![PC Only](https://images.uesp.net/d/d7/Computer.svg)
The [Unofficial Skyrim Patch](https://en.uesp.net/wiki/Skyrim:Mod_Unofficial_Skyrim_Patch), version 1.1, fixes this bug.
- Each rank of the Haggling perk delivers inconsistent results on prices. Specifically, Rank 1 only gives you a 9% discount when it should be 10%. Rank 2 only gives you a 13% discount when it should be 15%. Rank 3 only gives you a 17% discount when it should be 20%. Rank 4 only gives you a 20% discount when it should be 25%. Rank 5 only gives you a 23% discount when it should be 30%. - ![PC Only](https://images.uesp.net/d/d7/Computer.svg)
The [Unofficial Skyrim Patch](https://en.uesp.net/wiki/Skyrim:Mod_Unofficial_Skyrim_Patch), version 1.2.6, addresses this issue. The purchase prices were using incorrect decimal values to produce the expected discounts.

- All of the selling bonuses on these perks are correct regardless whether you have the patch or not.
- Allure only provides a 9% bonus when buying items instead of a 10% bonus as is stated in the description. - ![PC Only](https://images.uesp.net/d/d7/Computer.svg)
The [Unofficial Skyrim Legendary Edition Patch](https://en.uesp.net/wiki/Skyrim:Mod_Unofficial_Skyrim_Legendary_Edition_Patch), version 3.0.11, fixes this bug.
- The Lover's Insight reward from Black Book: The Winds of Change only gives a 9% bonus to prices instead of the advertised 10%. - ![PC Only](https://images.uesp.net/d/d7/Computer.svg)
The [Unofficial Dragonborn Patch](https://en.uesp.net/wiki/Skyrim:Mod_Unofficial_Dragonborn_Patch), version 1.0.5, fixes this bug.
- Several merchants may miss the bonus gold from the Master Trader perk despite the perk specifically stating ALL merchants in the world should have it. - ![PC Only](https://images.uesp.net/d/d7/Computer.svg)
The [Unofficial Skyrim Patch](https://en.uesp.net/wiki/Skyrim:Mod_Unofficial_Skyrim_Patch), version 1.3.2, fixes this bug.
- Innkeepers can fail to headtrack you upon entering the building due to the WITavern Greeting scenes not having headtracking set at all. - ![PC Only](https://images.uesp.net/d/d7/Computer.svg)
The [Unofficial Skyrim Patch](https://en.uesp.net/wiki/Skyrim:Mod_Unofficial_Skyrim_Patch), version 1.3.3, fixes this bug.
- Ysolda and Camilla may both accept investments in their shops after being married, which makes little sense considering they're no longer going to be running the shops they are assigned as backups to. - ![PC Only](https://images.uesp.net/d/d7/Computer.svg)
The [Unofficial Skyrim Patch](https://en.uesp.net/wiki/Skyrim:Mod_Unofficial_Skyrim_Patch), version 2.0.1, fixes this bug.
- Dwemer Scrap Metal is not classified as ores or ingots by merchants, and therefore cannot be sold to blacksmiths or jewelers without the [Merchant perk](Skyrim_Merchant_(perk).md). - ![PC Only](https://images.uesp.net/d/d7/Computer.svg)
The [Unofficial Skyrim Patch](https://en.uesp.net/wiki/Skyrim:Mod_Unofficial_Skyrim_Patch), version 2.0.5, fixes this bug.

- This bug is also fixed with version 1.6.1130 of the [Official Skyrim Special Edition Patch.](Skyrim_Special_Edition_Patch.md)
- Hunter merchants may attack your [horse](Skyrim_Horses.md) even though your horse is your ally. - ![PC Only](https://images.uesp.net/d/d7/Computer.svg)
The [Unofficial Skyrim Patch](https://en.uesp.net/wiki/Skyrim:Mod_Unofficial_Skyrim_Patch), version 2.0.7, addresses this issue. This was due to incomplete faction relationships.
- Spouse dialogue saying they're starting a new store repeats itself even though the "say once" flag is checked. - ![PC Only](https://images.uesp.net/d/d7/Computer.svg)
The [Unofficial Skyrim Patch](https://en.uesp.net/wiki/Skyrim:Mod_Unofficial_Skyrim_Patch), version 2.0.8, addresses this issue. A script variable has been added to block this after the first use as a workaround to the "say once flag".
- Despite being able to run a shop from one of the Hearthfire properties, your spouse never actually says they're going to do that if this is the first house you move them to because the dialogue conditions did not include the HF locations. - ![PC Only](https://images.uesp.net/d/d7/Computer.svg)
The [Unofficial Hearthfire Patch](https://en.uesp.net/wiki/Skyrim:Mod_Unofficial_Hearthfire_Patch), version 2.0.1, fixes this bug.

* Trading with vendors becomes unreliable when their gold reserves exceeds 32,767. The game's internal trading mechanism mistakenly treats their gold quantity as a [signed 16-bit integer](https://www.wikipedia.org/wiki/Integer_(computer_science)#Short_integer), whose value could be between -32768 and 32767. If you buy a lot of expensive items or receive high-level skill training, so much so that their gold reserve goes beyond 32,767, an [Integer overflow](https://www.wikipedia.org/wiki/Integer_overflow) bug occurs. Thus, you can still sell them items, but you lose the item without gaining any gold. Complicating the matter is the fact that each vendor's gold reserve is the sum of gold in their inventory plus the gold in their chests.

- A community-developed bug fix is available as a mod called "[Barter Limit Fix](https://www.nexusmods.com/skyrimspecialedition/mods/77173)."

- Merchants can sometimes lose the dialogue option "What have you got for sale?" making it impossible to trade with them. - [![On PC](https://images.uesp.net/d/d7/Computer.svg)](https://www.wikipedia.org/wiki/PC_game) You can try the following to resolve the issue: - open the console
- enter the console command `startquest dialoguegeneric`
- press enter
- close the console
- wait 1 to 2 minutes then make a new save file and then load from that save file
- check the merchant and see if the dialogue option is back
- The AI counter markers in various shops either lack ownership or have incorrect ownership assigned, causing NPCs other than the vendors to use them. - ![PC Only](https://images.uesp.net/d/d7/Computer.svg)
The [Unofficial Skyrim Legendary Edition Patch](https://en.uesp.net/wiki/Skyrim:Mod_Unofficial_Skyrim_Legendary_Edition_Patch), version 3.0.1, fixes this bug.
- The spouse merchant chests are missing an investor perk formlist, so that they never gain a permanent 500 gold increase after investing. This also means that if you marry an NPC who was already a merchant, the 500 gold bonus is being applied to a merchant chest they no longer have access to, rather than the spouse merchant chest they're currently using. - ![PC Only](https://images.uesp.net/d/d7/Computer.svg)
The [Unofficial Skyrim Legendary Edition Patch](https://en.uesp.net/wiki/Skyrim:Mod_Unofficial_Skyrim_Legendary_Edition_Patch), version 3.0.1, addresses this issue. The invest prompt with Taarie, Balimund, Muiri, Ghorza, Revyn Sadri, Filnjar, Quintus Navale, Dravynea, and Moth gro-Bagol will be removed once you marry one of them. The way the vendor stack works makes it impractical to continue to allow the option since it won't get directed to the proper place anyway.
- Investor perk dialogue does not use the correct condition checks to determine the amount of gold you need to be able to invest. - The [Unofficial Skyrim Special Edition Patch](https://en.uesp.net/wiki/Skyrim:Mod_Unofficial_Skyrim_Special_Edition_Patch), version 4.2.4, fixes this bug.
- The loot list for expert level spell tomes in dungeons incorrectly uses a global variable setting that's intended to be used on vendor inventories. - The [Unofficial Skyrim Special Edition Patch](https://en.uesp.net/wiki/Skyrim:Mod_Unofficial_Skyrim_Special_Edition_Patch), version 4.2.5, fixes this bug.
- Your spouse will be unable to talk to you about opening a store if the house you chose to move into after getting married was one of the Creation Club houses. Options did not exist for this to happen. - The [Unofficial Skyrim Special Edition Patch](https://en.uesp.net/wiki/Skyrim:Mod_Unofficial_Skyrim_Special_Edition_Patch), version 4.3.5, fixes this bug.