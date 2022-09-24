using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Zelda.Sprites;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace Zelda.Link
{
    public class LinkFacingUpState : ILinkState
    {
        private Link2 link;

        public LinkFacingUpState(Link2 link)
        {
            this.link = link;
        }

        public void MoveUp()
        {
            // TODO: moving up logic
        }
        public void MoveDown()
        {
            // link.state = new LinkMovingDownState(link);
        }
        public void MoveLeft()
        {
            // link.state = new LinkMovingLeftState(link);
        }
        public void MoveRight()
        {
            // link.state = new LinkMovingRightState(link);
        }
        public void Attack()
        {
            // link.state = new LinkAttackingDownUp(link);
        }
        public void UseItem()
        {
            // link.state new LinkUsingItemStateUp()
        }
        public void TakeDamage()
        {

        }

        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(link.Texture, link.DestinationLocation, link.SourceLocation, Color.White);
            spriteBatch.End();
        }
    }
}
