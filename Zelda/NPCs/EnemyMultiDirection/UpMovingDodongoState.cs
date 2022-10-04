using Microsoft.Xna.Framework;
using Zelda.Enemy;
using Zelda.NPCs.Classes;
using Zelda.Sprites.Factories;

namespace Zelda.NPCs.EnemyMultiDirection
{
    internal class UpMovingDodongoState : INPCState
    {
        private Dodongo enemy;

        public UpMovingDodongoState(Dodongo dodongo)
        {
            enemy = dodongo;
            enemy.sprite = NPCSpriteFactory.UpMovingDodongoSprite();
        }

        public void TurnLeft()
        {
            enemy.state = new LeftMovingDodongoState(enemy);
        }

        public void TurnRight()
        {
            enemy.state = new RightMovingDodongoState(enemy);
        }

        public void TurnDown()
        {
            enemy.state = new DownMovingDodongoState(enemy);

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
            enemy.state = new DamagedVertMovingDodongoState(enemy);

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
