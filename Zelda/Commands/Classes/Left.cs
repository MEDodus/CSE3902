﻿using Microsoft.Xna.Framework;
using Zelda.Link;

namespace Zelda.Commands
{
    public class Left : ICommand
    {
        private Game1 game;
        private ILink link;

        // TODO: Pass reference of playable sprite here?
        public Left(Game1 game, ILink link)
        {
            this.game = game;
            this.link = link;
        }

        // TODO: Execute left on playable sprite
        public void Execute(GameTime gametime)
        {
            link.MoveLeft();
        }
    }
}