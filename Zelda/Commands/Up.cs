using Zelda.Link;

namespace Zelda.Commands
{
    public class Up : ICommand
    {
        private Game1 game;
        private ILink link;

        // TODO: Pass reference of playable sprite here?
        public Up(Game1 game, ILink link)
        {
            this.game = game;
            this.link = link;
        }

        // TODO: Execute up on playable sprite
        public void Execute()
        {
            link.MoveUp();
        }
    }
}
