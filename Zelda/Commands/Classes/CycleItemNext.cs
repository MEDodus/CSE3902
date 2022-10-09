using Microsoft.Xna.Framework;
using Zelda.Items;

namespace Zelda.Commands.Classes
{
    public class CycleItemNext : ICommand
    {
        private readonly ItemBuilder itemBuilder;

        public CycleItemNext(ItemBuilder itemBuilder)
        {
            this.itemBuilder = itemBuilder;
        }

        private double lastExecuteTime = 0;
        public void Execute(GameTime gameTime)
        {
            double currentTime = gameTime.TotalGameTime.TotalSeconds;
            if (currentTime - lastExecuteTime > 0.25)
            {
                lastExecuteTime = currentTime;
                itemBuilder.NextItem();
            }
        }
    }
}
