using Microsoft.Xna.Framework;

namespace Zelda.Commands.Classes
{
    public class Quit : ICommand
    {
        private Game1 game;

        public Quit(Game1 game)
        {
            this.game = game;
        }

        public void Execute(GameTime gameTime)
        {
            game.Exit();
        }
    }
}
