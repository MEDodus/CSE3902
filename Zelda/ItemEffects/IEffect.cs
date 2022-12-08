using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zelda.Inventory;
using Zelda.Items;
using Zelda.Link;
using Microsoft.Xna.Framework;

namespace Zelda.ItemEffects
{
    public interface IEffect
    {
        public bool UseEffect(Item item, ILink link, Vector2 spawnPos, Vector2 facingDirection);
        public bool RequirementsMet(IInventory inventory);  
    }
}
