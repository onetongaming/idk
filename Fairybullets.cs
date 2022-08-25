using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Alexandria.ItemAPI;
using UnityEngine;

namespace Dulsamthings
{
    internal class FairyBullets : PassiveItem
    {

        public static void Init()
        {
            string ItemName = "Fairy Bullets";

            string SpriteDirectory = "Dulsamthings/Resources/Fairy_bullets";

            GameObject obj = new GameObject(ItemName);

            var item = obj.AddComponent<Dulsamthings>();

            ItemBuilder.AddSpriteToObject(ItemName, SpriteDirectory, obj);

            string shortDesc = "";

            string longDesc = "You called for help.... \n\n" +
            "But nobody came\n\n" +
            "So you decided to stick to your guns ";


            ItemBuilder.SetupItem(item, shortDesc, longDesc, "dls");

            ItemBuilder.AddPassiveStatModifier(item, PlayerStats.StatType.Health, 1, StatModifier.ModifyMethod.ADDITIVE);

            ItemBuilder.AddPassiveStatModifier(item, PlayerStats.StatType.Damage, 1.5f, StatModifier.ModifyMethod.ADDITIVE);

            item.quality = PickupObject.ItemQuality.A;
        }
       

        public override DebrisObject Drop(PlayerController player)
        {
            return base.Drop(player);
        }

    }
}