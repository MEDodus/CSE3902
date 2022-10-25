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
            // TODO: add item to inventory once inventory system is made
            roomBuilder.CurrentRoom.RemoveItem(item);
        }
    }
}
