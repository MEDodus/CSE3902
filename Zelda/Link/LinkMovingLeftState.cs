using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zelda.Sprites.Factories;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace Zelda.Link
{
    public class LinkMovingLeftState : ILinkState
    {
        private ILink link;

        private int runTime = 0;
        private int moveLeftCount = 0;

        public LinkMovingLeftState(ILink link)
        {
            this.link = link;
            link.Sprite = LinkSpriteFactory.LinkMovingLeftSprite();
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
            // Already moving left, stay in this state
            moveLeftCount++;
        }
        public void MoveRight()
        {
            link.State = new LinkMovingRightState(link);
        }
        public void TakeDamage(Game1 game, Vector2 pushDirection)
        {
            if (link.PlayerNumber == 1)
            {
                game.Link = new DamagedLink(link, game, pushDirection);
            }
            else
            {
                game.LinkCompanion = new DamagedLink(link, game, pushDirection);
            }
        }
        public void Attack()
        {
            if (link.TryUsePrimary())
            {
                link.State = new LinkUsingItemLeftState(link);
            }
        }
        public void AttackSecondary()
        {
            if (link.TryUseSecondary())
            {
                link.State = new LinkUsingItemLeftState(link);
            }
        }
        public void Update()
        {
            link.Position += new Vector2(-Settings.LINK_SPEED, 0);
            if (runTime > moveLeftCount)
            {
                link.State = new LinkFacingLeftState(link);
            }
            runTime++;
        }
    }
}
