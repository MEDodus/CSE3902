using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Zelda.Projectiles
{
    public static class ProjectileStorage
    {
        private static readonly HashSet<IProjectile> projectiles = new HashSet<IProjectile>();
        public static HashSet<IProjectile> Projectiles { 
            get {return projectiles;}
        }

        public static void Add(IProjectile projectile)
        {
            Projectiles.Add(projectile);
        }

        public static void Update(GameTime gameTime)
        {
            HashSet<IProjectile> projectilesToDelete = new HashSet<IProjectile>();
            foreach (IProjectile projectile in Projectiles)
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
                Projectiles.Remove(projectile);
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
            Projectiles.Clear();
        }
    }
}
