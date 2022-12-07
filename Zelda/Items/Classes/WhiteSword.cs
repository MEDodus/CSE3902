using Microsoft.Xna.Framework;
using Zelda.Sprites.Factories;

namespace Zelda.Items.Classes
{
    public class WhiteSword : IItem
    {
        public WhiteSword(Vector2 position) : base(ItemSpriteFactory.WhiteSwordSprite(), position, ONE, null, 1)
        {

        }

        /* Default constructor for item in inventory or not displayed in game */
        public WhiteSword() : base(ItemSpriteFactory.WhiteSwordSprite(), new Vector2(), ONE, null, 1)
        {

        }
    }
}
