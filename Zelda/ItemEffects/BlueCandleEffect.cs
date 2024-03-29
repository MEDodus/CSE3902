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
using IItem = Zelda.Items.Item;

namespace Zelda.ItemEffects
{
    public class BlueCandleEffect : IEffect
    {
        // Can only use effect class if it is in your inventory
        public bool RequirementsMet(IInventory inventory)
        {
            Item item = new BlueCandle(new Vector2());
            return inventory.Contains(item);
        }
        public bool UseEffect(IItem item, ILink link, Vector2 spawnPos, Vector2 facingDirection)
        {
            if (RequirementsMet(link.Inventory)) return true;
            return false;
        }
    }
}
