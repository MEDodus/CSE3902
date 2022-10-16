using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace Zelda.Link
{
    public class LinkMovingLeftState : ILinkState
    {
        private Link2 link;

        private Rectangle[] sourceRectangle = new Rectangle[2];
        private Rectangle destinationRectangle;
        private int runTime = 0;
        private int currentSprite = 0;
        private int moveLeftCount = 0;

        public LinkMovingLeftState(Link2 link)
        {
            this.link = link;
            sourceRectangle[0] = new Rectangle(96, 8, 16, 16);
            sourceRectangle[1] = new Rectangle(112, 8, 16, 16);
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
            // Already moving left, stay in this state
            moveLeftCount++;
        }
        public void MoveRight()
        {
            link.state = new LinkMovingRightState(link);
        }
        public void UseItem(int itemNum)
        {
            link.state = new LinkUsingItemLeftState(link);
            link.CreateItem(itemNum);
        }
        public void TakeDamage(Game1 game)
        {
            game.link = new DamagedLink(link, game);
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
            link.Xpos -= 2;
            destinationRectangle.X = link.Xpos;
            if (runTime > moveLeftCount)
            {
                link.state = new LinkFacingLeftState(link);
            }
            runTime++;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(link.Texture, destinationRectangle, sourceRectangle[currentSprite], Color.White);
        }
    }
}
