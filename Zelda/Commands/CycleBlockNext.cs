using Zelda.Blocks;

namespace Zelda.Commands
{
    public class CycleBlockNext : ICommand
    {
        private static int MOD = 6;
        private Tiles tiles;
        private int frame;

        public CycleBlockNext(Tiles tiles)
        {
            this.tiles = tiles;
            this.frame = 0;
        }

        public void Execute()
        {
            // "Y" pressed
            if (frame % MOD == 0) tiles.NextTile();
            frame++;
            frame %= MOD;
        }
    }
}
