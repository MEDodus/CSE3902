using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zelda.Enemy;

namespace Zelda.Commands
{
    public class CycleEnemyNext : ICommand
    {
        private Game1 game;

        public CycleEnemyNext(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.NextEnemy();
        }
    }
}
