﻿using Microsoft.Xna.Framework;
using Zelda.Link;

namespace Zelda.Commands
{
    public class UseItem1 : ICommand
    {
        private Game1 game;

        public UseItem1(Game1 game)
        {
            this.game = game;
        }

        public void Execute(GameTime gametime)
        {
            game.link.UseItem(1);
        }
    }
}