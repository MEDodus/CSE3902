using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Zelda.Projectiles
{
    public static class ProjectileStorage
    {
        private static readonly HashSet<IProjectile> projectiles = new HashSet<IProjectile>();

        public static void Add(IProjectile projectile)
        {
            projectiles.Add(projectile);
        }

        public static void Update(GameTime gameTime)
        {
            HashSet<IProjectile> projectilesToDelete = new HashSet<IProjectile>();
            foreach (IProjectile projectile in projectiles)
            {
                bool lifetimeExpired = projectile.Update(gameTime);
                if (lifetimeExpired)
                {
                    // can't remove directly from projectiles within foreach loop
                    projectilesToDelete.Add(projectile);
                }
            }
            foreach (IProjectile projectile in projectilesToDelete)
            {
                projectile.Delete();
                projectiles.Remove(projectile);
            }
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            foreach (IProjectile projectile in projectiles)
            {
                projectile.Draw(spriteBatch);
            }
        }

        public static void Clear()
        {
            projectiles.Clear();
        }
    }
}
