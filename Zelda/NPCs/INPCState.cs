using Microsoft.Xna.Framework;

namespace Zelda.Enemy
{
    public interface INPCState
    {
        void TurnLeft();
        void TurnRight();
        void TurnUp();
        void TurnDown();
        void Attack();
        void TakeDamage();
        public void Update(GameTime gameTime);
    }
}
