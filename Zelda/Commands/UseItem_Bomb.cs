using Zelda.Link;

namespace Zelda.Commands
{
    public class UseItem_Bomb : ICommand
    {
        private Game1 game;
        private ILink link;

        public UseItem_Bomb(Game1 game, ILink link)
        {
            this.game = game;
            this.link = link;
        }

        public void Execute()
        {
            link.UseItem(2);
        }
    }
}
