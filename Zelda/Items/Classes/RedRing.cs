using Microsoft.Xna.Framework;
using Zelda.Sprites.Factories;

namespace Zelda.Items.Classes
{
    public class RedRing : IItem
    {
        public RedRing(Vector2 position) : base(ItemSpriteFactory.RedRingSprite(), position, ONE, null, 1)
        {

        }

        /* Default constructor for item in inventory or not displayed in game */
        public RedRing() : base(ItemSpriteFactory.RedRingSprite(), new Vector2(), ONE, null, 1)
        {

        }
    }
}
