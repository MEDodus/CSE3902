using Microsoft.Xna.Framework;
using Zelda.Enemy;
using Zelda.NPCs.Classes;
using Zelda.Sprites.Factories;

namespace Zelda.NPCs.EnemyMultiDirection
{
    internal class OldManGhostState : INPCState
    {
        private OldMan ghost;

        public OldManGhostState(OldMan oldMan)
        {
            ghost = oldMan;
            ghost.Sprite = NPCSpriteFactory.LeftGhostFollower();
        }

        public void TurnLeft()
        {
        }

        public void TurnRight()
        {
        }

        public void TurnDown()
        {
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

        }
        public void KilledEnemyState()
        {
        }

        public void Update(GameTime gameTime)
        {
            //ghost.Position = Link.Position + new Vector2(1, 1);
        }
    }
}
