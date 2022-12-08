using Microsoft.Xna.Framework;
using Zelda.Projectiles;
using Zelda.Sprites.Factories;

namespace Zelda.Items.Classes
{
    public class Boomerang : Item
    {
        public Boomerang(Vector2 position) : base(ItemSpriteFactory.BoomerangSprite(), position, INFINITE, new Zelda.ItemEffects.BoomerangEffect())
        {

        }

        public override Projectile CreateProjectile(Vector2 position, Vector2 facingDirection)
        {
            return new Projectiles.Classes.Boomerang(position, facingDirection, ProjectileBehavior.Friendly);
        }
    }
}
