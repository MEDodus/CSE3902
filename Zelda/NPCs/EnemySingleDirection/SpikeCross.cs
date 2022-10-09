using Microsoft.Xna.Framework;
using System;
using Zelda.Sprites.Factories;

namespace Zelda.NPCs.Classes
{
    public class SpikeCross : EnemySingleDirection
    {
        public SpikeCross(Vector2 position) : base(NPCSpriteFactory.SpikeCross(), position, int.MaxValue, 8)
        {

        }

        private double changeDirectionCooldown = 0; // seconds
        private int timesChangedDirection = 0;
        protected override void UpdateAdditional(GameTime gameTime)
        {
            if (changeDirectionCooldown <= 0)
            {
                changeDirectionCooldown = 1;
                timesChangedDirection++;
                if (timesChangedDirection % 2 == 0)
                {
                    MoveLeft();
                }
                else
                {
                    MoveRight();
                }
            }
            changeDirectionCooldown -= gameTime.ElapsedGameTime.TotalSeconds;

            sprite.Update(gameTime);
        }

        public override void Attack()
        {
            throw new NotImplementedException();
        }

        public override void TakeDamage(int damage)
        {
            // spike traps are invincible
        }
    }
}
