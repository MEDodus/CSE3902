using Microsoft.Xna.Framework;
using Zelda.Link;

namespace Zelda.Commands
{
    public class Down : ICommand
    {
        private Game1 game;

        public Down(Game1 game)
        {
            this.game = game;
        }

        public void Execute(GameTime gametime)
        {
            game.GameState.Down();
        }
    }
}