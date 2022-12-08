using Microsoft.Xna.Framework;
using System;
using Zelda.Link;
using Zelda.Rooms.Parsers;

namespace Zelda.Rooms
{
    public class RoomTransitions
    {
        private static readonly double ANIMATION_LENGTH = 1;

        private static Game1 game;
        private static Vector2 goal;
        private static Vector2 start;
        private static double animationTime = 0;

        public static void Initialize(Game1 game)
        {
            RoomTransitions.game = game;
        }

        public static void Update(GameTime gameTime, ILink link, ILink linkCompanion)
        {
            // Stop any currently running animations if the room transitioned suddenly, such as via debug input
            Vector2 roomPosition = RoomBuilder.Instance.CurrentRoom.Position;
            if (goal != roomPosition)
            {
                animationTime = 0;
            }
            Vector2 linkPosition = link.Position;
            Vector2 linkCompanionPosition = linkCompanion.Position;
            // Detect room transitions
            if (linkPosition.X < roomPosition.X)
            {
                Transition(Room.Direction.Left);
                linkCompanion.Position = linkPosition + new Vector2(Settings.BLOCK_SIZE * -2, 0);
            }
            else if (linkPosition.X > roomPosition.X + Settings.ROOM_WINDOW_WIDTH)
            {
                Transition(Room.Direction.Right);
                linkCompanion.Position = linkPosition + new Vector2(Settings.BLOCK_SIZE * 1, 0);
            }
            else if (linkPosition.Y < roomPosition.Y)
            {
                Transition(Room.Direction.Up);
                linkCompanion.Position = linkPosition + new Vector2(0, Settings.BLOCK_SIZE * -2);

            }
            else if (linkPosition.Y > roomPosition.Y + Settings.ROOM_WINDOW_HEIGHT)
            {
                Transition(Room.Direction.Down);
                linkCompanion.Position = linkPosition + new Vector2(0, Settings.BLOCK_SIZE * 1);
            }
            else if (linkCompanionPosition.X < roomPosition.X)
            {
                Transition(Room.Direction.Left);
                link.Position = linkCompanionPosition + new Vector2(Settings.BLOCK_SIZE * -2, 0);
            }
            else if (linkCompanionPosition.X > roomPosition.X + Settings.ROOM_WINDOW_WIDTH)
            {
                Transition(Room.Direction.Right);
                link.Position = linkCompanionPosition + new Vector2(Settings.BLOCK_SIZE * 1, 0) ;
            }
            else if (linkCompanionPosition.Y < roomPosition.Y)
            {
                Transition(Room.Direction.Up);
                link.Position = linkCompanionPosition + new Vector2(0, Settings.BLOCK_SIZE * -2);

            }
            else if (linkCompanionPosition.Y > roomPosition.Y + Settings.ROOM_WINDOW_HEIGHT)
            {
                Transition(Room.Direction.Down);
                link.Position = linkCompanionPosition + new Vector2(0, Settings.BLOCK_SIZE * 1);
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

        public static void EnterWhiteBrickDungeon()
        {
            RoomBuilder roomBuilder = RoomBuilder.Instance;
            Room whiteBrickDungeon = roomBuilder.GetRoom("Room17");
            roomBuilder.CurrentRoom = whiteBrickDungeon;
            roomBuilder.WindowPosition = whiteBrickDungeon.Position;
            game.Link.Position = Parser.GetSpawnPosition(3, -1, whiteBrickDungeon) + new Vector2(0, Settings.BLOCK_SIZE + Settings.BLOCK_SIZE / 2);
            game.LinkCompanion.Position = Parser.GetSpawnPosition(3, -1, whiteBrickDungeon) + new Vector2(0, Settings.BLOCK_SIZE / 2);
        }

        public static void LeaveWhiteBrickDungeon()
        {
            RoomBuilder roomBuilder = RoomBuilder.Instance;
            Room spikeCrossRoom = roomBuilder.GetRoom("Room0");
            roomBuilder.CurrentRoom = spikeCrossRoom;
            roomBuilder.WindowPosition = spikeCrossRoom.Position;
            game.Link.Position = Parser.GetSpawnPosition(6, 3, spikeCrossRoom) + new Vector2 (-1 * Settings.BLOCK_SIZE, 0);
            game.LinkCompanion.Position = Parser.GetSpawnPosition(6, 3, spikeCrossRoom);
        }
    }
}
