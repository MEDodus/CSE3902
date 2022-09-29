namespace Zelda.Commands
{
    public class SecondaryItem : ICommand
    {
        private Game1 game;

        public SecondaryItem(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {

        }
    }
}
