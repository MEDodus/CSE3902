﻿using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Zelda.Sprites;
using Rectangle = Microsoft.Xna.Framework.Rectangle;
using Zelda.Commands;

namespace Zelda.Link
{
    public class LinkFacingLeftState : ILinkState
    {
        private Link2 link;

        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;

        public LinkFacingLeftState(Link2 link)
        {
            this.link = link;
            sourceRectangle = new Rectangle(159, 11, 16, 16);
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
            link.state = new LinkMovingLeftState(link);
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

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(link.Texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }
}