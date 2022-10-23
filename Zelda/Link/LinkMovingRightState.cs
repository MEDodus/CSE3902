using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zelda.Sprites.Factories;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace Zelda.Link
{
    public class LinkMovingRightState : ILinkState
    {
        private ILink link;

        private int runTime = 0;
        private int moveRightCount = 0;

        public LinkMovingRightState(ILink link)
        {
            this.link = link;
            link.Sprite = LinkSpriteFactory.LinkMovingRightSprite();
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
            // Already moving right, stay in this state
            moveRightCount++;
        }
        public void UseItem(int itemNum)
        {
            link.State = new LinkUsingItemRightState(link);
            link.CreateItem(itemNum);
        }
        public void TakeDamage(Game1 game)
        {
            game.link = new DamagedLink(link, game);
        }
        public void CancelMovement()
        {
            link.Position += new Vector2(-2, 0);
        }

        public void Update()
        {
            link.Position += new Vector2(2, 0);
            if (runTime > moveRightCount)
            {
                link.State = new LinkFacingRightState(link);
            }
            runTime++;
        }
    }
}
