using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace Zelda.Link
{
    public class LinkMovingDownState : ILinkState
    {
        private Link2 link;

        private Rectangle[] sourceRectangle = new Rectangle[2];
        private Rectangle destinationRectangle;
        private int runTime = 0;
        private int currentSprite = 0;
        private int moveDownCount = 0;

        public LinkMovingDownState(Link2 link)
        {
            this.link = link;
            sourceRectangle[0] = new Rectangle(1, 11, 16, 16);
            sourceRectangle[1] = new Rectangle(18, 11, 16, 16);
            destinationRectangle = new Rectangle(link.Xpos, link.Ypos, link.Width * Settings.LINK_SIZE_MULT, link.Height * Settings.LINK_SIZE_MULT);
        }

        public void MoveUp()
        {
            link.state = new LinkMovingUpState(link);
        }
        public void MoveDown()
        {
            // Already moving down, stay in this state
            moveDownCount++;
        }
        public void MoveLeft()
        {
            link.state = new LinkMovingLeftState(link);
        }
        public void MoveRight()
        {
            link.state = new LinkMovingRightState(link);
        }
        public void Attack()
        {
            link.state = new LinkAttackingDownState(link);
        }
        public void UseItem()
        {
            // link.state = new LinkUsingItemDownState()
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
            link.Ypos += 2;
            destinationRectangle.Y = link.Ypos;
            if (runTime > moveDownCount)
            {
                // TODO: Change to facing down
                link.state = new LinkFacingDownState(link);
            }
            runTime++;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(link.Texture, destinationRectangle, sourceRectangle[currentSprite], Color.White);
            spriteBatch.End();
        }
    }
}
