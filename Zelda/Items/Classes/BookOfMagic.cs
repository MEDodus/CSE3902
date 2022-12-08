using Microsoft.Xna.Framework;
using Zelda.Sprites.Factories;

namespace Zelda.Items.Classes
{
    public class BookOfMagic : IItem
    {
        public BookOfMagic(Vector2 position) : base(ItemSpriteFactory.BookOfMagicSprite(), position, ONE, null)
        {

        }

        /* Default constructor for item in inventory or not displayed in game */
        public BookOfMagic() : base(ItemSpriteFactory.BookOfMagicSprite(), new Vector2(), ONE, null)
        {

        }
    }
}
