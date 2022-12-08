using Microsoft.Xna.Framework;
using Zelda.Sprites.Factories;

namespace Zelda.Items.Classes
{
    public class Compass : IItem
    {
        public Compass(Vector2 position) : base(ItemSpriteFactory.CompassSprite(), position, ONE, null)
        {

        }

        /* Default constructor for item in inventory or not displayed in game */
        public Compass() : base(ItemSpriteFactory.CompassSprite(), new Vector2(), ONE, null)
        {

        }
    }
}
