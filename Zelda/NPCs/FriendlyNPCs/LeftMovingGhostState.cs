using Microsoft.Xna.Framework;
using Zelda.Enemy;
using Zelda.NPCs.Classes;
using Zelda.Sprites.Factories;
using Zelda.NPCs.FriendlyNPCs;
using Zelda.Projectiles.Classes;
using Zelda.Projectiles;

namespace Zelda.NPCs.EnemyMultiDirection
{
    public class LeftMovingGhostState : IFriendlyNPCState
    {
        protected GhostFollower ghost;
        protected Vector2 moveDirection = new Vector2(1, 0);
        protected Vector2 oldPosition;
        protected double attackCooldown;

        protected readonly int ATTACK_DIR_POS = 1;
        protected readonly int ATTACK_DIR_NEG = -1;
        protected readonly int ATTACK_DIR_ZERO = 0;
        protected readonly int ATTACK_COOLDOWN = 5;

        public LeftMovingGhostState(GhostFollower ghost)
        {
            this.ghost = ghost;
            this.ghost.Sprite = NPCSpriteFactory.LeftGhostFollower();
            attackCooldown = ATTACK_COOLDOWN;
        }

        public void TurnRight()
        {
            ghost.State = new RightMovingGhostState(ghost);

        }

        public void TurnLeft()
        {
        }

        public void TurnDown()
        {
        }

        public void TurnUp()
        {
        }

        public void Attack()
        {
            ghost.State = new LeftAttackingGhostState(ghost);
        }

        //Ghost can neither take damage or die - both methods do nothing
        public void TakeDamage()
        {
        }
        public void KilledEnemyState()
        {
        }

        public void Update(GameTime gameTime) { }
        public void Update(Game1 game, GameTime gameTime)
        {
            oldPosition = ghost.Position;
            ghost.Position = game.Link.Position + new Vector2(30, -30);
            DecideAttack(gameTime);
            CheckIfTurned();

        }

        protected void CheckIfTurned()
        {
            if (oldPosition.X < ghost.Position.X - 5)
            {
                TurnRight();
            }
        }
        protected void DecideAttack(GameTime gameTime)
        {
            attackCooldown -= gameTime.ElapsedGameTime.TotalSeconds;
            if (attackCooldown < 0)
            {
                attackCooldown = ATTACK_COOLDOWN;
                Attack();
            }
        }
    }
}
