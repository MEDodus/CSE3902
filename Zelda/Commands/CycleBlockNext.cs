using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zelda.Sprites;

namespace Zelda.Commands
{
    public class CycleBlockNext : ICommand
    {
        private Game1 game;
        private Tiles tiles;

        public CycleBlockNext(Game1 game, Tiles tiles)
        {
            this.game = game;
            this.tiles = tiles;
        }

        public void Execute()
        {
            // "Y" pressed
            tiles.NextTile();
        }
    }
}
