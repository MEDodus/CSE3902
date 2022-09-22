using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zelda.Sprites;

namespace Zelda.Commands
{
    internal class CycleBlockPrevious : ICommand
    {
        private static int MOD = 6;
        private Game1 game;
        private Tiles tiles;
        private int frame;

        public CycleBlockPrevious(Game1 game, Tiles tiles)
        {
            this.game = game;
            this.tiles = tiles;
            this.frame = 0;
        }

        public void Execute()
        {
            // "T" pressed
            if (frame % MOD == 0) tiles.PreviousTile();
            frame++;
            frame %= MOD;
        }
    }
}
