using Microsoft.Xna.Framework;
using Zelda.Link;

namespace Zelda.Commands
{
    public class UseItem7 : ICommand
    {
        private Game1 game;

        public UseItem7(Game1 game)
        {
            this.game = game;
        }

        public void Execute(GameTime gametime)
        {
            game.Link.UseItem(7);
        }
    }
}