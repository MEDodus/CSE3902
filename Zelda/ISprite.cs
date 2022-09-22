using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace Zelda
{
    public interface ISprite
    {
        public Texture2D Texture { get; }
        public Rectangle SourceLocation { get; }
        public Rectangle DestinationLocation { get; }

        public void Update();
    }
}
