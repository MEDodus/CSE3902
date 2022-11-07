using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Zelda.Items;

namespace Zelda.Inventory
{
    public class Record
    {
        public IItem Item { get; set; }
        private IItem item;
        private int quantity;

        public Record(IItem item)
        {
            this.item = item;
            this.quantity = 0;
        }

        public void AddToQuantity(int amount)
        {
            int newQuantity = quantity + amount;
            if (newQuantity > item.MaxItemCount)
            {
                quantity = item.MaxItemCount;
            } else
            {
                quantity = newQuantity;
            }
        }

        /* True if we successfully removed amount from item capacity,
         * false if we can't or results in zero or negative item capacity
         */
        public bool RemoveFromQuantity(int amount)
        {
            int newQuantity = quantity - amount;
            if (newQuantity <= 0)
            {
                return false;
            } else
            {
                quantity = newQuantity;
                return true;
            }
        }
    }
}
