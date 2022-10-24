using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zelda.Blocks;
using Zelda.NPCs;
using Zelda.NPCs.Classes;

namespace Zelda.Collision
{
    internal class EnemyBlockCollisionHandler
    {
        protected Direction collisionDirection;
        protected Rectangle collisionArea;
        public void HandleCollision(INPC enemy, IBlock block)
        {
            GetCollisionDirection(enemy, block);

            if (enemy is EnemySingleDirection)
            {
                CollisionHelper((EnemySingleDirection)enemy, block);
            }
            else if (enemy is EnemyMultiDirection)
            {
                CollisionHelper((EnemyMultiDirection)enemy, block);
            }
        }
        public void CollisionHelper(EnemySingleDirection enemy, IBlock block)
        {
            //change direction
            enemy.ChangeDirection();
        }

        public void CollisionHelper(EnemyMultiDirection enemy, IBlock block)
        {
            //change direction
        }
        
        protected void GetCollisionDirection(INPC enemy, IBlock block)
        {

            collisionArea = Rectangle.Intersect(enemy.Sprite.Destination, block.Sprite.Destination);
        }
    }
}
