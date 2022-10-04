using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Zelda.Sprites.Classes
{
    public class Sprite : ISprite
    {
        private readonly Texture2D TEXTURE;
        // the size of the dominant axis of the sprite in blocks
        // for use when a destination rectangle is not provided as an argument to Draw
        // if not passed to constructor (and thus kept as -1), use WIDTH/HEIGHT as size of destination rectangle
        private readonly double SIZE_IN_BLOCKS = -1;
        // default values used when a source rectangle is not provided as an argument to Draw
        private readonly int X = 0;
        private readonly int Y = 0;
        private readonly int WIDTH;
        private readonly int HEIGHT;

        // all-argument constructor, inherited by other constructors
        public Sprite(Texture2D texture, int x, int y, int width, int height, double sizeInBlocks)
        {
            TEXTURE = texture;
            X = x;
            Y = y;
            WIDTH = width;
            HEIGHT = height;
            SIZE_IN_BLOCKS = sizeInBlocks;
        }

        public Sprite(Texture2D texture)
            : this(texture, 0, 0, texture.Width, texture.Height, -1) { }

        public Sprite(Texture2D texture, double sizeInBlocks)
            : this(texture, 0, 0, texture.Width, texture.Height, sizeInBlocks) { }

        public Sprite(Texture2D texture, int x, int y, int width, int height)
            : this(texture, x, y, width, height, -1) { }

        public void Update(GameTime gameTime)
        {

        }

        private Rectangle GetScaledDestinationRectangle(Vector2 position)
        {
            int width;
            int height;
            if (SIZE_IN_BLOCKS > 0)
            {
                if (WIDTH > HEIGHT)
                {
                    double aspectRatio = (double)HEIGHT / WIDTH;
                    width = (int)(SIZE_IN_BLOCKS * Settings.BLOCK_SIZE);
                    height = (int)(width * aspectRatio);
                }
                else
                {
                    double aspectRatio = (double)WIDTH / HEIGHT;
                    height = (int)(SIZE_IN_BLOCKS * Settings.BLOCK_SIZE);
                    width = (int)(height * aspectRatio);
                }
            }
            else
            {
                width = WIDTH;
                height = HEIGHT;
            }
            return new Rectangle((int)position.X, (int)position.Y, width, height);
        }

        private Rectangle GetDefaultSourceRectangle()
        {
            return new Rectangle(X, Y, WIDTH, HEIGHT);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            spriteBatch.Draw(TEXTURE, GetScaledDestinationRectangle(position), GetDefaultSourceRectangle(), Color.White);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position, Color color)
        {
            spriteBatch.Draw(TEXTURE, GetScaledDestinationRectangle(position), GetDefaultSourceRectangle(), color);
        }

        public void Draw(SpriteBatch spriteBatch, Rectangle destination)
        {
            spriteBatch.Draw(TEXTURE, destination, GetDefaultSourceRectangle(), Color.White);
        }

        public void Draw(SpriteBatch spriteBatch, Rectangle destination, Color color)
        {
            spriteBatch.Draw(TEXTURE, destination, GetDefaultSourceRectangle(), color);
        }

        public void Draw(SpriteBatch spriteBatch, Rectangle destination, Rectangle source)
        {
            spriteBatch.Draw(TEXTURE, destination, source, Color.White);
        }

        public void Draw(SpriteBatch spriteBatch, Rectangle destination, Rectangle source, Color color)
        {
            spriteBatch.Draw(TEXTURE, destination, source, color);
        }
    }
}
