using Microsoft.Xna.Framework;
using Zelda.Sprites.Factories;

namespace Zelda.Items.Classes
{
    public class Bomb : IItem
    {
        public Bomb(Vector2 position) : base(ItemSpriteFactory.BombSprite(), position, 8, new Zelda.ItemEffects.BombEffect(), 4)
        {

        }
        
        /* Default constructor for item in inventory or not displayed in game */
        public Bomb() : base(ItemSpriteFactory.BombSprite(), new Vector2(), 8, new Zelda.ItemEffects.BombEffect(), 4)
        {

        }
    }
}
