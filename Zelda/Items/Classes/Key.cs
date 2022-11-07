using Microsoft.Xna.Framework;
using Zelda.Sprites.Factories;

namespace Zelda.Items.Classes
{
    public class Key : IItem
    {
        public Key(Vector2 position) : base(ItemSpriteFactory.KeySprite(), position, INFINITE)
        {

        }
    }
}
