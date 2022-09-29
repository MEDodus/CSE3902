using Zelda.Link;

namespace Zelda.Commands
{
    public class Down : ICommand
    {
        private Game1 game;
        private ILink link;

        // TODO: Pass reference of playable sprite here?
        public Down(Game1 game, ILink link)
        {
            this.game = game;
            this.link = link;
        }

        // TODO: Execute down on playable sprite
        public void Execute()
        {
            link.MoveDown();
        }
    }
}
