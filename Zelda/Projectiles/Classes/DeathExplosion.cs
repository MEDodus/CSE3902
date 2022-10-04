using Microsoft.Xna.Framework;
using Zelda.Sprites.Factories;

namespace Zelda.Projectiles.Classes
{
    public class DeathExplosion : IProjectile
    {
        public DeathExplosion(Vector2 position) : base(ProjectileSpriteFactory.DeathExplosionSprite(), position, new Vector2(), 0, 0.5)
        {
            
        }
    }
}
