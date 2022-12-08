using System.Collections.Generic;
using Zelda.Items;

namespace Zelda.Link
{
    public class OldInventory
    {
        /*
         * TODO:
         * this class is very basic at the moment, it still needs features such as max slots, item counts (perhaps change list to a map to do this)
         * consult gameplay footage for details
         */

        private List<Item> items;

        public List<Item> Items { get { return items; } }

        public OldInventory()
        {
            items = new List<Item>();
        }

        // Returns whether the item could be successfully added to the inventory
        public bool Add(Item item)
        {
            items.Add(item);
            return true; // TODO: return false if full inventory
        }

        public void Remove(Item item)
        {
            items.Remove(item);
        }
    }
}
