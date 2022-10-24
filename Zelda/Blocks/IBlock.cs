using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Zelda.Sprites;

namespace Zelda.Blocks
{
    public abstract class IBlock
    {
        public ISprite Sprite { get { return sprite; } }
        public bool CanCollide { get { return canCollide; } }
        public bool IsGap { get { return isGap; } }

        protected ISprite sprite;
        protected Vector2 position;
        protected bool canCollide;
        protected bool isGap; // canCollide is true but projectiles can fly over

        public IBlock(ISprite sprite, Vector2 position, bool canCollide, bool isGap)
        {
            this.sprite = sprite;
            this.position = position;
            this.canCollide = canCollide;
            this.isGap = isGap;
        }

        public virtual void Update(GameTime gameTime)
        {

        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, position);
        }
    }
}
