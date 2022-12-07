using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zelda.Sprites;
using Zelda.Sprites.Factories;

namespace Zelda.Menu
{
    public class Accomplish_SecretWeapon
    {
        public Rectangle Destination { get { return SecretWeaponSprite.Destination; } }


        private Vector2 position;
        private ISprite SecretWeaponSprite;


        private static readonly int WIDTH = 600;
        private static readonly int HEIGHT = WIDTH / 6;

        public Accomplish_SecretWeapon(Vector2 position)
        {
            this.position = position;
            SecretWeaponSprite = AccomplishmentSpriteFactory.SecretWeaponSprite();
        }

        public void Update(GameTime gameTime)
        {
            SecretWeaponSprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            SecretWeaponSprite.Draw(spriteBatch, new Rectangle((int)position.X, (int)position.Y, WIDTH, HEIGHT));
        }
    }
}