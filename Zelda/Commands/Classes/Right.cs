using Microsoft.Xna.Framework;
using Zelda.Link;

namespace Zelda.Commands
{
    public class Right : ICommand
    {
        private Game1 game;
        private ILink link;

        // TODO: Pass reference of playable sprite here?
        public Right(Game1 game, ILink link)
        {
            this.game = game;
            this.link = link;
        }

        // TODO: Execute right on playable sprite
        public void Execute(GameTime gametime)
        {
            link.MoveRight();
        }
    }
}