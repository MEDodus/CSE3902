using Zelda.Link;
using Zelda.Rooms;
using Zelda.Items;
using Zelda.Items.Classes;
using Zelda.GameStates.Classes;
using Zelda.Sound;

namespace Zelda.Collision.Handlers
{
    public class PlayerItemCollisionHandler : ICollision
    {
        public PlayerItemCollisionHandler()
        {
            
        }

        public void HandleCollision()
        {
            
        }

        public void HandleCollision(ILink link, IItem item, Game1 game)
        {
            if (link.AddToInventory(item))
            {
                // AddToInventory was successful, remove item from room
                if (item is Fairy)
                {
                    link.Health.addHealth(6);
                } 
                else if (item is Heart)
                {
                    SoundManager.Instance.PlayGetHealthSound();
                    link.Health.addHealth(2);
                } 
                else if (item is HeartContainer)
                {
                    SoundManager.Instance.PlayGetHealthSound();
                    link.Health.addMaxHealth(2);
                    link.Health.healthToFull();
                }
                else if (item is Triforce)
                {
                    game.GameState = new WinningGameState(game);
                }
                else
                {
                    SoundManager.Instance.PlayGetItemSound();
                }
                RoomBuilder.Instance.CurrentRoom.RemoveItem(item);
            }
        }
    }
}
