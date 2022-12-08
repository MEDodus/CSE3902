using Microsoft.Xna.Framework;
using Zelda.Sound;
using Zelda.Sprites.Factories;

namespace Zelda.Projectiles.Classes
{
    public class Fireball : IProjectile
    {
        public Fireball(Vector2 position, Vector2 direction, ProjectileBehavior behavior) :
            base(ProjectileSpriteFactory.FireballSprite(), position, direction, 8, 3, behavior)
        {
            SoundManager.Instance.PlayBossHitSound();
        }

        public Fireball(Vector2 position, Vector2 direction) : this(position, direction, ProjectileBehavior.Enemy)
        { }

        public override void OnDelete()
        {
            ProjectileStorage.Add(new Explosion(position));
        }
    }
}
