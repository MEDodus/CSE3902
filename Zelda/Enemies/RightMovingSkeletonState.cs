namespace Zelda.Enemy
{
    public class RightMovingSkeletonState : IEnemyState
    {
        private Skeleton enemy;

        public RightMovingSkeletonState(Skeleton Skeleton)
        {
            this.enemy = Skeleton;
            //this.enemy.texture = enemy.Texture;
        }

        public void TurnLeft()
        {
            enemy.state = new LeftMovingSkeletonState(enemy);
        }

        public void TurnRight()
        {
            //stay same direction
        }
        public void TurnDown()
        {
            enemy.state = new DownMovingSkeletonState(enemy);
        }

        public void TurnUp()
        {
            enemy.state = new UpMovingSkeletonState(enemy);
        }

        public void Attack()
        {
            //wait to implement enemy attack
            //enemy.state = new AttackingEnemyState(enemy);
        }
        public void TakeDamage()
        {
            //wait to implement damaged state
            //enemy.state = new DamagedEnemyState(enemy);
        }
        public void KilledEnemyState()
        {
            //wait on implementation
            //enemy.state = new KilledEnemyState(enemy);
        }

        public void Update()
        {
            enemy.MoveLeft();
        }
    }
}
