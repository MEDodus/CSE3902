using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Drawing;
using Zelda.Achievements;
using Zelda.HUD;
using Zelda.Items;
using Zelda.Projectiles;
using Zelda.Projectiles.Classes;
using Zelda.Rooms;
using Zelda.Sprites;
using Color = Microsoft.Xna.Framework.Color;
using Group = Zelda.NPCs.INPC.Group;

namespace Zelda.NPCs.Classes
{
    public abstract class EnemySingleDirection : INPC
    {
        public ISprite Sprite { get { return sprite; } }
        public bool Dead { get { return dead; } }
        public int Damage { get { return damage; } }

        protected ISprite sprite;
        protected Vector2 position;
        protected Vector2 moveDirection = new Vector2(0, 0);
        public double changeDirectionCooldown = 0;
        protected int health;
        protected bool dead;
        protected double blocksPerSecondSpeed;
        private double damageCooldown = 0; // seconds
        protected int damage;
        protected Group group;

        public EnemySingleDirection(ISprite sprite, Vector2 position, int health, double blocksPerSecondSpeed, Group enemyGroup)
        {
            this.sprite = sprite;
            this.position = position;

            this.health = health;
            this.blocksPerSecondSpeed = blocksPerSecondSpeed;
            this.dead = false;
            this.group = enemyGroup;
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

        bool visible = false;
        public void Draw(SpriteBatch spriteBatch)
        {
            if (visible)
            {
                Color color = damageCooldown <= 0 ? Color.White : Color.Red;
                sprite.Draw(spriteBatch, position + RoomBuilder.Instance.WindowOffset, color);
                DrawAdditional(spriteBatch);
            }
        }

        public void Appear()
        {
            visible = true;
            AppearanceCloud cloud = new AppearanceCloud(position);
            ProjectileStorage.Add(cloud);
        }

        public void Disappear()
        {
            visible = false;
        }

        public abstract void Attack();

        public virtual void Die()
        {
            ProjectileStorage.Add(new DeathExplosion(position));
            this.dead = true;
            AchievementManager.GrantAchievement(Achievement.FirstKill);
        }

        public Item DropItem()
        {
            int itemRow = EnemyCounter.Count;
            EnemyCounter.Increment(); // Increment counter to next row in the table
            int rand = new Random().Next(1, 5);
            switch(rand)
            {
                case 1:
                    return NPCUtil.GetItem(group, itemRow, position);
                case 2:
                case 3:
                case 4:
                default:
                    return null;
            }
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

        public virtual void ChangeDirection(Vector2 direction)
        {
            this.moveDirection = direction;
        }
    }
}
