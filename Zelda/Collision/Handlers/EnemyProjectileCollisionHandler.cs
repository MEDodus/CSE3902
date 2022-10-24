using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zelda.NPCs;
using Zelda.NPCs.Classes;
using Zelda.Projectiles;

namespace Zelda.Collision.Handlers
{
    internal class EnemyProjectileCollisionHandler
    {
        public void HandleCollision(INPC enemy, IProjectile projectile)
        {
            if (!NPCProjectiles.EnemyProjectiles.Contains(projectile))
            {
                projectile.Delete();

                if (enemy is EnemySingleDirection)
                {
                    CollisionHelper((EnemySingleDirection)enemy);
                }
                else if (enemy is EnemyMultiDirection)
                {
                    CollisionHelper((EnemyMultiDirection)enemy);
                }
            }
        }
        public void CollisionHelper(EnemySingleDirection enemy)
        {
            enemy.TakeDamage(1);
        }
        public void CollisionHelper(EnemyMultiDirection enemy)
        {
            enemy.TakeDamage(1);
        }
    }
}
