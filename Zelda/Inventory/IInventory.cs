﻿using System;
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
        public void AddItem(IItem item, int quantity);
        // Remove some item by some quantity
        public void RemoveItem(IItem item, int quantity);

        /* Could have a wrapper class for example "Record.cs" which contains fields
         * IItem item
         * int quantity
         * if refactory IItem is too difficult
         *
         * then AddItem -> AddItem(IRecord record, int quantity)
         *      RemoveItem(IRecord record, int quantity)
         */
    }
}