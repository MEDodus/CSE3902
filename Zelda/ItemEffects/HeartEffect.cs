using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zelda.Inventory;
using Zelda.Items;
using Zelda.Link;
using Zelda.Sound;

namespace Zelda.ItemEffects
{
    public class HeartEffect : IEffect
    {
        public bool RequirementsMet(IInventory inventory)
        {
            return true;
        }

        public bool UseEffect(Item item, ILink link, Vector2 spawnPos, Vector2 facingDirection)
        {
            if (RequirementsMet(link.Inventory))
            {
                SoundManager.Instance.PlayGetHealthSound();
                link.Health.addHealth(2);
                return true;
            }
            return false;
        }
    }
}
