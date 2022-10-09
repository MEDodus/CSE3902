using Microsoft.Xna.Framework;
using Zelda.NPCs;

namespace Zelda.Commands.Classes
{
    public class CycleNPCPrevious : ICommand
    {
        private readonly NPCBuilder npcBuilder;

        public CycleNPCPrevious(NPCBuilder npcBuilder)
        {
            this.npcBuilder = npcBuilder;
        }

        private double lastExecuteTime = 0;
        public void Execute(GameTime gameTime)
        {
            double currentTime = gameTime.TotalGameTime.TotalSeconds;
            if (currentTime - lastExecuteTime > 0.25)
            {
                lastExecuteTime = currentTime;
                npcBuilder.PreviousNPC();
            }
        }
    }
}
