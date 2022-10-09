using Microsoft.Xna.Framework;
using Zelda.Sprites.Factories;

namespace Zelda.Projectiles.Classes
{
    public class CandleFlame : IProjectile
    {
        public CandleFlame(Vector2 position, Vector2 direction) : base(ProjectileSpriteFactory.CandleFlameSprite(), position, direction, 10, 0.8)
        {

        }
    }
}
