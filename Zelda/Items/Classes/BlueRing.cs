using Microsoft.Xna.Framework;
using Zelda.Sprites.Factories;

namespace Zelda.Items.Classes
{
    public class BlueRing : IItem
    {
        public BlueRing(Vector2 position) : base(ItemSpriteFactory.BlueRingSprite(), position, ONE, null)
        {

        }
    }
}
