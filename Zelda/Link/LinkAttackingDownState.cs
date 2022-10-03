using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace Zelda.Link
{
    public class LinkAttackingDownState : ILinkState
    {
        private Link2 link;

        private static readonly int frames = 4;
        private readonly int MOD = 40;

        // private Rectangle destinationRectangle;
        private Rectangle[] sourceRectangle;
        private Rectangle[] destinationRectangle;

        private int idx;
        private int frame;

        public LinkAttackingDownState(Link2 link)
        {
            this.link = link;
            idx = 0;
            frame = 0;
            sourceRectangle = new Rectangle[frames];
            destinationRectangle = new Rectangle[frames];
            InitArrays();
        }

        public void InitArrays()
        {
            // Source rectangles for each frame
            sourceRectangle[0] = new Rectangle(0, 55, 16, 16);
            sourceRectangle[1] = new Rectangle(16, 55, 16, 27);
            sourceRectangle[2] = new Rectangle(32, 55, 16, 23);
            sourceRectangle[3] = new Rectangle(48, 55, 16, 19);

            // Destination rectangles for each frame
            for (int i = 0; i < frames; i++)
            {
                destinationRectangle[i] = new Rectangle(link.Xpos, link.Ypos, sourceRectangle[i].Width * Settings.LINK_SIZE_MULT, sourceRectangle[i].Height * Settings.LINK_SIZE_MULT);
            }
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
        public void UseItem(int itemNum)
        {
            // Can't use item while attacking
        }
        public void TakeDamage(Game1 game)
        {
            game.link = new DamagedLink(link, game);
        }

        public void Update()
        {
            if (frame == 40)
            {
                link.state = new LinkFacingDownState(link);
            }
            frame %= MOD;
            idx = frame / (MOD / frames);
            frame++;
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle source = sourceRectangle[idx];
            Rectangle destination = destinationRectangle[idx];
            spriteBatch.Draw(link.Texture, destination, source, Color.White);
        }
    }
}
