using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Zelda.Sprites;
using Rectangle = Microsoft.Xna.Framework.Rectangle;
using Zelda.Commands;

namespace Zelda.Link
{
    public class LinkAttackingDownState : ILinkState
    {
        private Link2 link;

        private Rectangle[] sourceRectangle = new Rectangle[4];
        private Rectangle destinationRectangle;
        private int runTime = 1;
        private int currentSprite = 0;

        public LinkAttackingDownState(Link2 link)
        {
            this.link = link;
            sourceRectangle[0] = new Rectangle(145, 45, 16, 19);
            sourceRectangle[1] = new Rectangle(128, 45, 16, 27);
            sourceRectangle[2] = new Rectangle(111, 45, 16, 28);
            sourceRectangle[3] = new Rectangle(94, 45, 16, 16);
            destinationRectangle = new Rectangle(link.Xpos, link.Ypos + 4 * 3, link.Width, link.Height + 4 * 3);
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
                link.state = new LinkFacingDownState(link);
            }
            runTime++;
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            if (currentSprite == 1)
            {
                destinationRectangle = new Rectangle(link.Xpos, link.Ypos + 4 * 11, link.Width, link.Height + 4 * 11);
            }
            if (currentSprite == 2)
            {
                destinationRectangle = new Rectangle(link.Xpos, link.Ypos + 4 * 12, link.Width, link.Height + 4 * 12);
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
