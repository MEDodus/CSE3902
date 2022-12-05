using Microsoft.Xna.Framework;

namespace Zelda.Commands.Classes
{
    public class LeftClick : ICommand
    {
        Game1 game;

        public LeftClick(Game1 game)
        {
            this.game = game;
        }

        public void Execute(GameTime gameTime)
        {
            game.GameState.LeftClick();
        }
    }
}
