using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zelda.Items.Classes;
using Zelda.NPCs;
using Zelda.NPCs.Classes;
using Zelda.Projectiles;
using Boomerang = Zelda.Projectiles.Classes.Boomerang;

namespace Zelda.Collision.Handlers
{
    public class EnemyProjectileCollisionHandler
    {
        public void HandleCollision(INPC enemy, IProjectile projectile)
        {
            if (projectile.Behavior == ProjectileBehavior.Friendly || projectile.Behavior == ProjectileBehavior.NeutralHarmful)
            {
                
                if (projectile is Boomerang) 
                {
                    if (enemy is Bat || enemy is Gel)
                    {
                        CollisionHelper((EnemySingleDirection)enemy);
                    } else
                    {
                        return;
                    }
                }
                else if (enemy is EnemySingleDirection)
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
                projectile.Delete();
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
            int damage = projectile is Projectiles.Classes.Explosion ? 3 : 1;
            enemy.TakeDamage(damage);
        }
        public void CollisionHelper(Goriya enemy)
        {
            enemy.TakeDamage(1);
        }
    }
}
