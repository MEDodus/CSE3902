using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zelda.Sprites;

namespace Zelda.NPCs
{
    public abstract class INPC
    {
        protected ISprite sprite;
        protected Vector2 position;

        public INPC(ISprite sprite, Vector2 position)
        {
            this.sprite = sprite;
            this.position = position;
        }

        public virtual void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, position);
        }
    }
}
