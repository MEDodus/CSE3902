using Microsoft.Xna.Framework.Graphics;
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
