using Zelda.Link;
using Zelda.Rooms;
using Zelda.Items;
using Zelda.Items.Classes;
using Zelda.GameStates.Classes;
using Zelda.Sound;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

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

        public void HandleCollision(ILink link, Item item, Game1 game)
        {
            link.AddToInventory(item);
            if (item is Triforce)
            {
                game.GameState = new WinningGameState(game);
            } 
            else if (item.MaxItemCount == 0)
            {
                item.UseItem(link, new Vector2(), new Vector2());
            }
            RoomBuilder.Instance.CurrentRoom.RemoveItem(item);
        }
    }
}
