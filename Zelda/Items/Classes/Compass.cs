using Microsoft.Xna.Framework;
using Zelda.Sprites.Factories;

namespace Zelda.Items.Classes
{
    public class Compass : Item
    {
        public Compass(Vector2 position) : base(ItemSpriteFactory.CompassSprite(), position, ONE, null)
        {

        }
    }
}
