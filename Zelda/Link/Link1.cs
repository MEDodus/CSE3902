using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zelda.Projectiles;
using Zelda.Sprites;
using Zelda.Items;
using Zelda.Rooms;
using Zelda.Inventory;
using Zelda.Sound;
using Zelda.Items.Classes;
using Zelda.ItemEffects;

namespace Zelda.Link
{
    public class Link1 : ILink
    {
        public ILinkState State { get { return state; } set { state = value; } }
        public ISprite Sprite { get { return sprite; } set { sprite = value; } }
        public Vector2 Position { get { return position; } set { position = value; } }
        public Vector2 Direction { get { return facingDirection;  } }
        public IInventory Inventory { get { return inventory; } }
        public Health Health { get { return health; } }
        public int PlayerNumber { get { return playerNumber; } }
        public ItemTimer ItemTimer { get { return itemTimer; } set { itemTimer = value; } }

        private Game1 game;
        private ILinkState state;
        private ISprite sprite;
        private Vector2 position;
        private Vector2 facingDirection;
        private double primaryAttackTimer = 0;
        private double secondaryAttackTimer = 0;
        private IInventory inventory;
        private Health health;
        private int playerNumber;
        private ItemTimer itemTimer;


        private readonly double ATTACK_TIMER_LENGTH = 0.35;
        private readonly double BEAM_ATTACK_TIMER_LENGTH = 0.7;

        public Link1(Game1 game, int number)
        {
            playerNumber = number;
            this.game = game;
            Reset();
            if (playerNumber == 1)
            {
                inventory = new LinkInventory();
                InventoryBuilder.BuildInventory(inventory);
                health = new Health();
                itemTimer = new ItemTimer();
            } else
            {
                inventory = game.Link.Inventory;
                health = game.Link.Health;
                itemTimer = game.Link.ItemTimer;
            }
        }

        public void Reset()
        {
            if(playerNumber == 1)
            {
                position = RoomBuilder.Instance.WindowPosition + new Vector2(Settings.BLOCK_SIZE * 7.5f, Settings.BLOCK_SIZE * 7);
            } else
            {
                position = RoomBuilder.Instance.WindowPosition + new Vector2(Settings.BLOCK_SIZE * 8.5f, Settings.BLOCK_SIZE * 7);
            }
            state = new LinkFacingUpState(this);
            facingDirection = new Vector2(0, -1);
        }

        public void Update(GameTime gameTime)
        {
            if (primaryAttackTimer > 0)
            {
                primaryAttackTimer -= gameTime.ElapsedGameTime.TotalSeconds;
            }
            if (secondaryAttackTimer > 0)
            {
                secondaryAttackTimer -= gameTime.ElapsedGameTime.TotalSeconds;
            } 
            if (itemTimer.Duration > 0)
            {
                itemTimer.Duration -= 1;
                if (state is LinkMovingUpState)
                {
                    ((LinkMovingUpState)state).Update(Settings.SPEED_MULT);
                }
                else if (state is LinkMovingDownState)
                {
                    ((LinkMovingDownState)state).Update(Settings.SPEED_MULT);
                }
                else if (state is LinkMovingLeftState)
                {
                    ((LinkMovingLeftState)state).Update(Settings.SPEED_MULT);
                }
                else if (state is LinkMovingRightState)
                {
                    ((LinkMovingRightState)state).Update(Settings.SPEED_MULT);
                }
                else
                {
                    state.Update();
                }
            } else
            {
                state.Update();
            }
            sprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, position + RoomBuilder.Instance.WindowOffset);
        }

        public void MoveUp()
        {
            state.MoveUp();
            facingDirection = new Vector2(0, -1);
        }
        public void MoveDown()
        {
            state.MoveDown();
            facingDirection = new Vector2(0, 1);
        }
        public void MoveLeft()
        {
            state.MoveLeft();
            facingDirection = new Vector2(-1, 0);
        }
        public void MoveRight()
        {
            state.MoveRight();
            facingDirection = new Vector2(1, 0);
        }
        public void TakeDamage(int damage, Vector2 direction)
        {
            health.removeHealth(damage, game);
            state.TakeDamage(game, direction);
            SoundManager.Instance.PlayLinkHurtSound();
        }
        public bool AddToInventory(Item item)
        {
            if(item is Bomb)
            {
                return inventory.AddItem(item, 4);
            }
            return inventory.AddItem(item, 1);
        }
        public void Attack()
        {
            state.Attack();
        }
        public void AttackSecondary()
        {
            state.AttackSecondary();
        }

        // Item usage (called in ILinkState)
        private Vector2 getPositionInFrontOfLink(double blocksInFrontOf)
        {
            return position + new Vector2(10, 12) + (facingDirection * Settings.BLOCK_SIZE * (float)blocksInFrontOf);
        }
        public bool TryUsePrimary()
        {
            if (primaryAttackTimer <= 0)
            {
                primaryAttackTimer = health.CurrentHealth == health.MaxHealth ? BEAM_ATTACK_TIMER_LENGTH : ATTACK_TIMER_LENGTH;
                // adjust spawn position
                Vector2 spawnPos = getPositionInFrontOfLink(0);
                if (facingDirection.Equals(new Vector2(1, 0)))
                {
                    spawnPos += new Vector2(-10, 0);
                }
                else if (facingDirection.Equals(new Vector2(0, 1)))
                {
                    spawnPos += new Vector2(0, -15);
                }
                else if (facingDirection.Equals(new Vector2(0, -1)))
                {
                    spawnPos += new Vector2(0, -10);
                }
                Item sword = new Items.Classes.Sword(new Vector2());
                if (inventory.Contains(sword) && inventory.GetItem(sword).UseItem(this, spawnPos, facingDirection))
                {
                    ProjectileStorage.Add(new Projectiles.Classes.Sword(spawnPos, facingDirection, 0.3));
                    return true;
                }
            }
            return false;
        }
        public bool TryUseSecondary()
        {
            Item secondary = inventory.Secondary;
            Vector2 spawnPos = getPositionInFrontOfLink(0);
            if (secondary != null && secondaryAttackTimer <= 0 && secondary.UseItem(this, spawnPos, facingDirection))
            {
                secondaryAttackTimer = ATTACK_TIMER_LENGTH;
                Projectile projectile = secondary.CreateProjectile(position, facingDirection);
                if (projectile != null)
                {
                    ProjectileStorage.Add(projectile);
                    return true;
                }
            }
            return false;
        }

        public void MarioAttack()
        {
            throw new System.NotImplementedException();
        }
    }
}
