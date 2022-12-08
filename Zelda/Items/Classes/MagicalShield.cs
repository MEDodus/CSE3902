using Microsoft.Xna.Framework;
using Zelda.Sprites.Factories;

namespace Zelda.Items.Classes
{
    public class MagicalShield : IItem
    {
        public MagicalShield(Vector2 position) : base(ItemSpriteFactory.MagicalShieldSprite(), position, ONE, null)
        {

        }

        /* Default constructor for item in inventory or not displayed in game */
        public MagicalShield() : base(ItemSpriteFactory.MagicalShieldSprite(), new Vector2(), ONE, null)
        {

        }
    }
}
