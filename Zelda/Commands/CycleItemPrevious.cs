using Zelda.Sprites;

namespace Zelda.Commands
{
    public class CycleItemPrevious : ICommand
    {
        private static int MOD = 6;
        private Items items;
        private int frame;

        public CycleItemPrevious(Items items)
        {
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
