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

namespace Zelda.Collision
{
    internal class CollisionDetector
    {

        //protected PlayerBlockCollisionHandler playerBlockCollisionHandler = new PlayerBlockCollisionHandler();
        protected PlayerEnemyCollisionHandler playerEnemyCollisionHandler = new PlayerEnemyCollisionHandler();


        protected List<INPC> staticEnemies = new List<INPC>();
        protected List<ILink> staticPlayers = new List<ILink>();

        protected List<INPC> dynamicEnemies = new List<INPC>();
        protected List<ILink> dynamicPlayers = new List<ILink>();


        public void DetectCollisions(Game1 myGame, GameTime gameTime, RoomBuilder roomBuilder, ILink link)
        {
            CheckStaticPlayerCollision(myGame, gameTime);
            CheckDynamicPlayerCollision(myGame, gameTime);
            CheckStaticEnemyCollision();
            CheckDynamicEnemyCollision();

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
                    //check if collision -->
                    playerEnemyCollisionHandler.HandleCollision(player, dynamicEnemy, myGame, gameTime);
                }

                foreach (IProjectile projectile in ProjectileStorage.projectiles)
                {
                    //check if collision
                    //playerProjectileCollisionHandler.HandleCollision();
                }

            }
        }
        protected void CheckDynamicPlayerCollision(Game1 myGame, GameTime gameTime)
        {
            foreach (ILink player in dynamicPlayers)
            {

                foreach (INPC dynamicEnemy in dynamicEnemies)
                {
                    //check if collision -->
                    playerEnemyCollisionHandler.HandleCollision(player, dynamicEnemy, myGame, gameTime);
                }

                foreach(IProjectile projectile in ProjectileStorage.projectiles)
                {
                    //check if collision
                    //playerProjectileCollisionHandler.HandleCollision();
                }

                //check block collisisons
                foreach()
                {

                }

            }
        }

        protected void CheckDynamicEnemyCollision()
        {

            foreach (INPC dynamicEnemy in dynamicEnemies)
            {
                foreach (IProjectile projectile in ProjectileStorage.projectiles)
                {
                    //check if collision
                }
                foreach ()//block collision check)
                {

                }
            }


        }

        protected void CheckStaticEnemyCollision()
        {
            foreach (INPC dynamicEnemy in dynamicEnemies)
            {
                foreach (IProjectile projectile in ProjectileStorage.projectiles)
                {
                    //check if collision
                }
            }
        }
    }
}
