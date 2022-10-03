﻿using Microsoft.Xna.Framework.Graphics;

namespace Zelda.Link
{
    public class Link2 : ILink
    {
        private static int HEIGHT = 16;
        private static int WIDTH = 16;

        public ILinkState state;
        private Texture2D texture;
        private int X = 300, Y = 700;

        public Texture2D Texture { get { return texture; } }
        public int Xpos { get { return X; } set { X = value; } }
        public int Ypos { get { return Y; } set { Y = value; } }
        public int Height { get { return HEIGHT; } set { HEIGHT = value; } }
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
        public void UseItem(int itemNum)
        {
            state.UseItem(itemNum);
        }
        public void TakeDamage()
        {
            state.TakeDamage();
        }

        public void AttackUsingSward()
        {
            //using sward state
        }
    }
}
