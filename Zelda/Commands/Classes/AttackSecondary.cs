using Microsoft.Xna.Framework;

namespace Zelda.Commands
{
    public class AttackSecondary : ICommand
    {
        private Game1 game;
        private int playerNumber;

        public AttackSecondary(Game1 game, int number)
        {
            this.game = game;
            playerNumber = number;
        }

        public void Execute(GameTime gameTime)
        {
            if(playerNumber == 1)
            {
                game.Link.AttackSecondary();
            }
            else
            {
                game.LinkCompanion.AttackSecondary();
            }
        }
    }
}