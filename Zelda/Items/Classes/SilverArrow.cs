using Microsoft.Xna.Framework;
using Zelda.Projectiles;
using Zelda.Sprites.Factories;

namespace Zelda.Items.Classes
{
    public class SilverArrow : Item
    {
        public SilverArrow(Vector2 position) : base(ItemSpriteFactory.SilverArrowSprite(), position, INFINITE, null)
        {

        }

        public override Projectile CreateProjectile(Vector2 position, Vector2 facingDirection)
        {
            return new Projectiles.Classes.SilverArrow(position, facingDirection);
        }
    }
}
