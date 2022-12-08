using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zelda.Sprites.Factories;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace Zelda.Link
{
    public class LinkUsingItemDownState : ILinkState
    {
        private ILink link;
        private int runTime = 0;

        public LinkUsingItemDownState(ILink link)
        {
            this.link = link;
            link.Sprite = LinkSpriteFactory.LinkUsingItemDownSprite(link.PlayerNumber);
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
            if (runTime < 10)
            {
                runTime++;
            }
            else
            {
                link.State = new LinkFacingDownState(link);
            }
        }
    }
}
