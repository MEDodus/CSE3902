using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zelda.Sprites;

namespace Zelda.Borders
{
    public abstract class IBorder
    {
        public bool Locked { get { return locked; } }

        protected ISprite sprite;
        protected Rectangle destination;
        protected bool locked;

        public IBorder(ISprite sprite, Rectangle destination, bool locked)
        {
            this.sprite = sprite;
            this.destination = destination;
            this.locked = locked;
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
