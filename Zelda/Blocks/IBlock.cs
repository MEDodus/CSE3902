using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Zelda.Sprites;

namespace Zelda.Blocks
{
    public abstract class IBlock
    {
        protected ISprite sprite;
        protected Vector2 position;
        protected Boolean barrier;
        public Boolean Barrier { get { return barrier; } set { barrier = value; } }

        public IBlock(ISprite sprite, Vector2 position, Boolean barrier)
        {
            this.sprite = sprite;
            this.position = position;
            this.barrier = barrier;
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
