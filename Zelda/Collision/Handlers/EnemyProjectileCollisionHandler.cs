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
                    CollisionHelper((Dodongo)enemy);
                }
                else if (enemy is Goriya)
                {
                    CollisionHelper((Goriya)enemy);
                }
                else if(enemy is OldMan)
                {
                    CollisionHelper((OldMan)enemy);
                }
            }
        }
        public void CollisionHelper(EnemySingleDirection enemy)
        {
            enemy.TakeDamage(1);
        }
        public void CollisionHelper(Snake enemy)
        {
            enemy.state.TakeDamage();
        }
        public void CollisionHelper(Dodongo enemy)
        {
            enemy.state.TakeDamage();
        }
        public void CollisionHelper(Goriya enemy)
        {
            enemy.state.TakeDamage();
        }
        public void CollisionHelper(OldMan enemy)
        {
            enemy.State.TakeDamage();
        }
    }
}
