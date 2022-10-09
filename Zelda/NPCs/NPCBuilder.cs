using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zelda.NPCs.Classes;

namespace Zelda.NPCs
{
    public class NPCBuilder
    {
        private readonly Vector2 SPAWN_POS = new Vector2(500, 500);
        private INPC[] npcs = new INPC[11];
        private int i = 0;

        public NPCBuilder()
        {
            Reset();
        }

        public void PreviousNPC()
        {
            if (i == 0)
            {
                i = npcs.Length - 1;
            }
            else
            {
                i--;
            }
        }

        public void NextNPC()
        {
            i = (i + 1) % npcs.Length;
        }

        public void Reset()
        {
            i = 0;
            npcs[0] = new OldMan(SPAWN_POS);
            npcs[1] = new Dragon(SPAWN_POS);
            npcs[2] = new Skeleton(SPAWN_POS);
            npcs[3] = new Bat(SPAWN_POS);
            npcs[4] = new Gel(SPAWN_POS);
            npcs[5] = new Zol(SPAWN_POS);
            npcs[6] = new Wallmaster(SPAWN_POS);
            npcs[7] = new SpikeCross(SPAWN_POS);
            npcs[8] = new SnakeRefactor(SPAWN_POS);
            npcs[9] = new Goriya(SPAWN_POS);
            npcs[10] = new Dodongo(SPAWN_POS);
        }

        public void Update(GameTime gameTime)
        {
            npcs[i].Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            npcs[i].Draw(spriteBatch);
        }
    }
}
