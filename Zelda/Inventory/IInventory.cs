using Zelda.Items;

namespace Zelda.Inventory
{
    public interface IInventory
    {
        public Item Secondary { get; }
        public int SecondaryIndex { get; set; }

        public bool AddItem(Item item, int quantity);
        public bool RemoveItem(Item item, int quantity);
        public bool Contains(Item item);
        public int GetCount(Item item);
        public Item GetItem(Item item);
        public void UpdateSecondary();
    }
}
