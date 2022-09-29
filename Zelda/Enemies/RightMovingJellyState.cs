namespace Zelda.Enemy
{
    public class RightMovingJellyState : IEnemyState
    {
        private Jelly enemy;

        public RightMovingJellyState(Jelly jelly)
        {
            this.enemy = jelly;
            //this.enemy.texture = enemy.Texture;
        }

        public void TurnLeft()
        {
            enemy.state = new LeftMovingJellyState(enemy);
        }

        public void TurnRight()
        {
            //stay same direction
        }
        public void TurnDown()
        {
            enemy.state = new DownMovingJellyState(enemy);
        }

        public void TurnUp()
        {
            enemy.state = new UpMovingJellyState(enemy);
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
