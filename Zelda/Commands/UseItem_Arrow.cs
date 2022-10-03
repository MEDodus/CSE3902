using Zelda.Link;

namespace Zelda.Commands
{
    public class UseItem_Arrow : ICommand
    {
        private Game1 game;
        private ILink link;

        public UseItem_Arrow(Game1 game, ILink link)
        {
            this.game = game;
            this.link = link;
        }

        public void Execute()
        {
            link.UseItem(3);
        }
    }
}
