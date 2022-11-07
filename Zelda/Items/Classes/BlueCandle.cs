using Microsoft.Xna.Framework;
using Zelda.Sprites.Factories;

namespace Zelda.Items.Classes
{
    public class BlueCandle : IItem
    {
        // Working in inventory for CandleFlame projectile at the moment
        public BlueCandle(Vector2 position) : base(ItemSpriteFactory.BlueCandleSprite(), position, INFINITE)
        {

        }
    }
}
