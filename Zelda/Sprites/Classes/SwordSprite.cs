using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Zelda.Sprites.Classes
{

    /* Functionality for sword sprite */
    /* Sword animation and collision should be part of link's attack animation, thus
     * we will draw a collision box around the sword in his animation, IProjectile's
     * update method should not remove or draw anything, instead IProjectile will be 
     * used for it's collision handling. 
     * This class is for drawing link when he is attacking, meaning we cannot use a
     * texture atlas.
     */
    public class SwordSprite : ISprite
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
        // animation properties
        private readonly int FPS;
        private int frame = 0;
        private Texture2D texture;
        private Rectangle destination;
        private Dictionary<int, Rectangle> frameSource;
        private Dictionary<int, Rectangle> frameSourceDown = new Dictionary<int, Rectangle> { { 0, new Rectangle(0, 55, 16, 15) }, { 1, new Rectangle(16, 55, 16, 27) }, { 2, new Rectangle(32, 55, 16, 23) }, { 3, new Rectangle(48, 55, 16, 19) } };
        private Dictionary<int, Rectangle> frameSourceUp = new Dictionary<int, Rectangle> { { 0, new Rectangle(0, 55, 16, 15) }, { 1, new Rectangle(16, 55, 16, 27) }, { 2, new Rectangle(32, 55, 16, 23) }, { 3, new Rectangle(48, 55, 16, 19) } };
        private Dictionary<int, Rectangle> frameSourceLeft = new Dictionary<int, Rectangle> { { 0, new Rectangle(0, 130, 16, 16) }, { 1, new Rectangle(16, 130, 27, 16) }, { 2, new Rectangle(43, 55, 23, 16) }, { 3, new Rectangle(66, 55, 19, 16) } };
        private Dictionary<int, Rectangle> frameSourceRight = new Dictionary<int, Rectangle> { { 0, new Rectangle(0, 83, 16, 16) }, { 1, new Rectangle(16, 83, 27, 16) }, { 2, new Rectangle(43, 83, 23, 16) }, { 3, new Rectangle(66, 83, 19, 16) } };
        // all-argument constructor, inherited by other constructors
        public SwordSprite(Texture2D texture, int fps, double sizeInBlocks, int direction)
        {
            if (direction == 0) // Down
            {
                frameSource = frameSourceDown;
            }
            else if (direction == 1) // Left
            {
                frameSource = frameSourceLeft;
            } else if (direction == 2) // Right
            {
                frameSource = frameSourceRight;
            }
            else if (direction == 3) // Up
            {
                frameSource = frameSourceUp;
            }
            this.texture = texture;
            FPS = fps;
            SIZE_IN_BLOCKS = sizeInBlocks;
        }

        public SwordSprite(Texture2D texture, int rows, int columns, int fps, double sizeInBlocks)
            : this(texture, fps, sizeInBlocks, -1) { }

        public SwordSprite(Texture2D texture, int rows, int columns, int rowHeight, int columnWidth, int fps)
            : this(texture, fps, -1, -1) { }

        public SwordSprite(Texture2D texture, int x, int y, int rows, int columns, int rowHeight, int columnWidth, int fps)
            : this(texture, fps, -1, -1) { }

        public SwordSprite(Texture2D texture, int rows, int columns, int rowHeight, int columnWidth, int fps, double sizeInBlocks)
            : this(texture, fps, sizeInBlocks, -1) { }

        private double timeSinceLastFrameSwitch = 0; // in seconds
        public void Update(GameTime gameTime)
        {
            timeSinceLastFrameSwitch += gameTime.ElapsedGameTime.TotalSeconds;
            if (timeSinceLastFrameSwitch > 1.0 / FPS)
            {
                timeSinceLastFrameSwitch = 0;
                frame = (frame + 1) % frameSource.Count;
            }
        }

        public bool AnimationFinished()
        {
            if (frame >= frameSource.Count - 1) return true;
            return false;
        }

        private Rectangle GetScaledDestinationRectangle(Vector2 position)
        {
            int width;
            int height;
            if (SIZE_IN_BLOCKS > 0)
            {
                /*if (frameSource[frame].Width > frameSource[frame].Height)
                {
                    double aspectRatio = (double)frameSource[frame].Height / frameSource[frame].Width;
                    width = (int)(SIZE_IN_BLOCKS * Settings.BLOCK_SIZE);
                    height = (int)(width * aspectRatio);
                }
                else
                {
                    double aspectRatio = (double)frameSource[frame].Width / frameSource[frame].Height;
                    height = (int)(SIZE_IN_BLOCKS * Settings.BLOCK_SIZE);
                    width = (int)(height * aspectRatio);
                }*/
                if (frameSource == frameSourceDown || frameSource == frameSourceUp)
                {
                    double aspectRatio = (double)frameSource[frame].Height / frameSource[frame].Width;
                    double widthDbl = SIZE_IN_BLOCKS * Settings.BLOCK_SIZE;
                    width = (int)(widthDbl);
                    height = (int)(widthDbl * aspectRatio);
                } else if (frameSource == frameSourceRight)
                {
                    double aspectRatio = (double)frameSource[frame].Width / frameSource[frame].Height;
                    double heightDbl = SIZE_IN_BLOCKS * Settings.BLOCK_SIZE;
                    height = (int)(heightDbl);
                    width = (int)(heightDbl * aspectRatio);
                } else
                {
                    double aspectRatio = (double)frameSource[frame].Width / frameSource[frame].Height;
                    double heightDbl = SIZE_IN_BLOCKS * Settings.BLOCK_SIZE;
                    height = (int)(heightDbl);
                    width = (int)(heightDbl * aspectRatio);
                    int x = Math.Abs(width - height);
                    return new Rectangle((int)position.X - x, (int)position.Y, width, height);
                }
             
            }
            else
            {
                width = frameSource[frame].Width;
                height = frameSource[frame].Height;
            }
            return new Rectangle((int)position.X, (int)position.Y, width, height);
        }

        private Rectangle GetSourceRectangle()
        {
            // use frame and map to get source rectangle
            return frameSource[frame];
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

