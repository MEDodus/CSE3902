﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zelda.Inventory;
using Zelda.Items;
using Zelda.Items.Classes;
using Microsoft.Xna.Framework;
using Zelda.Link;
using Zelda.Rooms;

namespace Zelda.ItemEffects
{
    public class KeyEffect : IEffect
    {
        // Can only use effect class if it is in your inventory
        public bool RequirementsMet(IInventory inventory)
        {
            Item item = new Key(new Vector2());
            return inventory.Contains(item) && inventory.GetItem(item).QuantityHeld > 0;
        }
        public bool UseEffect(Item item, ILink link, Vector2 spawnPos, Vector2 facingDirection)
        {
            if (RequirementsMet(link.Inventory))
            {
                item.AddToQuantity(-1);
                return true;
            }
            return false;
        }
    }
}
