using Microsoft.Xna.Framework;
using Zelda.Link;

namespace Zelda.Commands
{
    public class Attack : ICommand
    {
        private Game1 game;
        private ILink link;

        public Attack(Game1 game, ILink link)
        {
            this.game = game;
            this.link = link;
        }

        public void Execute(GameTime gameTime)
        {
            link.Attack();
        }
    }
}