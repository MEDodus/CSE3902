using Zelda.Link;
using Zelda.Rooms;
using Zelda.Items;

namespace Zelda.Collision.Handlers
{
    internal class PlayerItemCollisionHandler : ICollision
    {
        public PlayerItemCollisionHandler()
        {
            
        }

        public void HandleCollision()
        {
            
        }

        public void HandleCollision(ILink link, IItem item)
        {
            if (link.Equip(item))
            {
                // Equip was successful, remove item from room
                RoomBuilder.Instance.CurrentRoom.RemoveItem(item);
            }
        }
    }
}
