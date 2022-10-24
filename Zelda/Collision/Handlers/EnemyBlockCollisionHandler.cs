using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Zelda.Blocks;
using Zelda.NPCs;
using Zelda.NPCs.Classes;

namespace Zelda.Collision
{
    internal class EnemyBlockCollisionHandler
    {
        protected Direction AwayFromCollision;
        protected Rectangle collisionArea;
        protected Rectangle enemyBox;
        protected Rectangle blockBox;
        public void HandleCollision(INPC enemy, IBlock block)
        {
            GetCollisionDirection(enemy, block);

            if (enemy is EnemySingleDirection)
            {
                CollisionHelper((EnemySingleDirection)enemy, block);
            }
            else if (enemy is Snake)
            {
                CollisionHelper((Snake)enemy, block);
            }
            else if (enemy is Dodongo)
            {
                CollisionHelper((Dodongo)enemy, block);
            }
            else if (enemy is Goriya)
            {
                CollisionHelper((Goriya)enemy, block);
            }
        }
        public void CollisionHelper(EnemySingleDirection enemy, IBlock block)
        {
            //change direction
            enemy.ChangeDirection(this.AwayFromCollision.Vector);
        }

        public void CollisionHelper(Snake enemy, IBlock block)
        {
            //change direction
            enemy.ChangeDirection(this.AwayFromCollision.Vector);
        }
        public void CollisionHelper(Dodongo enemy, IBlock block)
        {
            enemy.ChangeDirection(this.AwayFromCollision.Vector);
        }
        public void CollisionHelper(Goriya enemy, IBlock block)
        {
            enemy.ChangeDirection(this.AwayFromCollision.Vector);
        }

        protected void GetCollisionDirection(INPC enemy, IBlock block)
        {
            collisionArea = Rectangle.Intersect(enemy.Sprite.Destination, block.Sprite.Destination);
            if(collisionArea.Height > collisionArea.Width)
            {
                LeftOrRightCollision(enemy, block);
            }
            else
            {
                UpOrDownCollision(enemy, block);
            }


        }

        protected void UpOrDownCollision(INPC enemy, IBlock block)
        {
            if(enemy.Sprite.Destination.Y > block.Sprite.Destination.Y)
            {
                this.AwayFromCollision = new Direction("down");
            }
            else
            {
                this.AwayFromCollision = new Direction("up");
            }
        }
        protected void LeftOrRightCollision(INPC enemy, IBlock block)
        {
            if (enemy.Sprite.Destination.X > block.Sprite.Destination.X)
            {
                this.AwayFromCollision = new Direction("right");
            }
            else
            {
                this.AwayFromCollision = new Direction("left");
            }
        }
    }
}
