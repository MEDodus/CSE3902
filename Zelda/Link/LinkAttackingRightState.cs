﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace Zelda.Link
{
    public class LinkAttackingRightState : ILinkState
    {
        private Link2 link;

        private static readonly int frames = 4;
        private readonly int MOD = 40;

        // private Rectangle destinationRectangle;
        private Rectangle[] sourceRectangle;
        private Rectangle[] destinationRectangle;

        private int idx;
        private int frame;

        public LinkAttackingRightState(Link2 link)
        {
            this.link = link;
            idx = 0;
            frame = 0;
            sourceRectangle = new Rectangle[frames];
            destinationRectangle = new Rectangle[frames];
            InitArrays();
        }

        public void InitArrays()
        {
            // Source rectangles for each frame
            sourceRectangle[0] = new Rectangle(94, 76, 16, 18);
            sourceRectangle[1] = new Rectangle(111, 76, 28, 18);
            sourceRectangle[2] = new Rectangle(138, 76, 27, 18);
            sourceRectangle[3] = new Rectangle(162, 76, 19, 18);

            // Destination rectangles for each frame
            for (int i = 0; i < frames; i++)
            {
                destinationRectangle[i] = new Rectangle(link.Xpos, link.Ypos, sourceRectangle[i].Width * Settings.LINK_SIZE_MULT, sourceRectangle[i].Height * Settings.LINK_SIZE_MULT);
            }
        }

        public void MoveUp()
        {
            // Can't move while attacking
        }
        public void MoveDown()
        {
            // Can't move while attacking
        }
        public void MoveLeft()
        {
            // Can't move while attacking
        }
        public void MoveRight()
        {
            // Can't move while attacking
        }
        public void Attack()
        {
            // Can't attack while attacking
        }
        public void UseItem()
        {
            // Can't use item while attacking
        }
        public void TakeDamage()
        {
            // TODO: decorator class for this
        }

        public void Update()
        {
            if (frame == 40)
            {
                link.state = new LinkFacingRightState(link);
            }
            frame %= MOD;
            idx = frame / (MOD / frames);
            frame++;
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle source = sourceRectangle[idx];
            Rectangle destination = destinationRectangle[idx];
            spriteBatch.Begin();
            spriteBatch.Draw(link.Texture, destination, source, Color.White);
            spriteBatch.End();
        }
    }
}