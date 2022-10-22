using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Zelda.Sprites
{
    public interface ISprite
    {
        public Texture2D Texture { set; }
        public Rectangle Destination { get; }

        public void Update(GameTime gameTime);

        public void Draw(SpriteBatch spriteBatch, Vector2 position);
        public void Draw(SpriteBatch spriteBatch, Vector2 position, Color color);
        public void Draw(SpriteBatch spriteBatch, Rectangle destination);
        public void Draw(SpriteBatch spriteBatch, Rectangle destination, Color color);
        public void Draw(SpriteBatch spriteBatch, Rectangle destination, Rectangle source);
        public void Draw(SpriteBatch spriteBatch, Rectangle destination, Rectangle source, Color color);
    }
}
