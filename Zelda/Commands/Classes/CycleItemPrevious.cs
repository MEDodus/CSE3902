using Microsoft.Xna.Framework;
using Zelda.Items;

namespace Zelda.Commands.Classes
{
    public class CycleItemPrevious : ICommand
    {
        private readonly ItemBuilder itemBuilder;

        public CycleItemPrevious(ItemBuilder itemBuilder)
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
                itemBuilder.PreviousItem();
            }
        }
    }
}
