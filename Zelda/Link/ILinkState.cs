using Microsoft.Xna.Framework.Graphics;

namespace Zelda.Link
{
    public interface ILinkState
    {
        void MoveUp();
        void MoveDown();
        void MoveLeft();
        void MoveRight();
        void Attack();
        void UseItem(int itemNum);
        void TakeDamage(Game1 game);

        public void Update();
        public void Draw(SpriteBatch spriteBatch);
    }
}
