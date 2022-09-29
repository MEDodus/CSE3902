namespace Zelda.Enemy
{
    public class LeftMovingGoriyaState : IEnemyState
    {
        private Goriya enemy;

        public LeftMovingGoriyaState(Goriya Goriya)
        {
            this.enemy = Goriya;
            //this.enemy.texture = enemy.Texture;
        }

        public void TurnLeft()
        {
            //keep same direction
        }

        public void TurnRight()
        {
            enemy.state = new RightMovingGoriyaState(enemy);
        }

        public void TurnDown()
        {
            enemy.state = new DownMovingGoriyaState(enemy);
        }

        public void TurnUp()
        {
            enemy.state = new UpMovingGoriyaState(enemy);
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
