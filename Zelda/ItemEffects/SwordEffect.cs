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
using Zelda.Projectiles;
using Zelda.Projectiles.Classes;
using Sword = Zelda.Items.Classes.Sword;

namespace Zelda.ItemEffects
{
    public class SwordEffect : IEffect
    {
        public bool RequirementsMet(IInventory inventory)
        {
            return inventory.Contains(new Sword(new Vector2()));
        }

        public bool UseEffect(IItem item, IInventory inventory, Health health, Vector2 spawnPos, Vector2 facingDirection)
        {
            if (RequirementsMet(inventory))
            {
                if (health.CurrentHealth == health.MaxHealth) ProjectileStorage.Add(new SwordBeam(spawnPos, facingDirection));
                return true;
            }
            return false;
            // Nothing required to use item, could potentially refactor to make the sword beam logic work here
        }
    }
}
