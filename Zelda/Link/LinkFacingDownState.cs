﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace Zelda.Link
{
    public class LinkFacingDownState : ILinkState
    {
        private Link2 link;

        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;

        public LinkFacingDownState(Link2 link)
        {
            this.link = link;
            sourceRectangle = new Rectangle(1, 11, 15, 16);
            destinationRectangle = new Rectangle(link.Xpos, link.Ypos, link.Width * Settings.LINK_SIZE_MULT, link.Height * Settings.LINK_SIZE_MULT);
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
            link.state = new LinkAttackingDownState(link);
        }
        public void UseItem()
        {
            link.state = new LinkUsingItemDownState(link);
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
