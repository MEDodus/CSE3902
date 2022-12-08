using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zelda.Inventory;
using Zelda.Items;
using Zelda.Items.Classes;
using Microsoft.Xna.Framework;
using Zelda.Link;

namespace Zelda.ItemEffects
{
    public class BowEffect : IEffect
    {
        public bool RequirementsMet(IInventory inventory)
        {
            return inventory.Contains(new Arrow(new Vector2())) && inventory.Contains(new Bow(new Vector2())) && inventory.Contains(new Rupy(new Vector2()));
        }

        public bool UseEffect(Item item, IInventory inventory, Health health, Vector2 spawnPos, Vector2 facingDirection)
        {
            if (RequirementsMet(inventory))
            {
                Item rupy = inventory.GetItem(new Rupy(new Vector2()));
                rupy.AddToQuantity(-1);
                return true;
            }
            return false;
        }
    }
}
