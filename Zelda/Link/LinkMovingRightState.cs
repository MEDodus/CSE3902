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
                link.State = new LinkUsingItemRightState(link);
            }
        }
        public void AttackSecondary()
        {
            if (link.TryUseSecondary())
            {
                link.State = new LinkUsingItemRightState(link);
            }
        }
        public void Update()
        {
            link.Position += new Vector2(Settings.LINK_SPEED, 0);
            if (runTime > moveRightCount)
            {
                link.State = new LinkFacingRightState(link);
            }
            runTime++;
        }

        public void Update(int speed)
        {
            link.Position += new Vector2(Settings.LINK_SPEED * speed, 0);
            if (runTime > moveRightCount)
            {
                link.State = new LinkFacingRightState(link);
            }
            runTime++;
        }
    }
}
