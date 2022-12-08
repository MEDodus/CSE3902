using Microsoft.Xna.Framework;
using System;
using Zelda.Enemy;
using Zelda.NPCs.Classes;
using Zelda.Projectiles;
using Zelda.Projectiles.Classes;
using Zelda.Sprites.Factories;

namespace Zelda.NPCs.EnemyMultiDirection
{
    internal class OldManAgroState : INPCState
    {
        private OldMan enemy;

        //Projectile Variables
        private readonly double ATTACK_COOLDOWN_LENGTH = 3;
        private readonly double ATTACK_ANIMATION_LENGTH = 1;
        private double attackCooldown = 0; // seconds
        private bool isAttacking = false;

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
            IProjectile fireball = new Fireball(new Vector2(0, 0), new Vector2(1, 0));
            ProjectileStorage.Add(fireball);
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
            enemy.State = new OldManGhostState(enemy);
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
