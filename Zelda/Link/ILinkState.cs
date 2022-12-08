using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Zelda.Link
{
    public interface ILinkState
    {
        void MoveUp();
        void MoveDown();
        void MoveLeft();
        void MoveRight();
        void TakeDamage(Game1 game, Vector2 pushDirection);
        void Attack();
        void AttackSecondary();
        public void Update();
    }
}
