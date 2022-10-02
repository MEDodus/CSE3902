using Microsoft.Xna.Framework;
using Zelda.Blocks;
using Zelda.Items;

namespace Zelda.Commands.Classes
{
    public class CycleBlockPrevious : ICommand
    {
        private readonly BlockBuilder blockBuilder;

        public CycleBlockPrevious(BlockBuilder blockBuilder)
        {
            this.blockBuilder = blockBuilder;
        }

        private double lastExecuteTime = 0;
        public void Execute(GameTime gameTime)
        {
            double currentTime = gameTime.TotalGameTime.TotalSeconds;
            if (currentTime - lastExecuteTime > 0.25)
            {
                lastExecuteTime = currentTime;
                blockBuilder.PreviousBlock();
            }
        }
    }
}
