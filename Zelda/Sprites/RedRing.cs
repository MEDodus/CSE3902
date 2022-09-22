using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace Zelda.Sprites
{
    public class RedRing : ISprite
    {
        private Texture2D texture;
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        private readonly int X = 100, Y = 50;
        private readonly int HEIGHT = 9;
        private readonly int WIDTH = 7;
        private readonly int ORIGIN = 0;

        public Texture2D Texture { get { return texture; } }
        public Rectangle SourceLocation { get { return sourceRectangle; } }
        public Rectangle DestinationLocation { get { return destinationRectangle; } }

        public RedRing(Texture2D texture2D)
        {
            texture = texture2D;
            sourceRectangle = new Rectangle(ORIGIN, ORIGIN, WIDTH, HEIGHT);
            destinationRectangle = new Rectangle(X, Y, WIDTH, HEIGHT);
        }

        public void Update()
        {

        }
    }
}

