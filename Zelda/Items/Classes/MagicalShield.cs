using Microsoft.Xna.Framework;
using Zelda.Sprites.Factories;

namespace Zelda.Items.Classes
{
    public class MagicalShield : Item
    {
        public MagicalShield(Vector2 position) : base(ItemSpriteFactory.MagicalShieldSprite(), position, ONE, null)
        {

        }
    }
}
