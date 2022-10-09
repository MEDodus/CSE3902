using Microsoft.Xna.Framework;
using Zelda.Sprites.Factories;

namespace Zelda.Items.Classes
{
    public class BlueCandle : IItem
    {
        public BlueCandle(Vector2 position) : base(ItemSpriteFactory.BlueCandleSprite(), position)
        {

        }
    }
}
