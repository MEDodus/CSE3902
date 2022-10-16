using Microsoft.Xna.Framework;
using Zelda.Enemy;
using Zelda.NPCs.Classes;
using Zelda.Sprites.Factories;

namespace Zelda.NPCs.EnemyMultiDirection
{
    internal class LeftMovingSnakeState : INPCState
    {
        private Snake enemy;
        protected Vector2 moveDirection = new Vector2(1, 0);

        public LeftMovingSnakeState(Snake snake)
        {
            enemy = snake;
            enemy.sprite = NPCSpriteFactory.LeftSnakeSprite();
        }

        public void TurnLeft()
        {
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
            enemy.state = new UpMovingSnakeState(enemy);
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
            enemy.MoveLeft(gameTime);
        }
    }
}
