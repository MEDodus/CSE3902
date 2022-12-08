using Microsoft.Xna.Framework;
using System;
using Zelda.Sprites.Factories;
using Group = Zelda.NPCs.INPC.Group;

namespace Zelda.NPCs.Classes
{
    public class Skeleton : EnemySingleDirection
    {
        public Skeleton(Vector2 position) : base(NPCSpriteFactory.SkeletonSprite(), position, 2, 3, Group.C)
        {
            damage = 1;
        }

        //private double changeDirectionCooldown = 0; // seconds
        protected override void UpdateAdditional(GameTime gameTime, double changeDirectionCooldown)
        {
            if (base.changeDirectionCooldown <= 0)
            {
                base.changeDirectionCooldown = 1.5;
                NPCUtil.MoveRandomly(this);
            }
            base.changeDirectionCooldown -= gameTime.ElapsedGameTime.TotalSeconds;

            sprite.Update(gameTime);
        }

        public override void Attack()
        {
            throw new NotImplementedException();
        }
    }
}
