using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Zelda.Inventory;
using Zelda.Items;
using Zelda.Items.Classes;
using Zelda.Link;
using Zelda.Sound;

namespace Zelda.ItemEffects
{
    public class FiveRupiesEffect : IEffect
    {
        private int fiveRupyValue = 5;
        public bool RequirementsMet(IInventory inventory)
        {
            return true;
        }

        public bool UseEffect(Item item, ILink link, Vector2 spawnPos, Vector2 facingDirection)
        {
            if (RequirementsMet(link.Inventory))
            {
                SoundManager.Instance.PlayGetItemSound();
                Item wallet = link.Inventory.GetItem(new Wallet());
                wallet.AddToQuantity(fiveRupyValue);
                return true;
            }
            return false;
        }
    }
}
