using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zelda.Inventory;
using Zelda.Items;
using Zelda.Link;

namespace Zelda.ItemEffects
{
    public class MushroomEffect : IEffect
    {
        public bool RequirementsMet(IInventory inventory)
        {
            return true;
        }

        public bool UseEffect(Item item, IInventory inventory, ILink link, Vector2 spawnPos, Vector2 facingDirection)
        {
            // update link to move quicker
            if (link is Link1)
            {
                ((Link1)link).ItemTimer = 300;
            }
            return true;
        }
    }
}
