using Microsoft.Xna.Framework;
using Zelda.Sprites.Factories;

namespace Zelda.Items.Classes
{
    public class BookOfMagic : Item
    {
        public BookOfMagic(Vector2 position) : base(ItemSpriteFactory.BookOfMagicSprite(), position, ONE, null)
        {

        }
    }
}
