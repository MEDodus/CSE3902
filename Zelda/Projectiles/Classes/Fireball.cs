using Microsoft.Xna.Framework;
using Zelda.Sprites.Factories;

namespace Zelda.Projectiles.Classes
{
    public class Fireball : IProjectile
    {
        public Fireball(Vector2 position, Vector2 direction) : base(ProjectileSpriteFactory.FireballSprite(), position, direction, 8, 3, ProjectileBehavior.Enemy)
        {

        }

        public override void OnDelete()
        {
            ProjectileStorage.Add(new Explosion(position));
        }
    }
}
