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
            Vector2 baseVector = new Vector2();
            inventory.AddItem(new Bomb(), 4); // Max Count is 8
            inventory.AddItem(new Sword(baseVector), 1); // For Sword and SwordBeam
            inventory.AddItem(new Arrow(), 1); // Need Bow and 1 Rupee cost
            inventory.AddItem(new BlueCandle(baseVector), 1); // For CandleFlame (Blue can be used once per screen) red infinite
            inventory.AddItem(new Wallet(), 1);
            inventory.AddItem(new BluePotion(baseVector), 1);
            inventory.AddItem(new Bow(), 1);
        }
    }
}
