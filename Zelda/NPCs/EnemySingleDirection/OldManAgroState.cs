using Microsoft.Xna.Framework;
using System;
using System.ComponentModel;
using Zelda.Enemy;
using Zelda.NPCs.Classes;
using Zelda.NPCs.FriendlyNPCs;
using Zelda.Projectiles;
using Zelda.Projectiles.Classes;
using Zelda.Sprites.Factories;

namespace Zelda.NPCs.EnemyMultiDirection
{
    internal class OldManAgroState : INPCState
    {
        private OldMan enemy;

        //Projectile Variables
        private readonly double ATTACK_COOLDOWN_LENGTH = 1;
        private readonly double ATTACK_ANIMATION_LENGTH = 1;
        private double attackCooldown = 0; // seconds
        private bool isAttacking = false;
        protected readonly int ATTACK_DIR_POS = 1;
        protected readonly int ATTACK_DIR_NEG = -1;
        protected readonly int ATTACK_DIR_ZERO = 0;

        public OldManAgroState(OldMan oldMan)
        {
            enemy = oldMan;
            enemy.Sprite = NPCSpriteFactory.OldManSprite();
            enemy.Health = enemy.OLDMAN_AGRO_HEALTH;
        }

        public void TurnLeft()
        {
        }

        public void TurnRight()
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
            IProjectile fireball0 = new Fireball(enemy.Position, new Vector2(ATTACK_DIR_POS, ATTACK_DIR_ZERO));
            IProjectile fireball1 = new Fireball(enemy.Position, new Vector2(ATTACK_DIR_POS, ATTACK_DIR_POS));
            IProjectile fireball2 = new Fireball(enemy.Position, new Vector2(ATTACK_DIR_ZERO, ATTACK_DIR_POS));
            IProjectile fireball3 = new Fireball(enemy.Position, new Vector2(ATTACK_DIR_NEG, ATTACK_DIR_POS));
            IProjectile fireball4 = new Fireball(enemy.Position, new Vector2(ATTACK_DIR_NEG, ATTACK_DIR_ZERO));
            IProjectile fireball5 = new Fireball(enemy.Position, new Vector2(ATTACK_DIR_NEG, ATTACK_DIR_NEG));
            IProjectile fireball6 = new Fireball(enemy.Position, new Vector2(ATTACK_DIR_ZERO, ATTACK_DIR_NEG));
            IProjectile fireball7 = new Fireball(enemy.Position, new Vector2(ATTACK_DIR_POS, ATTACK_DIR_NEG));


            ProjectileStorage.Add(fireball0);
            ProjectileStorage.Add(fireball1);
            ProjectileStorage.Add(fireball2);
            ProjectileStorage.Add(fireball3);
            ProjectileStorage.Add(fireball4);
            ProjectileStorage.Add(fireball5);
            ProjectileStorage.Add(fireball6);
            ProjectileStorage.Add(fireball7);

        }
        public void TakeDamage()
        {
            enemy.Health--;
            if (enemy.Health <= 0)
            {
                KilledEnemyState();
            }
        }
        public void KilledEnemyState()
        {
            FriendlyNPCManager.Instance.FriendlyNPCs.Add(new GhostFollower());
            enemy.Dead = true;
        }

        public void Update(GameTime gameTime)
        {

            if (attackCooldown > 0)
            {
                attackCooldown -= gameTime.ElapsedGameTime.TotalSeconds;
                //isAttacking = attackCooldown > ATTACK_COOLDOWN_LENGTH - ATTACK_ANIMATION_LENGTH;
            }
            else
            {
                Attack();
                attackCooldown = ATTACK_COOLDOWN_LENGTH;
            }
        }
    }
}
