using Microsoft.Xna.Framework;
using System;
using Zelda.Sprites.Factories;

namespace Zelda.NPCs.Classes
{
    public class Bat : EnemySingleDirection
    {
        public Bat(Vector2 position) : base(NPCSpriteFactory.BatSprite(), position, 1, 3)
        {

        }

        //double changeDirectionCooldown = 0; // seconds
        protected override void UpdateAdditional(GameTime gameTime, Double changeDirectionCooldown)
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
