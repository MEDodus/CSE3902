using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zelda
{
    public class CycleItemNext : ICommand
    {
        private Game1 game;

        public CycleItemNext(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {

        }
    }
}
