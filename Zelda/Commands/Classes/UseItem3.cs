using Microsoft.Xna.Framework;
using Zelda.Link;

namespace Zelda.Commands
{
    public class UseItem3 : ICommand
    {
        private Game1 game;

        public UseItem3(Game1 game)
        {
            this.game = game;
        }

        public void Execute(GameTime gametime)
        {
            game.link.UseItem(3);
        }
    }
}