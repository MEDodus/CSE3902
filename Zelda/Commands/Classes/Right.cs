using Microsoft.Xna.Framework;
using Zelda.Link;

namespace Zelda.Commands
{
    public class Right : ICommand
    {
        private Game1 game;

        public Right(Game1 game)
        {
            this.game = game;
        }

        public void Execute(GameTime gametime)
        {
            game.Link.MoveRight();
        }
    }
}