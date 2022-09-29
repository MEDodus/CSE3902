using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace Zelda.Link
{
    public class LinkAttackingRightState : ILinkState
    {
        private Link2 link;

        private Rectangle[] sourceRectangle = new Rectangle[4];
        private Rectangle destinationRectangle;
        private int runTime = 1;
        private int currentSprite = 0;

        public LinkAttackingRightState(Link2 link)
        {
            this.link = link;
            sourceRectangle[0] = new Rectangle(162, 76, 19, 18);
            sourceRectangle[1] = new Rectangle(138, 76, 27, 18);
            sourceRectangle[2] = new Rectangle(111, 76, 28, 18);
            sourceRectangle[3] = new Rectangle(94, 76, 16, 18);
            destinationRectangle = new Rectangle(link.Xpos, link.Xpos + 4 * 3, link.Width + 4 * 3, link.Height);
        }

        public void MoveUp()
        {
            // Can't move while attacking
        }
        public void MoveDown()
        {
            // Can't move while attacking
        }
        public void MoveLeft()
        {
            // Can't move while attacking
        }
        public void MoveRight()
        {
            // Can't move while attacking
        }
        public void Attack()
        {
            // Can't attack while attacking
        }
        public void UseItem()
        {
            // Can't use item while attacking
        }
        public void TakeDamage()
        {
            // TODO: decorator class for this
        }

        public void Update()
        {
            if (runTime % 10 == 0)
            {
                currentSprite++;
            }
            if (currentSprite >= 4)
            {
                link.state = new LinkFacingRightState(link);
            }
            runTime++;
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            if (currentSprite == 1)
            {
                destinationRectangle = new Rectangle(link.Xpos + 4 * 11, link.Ypos, link.Width + 4 * 11, link.Height);
            }
            if (currentSprite == 2)
            {
                destinationRectangle = new Rectangle(link.Xpos + 4 * 12, link.Ypos, link.Width + 4 * 12, link.Height);
            }
            if (currentSprite == 3)
            {
                destinationRectangle = new Rectangle(link.Xpos, link.Ypos, link.Width, link.Height);
            }
            spriteBatch.Begin();
            spriteBatch.Draw(link.Texture, destinationRectangle, sourceRectangle[currentSprite], Color.White);
            spriteBatch.End();
        }
    }
}
