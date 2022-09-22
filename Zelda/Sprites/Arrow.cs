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
    public class Arrow : ISprite
    {
        private Texture2D texture;
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        private readonly int height = 16;
        private readonly int width = 5;
        private readonly int origin = 0;

        public Texture2D Texture { get { return texture; } }
        public Rectangle SourceLocation { get { return sourceRectangle; } }
        public Rectangle DestinationLocation { get { return destinationRectangle; } }

        public Arrow(Texture2D texture)
        {
            this.texture = texture;
            this.sourceRectangle = new Rectangle(origin, origin, width, height);
            this.destinationRectangle = new Rectangle(100, 100, width, height);
        }
        public void Update()
        {

        }
    }
}
