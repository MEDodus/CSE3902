using Microsoft.Xna.Framework;
using Zelda.Blocks;
using Zelda.Items;

namespace Zelda.Commands.Classes
{
    public class CycleBlockNext : ICommand
    {
        private readonly BlockBuilder blockBuilder;

        public CycleBlockNext(BlockBuilder blockBuilder)
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
                blockBuilder.NextBlock();
            }
        }
    }
}
