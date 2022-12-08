using Microsoft.Xna.Framework;
using Zelda.Projectiles;
using Zelda.Sprites.Factories;

namespace Zelda.Items.Classes
{
    public class Arrow : Item
    {
        public Arrow(Vector2 position) : base(ItemSpriteFactory.ArrowSprite(), position, INFINITE, null)
        {

        }

        public override Projectile CreateProjectile(Vector2 position, Vector2 facingDirection)
        {
            return new Projectiles.Classes.Arrow(position, facingDirection);
        }
    }
}
