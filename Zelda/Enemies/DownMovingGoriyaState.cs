using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zelda.Enemy
{
    public class DownMovingGoriyaState : IEnemyState
    {
        private Goriya enemy;

        public DownMovingGoriyaState(Goriya Goriya)
        {
            this.enemy = Goriya;
            //this.enemy.texture = enemy.Texture;
        }

        public void TurnLeft()
        {
            enemy.state = new LeftMovingGoriyaState(enemy);
        }

        public void TurnRight()
        {
            enemy.state = new RightMovingGoriyaState(enemy);
        }

        public void TurnDown()
        {
            //no change
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
