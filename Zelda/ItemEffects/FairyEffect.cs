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
    public class FairyEffect : IEffect
    {
        // Can only use effect class if it is in your inventory
        public bool RequirementsMet(IInventory inventory)
        {
            return true;
        }
        public bool UseEffect(Item item, ILink link, Vector2 spawnPos, Vector2 facingDirection)
        {
            if (RequirementsMet(link.Inventory))
            {
                link.Health.addHealth(6);
                return true;
            }
            return false;
        }
    }
}
