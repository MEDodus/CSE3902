using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zelda.NPCs.Classes;
using Zelda.Projectiles;

namespace Zelda.Collision
{
    internal class EnemyProjectileCollisionHandler
    {
        public void HandleCollision(EnemySingleDirection enemy, IProjectile projectile)
        {
            enemy.TakeDamage(1);
        }
        public void HandleCollision(EnemyMultiDirection enemy, IProjectile projectile)
        {
            enemy.TakeDamage(1);
        }
    }
}
