using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zelda.Sprites;
using Zelda.Sprites.Factories;

namespace Zelda.Menu
{
    public class BackButton
    {
        public Rectangle Destination { get { return sprite.Destination; } }

        private Vector2 position;
        private ISprite sprite;

        private static readonly int WIDTH = 81;
        private static readonly int HEIGHT = 55;

        public BackButton(Vector2 position)
        {
            this.position = position;
            sprite = MenuSpriteFactory.BackButtonSprite();
        }

        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, new Rectangle((int)position.X, (int)position.Y, WIDTH, HEIGHT));
        }
    }
}
