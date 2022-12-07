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
            inventory.AddItem(new Bomb()); // Max Count is 8
            inventory.AddItem(new Sword()); // For Sword and SwordBeam
            inventory.AddItem(new Arrow()); // Need Bow and 1 Rupee cost
            inventory.AddItem(new BlueCandle()); // For CandleFlame (Blue can be used once per screen) red infinite
            inventory.AddItem(new Wallet());
            inventory.AddItem(new BluePotion());
            inventory.AddItem(new Bow());
        }
    }
}
