using Microsoft.Xna.Framework;
using System;
using Zelda.Sprites.Factories;
using Group = Zelda.NPCs.INPC.Group;

namespace Zelda.NPCs.Classes
{
    public class SpikeCross : EnemySingleDirection
    {
        private readonly double HORIZONTAL_CHANGE_DIRECTION_COOLDOWN_LENGTH = 2.2;
        private readonly double VERTICAL_CHANGE_DIRECTION_COOLDOWN_LENGTH = 1.2;
        private readonly double USED_CHANGE_DIRECTION_COOLDOWN_LENGTH;

        public SpikeCross(Vector2 position, Vector2 moveDirection) : base(NPCSpriteFactory.SpikeCross(), position, int.MaxValue, 5, Group.X)
        {
            damage = 1;
            this.moveDirection = moveDirection;
            USED_CHANGE_DIRECTION_COOLDOWN_LENGTH = moveDirection.Y == 0 ? HORIZONTAL_CHANGE_DIRECTION_COOLDOWN_LENGTH : VERTICAL_CHANGE_DIRECTION_COOLDOWN_LENGTH;
            changeDirectionCooldown = USED_CHANGE_DIRECTION_COOLDOWN_LENGTH;
        }

        protected override void UpdateAdditional(GameTime gameTime, double changeDirectionCooldown)
        {
            if (base.changeDirectionCooldown <= 0)
            {
                base.changeDirectionCooldown = USED_CHANGE_DIRECTION_COOLDOWN_LENGTH;
                moveDirection = -moveDirection;
            }
            base.changeDirectionCooldown -= gameTime.ElapsedGameTime.TotalSeconds;
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

        public override void ChangeDirection(Vector2 direction)
        {
            
        }
    }
}
