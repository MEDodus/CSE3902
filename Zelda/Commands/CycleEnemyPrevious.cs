using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zelda.Enemy;

namespace Zelda.Commands
{
    public class CycleEnemyPrevious : ICommand
    {
        private Game1 game;

        public CycleEnemyPrevious(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.PreviousEnemy();
        }
    }
}
