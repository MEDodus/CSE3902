using Microsoft.Xna.Framework.Graphics;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace Zelda.Sprites
{
    public class Rupy : ISprite
    {
        private Texture2D texture;
        private Rectangle[] sourceRectangle;
        private Rectangle destinationRectangle;
        private readonly int X = 200, Y = 50;
        private readonly int HEIGHT = 16;
        private readonly int WIDTH = 8;
        private readonly int COLS = 2;
        private readonly int MOD = 12;
        private int frame, idx;

        public Texture2D Texture { get { return texture; } }
        public Rectangle SourceLocation { get { return sourceRectangle[idx]; } }
        public Rectangle DestinationLocation { get { return destinationRectangle; } }

        public Rupy(Texture2D texture2D)
        {
            idx = 0;
            frame = 0;
            texture = texture2D;
            sourceRectangle = new Rectangle[COLS];
            destinationRectangle = new Rectangle(X, Y, WIDTH * Settings.ITEMS_MULT, HEIGHT * Settings.ITEMS_MULT);
            LoadFrames();
        }

        public void LoadFrames()
        {
            for (int i = 0; i < COLS; i++)
            {
                sourceRectangle[i] = new Rectangle(i * WIDTH, 0, WIDTH, HEIGHT);
            }
        }

        public void Update()
        {
            frame %= MOD;
            idx = frame / (MOD / 2);
            frame++;
        }
    }
}

