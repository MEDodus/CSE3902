using Microsoft.Xna.Framework;
using Zelda.Link;

namespace Zelda.Commands
{
    public class Left : ICommand
    {
        private Game1 game;

        public Left(Game1 game)
        {
            this.game = game;
        }

        public void Execute(GameTime gametime)
        {
            game.GameState.Left();
        }
    }
}