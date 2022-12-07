using Microsoft.Xna.Framework;
using Zelda.Sprites.Factories;

namespace Zelda.Items.Classes
{
    public class Letter : IItem
    {
        public Letter(Vector2 position) : base(ItemSpriteFactory.LetterSprite(), position, ONE, null, 1)
        {

        }

        /* Default constructor for item in inventory or not displayed in game */
        public Letter() : base(ItemSpriteFactory.LetterSprite(), new Vector2(), ONE, null, 1)
        {

        }
    }
}
