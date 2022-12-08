using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zelda.Sprites;
using Zelda.Sprites.Factories;

namespace Zelda.Menu
{
    public class Accomplish_DodongoScream
    {
        public Rectangle Destination { get { return DodongoScreamSprite.Destination; } }


        private Vector2 position;
        private ISprite DodongoScreamSprite;


        private static readonly int WIDTH = 600;
        private static readonly int HEIGHT = WIDTH / 6;

        public Accomplish_DodongoScream(Vector2 position)
        {
            this.position = position;
            DodongoScreamSprite = AccomplishmentSpriteFactory.DodongoScreamSprite();

        }

        public void Update(GameTime gameTime)
        {
            DodongoScreamSprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            DodongoScreamSprite.Draw(spriteBatch, new Rectangle((int)position.X, (int)position.Y, WIDTH, HEIGHT));
        }
    }
}