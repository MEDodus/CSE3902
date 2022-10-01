using Microsoft.Xna.Framework.Graphics;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace Zelda.Sprites
{
    public class BlueRing : ISprite
    {
        private Texture2D texture;
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        private readonly int X = 200, Y = 50;
        private readonly int HEIGHT = 9;
        private readonly int WIDTH = 7;
        private readonly int ORIGIN = 0;

        public Texture2D Texture { get { return texture; } }
        public Rectangle SourceLocation { get { return sourceRectangle; } }
        public Rectangle DestinationLocation { get { return destinationRectangle; } }

        public BlueRing(Texture2D texture2D)
        {
            texture = texture2D;
            sourceRectangle = new Rectangle(ORIGIN, ORIGIN, WIDTH, HEIGHT);
            destinationRectangle = new Rectangle(X, Y, WIDTH * Settings.ITEMS_MULT, HEIGHT * Settings.ITEMS_MULT);
        }

        public void Update()
        {

        }
    }
}

