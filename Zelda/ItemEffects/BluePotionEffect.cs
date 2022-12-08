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
using Zelda.Sound;

namespace Zelda.ItemEffects
{
    public class BluePotionEffect : IEffect
    {
        // Can only use effect class if it is in your inventory
        public bool RequirementsMet(IInventory inventory)
        {
            Item item = new BluePotion(new Vector2());
            return inventory.Contains(item) && inventory.GetCount(item) > 0;
        }
        public bool UseEffect(Item item, IInventory inventory, Health health, Vector2 spawnPos, Vector2 facingDirection)
        {
            if (RequirementsMet(inventory))
            {
                item.AddToQuantity(-1);
                health.healthToFull();
                inventory.UpdateSecondary();
                SoundManager.Instance.PlayGetHealthSound();
                return true;
            }
            return false;
        }
    }
}
