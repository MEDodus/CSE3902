using Microsoft.Xna.Framework;
using Zelda.Link;

namespace Zelda.Rooms
{
    public class RoomTransitions
    {
        private static readonly double ANIMATION_LENGTH = 1;

        private static Vector2 goal;
        private static Vector2 start;
        private static double animationTime = 0;

        public static void Update(GameTime gameTime, ILink link)
        {
            // Stop any currently running animations if the room transitioned suddenly, such as via debug input
            Vector2 roomPosition = RoomBuilder.Instance.CurrentRoom.Position;
            if (goal != roomPosition)
            {
                animationTime = 0;
            }
            // Detect room transitions
            Vector2 linkPosition = link.Position;
            if (linkPosition.X < roomPosition.X)
            {
                Transition(Room.Direction.Left);
            }
            else if (linkPosition.X > roomPosition.X + Settings.ROOM_WINDOW_WIDTH)
            {
                Transition(Room.Direction.Right);
            }
            else if (linkPosition.Y < roomPosition.Y)
            {
                Transition(Room.Direction.Up);
            }
            else if (linkPosition.Y > roomPosition.Y + Settings.ROOM_WINDOW_HEIGHT)
            {
                Transition(Room.Direction.Down);
            }
            // Animate
            if (animationTime > 0)
            {
                animationTime -= gameTime.ElapsedGameTime.TotalSeconds;
                if (animationTime < 0)
                {
                    animationTime = 0;
                }
                float alpha = (float) ((ANIMATION_LENGTH - animationTime) / ANIMATION_LENGTH);
                RoomBuilder.Instance.WindowPosition = (goal - start) * alpha + start;
            }
        }

        private static void Transition(Room.Direction direction)
        {
            Room current = RoomBuilder.Instance.CurrentRoom;
            Room next = current.AdjacentRooms[direction];
            RoomBuilder.Instance.CurrentRoom = next;
            start = current.Position;
            goal = next.Position;
            Vector2 windowPosition = RoomBuilder.Instance.WindowPosition;
            double alpha; // 0 to 1, 0 = full animation needs to play, 1 = goal met
            if (direction == Room.Direction.Left || direction == Room.Direction.Right)
            {
                alpha = 1 - (goal.X - windowPosition.X) / (goal.X - start.X);
            }
            else
            {
                alpha = 1 - (goal.Y - windowPosition.Y) / (goal.Y - start.Y);
            }
            animationTime = (1 - alpha) * ANIMATION_LENGTH;
        }
    }
}
