using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Zelda.Sprites;
using Rectangle = Microsoft.Xna.Framework.Rectangle;
using Zelda.Commands;

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
            sourceRectangle[0] = new Rectangle(35, 11, 16, 16);
            sourceRectangle[1] = new Rectangle(52, 11, 16, 16);
            destinationRectangle = new Rectangle(link.Xpos, link.Ypos, link.Width, link.Height);
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
            // link.state = new LinkAttackingUpState(link);
        }
        public void UseItem()
        {
            // link.state = new LinkUsingItemUpState()
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
            if (runTime > moveRightCount)
            {
                link.state = new LinkFacingRightState(link);
            }
            runTime++;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            destinationRectangle = new Rectangle(link.Xpos, link.Ypos, link.Width, link.Height);
            spriteBatch.Begin();
            spriteBatch.Draw(link.Texture, destinationRectangle, sourceRectangle[currentSprite], Color.White);
            spriteBatch.End();
        }
    }
}
