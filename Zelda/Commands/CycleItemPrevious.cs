using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zelda.Sprites;

namespace Zelda.Commands
{
    public class CycleItemPrevious : ICommand
    {
        private static int MOD = 6;
        private Game1 game;
        private Items items;
        private int frame;

        public CycleItemPrevious(Game1 game, Items items)
        {
            this.game = game;
            this.items = items;
            this.frame = 0;
        }

        public void Execute()
        {
            if (frame % MOD == 0) items.PreviousItem();
            frame++;
            frame %= MOD;

        }
    }
}
