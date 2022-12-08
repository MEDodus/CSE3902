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
using Zelda.Rooms;
using System.Text.RegularExpressions;
using Group = Zelda.NPCs.INPC.Group;
using Zelda.Items;

namespace Zelda.NPCs.Classes
{
    public class Goriya : INPC
    {
        public ISprite Sprite { get { return sprite; } }
        public bool Dead { get { return dead; } }
        public int Damage { get { return damage; } }


        public INPCState state;
        public ISprite sprite;
        protected Vector2 position;
        protected int health;
        protected bool dead;
        protected double blocksPerSecondSpeed;
        private double damageCooldown = 0; // seconds
        private double damageDelay = 0;
        private double changeDirectionCooldown = 0;
        int damage;
        protected Group group;
        bool appeared = false;


        //Projectile Variables
        private readonly double ATTACK_COOLDOWN_LENGTH = 3;
        private readonly double ATTACK_ANIMATION_LENGTH = 1;
        private double attackCooldown = 0; // seconds
        private bool isAttacking = false;

        public Goriya(Vector2 position)
        {
            sprite = NPCSpriteFactory.LeftGoriyaSprite();
            state = new LeftMovingGoriyaState(this);
            this.position = position;

            health = 2;
            blocksPerSecondSpeed = 1;
            this.dead = false;
            damage = 1;
            this.group = Group.B;
        }

        public void Update(GameTime gameTime)
        {
            //Movement
            if (changeDirectionCooldown <= 0 && damageDelay <= 0)
            {
                changeDirectionCooldown = 0.5;
                int dir = new Random().Next(1, 5);
                switch (dir)
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

            if (damageCooldown > 0)
            {
                damageCooldown -= gameTime.ElapsedGameTime.TotalSeconds;
            }
            
            //Attack
            int decideAttack = new Random().Next(100);
            if (decideAttack < 100)
            {
                state.Attack();
            }

            if (attackCooldown > 0)
            {
                attackCooldown -= gameTime.ElapsedGameTime.TotalSeconds;
                //isAttacking = attackCooldown > ATTACK_COOLDOWN_LENGTH - ATTACK_ANIMATION_LENGTH;
            }

            state.Update(gameTime);
            //state.Draw(spritebatch);
        }
        bool visible = false;
        public void Draw(SpriteBatch spriteBatch)
        {
            if (visible)
            {
                Color color = damageCooldown <= 0 ? Color.White : Color.Red;
                sprite.Draw(spriteBatch, position + RoomBuilder.Instance.WindowOffset, color);
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

        public void ChangeDirection(Vector2 direction)
        {
            switch (direction)
            {
                case (1,0):
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
        public void MoveUp(GameTime gameTime)
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
        public void Attack(Vector2 direction)
        {
            if (attackCooldown <= 0)
            {
                attackCooldown = ATTACK_COOLDOWN_LENGTH;
                isAttacking = true;
                IProjectile boomerang = new Boomerang(position, direction, ProjectileBehavior.Enemy);
                ProjectileStorage.Add(boomerang);
            }
        }
        public void TakeDamage(int damage)
        {
            if (damageCooldown <= 0)
            {
                damageCooldown = 0.5;
                health -= damage;
                changeDirectionCooldown = -1;
                if (health < 0)
                {
                    Die();
                }
            }
        }
        public void Die()
        {
            ProjectileStorage.Add(new DeathExplosion(position));
            this.dead = true;
        }

        public IItem DropItem()
        {
            IItem item = NPCUtil.GetItem(group, EnemyCounter.Count, position);
            EnemyCounter.Increment(); // Increment counter to next row in the table
            return item;

            // Uncomment for chance at drop, above makes it 100% chance, below makes it 25% chance at drop
            /*int rand = new Random().Next(1, 5);
            switch(rand)
            {
                case 1:
                    return NPCUtil.GetItem(group, EnemyCounter.Count, position);
                case 2:
                case 3:
                case 4:
                default:
                    return null;
            }*/
        }

    }
}
