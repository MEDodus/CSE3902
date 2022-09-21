using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zelda.Commands
{
    public class CycleItemPrevious : ICommand
    {
        private Game1 game;

        public CycleItemPrevious(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {

        }
    }
}
