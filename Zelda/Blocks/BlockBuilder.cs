using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zelda.Blocks.Classes;

namespace Zelda.Blocks
{
    public class BlockBuilder
    {
        private static readonly Vector2 SPAWN_POS = new Vector2(300, 100);
        private IBlock[] blocks = new IBlock[10];
        private int i = 0;

        public BlockBuilder()
        {
            blocks[0] = new BlueFloor(SPAWN_POS);
            blocks[1] = new PushableBlock(SPAWN_POS);
            blocks[2] = new Statue1(SPAWN_POS);
            blocks[3] = new Statue2(SPAWN_POS);
            blocks[4] = new WhiteBrick(SPAWN_POS);  
            blocks[5] = new BlackGap(SPAWN_POS);
            blocks[6] = new BlueSand(SPAWN_POS);
            blocks[7] = new BlueGap(SPAWN_POS);
            blocks[8] = new Stairs(SPAWN_POS);
            blocks[9] = new Ladder(SPAWN_POS);
        }

        public void PreviousBlock()
        {
            if (i == 0)
            {
                i = blocks.Length - 1;
            }
            else
            {
                i--;
            }
        }

        public void NextBlock()
        {
            i = (i + 1) % blocks.Length;
        }

        public void Reset()
        {
            i = 0;
        }

        public void Update(GameTime gameTime)
        {
            blocks[i].Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            blocks[i].Draw(spriteBatch);
        }
    }
}
