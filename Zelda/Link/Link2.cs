using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace Zelda.Link
{
    public class Link2 : ILink
    {
        public ILinkState state;
        private Texture2D texture;
        private int X = 300, Y = 700;
        private int HEIGHT = 48;
        private int WIDTH = 48;

        public Texture2D Texture { get { return texture; } }
        public int Xpos { get { return X; } set { X = value; } }
        public int Ypos { get { return Y; } set { Y = value; } }
        public int Height { get { return HEIGHT;  } set { HEIGHT = value; } }
        public int Width { get { return WIDTH; } set { WIDTH = value; } }

        public Link2()
        {
            texture = TextureStorage.GetTexture(TextureStorage.SpriteSheet.Link);
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
        public void UseItem()
        {
            state.UseItem();
        }
        public void TakeDamage()
        {
            state.TakeDamage();
        }
    }
}
