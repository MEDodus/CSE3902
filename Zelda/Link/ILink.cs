using Microsoft.Xna.Framework.Graphics;

namespace Zelda.Link
{
    public interface ILink
    {
        public Texture2D Texture { set { } }
        public void Update();

        public void Reset();
        public void Draw(SpriteBatch spriteBatch);

        void MoveUp();
        void MoveDown();
        void MoveLeft();
        void MoveRight();
        void Attack();
        void UseItem(int itemNum);
        void TakeDamage(Game1 game);
    }
}
