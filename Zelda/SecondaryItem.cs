using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zelda
{
    public class SecondaryItem : ICommand
    {
        private Game1 game;

        public SecondaryItem(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {

        }
    }
}
