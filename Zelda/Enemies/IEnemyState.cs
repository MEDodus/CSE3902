namespace Zelda.Enemy
{
    public interface IEnemyState
    {
        void TurnLeft();
        void TurnRight();
        void TurnUp();
        void TurnDown();
        void Attack();
        void TakeDamage();
        public void Update();
    }
}
