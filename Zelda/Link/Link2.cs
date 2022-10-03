using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Zelda.Sprites.Factories;
using Zelda.Projectiles;
using Zelda.Projectiles.Classes;
using System.Collections.Generic;
using Zelda.Controllers;

namespace Zelda.Link
{
    public class Link2 : SpriteFactory, ILink
    {
        private static int HEIGHT = 16;
        private static int WIDTH = 16;

        public ILinkState state;
        public Texture2D texture;
        private int X = 300, Y = 700;
        private Vector2 facingDirection;

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
        public void Update()
        {
            state.Update();
        }

        public void Reset()
        {
            X = 300;
            Y = 700;
            state = new LinkFacingRightState(this);

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            state.Draw(spriteBatch);
        }

        private bool TryMove(Vector2 newDirection)
        {
            // Don't set direction if multiple keys are being pressed unless the direction is the same as the current direction
            bool success = !KeyboardController.AreMultipleKeysPressed(movementKeys) || newDirection.Equals(facingDirection);
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
        public void Attack()
        {
            state.Attack();
        }
        public void UseItem(int itemNum)
        {
            state.UseItem(itemNum);
        }
        public void TakeDamage(Game1 game)
        {
            state.TakeDamage(game);
        }

        public void CreateItem(int itemNum)
        {
            IProjectile item = null;
            Vector2 position = new Vector2(X, Y);
            switch (itemNum)
            {
                case 1:
                    item = new Arrow(position, facingDirection);
                    break;
                case 2:
                    item = new Boomerang(position, facingDirection);
                    break;
                case 3:
                    item = new Arrow(position, facingDirection);
                    break;
            }
            ProjectileStorage.Add(item);
        }
    }
}
