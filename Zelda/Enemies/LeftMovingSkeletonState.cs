using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zelda.Enemy
{
    public class LeftMovingSkeletonState : IEnemyState
    {
        private Skeleton enemy;

        public LeftMovingSkeletonState(Skeleton skeleton)
        {
            this.enemy = skeleton;
            //this.enemy.texture = enemy.Texture;
        }

        public void TurnLeft()
        {
            //keep same direction
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
            enemy.state = new UpMovingSkeletonState(enemy);
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
