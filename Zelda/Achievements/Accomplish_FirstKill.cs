using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zelda.Sprites;
using Zelda.Sprites.Factories;

namespace Zelda.Menu
{
    public class Accomplish_FirstKill
    {
        public Rectangle Destination { get { return FirstKillSprite.Destination; } }


        private Vector2 position;
        private ISprite FirstKillSprite;

        private static readonly int WIDTH = 600;
        private static readonly int HEIGHT = WIDTH / 6;

        public Accomplish_FirstKill(Vector2 position)
        {
            this.position = position;
            FirstKillSprite = AccomplishmentSpriteFactory.FirstKillSprite();
        }

        public void Update(GameTime gameTime)
        {
            FirstKillSprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            FirstKillSprite.Draw(spriteBatch, new Rectangle((int)position.X, (int)position.Y, WIDTH, HEIGHT));
        }
    }
}