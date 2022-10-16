using Microsoft.Xna.Framework;
using Zelda.Rooms;

namespace Zelda.Commands.Classes
{
    public class CycleRoomPrevious : ICommand
    {
        private readonly RoomBuilder roomBuilder;

        public CycleRoomPrevious(RoomBuilder roomBuilder)
        {
            this.roomBuilder = roomBuilder;
        }

        private double lastExecuteTime = 0;
        public void Execute(GameTime gameTime)
        {
            double currentTime = gameTime.TotalGameTime.TotalSeconds;
            if (currentTime - lastExecuteTime > 0.25)
            {
                lastExecuteTime = currentTime;
                roomBuilder.PreviousRoom();
            }
        }
    }
}
