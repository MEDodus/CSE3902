using Microsoft.Xna.Framework;
using Zelda.Sound;
using Zelda.Sprites.Factories;

namespace Zelda.Projectiles.Classes
{
    public class CandleFlame : IProjectile
    {
        public CandleFlame(Vector2 position, Vector2 direction) : base(ProjectileSpriteFactory.CandleFlameSprite(), position, direction, 2, 0.6, ProjectileBehavior.Friendly)
        {
            SoundManager.Instance.PlayFireSound();
        }
    }
}
