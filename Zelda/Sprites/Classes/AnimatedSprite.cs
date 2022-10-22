using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Zelda.Sprites.Classes
{
    public class AnimatedSprite : ISprite
    {
        public Texture2D Texture
        {
            set
            {
                texture = value;
            }
        }
        public Rectangle Destination
        {
            get
            {
                return destination;
            }
            private set
            {
                destination = value;
            }
        }

        // the size of the dominant axis of the sprite in blocks
        // for use when a destination rectangle is not provided as an argument to Draw
        // if not passed to constructor (and thus kept as -1), use WIDTH/HEIGHT as size of destination rectangle
        private readonly double SIZE_IN_BLOCKS = -1;
        // texture atlas properties
        private readonly int NUM_ROWS;
        private readonly int NUM_COLUMNS;
        private readonly int ROW_HEIGHT;
        private readonly int COLUMN_WIDTH;
        // coordinates of top-left point of grid in texture atlas (typically 0 unless drawing a sub-grid of a larger spritesheet)
        private readonly int X = 0;
        private readonly int Y = 0;
        // animation properties
        private readonly int FPS;
        private int frame = 0;

        private Texture2D texture;
        private Rectangle destination;

        // all-argument constructor, inherited by other constructors
        public AnimatedSprite(Texture2D texture, int x, int y, int rows, int columns, int rowHeight, int columnWidth, int fps, double sizeInBlocks)
        {
            this.texture = texture;
            X = x;
            Y = y;
            NUM_ROWS = rows;
            NUM_COLUMNS = columns;
            ROW_HEIGHT = rowHeight;
            COLUMN_WIDTH = columnWidth;
            FPS = fps;
            SIZE_IN_BLOCKS = sizeInBlocks;
        }

        public AnimatedSprite(Texture2D texture, int rows, int columns, int fps)
            : this(texture, 0, 0, rows, columns, texture.Height / rows, texture.Width / columns, fps, -1) { }

        public AnimatedSprite(Texture2D texture, int rows, int columns, int fps, double sizeInBlocks)
            : this(texture, 0, 0, rows, columns, texture.Height / rows, texture.Width / columns, fps, sizeInBlocks) { }

        public AnimatedSprite(Texture2D texture, int rows, int columns, int rowHeight, int columnWidth, int fps)
            : this(texture, 0, 0, rows, columns, rowHeight, columnWidth, fps, -1) { }

        public AnimatedSprite(Texture2D texture, int x, int y, int rows, int columns, int rowHeight, int columnWidth, int fps)
            : this(texture, x, y, rows, columns, rowHeight, columnWidth, fps, -1) { }

        public AnimatedSprite(Texture2D texture, int rows, int columns, int rowHeight, int columnWidth, int fps, double sizeInBlocks)
            : this(texture, 0, 0, rows, columns, rowHeight, columnWidth, fps, sizeInBlocks) { }

        private double timeSinceLastFrameSwitch = 0; // in seconds
        public void Update(GameTime gameTime)
        {
            timeSinceLastFrameSwitch += gameTime.ElapsedGameTime.TotalSeconds;
            if (timeSinceLastFrameSwitch > 1.0 / FPS)
            {
                timeSinceLastFrameSwitch = 0;
                frame = (frame + 1) % (NUM_ROWS * NUM_COLUMNS);
            }
        }

        private Rectangle GetScaledDestinationRectangle(Vector2 position)
        {
            int width;
            int height;
            if (SIZE_IN_BLOCKS > 0)
            {
                if (COLUMN_WIDTH > ROW_HEIGHT)
                {
                    double aspectRatio = (double)ROW_HEIGHT / COLUMN_WIDTH;
                    width = (int)(SIZE_IN_BLOCKS * Settings.BLOCK_SIZE);
                    height = (int)(width * aspectRatio);
                }
                else
                {
                    double aspectRatio = (double)COLUMN_WIDTH / ROW_HEIGHT;
                    height = (int)(SIZE_IN_BLOCKS * Settings.BLOCK_SIZE);
                    width = (int)(height * aspectRatio);
                }
            }
            else
            {
                width = COLUMN_WIDTH;
                height = ROW_HEIGHT;
            }
            return new Rectangle((int)position.X, (int)position.Y, width, height);
        }

        private Rectangle GetSourceRectangle()
        {
            int row = frame / NUM_COLUMNS;
            int column = frame / NUM_ROWS;
            return new Rectangle(column * COLUMN_WIDTH + X, row * ROW_HEIGHT + Y, COLUMN_WIDTH, ROW_HEIGHT);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            destination = GetScaledDestinationRectangle(position);
            spriteBatch.Draw(texture, destination, GetSourceRectangle(), Color.White);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position, Color color)
        {
            destination = GetScaledDestinationRectangle(position);
            spriteBatch.Draw(texture, destination, GetSourceRectangle(), color);
        }

        public void Draw(SpriteBatch spriteBatch, Rectangle destination)
        {
            this.destination = destination;
            spriteBatch.Draw(texture, destination, GetSourceRectangle(), Color.White);
        }

        public void Draw(SpriteBatch spriteBatch, Rectangle destination, Color color)
        {
            this.destination = destination;
            spriteBatch.Draw(texture, destination, GetSourceRectangle(), color);
        }

        // Draw methods using source rectangle arguments are unavailable
        public void Draw(SpriteBatch spriteBatch, Rectangle destination, Rectangle source)
        {
            throw new System.NotImplementedException();
        }

        public void Draw(SpriteBatch spriteBatch, Rectangle destination, Rectangle source, Color color)
        {
            throw new System.NotImplementedException();
        }
    }
}
