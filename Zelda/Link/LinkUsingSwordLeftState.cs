using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zelda.Sprites.Factories;

namespace Zelda.Link
{
    public class LinkUsingSwordLeftState : ILinkState
    {
        private ILink link;
        private int runTime = 0;

        public LinkUsingSwordLeftState(ILink link)
        {
            this.link = link;
            link.Sprite = LinkSpriteFactory.LinkUsingSwordLeftSprite();
        }

        public void MoveUp()
        {
            // Can't move while using item
        }
        public void MoveDown()
        {
            // Can't move while using item
        }
        public void MoveLeft()
        {
            // Can't move while using item
        }
        public void MoveRight()
        {
            // Can't move while using item
        }
        public void UseItem(int itemNum)
        {
            // Can't use item while using item
        }
        public void TakeDamage(Game1 game)
        {
            game.link = new DamagedLink(link, game);
        }
        public void CancelMovement()
        {
            // No movement to cancel when Link is using an item
        }

        public void Update()
        {
            if (runTime < 16)
            {
                runTime++;
            }
            else
            {
                link.State = new LinkFacingLeftState(link);
            }
        }
    }
}
