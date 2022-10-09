using Microsoft.Xna.Framework;
using Zelda.Link;

namespace Zelda.Commands
{
    public class UseItem7 : ICommand
    {
        private Game1 game;
        private ILink link;

        public UseItem7(Game1 game, ILink link)
        {
            this.game = game;
            this.link = link;
        }

        public void Execute(GameTime gametime)
        {
            link.UseItem(7);
        }
    }
}