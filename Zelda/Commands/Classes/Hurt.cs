using Microsoft.Xna.Framework;
using Zelda.Link;
using Zelda.Sound;

namespace Zelda.Commands
{
    public class Hurt : ICommand
    {
        private Game1 game;

        public Hurt(Game1 game, ILink link)
        {
            this.game = game;
        }

        public void Execute(GameTime gametime)
        {
            game.link.TakeDamage(game, 1);
        }
    }
}