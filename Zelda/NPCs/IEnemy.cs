﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zelda.Sprites;

namespace Zelda.NPCs
{
    public abstract class IEnemy : INPC
    {
        protected Vector2 moveDirection = new Vector2(0, 0);
        protected int health;
        protected double speed; // blocks per second
        private double damageCooldown = 0; // seconds

        public IEnemy(ISprite sprite, Vector2 position, int health, double speed) : base(sprite, position)
        {
            this.health = health;
            this.speed = speed;
        }

        // additional update features that differ between enemies
        protected virtual void UpdateAdditional(GameTime gameTime)
        {

        }

        public override void Update(GameTime gameTime)
        {
            double timeDelta = gameTime.ElapsedGameTime.TotalSeconds;

            // Update position based on move direction
            float magnitude = moveDirection.Length();
            if (magnitude > 0)
            {
                double pixelsDelta = speed * Settings.BLOCK_SIZE * timeDelta;
                float xDelta = (float)((moveDirection.X / magnitude) * pixelsDelta);
                float yDelta = (float)((moveDirection.Y / magnitude) * pixelsDelta);
                position += new Vector2(xDelta, yDelta);
            }

            // Update damage cooldown timer
            if (damageCooldown > 0)
            {
                damageCooldown -= timeDelta;
            }

            UpdateAdditional(gameTime);
        }

        // additional draw features that differ between enemies
        protected virtual void DrawAdditional(SpriteBatch spriteBatch)
        {

        }

        bool appeared = false;
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (!appeared)
            {
                appeared = true;
                // TODO: appearance cloud
            }
            Color color = damageCooldown <= 0 ? Color.White : Color.Red;
            sprite.Draw(spriteBatch, position, color);
            DrawAdditional(spriteBatch);
        }

        public abstract void Attack();

        public virtual void Die()
        {
            // TODO: death explosion
        }

        public virtual void TakeDamage(int damage)
        {
            if (damageCooldown <= 0)
            {
                damageCooldown = 0.5;
                health -= damage;
                if (health <= 0)
                {
                    Die();
                }
            }
        }

        public virtual void MoveRight()
        {
            moveDirection = new Vector2(1, 0);
        }

        public virtual void MoveLeft()
        {
            moveDirection = new Vector2(-1, 0);
        }

        public virtual void MoveUp()
        {
            moveDirection = new Vector2(0, 1);
        }

        public virtual void MoveDown()
        {
            moveDirection = new Vector2(0, -1);
        }
    }
}
