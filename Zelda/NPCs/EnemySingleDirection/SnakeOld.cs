﻿using Microsoft.Xna.Framework;
using System;
using Zelda.Sprites.Factories;

namespace Zelda.NPCs.Classes
{
    public class SnakeOld : EnemySingleDirection
    {
        public SnakeOld(Vector2 position) : base(NPCSpriteFactory.LeftSnakeSprite(), position, 1, 3)
        {

        }

        //double changeDirectionCooldown = 0; // seconds
        protected override void UpdateAdditional(GameTime gameTime, double changeDirectionCooldown)
        {
            if (changeDirectionCooldown <= 0)
            {
                changeDirectionCooldown = 0.5;
                NPCUtil.MoveRandomly(this);
            }
            changeDirectionCooldown -= gameTime.ElapsedGameTime.TotalSeconds;

            sprite.Update(gameTime);
        }

        public override void Attack()
        {
            throw new NotImplementedException();
        }
    }
}
