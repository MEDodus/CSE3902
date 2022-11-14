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
            inventory.AddItem(new Bomb(new Vector2(0, 0)), 1); // Max Count is 8
            inventory.AddItem(new Sword(new Vector2(0, 0)), 999); // For Sword and SwordBeam
            inventory.AddItem(new Arrow(new Vector2(0, 0)), 1); // Need Bow and 1 Rupee cost
            inventory.AddItem(new Boomerang(new Vector2(0, 0)), 1); // Infinite
            inventory.AddItem(new BlueCandle(new Vector2(0, 0)), 1); // For CandleFlame (Blue can be used once per screen) red infinite
            inventory.AddItem(new MagicalBoomerang(new Vector2(0, 0)), 1); // Infinite
            inventory.AddItem(new SilverArrow(new Vector2(0, 0)), 1); // Need Bow and 1 Rupee cost
        }
    }
}
