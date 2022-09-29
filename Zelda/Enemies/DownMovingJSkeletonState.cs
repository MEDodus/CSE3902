namespace Zelda.Enemy
{
    public class DownMovingSkeletonState : IEnemyState
    {
        private Skeleton enemy;

        public DownMovingSkeletonState(Skeleton skeleton)
        {
            this.enemy = skeleton;
            //this.enemy.texture = enemy.Texture;
        }

        public void TurnLeft()
        {
            enemy.state = new LeftMovingSkeletonState(enemy);
        }

        public void TurnRight()
        {
            enemy.state = new RightMovingSkeletonState(enemy);
        }

        public void TurnDown()
        {
            //no change
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
