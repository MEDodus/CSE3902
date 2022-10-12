using Microsoft.Xna.Framework;
using Zelda.Sprites.Factories;

namespace Zelda.Items.Classes
{
    public class Bomb : IItem
    {
        public Bomb(Vector2 position) : base(ItemSpriteFactory.BombSprite(), position)
        {

        }
    }
}
