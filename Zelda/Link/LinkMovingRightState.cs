using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace Zelda.Link
{
    public class LinkMovingRightState : ILinkState
    {
        private Link2 link;

        private Rectangle[] sourceRectangle = new Rectangle[2];
        private Rectangle destinationRectangle;
        private int runTime = 0;
        private int currentSprite = 0;
        private int moveRightCount = 0;

        public LinkMovingRightState(Link2 link)
        {
            this.link = link;
            sourceRectangle[0] = new Rectangle(32, 8, 16, 16);
            sourceRectangle[1] = new Rectangle(48, 8, 16, 16);
            destinationRectangle = new Rectangle(link.Xpos, link.Ypos, link.Width * Settings.LINK_SIZE_MULT, link.Height * Settings.LINK_SIZE_MULT);
        }

        public void MoveUp()
        {
            link.state = new LinkMovingUpState(link);
        }
        public void MoveDown()
        {
            link.state = new LinkMovingDownState(link);
        }
        public void MoveLeft()
        {
            link.state = new LinkMovingLeftState(link);
        }
        public void MoveRight()
        {
            // Already moving right, stay in this state
            moveRightCount++;
        }
        public void Attack()
        {
            link.state = new LinkAttackingRightState(link);
        }
        public void UseItem()
        {
            link.state = new LinkUsingItemRightState(link);
        }
        public void TakeDamage()
        {
            // TODO: decorator class for this
        }

        public void Update()
        {
            if (runTime % 10 == 0)
            {
                if (currentSprite == 0)
                {
                    currentSprite++;
                }
                else
                {
                    currentSprite = 0;
                }
            }
            link.Xpos += 2;
            destinationRectangle.X = link.Xpos;
            if (runTime > moveRightCount)
            {
                link.state = new LinkFacingRightState(link);
            }
            runTime++;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(link.Texture, destinationRectangle, sourceRectangle[currentSprite], Color.White);
        }
    }
}
