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
            link.Sprite = LinkSpriteFactory.LinkMovingDownSprite(link.PlayerNumber);
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
                link.State = new LinkUsingItemDownState(link);
            }
        }
        public void AttackSecondary()
        {
            if (link.TryUseSecondary())
            {
                link.State = new LinkUsingItemDownState(link);
            }
        }
        public void Update()
        {
            link.Position += new Vector2(0, Settings.LINK_SPEED);
            if (runTime > moveDownCount)
            {
                link.State = new LinkFacingDownState(link);
            }
            runTime++;
        }

        public void Update(int speed)
        {
            link.Position += new Vector2(0, Settings.LINK_SPEED * speed);
            if (runTime > moveDownCount)
            {
                link.State = new LinkFacingDownState(link);
            }
            runTime++;
        }
    }
}
