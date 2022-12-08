using Microsoft.Xna.Framework;
using Zelda.Sound;
using Zelda.Sprites.Factories;

namespace Zelda.Projectiles.Classes
{
    public class DeathExplosion : Projectile
    {
        public DeathExplosion(Vector2 position) : base(ProjectileSpriteFactory.DeathExplosionSprite(), position, new Vector2(), 0, 0.5, ProjectileBehavior.NeutralHarmless, false)
        {
            SoundManager.Instance.PlayEnemyDieSound();
        }
    }
}
