using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zelda.Sprites.Factories;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace Zelda.Link
{
    public class LinkUsingItemLeftState : ILinkState
    {
        private ILink link;
        private int runTime = 0;

        public LinkUsingItemLeftState(ILink link)
        {
            this.link = link;
            link.Sprite = LinkSpriteFactory.LinkUsingItemLeftSprite();
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

        public void Update()
        {
            if (runTime < 10)
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
