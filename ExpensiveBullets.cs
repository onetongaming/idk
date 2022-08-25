using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Alexandria.ItemAPI;
using UnityEngine;

namespace YourNameSpace
{
    class ExpensiveBullets : PassiveItem
    {
        public void OnPlayerMakesPurchase(PlayerController player,ShopItemController shopitem)

        {
            this.AddPassiveStatModifier(PlayerStats.StatType.Damage, 0.05f, StatModifier.ModifyMethod.ADDITIVE);
            player.stats.RecalculateStats(player, false, false);


        }

        public static void Init()
        {
            string ItemName = "Expensive Bullets";

            string SpriteDirectory = "Dulsamthings/Resources/Golden bullets";

            GameObject obj = new GameObject(ItemName);

            var item = obj.AddComponent<Dulsamthings>();

            ItemBuilder.AddSpriteToObject(ItemName, SpriteDirectory, obj);

            string shortDesc = "Costly";

            string longDesc = "These bullets were forged on the most capitalist of planets \n\n" +
            "They still yearn to witness the exchange of currency\n\n" +
            "Grows more powerful with each purchase made"
            ;


            ItemBuilder.SetupItem(item, shortDesc, longDesc, "dls");


            ItemBuilder.AddPassiveStatModifier(item, PlayerStats.StatType.Damage, .5f, StatModifier.ModifyMethod.ADDITIVE);

            item.quality = PickupObject.ItemQuality.C;
        }
        public override void Pickup(PlayerController player)
        {
            base.Pickup(player);
            player.OnItemPurchased += OnPlayerMakesPurchase;
        }

        public override void DisableEffect(PlayerController disablingPlayer)
        {
            disablingPlayer.OnItemPurchased -= OnPlayerMakesPurchase;
            base.DisableEffect(disablingPlayer);
        }

    }
}