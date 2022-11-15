using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zelda.Items.Classes;
using Microsoft.Xna.Framework;

namespace Zelda.Inventory
{
    public static class InventoryBuidler
    {

        public static void BuildInventory(IInventory inventory)
        {
            inventory.AddItem(new Bomb(new Vector2()), 8); // Max Count is 8
            inventory.AddItem(new Sword(new Vector2()), 1); // For Sword and SwordBeam
            inventory.AddItem(new Arrow(new Vector2()), 1); // Need Bow and 1 Rupee cost
            inventory.AddItem(new BlueCandle(new Vector2()), 1); // For CandleFlame (Blue can be used once per screen) red infinite
            inventory.AddItem(new Wallet(new Vector2()), 0);
            //inventory.AddItem(new MagicalBoomerang(new Vector2()), 1); // Infinite
            //inventory.AddItem(new SilverArrow(new Vector2()), 1); // Need Bow and 1 Rupee cost
            // TODO: Added arrow and bow functionality so it works with FiveRupies as well
            //inventory.AddItem(new FiveRupies(new Vector2()), 3);
            inventory.AddItem(new BluePotion(new Vector2()), 1);
            inventory.AddItem(new Bow(new Vector2()), 1);
        }
    }
}
