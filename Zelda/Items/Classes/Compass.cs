using Microsoft.Xna.Framework;
using Zelda.Sprites.Factories;

namespace Zelda.Items.Classes
{
    public class Compass : IItem
    {
        public Compass(Vector2 position) : base(ItemSpriteFactory.CompassSprite(), position, ONE, null)
        {

        }
    }
}
