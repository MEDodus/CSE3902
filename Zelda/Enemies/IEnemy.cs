using Microsoft.Xna.Framework.Graphics;


namespace Zelda.Enemy
{
    public interface IEnemy
    {
        //public Texture2D Texture { get; }
        //public Rectangle SourceLocation { get; set; }
        //public Rectangle DestinationLocation { get; set; }

        //public IEnemyState state;

        public void Update();
        public void Draw(SpriteBatch spriteBatch);

        void MoveUp();
        void MoveDown();
        void MoveLeft();
        void MoveRight();
        void Attack();
        void TakeDamage(int damage);

    }
}
