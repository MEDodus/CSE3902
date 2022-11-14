using Microsoft.Xna.Framework;

namespace Zelda.Commands
{
    public class AttackSecondary : ICommand
    {
        private Game1 game;

        public AttackSecondary(Game1 game)
        {
            this.game = game;
        }

        public void Execute(GameTime gameTime)
        {
            game.Link.UseItem(1);
        }
    }
}