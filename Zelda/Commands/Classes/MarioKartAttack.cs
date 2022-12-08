using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zelda.Commands.Classes
{
    public class MarioKartAttack : ICommand
    {
        private Game1 game;
        int playerNumber;

        public MarioKartAttack(Game1 game, int number)
        {
            this.game = game;
            playerNumber = number;
        }

        public void Execute(GameTime gameTime)
        {
            if (playerNumber == 1)
            {
                game.Link.MarioAttack();
            }
            else
            {
                game.LinkCompanion.MarioAttack();
            }
        }
    }
}
