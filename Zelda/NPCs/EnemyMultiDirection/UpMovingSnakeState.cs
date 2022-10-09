using Microsoft.Xna.Framework;
using Zelda.Enemy;
using Zelda.NPCs.Classes;

namespace Zelda.NPCs.EnemyMultiDirection
{
    internal class UpMovingSnakeState : INPCState
    {
        private SnakeRefactor enemy;

        public UpMovingSnakeState(SnakeRefactor snake)
        {
            enemy = snake;
            //dont update sprite as snake only has left and right sprite
        }

        public void TurnLeft()
        {
            enemy.state = new LeftMovingSnakeState(enemy);
        }

        public void TurnRight()
        {
            enemy.state = new RightMovingSnakeState(enemy);
        }

        public void TurnDown()
        {
            enemy.state = new DownMovingSnakeState(enemy);
        }

        public void TurnUp()
        {
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

        public void Update(GameTime gameTime)
        {
            enemy.MoveUp(gameTime);
        }
    }
}
