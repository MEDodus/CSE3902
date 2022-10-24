using System;
using System.Collections.Generic;
using Zelda.NPCs.Classes;
using Zelda.Projectiles;

namespace Zelda.NPCs
{
    public static class NPCProjectiles
    {
        public static HashSet<IProjectile> EnemyProjectiles { get { return enemyProjectiles; } }

        private static HashSet<IProjectile> enemyProjectiles = new HashSet<IProjectile>();
    
        public static void AddEnemyProjectile(IProjectile projectile)
        {
            enemyProjectiles.Add(projectile);
        }
    }
}
