using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Zelda.Enemy;
using Zelda.NPCs.EnemyMultiDirection;
using Zelda.Projectiles;
using Zelda.Projectiles.Classes;
using Zelda.Sprites;
using Zelda.Sprites.Factories;
using Zelda.Collision;

namespace Zelda.NPCs.Classes
{
    public class Dodongo : INPC
    {
        public ISprite Sprite { get { return sprite; } }
        public bool Dead { get { return dead; } }


        public INPCState state;
        public ISprite sprite;
        protected Vector2 position;
        protected int health;
        protected bool dead;
        protected double blocksPerSecondSpeed;
        private double damageCooldown = 0; // seconds
        private double damageDelay = 0;
        private double changeDirectionCooldown = 0;
        private double attackCooldown = 0; // seconds
        private bool facingRight;

        bool appeared = false;


        public Dodongo(Vector2 position)
        {
            sprite = NPCSpriteFactory.LeftMovingDodongoSprite();
            state = new LeftMovingDodongoState(this);
            this.position = position;
            facingRight = false;

            health = 1;
            blocksPerSecondSpeed = 1;

            this.dead = false;

        }

        public void Update(GameTime gameTime)
        {
            if (changeDirectionCooldown <= 0 && damageDelay <= 0)
            {
                changeDirectionCooldown = 0.5;
                int rand = new Random().Next(1, 5);
                switch (rand)
                {
                    case 1:
                        state.TurnRight();
                        break;
                    case 2:
                        state.TurnLeft();
                        break;
                    case 3:
                        state.TurnUp();
                        break;
                    case 4:
                        state.TurnDown();
                        break;
                }
            }
            changeDirectionCooldown -= gameTime.ElapsedGameTime.TotalSeconds;


            //Take Damage
            if (damageDelay <= 0)
            {
                damageDelay = 1;
                int takeDamage = new Random().Next(100);
                if (takeDamage < 30)
                {
                    state.TakeDamage();
                    //damageDelay = 2;
                }
            }
            damageDelay -= gameTime.ElapsedGameTime.TotalSeconds;


            if (attackCooldown > 0)
            {
                attackCooldown -= gameTime.ElapsedGameTime.TotalSeconds;
                //isAttacking = attackCooldown > ATTACK_COOLDOWN_LENGTH - ATTACK_ANIMATION_LENGTH;
            }

            state.Update(gameTime);
            //state.Draw(spritebatch);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            Color color = damageCooldown <= 0 ? Color.White : Color.Red;
            sprite.Draw(spriteBatch, position, color);
            if (!appeared)
            {
                appeared = true;
                AppearanceCloud cloud = new AppearanceCloud(position);
                cloud.Draw(spriteBatch);
                ProjectileStorage.Add(cloud);
            }
        }
        public void ChangeDirection(Vector2 direction)
        {
            switch (direction)
            {
                case (1, 0):
                    state.TurnRight();
                    break;
                case (-1, 0):
                    state.TurnLeft();
                    break;
                case (0, -1):
                    state.TurnUp();
                    break;
                case (0, 1):
                    state.TurnDown();
                    break;
            }
        }

        public virtual void MoveUp(GameTime gameTime)
        {
            double timeDelta = gameTime.ElapsedGameTime.TotalSeconds;
            double pixelsDelta = blocksPerSecondSpeed * Settings.BLOCK_SIZE * timeDelta;

            position += new Vector2(0, -1 * (float)pixelsDelta);

            sprite.Update(gameTime);
        }
        public void MoveDown(GameTime gameTime)
        {
            double timeDelta = gameTime.ElapsedGameTime.TotalSeconds;
            double pixelsDelta = blocksPerSecondSpeed * Settings.BLOCK_SIZE * timeDelta;

            position += new Vector2(0, (float)pixelsDelta);

            sprite.Update(gameTime);
        }
        public void MoveLeft(GameTime gameTime)
        {
            double timeDelta = gameTime.ElapsedGameTime.TotalSeconds;
            double pixelsDelta = blocksPerSecondSpeed * Settings.BLOCK_SIZE * timeDelta;

            position += new Vector2(-1 * (float)pixelsDelta, 0);

            sprite.Update(gameTime);
        }
        public void MoveRight(GameTime gameTime)
        {
            double timeDelta = gameTime.ElapsedGameTime.TotalSeconds;
            double pixelsDelta = blocksPerSecondSpeed * Settings.BLOCK_SIZE * timeDelta;

            position += new Vector2((float)pixelsDelta, 0);

            sprite.Update(gameTime);
        }
        public void Attack()
        {
            //implement attack later
        }
        public void TakeDamage(int damage)
        {
            health -= damage;
            changeDirectionCooldown = -1;
            if(health < 0)
            {
                Die();
            }
        }
        public void Die()
        {
            ProjectileStorage.Add(new DeathExplosion(position));
            this.dead = true;
        }

    }
}
