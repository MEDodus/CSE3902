using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zelda.Items.Classes;
using Microsoft.Xna.Framework;

namespace Zelda.Inventory
{
    public static class InventoryBuilder
    {

        public static void BuildInventory(IInventory inventory)
        {
            Vector2 baseVector = new Vector2();
            inventory.AddItem(new Sword(baseVector), 1); // For Sword and SwordBeam
            inventory.AddItem(new Wallet(), 1);
        }
    }
}
