using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using Zelda.Controllers;
using Zelda.Projectiles;
using Zelda.Projectiles.Classes;
using Zelda.Sprites;
using Zelda.Items;
using Zelda.Rooms;
using Zelda.Inventory;
using System;
using Zelda.Items.Classes;
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
        private HashSet<Keys> movementKeys = new HashSet<Keys>();
        private IInventory inventory;
        private Health health;
        public Link1()
        {
            Reset();
            movementKeys.Add(Keys.W);
            movementKeys.Add(Keys.A);
            movementKeys.Add(Keys.S);
            movementKeys.Add(Keys.D);
            movementKeys.Add(Keys.Up);
            movementKeys.Add(Keys.Left);
            movementKeys.Add(Keys.Down);
            movementKeys.Add(Keys.Right);
            inventory = new LinkInventory();
            InventoryBuidler.BuildInventory(inventory);
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

        private bool TryMove(Vector2 newDirection)
        {
            // Don't set direction if multiple keys are being pressed unless the direction is the same as the current direction
            // also don't move if currently attacking with the sword
            bool success = (!KeyboardController.AreMultipleKeysInSetPressed(movementKeys) || newDirection.Equals(facingDirection))
                && swordAttackTimer <= 0;
            if (success)
            {
                facingDirection = newDirection;
            }
            return success;
        }

        public void MoveUp()
        {
            if (TryMove(new Vector2(0, -1)))
            {
                state.MoveUp();
            }
        }
        public void MoveDown()
        {
            if (TryMove(new Vector2(0, 1)))
            {
                state.MoveDown();
            }
        }
        public void MoveLeft()
        {
            if (TryMove(new Vector2(-1, 0)))
            {
                state.MoveLeft();
            }
        }
        public void MoveRight()
        {
            if (TryMove(new Vector2(1, 0)))
            {
                state.MoveRight();
            }
        }
        public void TakeDamage(Game1 game, int damage, Vector2 direction)
        {
            health.removeHealth(damage);
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
            switch (itemNum)
            {
                case 0:
                    // base attack
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
                        type = new Items.Classes.Sword(new Vector2());
                    }
                    break;
                case 1:
                    item = new SwordBeam(defaultItemSpawnPos, facingDirection);
                    type = new Zelda.Items.Classes.Sword(new Vector2());
                    break;
                case 2:
                    item = new Projectiles.Classes.Arrow(defaultItemSpawnPos, facingDirection);
                    type = new Zelda.Items.Classes.Bow(new Vector2()); // When using an arrow we need a bow
                    break;
                case 3:
                    item = new Projectiles.Classes.SilverArrow(defaultItemSpawnPos, facingDirection);
                    type = new Zelda.Items.Classes.Bow(new Vector2()); // When using an arrow we need a bow
                    break;
                case 4:
                    item = new Projectiles.Classes.Boomerang(defaultItemSpawnPos, facingDirection, ProjectileBehavior.Friendly);
                    type = new Zelda.Items.Classes.Boomerang(new Vector2());
                    break;
                case 5:
                    item = new Projectiles.Classes.MagicalBoomerang(defaultItemSpawnPos, facingDirection);
                    type = new Zelda.Items.Classes.MagicalBoomerang(new Vector2());
                    break;
                case 6:
                    item = new Projectiles.Classes.Bomb(getPositionInFrontOfLink(1.5));
                    type = new Zelda.Items.Classes.Bomb(new Vector2());
                    break;
                case 7:
                    item = new CandleFlame(defaultItemSpawnPos, facingDirection);
                    type = new Zelda.Items.Classes.BlueCandle(new Vector2());
                    break;
            }
            if (item != null && inventory.FindInSet(type) && inventory.GetItem(type).UseItem(inventory, health, defaultItemSpawnPos, facingDirection))
            {
                ProjectileStorage.Add(item);
            }
        }

        public bool AddToInventory(IItem item)
        {
            return inventory.AddItem(item, 1);
        }
    }
}
