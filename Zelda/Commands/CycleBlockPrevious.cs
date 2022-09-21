using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zelda.Commands
{
    internal class CycleBlockPrevious : ICommand
    {
        private Game1 game;

        public CycleBlockPrevious(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {

        }
    }
}
