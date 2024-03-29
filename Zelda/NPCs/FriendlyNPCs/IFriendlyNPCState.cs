﻿using Microsoft.Xna.Framework;

namespace Zelda.NPCs.FriendlyNPCs
{
    public interface IFriendlyNPCState
    {
        void TurnLeft();
        void TurnRight();
        void TurnUp();
        void TurnDown();
        void Attack();
        void TakeDamage();
        public void Update(Game1 game, GameTime gameTime);
    }
}

