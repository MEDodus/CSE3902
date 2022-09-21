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
        private Texture2D texture;
        private Rectangle sourceLocation;
        private Rectangle destinationLocation;

        public Texture2D Texture { get { return texture; } }
        public Rectangle SourceLocation { get { return sourceLocation; } }
        public Rectangle DestinationLocation { get { return destinationLocation; } }    

        public Tile(Texture2D texture, Rectangle sourceLocation, Rectangle destinationRectangle)
        {
            this.texture = texture;
            this.sourceLocation = sourceLocation;
            this.destinationLocation = destinationRectangle;
        }

        public void Update()
        {
            
        }
    }
}
