using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zelda.Sprites.Factories;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace Zelda.Link
{
    public class LinkMovingUpState : ILinkState
    {
        private ILink link;

        private int runTime = 0;
        private int moveUpCount = 0;

        public LinkMovingUpState(ILink link)
        {
            this.link = link;
            link.Sprite = LinkSpriteFactory.LinkMovingUpSprite();
        }

        public void MoveUp()
        {
            // Already moving up, stay in this state
            moveUpCount++;
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
            link.State = new LinkUsingItemUpState(link);
            link.CreateItem(itemNum);
        }
        public void TakeDamage(Game1 game)
        {
            game.link = new DamagedLink(link, game);
        }
        public void Update()
        {
            link.Position += new Vector2(0, -2);
            if (runTime > moveUpCount)
            {
                link.State = new LinkFacingUpState(link);
            }
            runTime++;
        }
    }
}
