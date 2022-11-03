using Microsoft.Xna.Framework;
using Zelda.Link;
using Zelda.Rooms;

namespace Zelda.Commands.Classes
{
    public class CycleRoomPrevious : ICommand
    {
        private ILink link;

        public CycleRoomPrevious(ILink link)
        {
            this.link = link;
        }

        private double lastExecuteTime = 0;
        public void Execute(GameTime gameTime)
        {
            double currentTime = gameTime.TotalGameTime.TotalSeconds;
            if (currentTime - lastExecuteTime > 0.25)
            {
                lastExecuteTime = currentTime;
                RoomBuilder.Instance.PreviousRoom(link);
            }
        }
    }
}
