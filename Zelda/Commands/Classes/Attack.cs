using Microsoft.Xna.Framework;

namespace Zelda.Commands
{
    public class Attack : ICommand
    {
        private Game1 game;
        int playerNumber;

        public Attack(Game1 game, int number)
        {
            this.game = game;
            playerNumber = number;
        }

        public void Execute(GameTime gameTime)
        {
            if(game.PlayerCount == 1 || playerNumber == 1)
            {
                game.Link.Attack();
            }
            else
            {
                game.LinkCompanion.Attack();
            }
        }
    }
}