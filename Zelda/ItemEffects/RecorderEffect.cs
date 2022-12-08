using Zelda.Inventory;
using Zelda.Items;
using Zelda.Items.Classes;
using Microsoft.Xna.Framework;
using Zelda.Link;

namespace Zelda.ItemEffects
{
    public class RecorderEffect : IEffect
    {
        // Can only use effect class if it is in your inventory
        public bool RequirementsMet(IInventory inventory)
        {
            Item item = new Recorder(new Vector2());
            return inventory.Contains(item);
        }
        public bool UseEffect(Item item, IInventory inventory, ILink link, Vector2 spawnPos, Vector2 facingDirection)
        {
            if (RequirementsMet(inventory)) return true;
            return false;
        }
    }
}
