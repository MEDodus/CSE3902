using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace Zelda.Link
{
    public class LinkUsingItemRightState : ILinkState
    {
        private Link2 link;

        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        private int runTime = 0;

        public LinkUsingItemRightState(Link2 link)
        {
            this.link = link;
            sourceRectangle = new Rectangle(16, 32, 16, 16);
            destinationRectangle = new Rectangle(link.Xpos, link.Ypos, link.Width * Settings.LINK_SIZE_MULT, link.Height * Settings.LINK_SIZE_MULT);
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
        public void Attack()
        {
            // Can't attack while using item
        }
        public void UseItem(int itemNum)
        {
            // Can't use item while using item
        }
        public void TakeDamage(Game1 game)
        {
            game.link = new DamagedLink(link, game);
        }

        public void Update()
        {
            if (runTime < 10)
            {
                runTime++;
            }
            else
            {
                link.state = new LinkFacingRightState(link);
            }
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(link.Texture, destinationRectangle, sourceRectangle, Color.White);
        }
    }
}
