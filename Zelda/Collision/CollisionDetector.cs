using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using Zelda.Link;
using Zelda.NPCs;
using Zelda.Projectiles;
using Zelda.Rooms;
using Zelda.Blocks;
using Zelda.Collision.Handlers;

namespace Zelda.Collision
{
    internal class CollisionDetector
    {
        protected enum CollisionDirection { left, right, up, down }

        private PlayerBlockCollisionHandler playerBlockCollisionHandler = new PlayerBlockCollisionHandler();
        private PlayerEnemyCollisionHandler playerEnemyCollisionHandler = new PlayerEnemyCollisionHandler();
        private EnemyBlockCollisionHandler enemyBlockCollisionHandler = new EnemyBlockCollisionHandler();
        private EnemyProjectileCollisionHandler enemyProjectileCollisionHandler = new EnemyProjectileCollisionHandler();
        private PlayerProjectileCollisionHandler playerProjectileCollisionHandler = new PlayerProjectileCollisionHandler();
        private ProjectileBlockCollisionHandler projectileBlockCollisionHandler = new ProjectileBlockCollisionHandler();

        private List<INPC> staticEnemies = new List<INPC>();
        private List<ILink> staticPlayers = new List<ILink>();
        private HashSet<INPC> dynamicEnemies = new HashSet<INPC>();
        private List<ILink> dynamicPlayers = new List<ILink>();

        public CollisionDetector()
        {

        }

        public void DetectCollisions(Game1 myGame, GameTime gameTime, RoomBuilder roomBuilder, ILink link)
        {
            dynamicEnemies = roomBuilder.CurrentRoom.NPCs;
            dynamicPlayers.Add(link);
            CheckPlayerCollision(myGame, gameTime, roomBuilder);
            CheckStaticEnemyCollision();  //Will wait to implement static enemy collisions; for now, assume always moving
            CheckDynamicEnemyCollision(roomBuilder);
            CheckProjectileBlockCollision(roomBuilder);
        }

        public void AddMovingObject(ILink player)
        {
            dynamicPlayers.Add(player);
            staticPlayers.Remove(player);
        }
        public void AddMovingObject(INPC enemy)
        {
            dynamicEnemies.Add(enemy);
            staticEnemies.Remove(enemy);
        }

        private void CheckStaticPlayerCollision(Game1 myGame, GameTime gameTime)
        {
            foreach (ILink player in staticPlayers)
            {
                foreach (INPC dynamicEnemy in dynamicEnemies)
                {
                    if (player.Sprite.Destination.Intersects(dynamicEnemy.Sprite.Destination))
                    {
                        playerEnemyCollisionHandler.HandleCollision(player, dynamicEnemy, myGame, gameTime);
                    }
                }
                foreach (IProjectile projectile in ProjectileStorage.Projectiles)
                {
                    if (player.Sprite.Destination.Intersects(projectile.Sprite.Destination))
                    {
                        playerProjectileCollisionHandler.HandleCollision(player, projectile, myGame);
                    }
                }
            }
        }

        private void CheckPlayerCollision(Game1 myGame, GameTime gameTime, RoomBuilder roomBuilder)
        {
            foreach (ILink player in dynamicPlayers)
            {
                foreach (INPC dynamicEnemy in dynamicEnemies)
                {
                    if (player.Sprite.Destination.Intersects(dynamicEnemy.Sprite.Destination))
                    {
                        playerEnemyCollisionHandler.HandleCollision(player, dynamicEnemy, myGame, gameTime);
                    }
                }
                foreach(IProjectile projectile in ProjectileStorage.Projectiles)
                {
                    if (player.Sprite.Destination.Intersects(projectile.Sprite.Destination))
                    {
                        playerProjectileCollisionHandler.HandleCollision(player, projectile, myGame);
                    }
                }
                foreach(IBlock block in roomBuilder.CurrentRoom.Barriers)
                {
                    if (block != null && player.Sprite.Destination.Intersects(block.Sprite.Destination))
                    {
                        playerBlockCollisionHandler.HandleCollision(player, block);
                    }
                }
            }
        }

        private void CheckDynamicEnemyCollision(RoomBuilder roomBuilder)
        {
            foreach (INPC dynamicEnemy in dynamicEnemies)
            {
                foreach (IProjectile projectile in ProjectileStorage.Projectiles)
                {
                    if (projectile.Sprite.Destination.Intersects(dynamicEnemy.Sprite.Destination))
                    {
                        enemyProjectileCollisionHandler.HandleCollision(dynamicEnemy, projectile);
                    }
                }
                foreach (IBlock block in roomBuilder.CurrentRoom.Barriers)
                {
                    if (dynamicEnemy.Sprite.Destination.Intersects(block.Sprite.Destination))
                    {
                        enemyBlockCollisionHandler.HandleCollision(dynamicEnemy, block);
                    }
                }
            }
        }

        private void CheckStaticEnemyCollision()
        {
            foreach (INPC staticEnemy in staticEnemies)
            {
                foreach (IProjectile projectile in ProjectileStorage.Projectiles)
                {
                    projectile.Sprite.Destination.Intersects(staticEnemy.Sprite.Destination);
                }
            }
        }

        private void CheckProjectileBlockCollision(RoomBuilder roomBuilder)
        {
            foreach (IProjectile projectile in ProjectileStorage.Projectiles)
            {
                foreach (IBlock block in roomBuilder.CurrentRoom.Barriers)
                {
                    if (projectile.Sprite.Destination.Intersects(block.Sprite.Destination))
                    {
                        projectileBlockCollisionHandler.HandleCollision(projectile, block);
                    }
                }
            }
        }
    }
}
