using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zelda.Inventory;
using Zelda.Items;
using Zelda.Link;
using Zelda.Items.Classes;

namespace Zelda.ItemEffects
{
    public class StarEffect : IEffect
    {
        public bool RequirementsMet(IInventory inventory)
        {
            return true;
        }

        public bool UseEffect(Item item, ILink link, Vector2 spawnPos, Vector2 facingDirection)
        {
            // update link to move quicker
            if (RequirementsMet(link.Inventory))
            {
                if (link is Link1)
                {
                    ((Link1)link).ItemTimer.Duration = 420;
                    ((Link1)link).ItemTimer.Item = new Star(new Vector2());
                }
                return true;
            }
            return false;
        }
    }
}
