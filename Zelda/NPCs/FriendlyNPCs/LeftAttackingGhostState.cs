using Microsoft.Xna.Framework;
using Zelda.Enemy;
using Zelda.NPCs.Classes;
using Zelda.Sprites.Factories;
using Zelda.NPCs.FriendlyNPCs;
using Zelda.Projectiles.Classes;
using Zelda.Projectiles;
using Zelda.NPCs.FriendlyNPCs;

namespace Zelda.NPCs.EnemyMultiDirection
{
    public class LeftAttackingGhostState : IFriendlyNPCState
    {
        protected GhostFollower ghost;
        protected Vector2 moveDirection = new Vector2(1, 0);
        protected double attackAnimationTime;

        protected readonly int ATTACK_DIR_POS = 1;
        protected readonly int ATTACK_DIR_NEG = -1;
        protected readonly int ATTACK_DIR_ZERO = 0;
        private readonly double ATTACK_ANIMATION_LENGTH = 1;

        public LeftAttackingGhostState(GhostFollower ghost)
        {
            this.ghost = ghost;
            this.ghost.Sprite = NPCSpriteFactory.LeftAttackGhostFollower();
        }

        public void TurnRight()
        {
            ghost.State = new RightMovingGhostState(ghost);
        }

        public void TurnLeft()
        {
        }

        //Ghost only has sprites for left and right movements - methods empty
        public void TurnDown()
        {
        }

        public void TurnUp()
        {
        }

        public void Attack()
        {
            IProjectile fireball0 = new Fireball(ghost.Position + new Vector2(-100, 0), new Vector2(ATTACK_DIR_POS, ATTACK_DIR_ZERO));
            IProjectile fireball1 = new Fireball(ghost.Position + new Vector2(-100, 0), new Vector2(ATTACK_DIR_POS, ATTACK_DIR_POS));
            IProjectile fireball2 = new Fireball(ghost.Position + new Vector2(-100, 0), new Vector2(ATTACK_DIR_ZERO, ATTACK_DIR_POS));


            ProjectileStorage.Add(fireball0);
            ProjectileStorage.Add(fireball1);
            ProjectileStorage.Add(fireball2);
            attackAnimationTime = ATTACK_ANIMATION_LENGTH;
        }

        //Ghost can neither take damage or die - methods empty
        public void TakeDamage()
        {
        }
        public void KilledEnemyState()
        {
        }

        public void Update(GameTime gameTime) { }
        public void Update(Game1 game, GameTime gameTime)
        {
            ghost.Position = game.Link.Position + new Vector2(30, -30);
            attackAnimationTime -= gameTime.ElapsedGameTime.TotalSeconds;
            if (attackAnimationTime < 0)
            {
                TurnLeft();
            }
        }
    }
}
