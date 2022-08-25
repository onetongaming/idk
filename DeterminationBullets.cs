using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Alexandria.ItemAPI;
using UnityEngine;

namespace YourNameSpace
{
    class Dulsamthings : PassiveItem
    {
        public void OnPlayerTookDamage(PlayerController player) {
            this.AddPassiveStatModifier(PlayerStats.StatType.Damage, 0.07f, StatModifier.ModifyMethod.ADDITIVE);
            player.stats.RecalculateStats(player, false, false);


        }

        public static void Init()
        {
            string ItemName = "Determination Bullets";

            string SpriteDirectory = "Dulsamthings/Resources/Determinationbullets.png";

            GameObject obj = new GameObject(ItemName);

            var item = obj.AddComponent<Dulsamthings>();

            ItemBuilder.AddSpriteToObject(ItemName, SpriteDirectory, obj);

            string shortDesc = "It fills you.";

            string longDesc = "You called for help.... \n\n" +
            "But nobody came\n\n" +
            "So you decided to stick to your guns ";


            ItemBuilder.SetupItem(item, shortDesc, longDesc, "dls");

            ItemBuilder.AddPassiveStatModifier(item, PlayerStats.StatType.Health, 1, StatModifier.ModifyMethod.ADDITIVE);

            ItemBuilder.AddPassiveStatModifier(item, PlayerStats.StatType.Damage, .5f, StatModifier.ModifyMethod.ADDITIVE);

            item.quality = PickupObject.ItemQuality.S;
        }
        public override void DisableEffect(PlayerController disablingPlayer)
        {
            disablingPlayer.OnReceivedDamage -= OnPlayerTookDamage;
            base.DisableEffect(disablingPlayer);
        }

        public override DebrisObject Drop(PlayerController player)
        {
            return base.Drop(player);
        }

    }
}