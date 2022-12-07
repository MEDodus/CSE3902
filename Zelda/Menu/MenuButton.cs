using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zelda.Sprites;
using Zelda.Sprites.Factories;

namespace Zelda.Menu
{
    public class MenuButton
    {
        public Rectangle Destination { get { return buttonSprite.Destination; } }

        private Vector2 position;
        private string text;
        private ISprite buttonSprite;
        private SpriteFont font;

        private static readonly int WIDTH = 300;
        private static readonly int HEIGHT = WIDTH / 4;

        public MenuButton(Vector2 position, string text)
        {
            this.position = position;
            this.text = text;
            buttonSprite = MenuSpriteFactory.MenuButtonSprite();
            font = MenuSpriteFactory.MenuFont();
        }

        public void Update(GameTime gameTime)
        {
            buttonSprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            buttonSprite.Draw(spriteBatch, new Rectangle((int)position.X, (int)position.Y, WIDTH, HEIGHT));
            spriteBatch.DrawString(font, text, position + new Vector2(40, 20), Color.PeachPuff);
        }
    }
}
