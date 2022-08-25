using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Alexandria.ItemAPI;
using UnityEngine;

namespace YourNameSpace
{
    class CheesyBullets : PassiveItem
    {
        public Projectile CheeseReplace(Gun sourcegun, Projectile sourceprojectile)
        { if (UnityEngine.Random.value <= 0.1f)
            {  return (PickupObjectDatabase.GetById(626) as Gun).DefaultModule.projectiles[0];

            }
            return sourceprojectile;

        }




        public static void Init()
        {
            string ItemName = "Expensive Bullets";

            string SpriteDirectory = "Dulsamthings/Resources/Cheesy Rounds";

            GameObject obj = new GameObject(ItemName);

            var item = obj.AddComponent<Dulsamthings>();

            ItemBuilder.AddSpriteToObject(ItemName, SpriteDirectory, obj);

            string shortDesc = "Parmesan";

            string longDesc = "Bullets made of cheese\n\n" +
            
            "Donated to the gungeon by the Resourceful Rat. " +
            "These bullets mark a sort of apology for all the hardship he has caused for the gungeoneers."
            + "He will still steal them.\n\n" + "Not actually parmesan"
            ;


            ItemBuilder.SetupItem(item, shortDesc, longDesc, "dls");



            item.quality = PickupObject.ItemQuality.A;
        }
        public override void Pickup(PlayerController player)
        {
            base.Pickup(player);
            player.OnPreFireProjectileModifier += CheeseReplace;
        }


        public override void DisableEffect(PlayerController disablingPlayer)
        {
            disablingPlayer.OnPreFireProjectileModifier -= CheeseReplace;
            base.DisableEffect(disablingPlayer);
        }
    }
}