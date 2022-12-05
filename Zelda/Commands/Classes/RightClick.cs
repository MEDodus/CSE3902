using Microsoft.Xna.Framework;

namespace Zelda.Commands.Classes
{
    public class RightClick : ICommand
    {
        Game1 game;

        public RightClick(Game1 game)
        {
            this.game = game;
        }

        public void Execute(GameTime gameTime)
        {
            game.GameState.RightClick();
        }
    }
}
