﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zelda.Projectiles;
using Zelda.Projectiles.Classes;
using Zelda.Rooms;
using Zelda.Sprites;

namespace Zelda.NPCs.Classes
{
    public abstract class EnemyMultiDirection : INPC
    {
        public ISprite Sprite { get { return sprite; } }
        public bool Dead { get { return dead; } }
        public int Damage { get { return damage; } }

        protected ISprite sprite;
        protected Vector2 position;
        protected Vector2 moveDirection = new Vector2(0, 0);
        protected int health;
        protected bool dead;
        protected double blocksPerSecondSpeed;
        private double damageCooldown = 0; // seconds
        private int damage;

        public EnemyMultiDirection(ISprite sprite, Vector2 position, int health, double blocksPerSecondSpeed)
        {
            this.sprite = sprite;
            this.position = position;

            this.health = health;
            this.blocksPerSecondSpeed = blocksPerSecondSpeed;
        }

        // additional update features that differ between enemies
        protected virtual void UpdateAdditional(GameTime gameTime)
        {

        }

        public void Update(GameTime gameTime)
        {
            double timeDelta = gameTime.ElapsedGameTime.TotalSeconds;

            // Update position based on move direction
            float magnitude = moveDirection.Length();
            if (magnitude > 0 && damageCooldown <= 0) // do not move when damaged
            {
                double pixelsDelta = blocksPerSecondSpeed * Settings.BLOCK_SIZE * timeDelta;
                float xDelta = (float)(moveDirection.X / magnitude * pixelsDelta);
                float yDelta = (float)(moveDirection.Y / magnitude * pixelsDelta);
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
        public void Draw(SpriteBatch spriteBatch)
        {
            Color color = damageCooldown <= 0 ? Color.White : Color.Red;
            sprite.Draw(spriteBatch, position + RoomBuilder.Instance.WindowOffset, color);
            if (!appeared)
            {
                appeared = true;
                AppearanceCloud cloud = new AppearanceCloud(position);
                cloud.Draw(spriteBatch);
                ProjectileStorage.Add(cloud);
            }
            DrawAdditional(spriteBatch);
        }

        public virtual void Attack()
        {

        }

        public virtual void Die()
        {
            dead = true;
            ProjectileStorage.Add(new DeathExplosion(position));
            NPCUtil.DropRandomItem(position);
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
