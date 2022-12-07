using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zelda.Sprites;
using Zelda.Sprites.Factories;

namespace Zelda.Menu
{
    public class Accomplish_DoorUnlock
    {
        public Rectangle Destination { get { return DoorUnlockedSprite.Destination; } }


        private Vector2 position;

        private ISprite DoorUnlockedSprite;


        private static readonly int WIDTH = 600;
        private static readonly int HEIGHT = WIDTH / 6;

        public Accomplish_DoorUnlock(Vector2 position)
        {
            this.position = position;
            DoorUnlockedSprite = AccomplishmentSpriteFactory.DoorUnlockedSprite();
    }

        public void Update(GameTime gameTime)
        {
            DoorUnlockedSprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            DoorUnlockedSprite.Draw(spriteBatch, new Rectangle((int)position.X, (int)position.Y, WIDTH, HEIGHT));
        }
    }
}