using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zelda.Items;

namespace Zelda.Inventory
{
    public class LinkInventory : IInventory
    {

        private IItem itemToChange;
        private List<IItem> inventory;

        public LinkInventory()
        {
            inventory = new List<IItem>();
        }
        public bool AddItem(IItem item, int quantity)
        {
            if (itemToChange == null) 
            {
                inventory.Add(item);
                item.AddToQuantity(quantity);
                return true;
            } else
            {
                itemToChange.AddToQuantity(quantity);
                return true;
            }
            // only returning true now, conditions could chagne,
            // for example, an item that can't be picked up until
            // something happens in the story...
        }

        /* Contains must be called before call to RemoveItem
         */
        public bool RemoveItem(IItem item, int quantity)
        {
            if (itemToChange == null) return true;

            if (!itemToChange.RemoveFromQuantity(quantity))
            {
                inventory.Remove(itemToChange);
            }
            return true;
            // only returning true now, conditions could chagne,
            // for example, an item that can't be picked up until
            // something happens in the story...
        }

        /* Sets index in list of found item and returns true if found
         */
        public bool FindInSet(IItem item)
        {
            foreach (IItem currentItem in inventory)
            {
                if (currentItem.GetType() == item.GetType())
                {
                    itemToChange = currentItem;
                    return true;
                }
            }
            itemToChange = null;
            return false;
        }
    }
}
