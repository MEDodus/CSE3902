using Microsoft.Xna.Framework;
using System;
using Zelda.Projectiles;
using Zelda.Projectiles.Classes;
using Zelda.Sprites.Factories;

namespace Zelda.NPCs.Classes
{
    public class Dragon : EnemySingleDirection
    {
        private readonly double ATTACK_COOLDOWN_LENGTH = 5;
        private readonly double ATTACK_ANIMATION_LENGTH = 1;

        private double attackCooldown = 0; // seconds
        private bool isAttacking = false;

        public Dragon(Vector2 position) : base(NPCSpriteFactory.NonAttackingDragonSprite(), position, 6, 0.5)
        {

        }

        private double changeDirectionCooldown = 0; // seconds
        private bool wasAttackingLastFrame = false;
        protected override void UpdateAdditional(GameTime gameTime)
        {
            // Move around randomly
            if (changeDirectionCooldown <= 0)
            {
                changeDirectionCooldown = 1;
                NPCUtil.MoveRandomly(this);
            }
            changeDirectionCooldown -= gameTime.ElapsedGameTime.TotalSeconds;

            // Attack randomly
            int rand = new Random().Next(100);
            if (rand < 30)
            {
                Attack();
            }

            // Update attack cooldown/flag
            if (attackCooldown > 0)
            {
                attackCooldown -= gameTime.ElapsedGameTime.TotalSeconds;
                isAttacking = attackCooldown > ATTACK_COOLDOWN_LENGTH - ATTACK_ANIMATION_LENGTH;
            }

            // Update sprite
            if (isAttacking != wasAttackingLastFrame)
            {
                sprite = isAttacking ? NPCSpriteFactory.AttackingDragonSprite() : NPCSpriteFactory.NonAttackingDragonSprite();
            }
            wasAttackingLastFrame = isAttacking;
            sprite.Update(gameTime);
        }

        public override void Attack()
        {
            if (attackCooldown <= 0)
            {
                attackCooldown = ATTACK_COOLDOWN_LENGTH;
                isAttacking = true;
                ProjectileStorage.Add(new Fireball(position, new Vector2(-1, 0)));
                ProjectileStorage.Add(new Fireball(position, new Vector2(-3, 1)));
                ProjectileStorage.Add(new Fireball(position, new Vector2(-3, -1)));
            }
        }
    }
}
