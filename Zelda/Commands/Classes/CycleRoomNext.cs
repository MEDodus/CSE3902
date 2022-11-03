using Microsoft.Xna.Framework;
using Zelda.Link;
using Zelda.Rooms;

namespace Zelda.Commands.Classes
{
    public class CycleRoomNext : ICommand
    {
        private ILink link;

        public CycleRoomNext(ILink link)
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
                RoomBuilder.Instance.NextRoom(link);
            }
        }
    }
}
