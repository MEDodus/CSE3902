using Zelda.Blocks;
using Zelda.Blocks.Classes;
using Zelda.Projectiles;

namespace Zelda.Collision.Handlers
{
    public class ProjectileBlockCollisionHandler
    {
        public void HandleCollision(Projectile projectile, Block block)
        {
            if (projectile.CanCollide && !block.IsGap)
            {
                projectile.Delete();
            }
        }
    }
}
