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
    internal class RightMovingDodongoState : INPCState
    {
        private Dodongo enemy;

        public RightMovingDodongoState(Dodongo dodongo)
        {
            enemy = dodongo;
            enemy.sprite = NPCSpriteFactory.RightMovingDodongoSprite();
        }

        public void TurnLeft()
        {
            enemy.state = new LeftMovingDodongoState(enemy);
        }

        public void TurnRight()
        {
        }

        public void TurnDown()
        {
            enemy.state = new DownMovingDodongoState(enemy);

        }

        public void TurnUp()
        {
            enemy.state = new UpMovingDodongoState(enemy);

        }

        public void Attack()
        {
            //wait to implement enemy attack
            //enemy.state = new AttackingEnemyState(enemy);
        }
        public void TakeDamage()
        {
            //wait to implement damaged state
            enemy.state = new DamagedRightMovingDodongoState(enemy);
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
