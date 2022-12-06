using Zelda.Items;

namespace Zelda.Inventory
{
    public interface IInventory
    {
        public IItem Secondary { get; }
        public int SecondaryIndex { get; set; }

        public bool AddItem(IItem item, int quantity);
        public bool RemoveItem(IItem item, int quantity);
        public bool Contains(IItem item);
        public int GetCount(IItem item);
        public IItem GetItem(IItem item);
    }
}
