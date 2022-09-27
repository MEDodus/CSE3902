using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zelda.Enemy
{
    public class RightMovingGoriyaState : IEnemyState
    {
        private Goriya enemy;

        public RightMovingGoriyaState(Goriya Goriya)
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
            //stay same direction
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
