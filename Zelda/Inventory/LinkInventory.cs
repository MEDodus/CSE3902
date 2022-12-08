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
        public Item Secondary { get { return secondary; } }
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

        private Dictionary<Type, Item> inventory;
        private Item secondary;
        private int secondaryIndex = 0;

        private readonly int NUM_SECONDARY_SLOTS = 8;

        public LinkInventory()
        {
            inventory = new Dictionary<Type, Item>();
            secondary = null;
        }

        public bool AddItem(Item item, int quantity)
        {
            if ((item is Banana || item is RedShell || item is GreenShell) && ContainsMarioKartProjectile())
            {
                RemoveMarioKartProjectile();
            }

            if (!Contains(item))
            {
                inventory.Add(item.GetType(), item);
                item.AddToQuantity(quantity);
            } else
            {
                Item itemToChange = inventory[item.GetType()];
                itemToChange.AddToQuantity(quantity);
            }
            UpdateSecondary();
            return true;
        }

        // Sets index in list of found item and returns true if found
        public bool Contains(Item item)
        {
            if (inventory.ContainsKey(item.GetType()) && inventory[item.GetType()].QuantityHeld <= 0)
            {
                inventory.Remove(item.GetType());
            }
            return inventory.ContainsKey(item.GetType()) && inventory[item.GetType()].QuantityHeld > 0;
        }

        public int GetCount(Item item)
        {
            if (!Contains(item))
            {
                return 0;
            }
            return inventory[item.GetType()].QuantityHeld;
        }

        public Item GetItem(Item item)
        {
            if (Contains(item))
            {
                return inventory[item.GetType()];
            }
            return null;
        }

        public void UpdateSecondary()
        {
            Item type;
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

        public bool ContainsMarioKartProjectile()
        {
            return Contains(new GreenShell()) || Contains(new RedShell()) || Contains(new Banana());
        }

        public void RemoveMarioKartProjectile()
        {
            if (Contains(new GreenShell()))
            {
                inventory.Remove(new GreenShell().GetType());
            }
            if (Contains(new RedShell()))
            {
                inventory.Remove(new RedShell().GetType());
            }
            if (Contains(new Banana()))
            {
                inventory.Remove(new Banana().GetType());
            }
        }
    }
}
