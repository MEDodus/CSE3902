using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Zelda.Rooms;
using Zelda.Sprites;

namespace Zelda.Blocks
{
    public abstract class Block
    {
        public ISprite Sprite { get { return sprite; } }
        public Vector2 Position { get { return position; } }
        public bool CanCollide { get { return canCollide; } set { canCollide = value; } }
        public bool IsGap { get { return isGap; } }

        protected ISprite sprite;
        protected Vector2 position;
        protected bool canCollide;
        protected bool isGap; // canCollide is true but projectiles can fly over

        public Block(ISprite sprite, Vector2 position, bool canCollide, bool isGap)
        {
            this.sprite = sprite;
            this.position = position;
            this.canCollide = canCollide;
            this.isGap = isGap;
        }

        public virtual void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, position + RoomBuilder.Instance.WindowOffset);
        }
    }
}
