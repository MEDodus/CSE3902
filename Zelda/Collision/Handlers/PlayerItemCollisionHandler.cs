using Zelda.Link;
using Zelda.Rooms;
using Zelda.Items;
using Zelda.Items.Classes;

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
                if(item is Fairy)
                {
                    link.Health.addHealth(6);
                } else if(item is Heart)
                {
                    link.Health.addHealth(2);
                } else if(item is HeartContainer)
                {
                    link.Health.addMaxHealth(2);
                    link.Health.healthToFull();
                }
                RoomBuilder.Instance.CurrentRoom.RemoveItem(item);
            }
        }
    }
}
