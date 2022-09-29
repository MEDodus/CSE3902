using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Zelda.Enemy
{
    public class Jelly : IEnemy
    {
        public IEnemyState state;

        //Texture Atlas Variables
        private Texture2D texture = TextureStorage.GetTexture(TextureStorage.SpriteSheet.JellyBlue);
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        private int WIDTH;
        private int HEIGHT;

        //sprite frame
        private int ROWS = 1;
        private int COLUMNS = 2;
        private int spriteRow = 0;
        private int spriteColumn = 0;
        private Vector2 location;

        //public Texture2D Texture { get { return texture; } set { texture = value; } }
        public Vector2 Location { get { return location; } set { location = value; } }
        //public Rectangle SourceLocation { get { return sourceRectangle; } set { } }
        // public Rectangle DestinationLocation { get { return destinationRectangle; } set { } }


        private int health = 1;


        private readonly int speed = 5;



        public Jelly()
        {
            texture = TextureStorage.GetTexture(TextureStorage.SpriteSheet.JellyBlue);
            WIDTH = 32;//texture.Width / COLUMNS;
            HEIGHT = 36;//texture.Height / ROWS;

            sourceRectangle = new Rectangle(WIDTH * spriteColumn, 0, WIDTH, HEIGHT);
            destinationRectangle = new Rectangle(100, 100, WIDTH, HEIGHT);
            state = new UpMovingJellyState(this);


        }

        public void Update()
        {
            state.Update();
            //state.Draw(spritebatch);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }

        public void MoveUp()
        {
            location.Y = location.Y - speed;
            spriteColumn++;
            if (spriteColumn >= COLUMNS)
            {
                spriteColumn = 1;
            }
        }
        public void MoveDown()
        {
            location.Y = location.Y + speed;
            spriteColumn++;
            if (spriteColumn >= COLUMNS)
            {
                spriteColumn = 1;
            }
        }
        public void MoveLeft()
        {
            location.X = location.X - speed;
            spriteColumn++;
            if (spriteColumn >= COLUMNS)
            {
                spriteColumn = 1;
            }
        }
        public void MoveRight()
        {
            location.X = location.X + speed;
            spriteColumn++;
            if (spriteColumn >= COLUMNS)
            {
                spriteColumn = 1;
            }
        }
        public void Attack()
        {
            //implement attack later
        }
        public void TakeDamage(int damage)
        {
            health -= damage;

        }
        public void KilledEnemy()
        {
            //display killed enemy sprite
            //delete enemy
        }



    }
}
