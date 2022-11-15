using Microsoft.Xna.Framework;

namespace Zelda.Commands
{
    public class Attack : ICommand
    {
        private Game1 game;

        public Attack(Game1 game)
        {
            this.game = game;
        }

        public void Execute(GameTime gameTime)
        {
            game.Link.UseItem(0);
        }
    }
}