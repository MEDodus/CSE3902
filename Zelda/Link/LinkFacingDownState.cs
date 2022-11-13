﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zelda.Sprites.Factories;

namespace Zelda.Link
{
    public class LinkFacingDownState : ILinkState
    {
        private ILink link;

        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;

        public LinkFacingDownState(ILink link)
        {
            this.link = link;
            link.Sprite = LinkSpriteFactory.LinkFacingDownSprite();
        }

        public void MoveUp()
        {
            link.State = new LinkMovingUpState(link);
        }
        public void MoveDown()
        {
            link.State = new LinkMovingDownState(link);
        }
        public void MoveLeft()
        {
            link.State = new LinkMovingLeftState(link);
        }
        public void MoveRight()
        {
            link.State = new LinkMovingRightState(link);
        }
        public void UseItem(int itemNum)
        {
            link.State = new LinkUsingItemDownState(link);
            link.CreateItem(itemNum);
        }
        public void TakeDamage(Game1 game)
        {
            game.Link = new DamagedLink(link, game);
        }

        public void Update()
        {
            
        }
    }
}
