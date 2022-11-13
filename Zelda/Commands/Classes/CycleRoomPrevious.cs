using Microsoft.Xna.Framework;
using Zelda.Link;
using Zelda.Rooms;

namespace Zelda.Commands.Classes
{
    public class CycleRoomPrevious : ICommand
    {
        Game1 game;

        public CycleRoomPrevious(Game1 game)
        {
            this.game = game;
        }

        private double lastExecuteTime = 0;
        public void Execute(GameTime gameTime)
        {
            double currentTime = gameTime.TotalGameTime.TotalSeconds;
            if (currentTime - lastExecuteTime > 0.25)
            {
                lastExecuteTime = currentTime;
                RoomBuilder.Instance.PreviousRoom(game.Link);
            }
        }
    }
}
