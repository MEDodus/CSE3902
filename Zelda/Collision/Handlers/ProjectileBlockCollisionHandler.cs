using Zelda.Blocks;
using Zelda.Blocks.Classes;
using Zelda.Projectiles;

namespace Zelda.Collision.Handlers
{
    internal class ProjectileBlockCollisionHandler
    {
        public void HandleCollision(IProjectile projectile, IBlock block)
        {
            if (projectile.CanCollide && !block.IsGap)
            {
                projectile.Delete();
            }
        }
    }
}
