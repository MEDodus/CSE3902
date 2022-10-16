using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using Zelda.Controllers;
using Zelda.Projectiles;
using Zelda.Projectiles.Classes;
using Zelda.Sprites.Factories;

namespace Zelda.Link
{
    public class Link2 : SpriteFactory, ILink
    {
        private static int HEIGHT = 16;
        private static int WIDTH = 16;

        public ILinkState state;
        public Texture2D texture;
        private int X = 450, Y = 450;
        private Vector2 facingDirection;
        private double swordAttackTimer = 0;

        public Texture2D Texture { get { return texture; } set { texture = value; } }
        public int Xpos { get { return X; } set { X = value; } }
        public int Ypos { get { return Y; } set { Y = value; } }
        public int Height { get { return HEIGHT; } set { HEIGHT = value; } }
        public int Width { get { return WIDTH; } set { WIDTH = value; } }

        private HashSet<Keys> movementKeys = new HashSet<Keys>();

        public Link2()
        {
            texture = GetTexture("Link");
            state = new LinkFacingRightState(this);
            facingDirection = new Vector2(1, 0);
            movementKeys.Add(Keys.W);
            movementKeys.Add(Keys.A);
            movementKeys.Add(Keys.S);
            movementKeys.Add(Keys.D);
            movementKeys.Add(Keys.Up);
            movementKeys.Add(Keys.Left);
            movementKeys.Add(Keys.Down);
            movementKeys.Add(Keys.Right);
        }
        public void Update(GameTime gameTime)
        {
            if (swordAttackTimer > 0)
            {
                swordAttackTimer -= gameTime.ElapsedGameTime.TotalSeconds;
            }
            state.Update();
        }

        public void Reset()
        {
            X = 300;
            Y = 700;
            state = new LinkFacingRightState(this);
            facingDirection = new Vector2(1, 0);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            state.Draw(spriteBatch);
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
        public void UseItem(int itemNum)
        {
            state.UseItem(itemNum);
        }
        public void TakeDamage(Game1 game)
        {
            state.TakeDamage(game);
        }

        private Vector2 getPositionInFrontOfLink(double blocksInFrontOf)
        {
            return new Vector2(X + 10, Y + 12) + (facingDirection * Settings.BLOCK_SIZE * (float)blocksInFrontOf);
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
                        // adjust spawn position if facing left or up
                        Vector2 spawnPos = defaultItemSpawnPos;
                        if (facingDirection.Equals(new Vector2(-1, 0)))
                        {
                            spawnPos += new Vector2(-20, 0);
                        }
                        else if (facingDirection.Equals(new Vector2(0, -1)))
                        {
                            spawnPos += new Vector2(0, -22);
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
                    item = new Boomerang(defaultItemSpawnPos, facingDirection);
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
