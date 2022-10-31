using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Zelda.Rooms;

namespace Zelda.Projectiles
{
    public static class ProjectileStorage
    {
        private static readonly HashSet<IProjectile> projectiles = new();
        private static readonly HashSet<IProjectile> projectilesToAdd = new();
        public static HashSet<IProjectile> Projectiles { 
            get {return projectiles;}
        }

        public static void Add(IProjectile projectile)
        {
            // Projectiles might be created externally within foreach loops over Projectiles, so do not add directly to Projectiles
            projectilesToAdd.Add(projectile);
        }

        public static void Update(GameTime gameTime)
        {
            foreach (IProjectile projectile in projectilesToAdd)
            {
                Projectiles.Add(projectile);
            }
            projectilesToAdd.Clear();
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
                projectile.OnDelete();
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
