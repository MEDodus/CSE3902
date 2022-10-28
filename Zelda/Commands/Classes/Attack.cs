﻿using Microsoft.Xna.Framework;
using Zelda.Link;

namespace Zelda.Commands
{
    public class Attack : ICommand
    {
        private Game1 game;

        public Attack(Game1 game)
        {
            this.game = game;
        }

        public void Execute(GameTime gameTime)
        {
            game.link.UseItem(0);
        }
    }
}