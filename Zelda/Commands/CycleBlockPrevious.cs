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
        private Game1 game;
        private Tiles tiles;

        public CycleBlockPrevious(Game1 game, Tiles tiles)
        {
            this.game = game;
            this.tiles = tiles;
        }

        public void Execute()
        {
            // "T" pressed
            tiles.PreviousTile();
        }
    }
}
