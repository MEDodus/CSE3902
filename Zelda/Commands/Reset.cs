using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zelda.Link;
using Zelda.Sprites;

namespace Zelda.Commands
{
    public class Reset : ICommand
    {
        private Tiles tiles;
        private Items items;
        private ILink link;

        public Reset(Items items, Tiles tiles, ILink link)
        {
            this.items = items;
            this.tiles = tiles;
            this.link = link;
        }

        public void Execute()
        {
            // Add other classes to reset
            items.Reset();
            tiles.Reset();
            link.Reset();
        }
    }
}
