using Microsoft.Xna.Framework;
using Zelda.Sprites.Factories;

namespace Zelda.Items.Classes
{
    public class MagicalBoomerang : IItem
    {
        // Working in inventory system as MagicalBoomerang projectile at the moment
        public MagicalBoomerang(Vector2 position) : base(ItemSpriteFactory.MagicalBoomerangSprite(), position, INFINITE, null, 1)
        {

        }

        /* Default constructor for item in inventory or not displayed in game */
        public MagicalBoomerang() : base(ItemSpriteFactory.MagicalBoomerangSprite(), new Vector2(), INFINITE, null, 1)
        {

        }
    }
}
