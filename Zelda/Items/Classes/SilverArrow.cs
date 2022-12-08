using Microsoft.Xna.Framework;
using Zelda.Projectiles;
using Zelda.Sprites.Factories;

namespace Zelda.Items.Classes
{
    public class SilverArrow : IItem
    {
        public SilverArrow(Vector2 position) : base(ItemSpriteFactory.SilverArrowSprite(), position, INFINITE, null)
        {

        }

        /* Default constructor for item in inventory or not displayed in game */
        public SilverArrow() : base(ItemSpriteFactory.SilverArrowSprite(), new Vector2(), INFINITE, null)
        {

        }

        public override IProjectile CreateProjectile(Vector2 position, Vector2 facingDirection)
        {
            return new Projectiles.Classes.SilverArrow(position, facingDirection);
        }
    }
}
