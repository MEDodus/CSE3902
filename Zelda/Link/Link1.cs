using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zelda.Projectiles;
using Zelda.Sprites;
using Zelda.Items;
using Zelda.Rooms;
using Zelda.Inventory;
using Zelda.Sound;

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

        private ILinkState state;
        private ISprite sprite;
        private Vector2 position;
        private Vector2 facingDirection;
        private double swordAttackTimer = 0;
        private IInventory inventory;
        private Health health;
        public Link1()
        {
            Reset();
            inventory = new LinkInventory();
            InventoryBuilder.BuildInventory(inventory);
            health = new Health();
        }

        public void Reset()
        {
            position = RoomBuilder.Instance.WindowPosition + new Vector2(Settings.BLOCK_SIZE * 7.5f, Settings.BLOCK_SIZE * 7);
            state = new LinkFacingUpState(this);
            facingDirection = new Vector2(0, -1);
        }

        public void Update(GameTime gameTime)
        {
            if (swordAttackTimer > 0)
            {
                swordAttackTimer -= gameTime.ElapsedGameTime.TotalSeconds;
            }
            state.Update();
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
        public void TakeDamage(Game1 game, int damage, Vector2 direction)
        {
            health.removeHealth(damage, game);
            state.TakeDamage(game, direction);
            SoundManager.Instance.PlayLinkHurtSound();
        }

        public void UseItem(int itemNum)
        {
            state.UseItem(itemNum);
        }

        private Vector2 getPositionInFrontOfLink(double blocksInFrontOf)
        {
            return position + new Vector2(10, 12) + (facingDirection * Settings.BLOCK_SIZE * (float)blocksInFrontOf);
        }

        public void CreateItem(int itemNum)
        {
            IProjectile item = null;
            IItem type = null;
            Vector2 defaultItemSpawnPos = getPositionInFrontOfLink(0);

            if(itemNum == 0)
            {
                if (swordAttackTimer <= 0)
                {
                    swordAttackTimer = 0.35;
                    // adjust spawn position
                    Vector2 spawnPos = defaultItemSpawnPos;
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
                    item = new Zelda.Projectiles.Classes.Sword(spawnPos, facingDirection, 0.3);
                    type = new Items.Classes.Sword(new Vector2());
                }
                if (item != null && inventory.Contains(type) && inventory.GetItem(type).UseItem(inventory, health, defaultItemSpawnPos, facingDirection))
                {
                    ProjectileStorage.Add(item);
                }
            } else
            {
                LinkItemHandler.UseItem(itemNum, facingDirection, health, inventory, getPositionInFrontOfLink(0));
            }
        }

        public bool AddToInventory(IItem item)
        {
            return inventory.AddItem(item, 1);
        }
    }
}
