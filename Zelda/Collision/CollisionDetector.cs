//using Microsoft.Xna.Framework;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Zelda.Link;
//using Zelda.NPCs;
//using Zelda.NPCs.Classes;
//using Zelda.Projectiles;
//using Zelda.Rooms;
//using Zelda.Collision;
//using Zelda.Projectiles;
//using Zelda.Blocks;
//using Zelda.Collision.Handlers;

//namespace Zelda.Collision
//{
//    internal class CollisionDetector
//    {

//        protected PlayerBlockCollisionHandler playerBlockCollisionHandler = new PlayerBlockCollisionHandler();
//        protected PlayerEnemyCollisionHandler playerEnemyCollisionHandler = new PlayerEnemyCollisionHandler();
//        protected EnemyBlockCollisionHandler enemyBlockCollisionHandler = new EnemyBlockCollisionHandler();


//        protected List<INPC> staticEnemies = new List<INPC>();
//        protected List<ILink> staticPlayers = new List<ILink>();

//        protected List<INPC> dynamicEnemies = new List<INPC>();
//        protected List<ILink> dynamicPlayers = new List<ILink>();


//        public void DetectCollisions(Game1 myGame, GameTime gameTime, RoomBuilder roomBuilder, ILink link)
//        {
//            CheckStaticPlayerCollision(myGame, gameTime);
//            CheckDynamicPlayerCollision(myGame, gameTime, roomBuilder);
//            CheckStaticEnemyCollision();  //Will wait to implement static enemy collisions; for now, assume always moving
//            CheckDynamicEnemyCollision(roomBuilder);

//        }

//        public void AddMovingObject(ILink player)
//        {
//            dynamicPlayers.Add(player);
//            staticPlayers.Remove(player);
//        }
//        public void AddMovingObject(INPC enemy)
//        {
//            dynamicEnemies.Add(enemy);
//            staticEnemies.Remove(enemy);
//        }


//        LINK COLLISION - NICHOLAS
//        /*protected void CheckStaticPlayerCollision(Game1 myGame, GameTime gameTime)
//        {
//            foreach (ILink player in staticPlayers)
//            {

//                foreach (INPC dynamicEnemy in dynamicEnemies)
//                {
//                    check if collision -->
//                    playerEnemyCollisionHandler.HandleCollision(player, dynamicEnemy, myGame, gameTime);
//                }

//                foreach (IProjectile projectile in ProjectileStorage.projectiles)
//                {
//                    check if collision
//                    playerProjectileCollisionHandler.HandleCollision();
//                }

//            }
//        }*/

//        LINK COLLISION - NICHOLAS
//        /*protected void CheckDynamicPlayerCollision(Game1 myGame, GameTime gameTime, RoomBuilder roomBuilder)
//        {
//            foreach (ILink player in dynamicPlayers)
//            {

//                foreach (INPC dynamicEnemy in dynamicEnemies)
//                {
//                    check if collision -->
//                    playerEnemyCollisionHandler.HandleCollision(player, dynamicEnemy, myGame, gameTime);
//                }

//                foreach(IProjectile projectile in ProjectileStorage.projectiles)
//                {
//                    check if collision
//                    playerProjectileCollisionHandler.HandleCollision();
//                }

//                check block collisisons
//                foreach(IBlock block in roomBuilder.CurrentRoom.Barriers)
//                {
//                    if (player.Sprite.Destination.Intersects(block.Sprite.Destination){
//                        PlayerBlockCollisionHandler.HandleCollision(player, block);
//                    }
//                }

//            }
//        }*/

//        protected void CheckDynamicEnemyCollision(RoomBuilder roomBuilder)
//        {

//            foreach (INPC dynamicEnemy in dynamicEnemies)
//            {
//                foreach (IProjectile projectile in ProjectileStorage.Projectiles)
//                {
//                    check if collision
//                    projectile.Sprite.Destination.Intersects(dynamicEnemy.Sprite.Destination);
//                }
//                foreach (IBlock block in roomBuilder.CurrentRoom.Barriers)//block collision check)
//                {
//                    if (dynamicEnemy.Sprite.Destination.Intersects(block.Sprite.Destination))
//                    {
//                        enemyBlockCollisionHandler.HandleCollision(dynamicEnemy, block);
//                    }
//                }
//            }


//        }

//        protected void CheckStaticEnemyCollision()
//        {
//            foreach (INPC dynamicEnemy in dynamicEnemies)
//            {
//                foreach (IProjectile projectile in ProjectileStorage.Projectiles)
//                {
//                    projectile.Sprite.Destination.Intersects(dynamicEnemy.Sprite.Destination);
//                }
//            }
//        }
//    }
//}
