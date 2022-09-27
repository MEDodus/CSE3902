using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zelda.Enemy
{
    public class UpMovingSkeletonState : IEnemyState
    {
        private Skeleton enemy;

        public UpMovingSkeletonState(Skeleton Skeleton)
        {
            this.enemy = Skeleton;
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
            enemy.state = new DownMovingSkeletonState(enemy);
        }

        public void TurnUp()
        {
            //no implementation - keep same direction
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
