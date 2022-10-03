using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace Zelda.Link
{
    public class LinkAttackingLeftState : ILinkState
    {
        private Link2 link;

        private static readonly int frames = 4;
        private readonly int MOD = 40;

        private Rectangle[] sourceRectangle;
        private Rectangle[] destinationRectangle;

        private int idx;
        private int frame;

        public LinkAttackingLeftState(Link2 link)
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
            sourceRectangle[0] = new Rectangle(0, 129, 16, 16);
            sourceRectangle[1] = new Rectangle(16, 129, 27, 16);
            sourceRectangle[2] = new Rectangle(43, 129, 23, 16);
            sourceRectangle[3] = new Rectangle(66, 129, 19, 16);

            // Destination rectangles for each frame
            for (int i = 0; i < frames; i++)
            {
                destinationRectangle[i] = new Rectangle(link.Xpos - (Settings.LINK_ATTACKING_LEFT_FRAMES_X[i] * Settings.LINK_SIZE_MULT), link.Ypos, sourceRectangle[i].Width * Settings.LINK_SIZE_MULT, sourceRectangle[i].Height * Settings.LINK_SIZE_MULT);
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
        public void UseItem()
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
                link.state = new LinkFacingLeftState(link);
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
