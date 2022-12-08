using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zelda.Sprites;
using Zelda.Sprites.Factories;

namespace Zelda.Menu
{
    public class BackButton
    {
        public Rectangle Destination { get { return sprite.Destination; } }

        private ISprite sprite;

        private readonly int X = 100;
        private readonly int Y = 100;
        private readonly int WIDTH = 81;
        private readonly int HEIGHT = 55;

        public BackButton()
        {
            sprite = MenuSpriteFactory.BackButtonSprite();
        }

        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, new Rectangle(X, Y, WIDTH, HEIGHT));
        }
    }
}
