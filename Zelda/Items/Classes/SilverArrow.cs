using Microsoft.Xna.Framework;
using Zelda.Sprites.Factories;

namespace Zelda.Items.Classes
{
    public class SilverArrow : IItem
    {
        public SilverArrow(Vector2 position) : base(ItemSpriteFactory.SilverArrowSprite(), position, INFINITE, null, 1)
        {

        }

        /* Default constructor for item in inventory or not displayed in game */
        public SilverArrow() : base(ItemSpriteFactory.SilverArrowSprite(), new Vector2(), INFINITE, null, 1)
        {

        }
    }
}
