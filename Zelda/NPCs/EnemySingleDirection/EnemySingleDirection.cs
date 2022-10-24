using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zelda.Projectiles;
using Zelda.Projectiles.Classes;
using Zelda.Sprites;

namespace Zelda.NPCs.Classes
{
    public abstract class EnemySingleDirection : INPC
    {
        public ISprite Sprite { get { return sprite; } }

        protected ISprite sprite;
        protected Vector2 position;
        protected Vector2 moveDirection = new Vector2(0, 0);
        public double changeDirectionCooldown = 0;
        protected int health;
        protected double blocksPerSecondSpeed;
        private double damageCooldown = 0; // seconds

        public EnemySingleDirection(ISprite sprite, Vector2 position, int health, double blocksPerSecondSpeed)
        {
            this.sprite = sprite;
            this.position = position;

            this.health = health;
            this.blocksPerSecondSpeed = blocksPerSecondSpeed;
        }

        // additional update features that differ between enemies
        protected virtual void UpdateAdditional(GameTime gameTime, double changeDirectionCooldown)
        {

        }

        public void Update(GameTime gameTime)
        {
            double timeDelta = gameTime.ElapsedGameTime.TotalSeconds;

            // Update position based on move direction
            float magnitude = moveDirection.Length();
            if (magnitude > 0)
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

            UpdateAdditional(gameTime, changeDirectionCooldown);
        }

        // additional draw features that differ between enemies
        protected virtual void DrawAdditional(SpriteBatch spriteBatch)
        {

        }

        bool appeared = false;
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
                NPCProjectiles.AddEnemyProjectile(cloud);
            }
            DrawAdditional(spriteBatch);
        }

        public abstract void Attack();

        public virtual void Die()
        {
            ProjectileStorage.Add(new DeathExplosion(position));
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

        public virtual void ChangeDirection()
        {
            changeDirectionCooldown = -1;
        }
    }
}
