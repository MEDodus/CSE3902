using Microsoft.Xna.Framework;
using Zelda.Enemy;
using Zelda.NPCs.Classes;
using Zelda.Sprites.Factories;

namespace Zelda.NPCs.EnemyMultiDirection
{
    internal class DamagedVertMovingDodongoState : INPCState
    {
        private Dodongo enemy;

        public DamagedVertMovingDodongoState(Dodongo dodongo)
        {
            enemy = dodongo;
            enemy.sprite = NPCSpriteFactory.DamagedVertDodongoSprite();
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
