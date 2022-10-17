using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zelda.Sprites;

namespace Zelda.Borders
{
    public abstract class IBorder
    {
        protected ISprite sprite;
        protected Rectangle destination;

        public IBorder(ISprite sprite, Rectangle destination)
        {
            this.sprite = sprite;
            this.destination = destination;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, destination);
        }

        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }
    }
}
