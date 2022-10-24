using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Zelda.NPCs;
using Zelda.Link;
using Zelda.Projectiles;
using Zelda.Projectiles.Classes;
using Zelda.Sprites;
using Zelda.Sprites.Factories;
using Zelda.NPCs.Classes;
using Zelda.Blocks;
using Zelda.Projectiles;

namespace Zelda.Collision.Handlers
{
    internal class PlayerProjectileCollisionHandler : ICollision
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
                    game.link.TakeDamage(game);
                }
                projectile.Delete();
            }
        }




    }
}
