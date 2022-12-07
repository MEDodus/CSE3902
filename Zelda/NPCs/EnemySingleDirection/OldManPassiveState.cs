using Microsoft.Xna.Framework;
using Zelda.Enemy;
using Zelda.NPCs.Classes;
using Zelda.Sprites.Factories;

namespace Zelda.NPCs.EnemyMultiDirection
{
    internal class OldManPassiveState : INPCState
    {
        private OldMan enemy;

        public OldManPassiveState(OldMan oldMan)
        {
            enemy = oldMan;
            enemy.Sprite = NPCSpriteFactory.OldManSprite();
        }

        public void TurnLeft() { }

        public void TurnRight() { }

        public void TurnDown() { }

        public void TurnUp() { }

        public void Attack() { }
        public void TakeDamage()
        {
            enemy.State = new OldManAgroState(enemy);
        }
        public void KilledEnemyState() { }

        public void Update(GameTime gameTime) { }
    }
}
