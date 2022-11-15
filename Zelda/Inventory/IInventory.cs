using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zelda.Items;

namespace Zelda.Inventory
{
    public interface IInventory
    {
        // Have some quantity field in item class or additional class with quantity functionality
        public bool AddItem(IItem item, int quantity);
        // Remove some item by some quantity
        public bool RemoveItem(IItem item, int quantity);
        // Check if inventory contains an item
        public bool Contains(IItem item);
        /* Item class could also have field for max stackable item quantity */
        public int GetCount(IItem item);
        // Retrieve item from inventory
        public IItem GetItem(IItem item);
    }
}
