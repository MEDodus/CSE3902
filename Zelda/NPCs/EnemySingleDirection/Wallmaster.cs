using Microsoft.Xna.Framework;
using System;
using Zelda.Sprites.Factories;

namespace Zelda.NPCs.Classes
{
    public class Wallmaster : EnemySingleDirection
    {
        public Wallmaster(Vector2 position) : base(NPCSpriteFactory.WallmasterSprite(), position, 3, 1)
        {

        }

        private double changeDirectionCooldown = 0; // seconds
        protected override void UpdateAdditional(GameTime gameTime)
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
