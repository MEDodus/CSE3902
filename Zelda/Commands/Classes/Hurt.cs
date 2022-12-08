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
            game.Link.TakeDamage(1, new Vector2(0,0));
        }
    }
}