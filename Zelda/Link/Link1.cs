using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using Zelda.Collision.Handlers;
using Zelda.Controllers;
using Zelda.Projectiles;
using Zelda.Projectiles.Classes;
using Zelda.Sprites;
using Zelda.Utilities;

namespace Zelda.Link
{
    public class Link1 : ILink
    {
        public ILinkState State { get { return state; } set { state = value; } }
        public ISprite Sprite { get { return sprite; } set { sprite = value; } }
        public Vector2 Position { get { return position; } set { position = value; } }
        public Vector2 Direction { get { return facingDirection;  } }

        private ILinkState state;
        private ISprite sprite;
        private Vector2 position;
        private Vector2 facingDirection;
        private double swordAttackTimer = 0;
        private HashSet<Keys> movementKeys = new HashSet<Keys>();

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
        }

        public void Reset()
        {
            position = new Vector2(475, 500);
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
            sprite.Draw(spriteBatch, position);
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
        public void TakeDamage(Game1 game)
        {
            state.TakeDamage(game);
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
                        if (facingDirection.Equals(new Vector2(-1, 0)))
                        {
                            spawnPos += new Vector2(-20, 0);
                        }
                        else if (facingDirection.Equals(new Vector2(1, 0)))
                        {
                            spawnPos += new Vector2(-10, 0);
                        }
                        else
                        {
                            spawnPos += new Vector2(0, -20);
                        }
                        item = new Sword(spawnPos, facingDirection, 0.3);
                    }
                    break;
                case 1:
                    item = new SwordBeam(defaultItemSpawnPos, facingDirection);
                    break;
                case 2:
                    item = new Arrow(defaultItemSpawnPos, facingDirection);
                    break;
                case 3:
                    item = new SilverArrow(defaultItemSpawnPos, facingDirection);
                    break;
                case 4:
                    item = new Boomerang(defaultItemSpawnPos, facingDirection, ProjectileBehavior.Friendly);
                    break;
                case 5:
                    item = new MagicalBoomerang(defaultItemSpawnPos, facingDirection);
                    break;
                case 6:
                    item = new Bomb(getPositionInFrontOfLink(1.5));
                    break;
                case 7:
                    item = new CandleFlame(defaultItemSpawnPos, facingDirection);
                    break;
            }
            if (item != null)
            {
                ProjectileStorage.Add(item);
            }
        }
    }
}
