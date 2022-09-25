﻿using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Zelda.Sprites;
using Rectangle = Microsoft.Xna.Framework.Rectangle;
using Zelda.Commands;

namespace Zelda.Link
{
    public class LinkMovingLeftState : ILinkState
    {
        private Link2 link;

        private Rectangle[] sourceRectangle = new Rectangle[2];
        private Rectangle destinationRectangle;
        private int runTime = 0;
        private int currentSprite = 0;

        public LinkMovingLeftState(Link2 link)
        {
            this.link = link;
            sourceRectangle[0] = new Rectangle(159, 11, 16, 16);
            sourceRectangle[1] = new Rectangle(177, 11, 16, 16);
            destinationRectangle = new Rectangle(link.Xpos, link.Ypos, link.Width, link.Height);
        }

        public void MoveUp()
        {
            link.state = new LinkMovingUpState(link);
        }
        public void MoveDown()
        {
            link.state = new LinkMovingDownState(link);
        }
        public void MoveLeft()
        {
            // Already moving left, stay in this state
        }
        public void MoveRight()
        {
            link.state = new LinkMovingRightState(link);
        }
        public void Attack()
        {
            // link.state = new LinkAttackingUpState(link);
        }
        public void UseItem()
        {
            // link.state = new LinkUsingItemUpState()
        }
        public void TakeDamage()
        {
            // TODO: decorator class for this
        }

        public void Update()
        {
            if (runTime == 10)
            {
                if (currentSprite == 0)
                {
                    currentSprite++;
                }
                else
                {
                    currentSprite = 0;
                }
                runTime = 0;
            }
            link.Xpos -= 2;
            runTime++;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            destinationRectangle = new Rectangle(link.Xpos, link.Ypos, link.Width, link.Height);
            spriteBatch.Begin();
            spriteBatch.Draw(link.Texture, destinationRectangle, sourceRectangle[currentSprite], Color.White);
            spriteBatch.End();
        }
    }
}
