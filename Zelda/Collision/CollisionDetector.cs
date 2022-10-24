using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zelda.Link;
using Zelda.NPCs;
 using Zelda.NPCs.Classes;
 using Zelda.Projectiles;
 using Zelda.Rooms;
 using Zelda.Collision;
 using Zelda.Projectiles;
 using Zelda.Blocks;
 using Zelda.Collision.Handlers;

 namespace Zelda.Collision
 {
     internal class CollisionDetector
     {
        protected enum CollisionDirection { left, right, up, down }
        protected PlayerBlockCollisionHandler playerBlockCollisionHandler = new PlayerBlockCollisionHandler();
        protected PlayerEnemyCollisionHandler playerEnemyCollisionHandler = new PlayerEnemyCollisionHandler();
        protected EnemyBlockCollisionHandler enemyBlockCollisionHandler = new EnemyBlockCollisionHandler();
        protected EnemyProjectileCollisionHandler enemyProjectileCollisionHandler = new EnemyProjectileCollisionHandler();
        protected PlayerProjectileCollisionHandler playerProjectileCollisionHandler = new PlayerProjectileCollisionHandler();


         protected List<INPC> staticEnemies = new List<INPC>();
         protected List<ILink> staticPlayers = new List<ILink>();

         protected HashSet<INPC> dynamicEnemies = new HashSet<INPC>();
         protected List<ILink> dynamicPlayers = new List<ILink>();

        public CollisionDetector()
        {

        }

         public void DetectCollisions(Game1 myGame, GameTime gameTime, RoomBuilder roomBuilder, ILink link)
         {
            this.dynamicEnemies = roomBuilder.CurrentRoom.NPCs;
            this.dynamicPlayers.Add(link);
            CheckPlayerCollision(myGame, gameTime, roomBuilder);
            CheckStaticEnemyCollision();  //Will wait to implement static enemy collisions; for now, assume always moving
            CheckDynamicEnemyCollision(roomBuilder);

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


         protected void CheckStaticPlayerCollision(Game1 myGame, GameTime gameTime)
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

                 foreach (IProjectile projectile in ProjectileStorage.Projectiles.ToArray())
                 {
                    if (player.Sprite.Destination.Intersects(projectile.Sprite.Destination))
                    {
                        playerProjectileCollisionHandler.HandleCollision(player, projectile, myGame);
                    }
                 }

             }
         }

         protected void CheckPlayerCollision(Game1 myGame, GameTime gameTime, RoomBuilder roomBuilder)
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

                 foreach(IProjectile projectile in ProjectileStorage.Projectiles.ToArray())
                 {
                    if (player.Sprite.Destination.Intersects(projectile.Sprite.Destination))
                    {
                        playerProjectileCollisionHandler.HandleCollision(player, projectile, myGame);
                    }
                }

                 foreach(IBlock block in roomBuilder.CurrentRoom.Barriers.ToArray())
                 {
                     if (block != null && player.Sprite.Destination.Intersects(block.Sprite.Destination))
                     {
                         playerBlockCollisionHandler.HandleCollision(player, block);
                     }
                 }

             }
         }

         protected void CheckDynamicEnemyCollision(RoomBuilder roomBuilder)
         {

             foreach (INPC dynamicEnemy in dynamicEnemies)
             {
                //HashSet<IProjectile> projectilesCopy = ProjectileStorage.Projectiles;
                 foreach (IProjectile projectile in ProjectileStorage.Projectiles.ToArray())
                 {
                    //check if collision
                    if (projectile.Sprite.Destination.Intersects(dynamicEnemy.Sprite.Destination))
                    {
                        enemyProjectileCollisionHandler.HandleCollision(dynamicEnemy, projectile);
                    }
                 }

                foreach (IBlock block in roomBuilder.CurrentRoom.Barriers.ToArray())//block collision check)
                {
                    if (dynamicEnemy.Sprite.Destination.Intersects(block.Sprite.Destination))
                    {
                        enemyBlockCollisionHandler.HandleCollision(dynamicEnemy, block);
                    }
                }
                
             }


         }

         protected void CheckStaticEnemyCollision()
         {
             foreach (INPC staticEnemy in staticEnemies)
             {
                 foreach (IProjectile projectile in ProjectileStorage.Projectiles)
                 {
                     projectile.Sprite.Destination.Intersects(staticEnemy.Sprite.Destination);
                 }
             }
         }
     }
 }
