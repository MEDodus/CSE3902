using Microsoft.Xna.Framework;
using Zelda.Sprites.Factories;

namespace Zelda.Items.Classes
{
    public class RedRing : Item
    {
        public RedRing(Vector2 position) : base(ItemSpriteFactory.RedRingSprite(), position, ONE, null)
        {

        }
    }
}
