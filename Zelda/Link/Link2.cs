using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zelda.Sprites.Factories;
using Zelda.Projectiles;
using Zelda.Projectiles.Classes;

namespace Zelda.Link
{
    public class Link2 : SpriteFactory, ILink
    {
        private static int HEIGHT = 16;
        private static int WIDTH = 16;

        public ILinkState state;
        public Texture2D texture;
        private int X = 300, Y = 700;

        public Texture2D Texture { get { return texture; } set { texture = value; } }
        public int Xpos { get { return X; } set { X = value; } }
        public int Ypos { get { return Y; } set { Y = value; } }
        public int Height { get { return HEIGHT; } set { HEIGHT = value; } }
        public int Width { get { return WIDTH; } set { WIDTH = value; } }

        public Link2()
        {
            texture = GetTexture("Link");
            state = new LinkFacingRightState(this);
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

        public void MoveUp()
        {
            state.MoveUp();
        }
        public void MoveDown()
        {
            state.MoveDown();
        }
        public void MoveLeft()
        {
            state.MoveLeft();
        }
        public void MoveRight()
        {
            state.MoveRight();
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

        public void CreateItem(int itemNum, Vector2 direction)
        {
            IProjectile item = null;
            Vector2 position = new Vector2(X, Y);
            switch (itemNum)
            {
                case 1:
                    item = new Arrow(position, direction);
                    break;
                case 2:
                    item = new Boomerang(position, direction);
                    break;
                case 3:
                    item = new Arrow(position, direction);
                    break;
            }
            ProjectileStorage.Add(item);
        }
    }
}
