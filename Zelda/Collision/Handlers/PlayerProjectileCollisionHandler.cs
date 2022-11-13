using Microsoft.Xna.Framework;
using Zelda.Link;
using Zelda.Projectiles;
using Zelda.Projectiles.Classes;

namespace Zelda.Collision.Handlers
{
    public class PlayerProjectileCollisionHandler : ICollision
    {
        public PlayerProjectileCollisionHandler()
        {

        }

        public void HandleCollision()
        {

        }

        public void HandleCollision(ILink link, IProjectile projectile, Game1 game)
        {
            if (projectile.Behavior == ProjectileBehavior.Enemy || projectile.Behavior == ProjectileBehavior.NeutralHarmful)
            {
                Vector2 linkDirection = link.Direction;
                Vector2 projectileDirection = projectile.Velocity;
                linkDirection.Normalize();
                projectileDirection.Normalize();
                if (!Vector2.Add(linkDirection, projectileDirection).Equals(new Vector2(0, 0)))
                {
                    int damage = 0;
                    if(projectile is Explosion)
                    {
                        damage = 4;
                    } else if(projectile is Boomerang) {
                        damage = 2;
                    } else if(projectile is Fireball)
                    {
                        damage = 1;
                    }
                    game.Link.TakeDamage(game, damage);
                }
                projectile.Delete();
            }
        }




    }
}
