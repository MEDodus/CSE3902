using Microsoft.Xna.Framework;
using Zelda.Sprites.Factories;

namespace Zelda.Items.Classes
{
    public class BlueCandle : IItem
    {
        // Working in inventory for CandleFlame projectile at the moment
        public BlueCandle(Vector2 position) : base(ItemSpriteFactory.BlueCandleSprite(), position, INFINITE, new Zelda.ItemEffects.BlueCandleEffect(), 1)
        {

        }

        /* Default constructor for item in inventory or not displayed in game */
        public BlueCandle() : base(ItemSpriteFactory.BlueCandleSprite(), new Vector2(), INFINITE, new Zelda.ItemEffects.BlueCandleEffect(), 1)
        {

        }
    }
}
