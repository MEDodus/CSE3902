using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zelda.Commands
{
    public class Left : ICommand
    {
        private Game1 game;

        // TODO: Pass reference of playable sprite here?
        public Left(Game1 game)
        {
            this.game = game;
        }

        // TODO: Execute left on playable sprite
        public void Execute()
        {

        }
    }
}
