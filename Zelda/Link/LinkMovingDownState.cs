using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zelda.Sprites.Factories;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace Zelda.Link
{
    public class LinkMovingDownState : ILinkState
    {
        private ILink link;

        private int runTime = 0;
        private int moveDownCount = 0;

        public LinkMovingDownState(ILink link)
        {
            this.link = link;
            link.Sprite = LinkSpriteFactory.LinkMovingDownSprite();
        }

        public void MoveUp()
        {
            link.State = new LinkMovingUpState(link);
        }
        public void MoveDown()
        {
            // Already moving down, stay in this state
            moveDownCount++;
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
            game.link = new DamagedLink(link, game);
        }
        public void CancelMovement()
        {
            link.Position += new Vector2(0, -2);
        }

        public void Update()
        {
            link.Position += new Vector2(0, 2);
            if (runTime > moveDownCount)
            {
                link.State = new LinkFacingDownState(link);
            }
            runTime++;
        }
    }
}
