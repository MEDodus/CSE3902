using Microsoft.Xna.Framework;
using Zelda.Link;

namespace Zelda.Commands
{
    public class Up : ICommand
    {
        private Game1 game;

        public Up(Game1 game)
        {
            this.game = game;
        }

        public void Execute(GameTime gametime)
        {
            game.GameState.Up();
        }
    }
}