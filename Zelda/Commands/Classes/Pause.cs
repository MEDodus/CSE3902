using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zelda.Commands.Classes
{
    public class Pause : ICommand
    {
        private Game1 game;

        public Pause(Game1 game)
        {
            this.game = game;
        }

        public void Execute(GameTime gameTime)
        {
            game.Paused = !game.Paused;
        }
    }
}
