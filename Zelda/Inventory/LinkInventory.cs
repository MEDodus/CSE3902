using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Zelda.Items;
using Zelda.Items.Classes;
using Zelda.Utilities;

namespace Zelda.Inventory
{
    public class LinkInventory : IInventory
    {
        public IItem Secondary { get { return secondary; } }
        public int SecondaryIndex { 
            get { return secondaryIndex; }
            set
            {
                if (value >= 0 && value < NUM_SECONDARY_SLOTS)
                {
                    secondaryIndex = value;
                    UpdateSecondary();
                }
            }
        }

        private Dictionary<Type, IItem> inventory;
        private IItem secondary;
        private int secondaryIndex = 0;

        private readonly int NUM_SECONDARY_SLOTS = 8;

        public LinkInventory()
        {
            inventory = new Dictionary<Type, IItem>();
            secondary = null;
        }

        public bool AddItem(IItem item, int quantity)
        {
            if (!Contains(item))
            {
                inventory.Add(item.GetType(), item);
                item.AddToQuantity(quantity);
                UpdateSecondary();
                return true;
            } 
            else
            {
                if(item is Bomb && GetCount(item) + quantity > LinkUtilities.BOMB_MAX_COUNT)
                {
                    quantity = GetCount(item) + quantity - LinkUtilities.BOMB_MAX_COUNT;
                    if(quantity == LinkUtilities.BOMB_ITEM_PICKUP_AMOUNT)
                    {
                        return false;
                    }
                }
                IItem itemToChange = inventory[item.GetType()];
                itemToChange.AddToQuantity(quantity);
                UpdateSecondary();
                return true;
            }
            // only returning true now, conditions could chagne,
            // for example, an item that can't be picked up until
            // something happens in the story...
        }

        // Contains must be called before call to RemoveItem
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

        // Sets index in list of found item and returns true if found
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
            if (!Contains(item))
            {
                return 0;
            }
            return inventory[item.GetType()].QuantityHeld;
        }

        public IItem GetItem(IItem item)
        {
            if (Contains(item))
            {
                return inventory[item.GetType()];
            }
            return null;
        }

        public void UpdateSecondary()
        {
            IItem type;
            Vector2 defaultPos = new Vector2();
            switch (secondaryIndex)
            {
                case 0:
                    type = new Boomerang(defaultPos);
                    break;
                case 1:
                    type = new Bomb(defaultPos);
                    break;
                case 2:
                    type = new Bow(defaultPos);
                    break;
                case 3:
                    type = new BlueCandle(defaultPos);
                    break;
                case 4:
                    type = new Recorder(defaultPos);
                    break;
                case 5:
                    type = new Food(defaultPos);
                    break;
                case 6:
                    type = new BluePotion(defaultPos);
                    break;
                default:
                    type = new MagicalRod(defaultPos);
                    break;
            }
            if (Contains(type))
            {
                secondary = GetItem(type);
            }
            else
            {
                secondary = null;
            }
        }
    }
}
