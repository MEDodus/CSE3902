using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zelda
{
    public class Right : ICommand
    {
        private Game1 game;

        // TODO: Pass reference of playable sprite here?
        public Right(Game1 game)
        {
            this.game = game;
        }

        // TODO: Execute right on playable sprite
        public void Execute()
        {

        }
    }
}
