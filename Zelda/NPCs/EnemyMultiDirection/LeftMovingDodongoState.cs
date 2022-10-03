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
    internal class LeftMovingDodongoState : INPCState
    {
        private Dodongo enemy;

        public LeftMovingDodongoState(Dodongo dodongo)
        {
            enemy = dodongo;
            enemy.sprite = NPCSpriteFactory.LeftMovingDodongoSprite();
        }

        public void TurnLeft()
        {
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
            enemy.state = new UpMovingDodongoState(enemy);

        }

        public void Attack()
        {
            //wait to implement enemy attack
            //enemy.state = new AttackingEnemyState(enemy);
        }
        public void TakeDamage()
        {
            enemy.state = new DamagedLeftMovingDodongoState(enemy);
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
