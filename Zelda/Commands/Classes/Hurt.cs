using Microsoft.Xna.Framework;
using Zelda.Link;

namespace Zelda.Commands
{
    public class Hurt : ICommand
    {
        private Game1 game;
        private ILink link;

        public Hurt(Game1 game, ILink link)
        {
            this.game = game;
            this.link = link;
        }

        public void Execute(GameTime gametime)
        {
            link.TakeDamage(game);
        }
    }
}