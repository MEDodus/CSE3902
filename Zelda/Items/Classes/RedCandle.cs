using Microsoft.Xna.Framework;
using Zelda.Sprites.Factories;

namespace Zelda.Items.Classes
{
    public class RedCandle : IItem
    {
        public RedCandle(Vector2 position) : base(ItemSpriteFactory.RedCandleSprite(), position, ONE, null, 1)
        {

        }

        /* Default constructor for item in inventory or not displayed in game */
        public RedCandle() : base(ItemSpriteFactory.RedCandleSprite(), new Vector2(), ONE, null, 1)
        {

        }
    }
}
