using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zelda.Commands
{
    public class UseItem : ICommand
    {
        private Game1 game;

        public UseItem(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {

        }
    }
}
