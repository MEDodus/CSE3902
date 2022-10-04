using Microsoft.Xna.Framework;
using Zelda.Sprites.Factories;

namespace Zelda.Projectiles.Classes
{
    public class Explosion : IProjectile
    {
        public Explosion(Vector2 position) : base(ProjectileSpriteFactory.ExplosionSprite(), position, new Vector2(), 0, 0.5)
        {

        }
    }
}
