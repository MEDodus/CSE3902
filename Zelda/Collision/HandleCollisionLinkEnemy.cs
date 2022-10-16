using Microsoft.Xna.Framework;
using Zelda.Link;
using Zelda.NPCs;


namespace Zelda.Collision
{
    internal class HandleCollisionLinkEnemy
    {
        public HandleCollisionLinkEnemy(ILink link, INPC enemy, Game1 game, GameTime gameTime)
        {

            link.TakeDamage(game);

            //return vector pointing in direction from first parameter to side of collision
            //Vector2D direction = CollisionSide(enemy, link);    //dont need collision side for this isntance

            //ChangeEnemyDirection(enemy, gameTime);


        }

        // Commented out to compile code
        /* private Vector2 CollisionSide(INPC enemy, ILink link)
         {
             return new Vector2(0, 0);
         }

         private void ChangeEnemyDirection(INPC enemy, Vector2 direction, GameTime gameTime) 
         {
             if(direction.X > 0)
             {
                 enemy.state.MoveRight(gameTime);
             }
             else
             {
                 if(direction.Y > 0)
                 {
                     enemy.state.MoveDown(gameTime);
                 }
                 else
                 {
                     enemy.state.MoveDown(gameTime);
                 }

                 enemy.state.MoveLeft(gameTime);
             }
         } */
    }
}
