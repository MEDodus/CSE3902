using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Zelda.NPCs;
using Zelda.Link;
using Zelda.Projectiles;
using Zelda.Projectiles.Classes;
using Zelda.Sprites;
using Zelda.Sprites.Factories;


namespace Zelda.Collision
{
    internal class HandleCollisionLinkEnemy
    {
        public HandleCollisionLinkEnemy(ILink link, INPC enemy, Game1 game, GameTime gameTime)
        {

            link.TakeDamage(game);

            //return vector pointing in direction from first parameter to side of collision
            Vector2D direction = CollisionSide(enemy, link);

            ChangeEnemyDirection(enemy, direction, gameTime);


        }

        private Vector2D CollisionSide(INPC enemy, ILink link)
        {

        }

        private void ChangeEnemyDirection(INPC enemy, Vector2D direction, GameTime gameTime) 
        {
            if(direction.X > 0)
            {
                enemy.MoveRight(gameTime);
            }
            else
            {
                if(direction.Y > 0)
                {
                    enemy.MoveDown(gameTime);
                }
                else
                {
                    enemy.MoveDown(gameTime);
                }

                enemy.MoveLeft(GameTime);
            }
        }
    }
}
