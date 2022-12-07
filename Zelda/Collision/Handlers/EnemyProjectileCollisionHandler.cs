using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zelda.NPCs;
using Zelda.NPCs.Classes;
using Zelda.Projectiles;
using Zelda.Projectiles.Classes;

namespace Zelda.Collision.Handlers
{
    public class EnemyProjectileCollisionHandler
    {
        public void HandleCollision(INPC enemy, IProjectile projectile)
        {
            if (projectile.Behavior == ProjectileBehavior.Friendly || projectile.Behavior == ProjectileBehavior.NeutralHarmful)
            {
                projectile.Delete();

                if (enemy is EnemySingleDirection)
                {
                    CollisionHelper((EnemySingleDirection)enemy);
                }
                else if (enemy is Snake)
                {
                    CollisionHelper((Snake)enemy);
                }
                else if (enemy is Dodongo)
                {
                    CollisionHelper((Dodongo)enemy, projectile);
                }
                else if (enemy is Goriya)
                {
                    CollisionHelper((Goriya)enemy);
                }
            }
        }
        public void CollisionHelper(EnemySingleDirection enemy)
        {
            enemy.TakeDamage(1);
        }
        public void CollisionHelper(Snake enemy)
        {
            enemy.TakeDamage(1);
        }
        public void CollisionHelper(Dodongo enemy, IProjectile projectile)
        {
            int damage = projectile is Explosion ? 3 : 1;
            enemy.TakeDamage(damage);
        }
        public void CollisionHelper(Goriya enemy)
        {
            enemy.TakeDamage(1);
        }
    }
}
