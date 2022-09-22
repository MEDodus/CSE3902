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
    public class Tile : ISprite
    {
        private Rectangle sourceLocation;
        private Rectangle destinationLocation;

        public Texture2D Texture { get { return null; } }
        public Rectangle SourceLocation { get { return sourceLocation; } }
        public Rectangle DestinationLocation { get { return destinationLocation; } }

        public Tile(Rectangle sourceLocation, Rectangle destinationRectangle)
        {
            this.sourceLocation = sourceLocation;
            this.destinationLocation = destinationRectangle;
        }

        public void Update()
        {
            
        }
    }
}
