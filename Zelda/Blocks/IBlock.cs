using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zelda.Sprites;

namespace Zelda.Blocks
{
    public abstract class IBlock
    {
        protected ISprite sprite;
        protected Vector2 position;

        public IBlock(ISprite sprite, Vector2 position)
        {
            this.sprite = sprite;
            this.position = position;
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
