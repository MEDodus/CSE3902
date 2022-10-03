using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zelda.Enemy;
using Zelda.NPCs.Classes;
using Zelda.Sprites.Factories;

namespace Zelda.NPCs.EnemyMultiDirection
{
    internal class DamagedRightMovingGoriyaState : INPCState
    {
        private Goriya enemy;
        protected Vector2 moveDirection = new Vector2(1, 0);

        public DamagedRightMovingGoriyaState(Goriya goriya)
        {
            enemy = goriya;
            enemy.sprite = NPCSpriteFactory.DamagedRightGoriyaSprite();
        }

        public void TurnRight()
        {
            enemy.state = new RightMovingGoriyaState(enemy);
        }

        public void TurnLeft()
        {
            enemy.state = new LeftMovingGoriyaState(enemy);
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
            enemy.Attack(new Vector2(0, -1));

        }
        public void TakeDamage()
        {

        }
        public void KilledEnemyState()
        {
            //wait on implementation
            //enemy.state = new KilledEnemyState(enemy);
        }

        public void Update(GameTime gameTime)
        {
            enemy.TakeDamage(1);
        }
    }
}

