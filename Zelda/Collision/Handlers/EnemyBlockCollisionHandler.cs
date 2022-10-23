using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zelda.Blocks;
using Zelda.NPCs.Classes;

namespace Zelda.Collision.Handlers
{
    internal class EnemyBlockCollisionHandler
    {
        public void HandleCollision(EnemySingleDirection enemy, IBlock block)
        {
            enemy.ChangeDirection();
        }

        public void HandleCollision(EnemyMultiDirection enemy, IBlock block)
        {
            //Rectangle.Intersect(enemy.Position, block.Position);
        }
    }
}
