using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zelda.Items;
using Zelda.Items.Classes;
using Zelda.Link;

namespace Zelda.Inventory
{
    public class LinkInventory : IInventory
    {
        private Dictionary<Type, IItem> inventory;
        public LinkInventory()
        {
            inventory = new Dictionary<Type, IItem>();
        }
        public bool AddItem(IItem item)
        {
            if (!Contains(item))
            {
                inventory.Add(item.GetType(), item);
                item.AddToQuantity(item.BundleSize);
                return true;
            } else
            {
                IItem itemToChange = inventory[item.GetType()];
                itemToChange.AddToQuantity(item.BundleSize);
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
            if (!Contains(item)) return false;

            // Try to use item... check requirements etc...
            IItem itemToChange = inventory[item.GetType()];
            return itemToChange.UseItem(this, null, new Vector2(), new Vector2());
            // only returning true now, conditions could chagne,
            // for example, an item that can't be picked up until
            // something happens in the story...
        }

        /* Sets index in list of found item and returns true if found
         */
        public bool Contains(IItem item)
        {
            if (item is Wallet && inventory.ContainsKey(item.GetType()))
            {
                return true;
            }
            else if (inventory.ContainsKey(item.GetType()) && inventory[item.GetType()].QuantityHeld <= 0)
            {
                inventory.Remove(item.GetType());
            }
            return inventory.ContainsKey(item.GetType()) && inventory[item.GetType()].QuantityHeld > 0;
        }

        public int GetCount(IItem item)
        {
            if (!Contains(item)) return 0;
            return inventory[item.GetType()].QuantityHeld;
        }

        public IItem GetItem(IItem item)
        {
            if (Contains(item)) return inventory[item.GetType()];
            return null;
        }
    }
}
