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
        public void HandleCollision(INPC enemy, IBlock block)
        {
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
    }
}
