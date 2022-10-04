using Microsoft.Xna.Framework;
using Zelda.Enemy;
using Zelda.NPCs.Classes;
using Zelda.Sprites.Factories;

namespace Zelda.NPCs.EnemyMultiDirection
{
    internal class LeftMovingGoriyaState : INPCState
    {
        private Goriya enemy;
        protected Vector2 moveDirection = new Vector2(1, 0);

        public LeftMovingGoriyaState(Goriya goriya)
        {
            enemy = goriya;
            enemy.sprite = NPCSpriteFactory.LeftGoriyaSprite();
        }

        public void TurnLeft()
        {
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
            enemy.Attack(new Vector2(-1, 0));
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
