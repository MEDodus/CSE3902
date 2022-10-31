using System.Collections.Generic;
using Zelda.Items;

namespace Zelda.Link
{
    public class Inventory
    {
        /*
         * TODO:
         * this class is very basic at the moment, it still needs features such as max slots, item counts (perhaps change list to a map to do this)
         * consult gameplay footage for details
         */

        private List<IItem> items;

        public List<IItem> Items { get { return items; } }

        public Inventory()
        {
            items = new List<IItem>();
        }

        // Returns whether the item could be successfully added to the inventory
        public bool Add(IItem item)
        {
            items.Add(item);
            return true; // TODO: return false if full inventory
        }

        public void Remove(IItem item)
        {
            items.Remove(item);
        }
    }
}
