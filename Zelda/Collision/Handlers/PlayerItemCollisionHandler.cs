using Zelda.Link;
using Zelda.Rooms;
using Zelda.Items;
using Zelda.Items.Classes;
using Zelda.GameStates.Classes;
using Zelda.Sound;
using Microsoft.Xna.Framework;

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
            if (item is not Rupy && item is not FiveRupies && link.AddToInventory(item))
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
                    SoundManager.Instance.PlayGetItemSound();
                }
                else if (item is Key)
                {
                    SoundManager.Instance.PlayGetKeySound();
                }
                RoomBuilder.Instance.CurrentRoom.RemoveItem(item);
            } else if (item is Rupy || item is FiveRupies)
            {
                IItem wallet = link.Inventory.GetItem(new Wallet());
                int add = item is Rupy ? 1 : 5;
                wallet.AddToQuantity(add);
                RoomBuilder.Instance.CurrentRoom.RemoveItem(item);
            }
        }
    }
}
