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
                link.State = new LinkUsingItemUpState(link);
            }
        }
        public void AttackSecondary()
        {
            if (link.TryUseSecondary())
            {
                link.State = new LinkUsingItemUpState(link);
            }
        }
        public void Update()
        {
            link.Position += new Vector2(0, -Settings.LINK_SPEED);
            if (runTime > moveUpCount)
            {
                link.State = new LinkFacingUpState(link);
            }
            runTime++;
        }
    }
}
