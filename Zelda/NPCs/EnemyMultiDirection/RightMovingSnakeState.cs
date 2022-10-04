using Microsoft.Xna.Framework;
using Zelda.Enemy;
using Zelda.NPCs.Classes;
using Zelda.Sprites.Factories;

namespace Zelda.NPCs.EnemyMultiDirection
{
    internal class RightMovingSnakeState : INPCState
    {
        private SnakeRefactor enemy;
        protected Vector2 moveDirection = new Vector2(1, 0);

        public RightMovingSnakeState(SnakeRefactor snake)
        {
            enemy = snake;
            enemy.sprite = NPCSpriteFactory.RightSnakeSprite();
        }

        public void TurnLeft()
        {
            enemy.state = new LeftMovingSnakeState(enemy);
        }

        public void TurnRight()
        {

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
            enemy.MoveRight(gameTime);
        }
    }
}
