using Microsoft.Xna.Framework;
using Zelda.Sprites.Factories;

namespace Zelda.Items.Classes
{
    public class Arrow : IItem
    {
        public Arrow(Vector2 position) : base(ItemSpriteFactory.ArrowSprite(), position, INFINITE, null, 1)
        {

        }

        /* Default constructor for item in inventory or not displayed in game */
        public Arrow() : base(ItemSpriteFactory.ArrowSprite(), new Vector2(), INFINITE, null, 1)
        {

        }
    }
}
