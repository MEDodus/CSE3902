using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zelda.Sprites;

namespace Zelda.Commands
{
    public class Reset : ICommand
    {
        private Tiles tiles;
        private Items items;

        public Reset(Items items, Tiles tiles)
        {
            this.items = items;
            this.tiles = tiles;
        }

        public void Execute()
        {
            // Add other classes to reset
            items.Reset();
            tiles.Reset();
        }
    }
}
