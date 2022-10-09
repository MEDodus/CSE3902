using Microsoft.Xna.Framework;
using Zelda.Enemy;
using Zelda.NPCs.Classes;
using Zelda.Sprites.Factories;

namespace Zelda.NPCs.EnemyMultiDirection
{
    internal class DamagedLeftMovingDodongoState : INPCState
    {
        private Dodongo enemy;

        public DamagedLeftMovingDodongoState(Dodongo dodongo)
        {
            enemy = dodongo;
            enemy.sprite = NPCSpriteFactory.DamagedLeftDodongoSprite();
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
            //Collision detection, no attack animation
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
            //enemy.state = new LeftMovingDodongoState(enemy);
        }
    }
}
