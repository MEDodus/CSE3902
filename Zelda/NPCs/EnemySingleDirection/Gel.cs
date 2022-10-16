using Microsoft.Xna.Framework;
using System;
using Zelda.Sprites.Factories;

namespace Zelda.NPCs.Classes
{
    public class Gel : EnemySingleDirection
    {
        public Gel(Vector2 position) : base(NPCSpriteFactory.GelSprite(), position, 1, 1)
        {

        }

        //private double changeDirectionCooldown = 0; // seconds
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
