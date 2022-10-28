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

        public void HandleCollision(ILink link, IItem item, RoomBuilder roomBuilder)
        {
            if (link.Equip(item))
            {
                // Equip was successful, remove item from room
                roomBuilder.CurrentRoom.RemoveItem(item);
            }
        }
    }
}
