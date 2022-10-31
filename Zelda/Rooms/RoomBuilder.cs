using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using Zelda.Projectiles;
using Zelda.Rooms.Parsers;

namespace Zelda.Rooms
{
    public class RoomBuilder
    {
        private static RoomBuilder instance = new RoomBuilder();
        public static RoomBuilder Instance { get { return instance; } }

        public Room CurrentRoom { get { return rooms[i]; } }
        public Vector2 WindowPosition { get { return windowPosition; } }
        public Vector2 WindowOffset { get { return BASE_WINDOW_POSITION - windowPosition; } }

        private Room[] rooms = new Room[17]; // TODO: re-add white brick dungeon and fix offset (change array size to 18 to do this)
        private Dictionary<string, Room> roomMap = new Dictionary<string, Room>();
        private int i;
        private Vector2 windowPosition;

        private static readonly Vector2 BASE_WINDOW_POSITION = new Vector2(Settings.ROOM_WINDOW_X, Settings.ROOM_WINDOW_Y);

        private RoomBuilder()
        { 
        }

        public void Initialize()
        {
            // Build the rooms first
            for (int j = 0; j < rooms.Length; j++)
            {
                Room room = new Room("Room" + j);
                rooms[j] = room;
                roomMap.Add(room.Name, room);
            }
            // Create the room graph starting from the entrance room
            i = 15;
            windowPosition = new Vector2(Settings.ROOM_WINDOW_X, Settings.ROOM_WINDOW_Y);
            ConnectAdjacentRooms(CurrentRoom, windowPosition);
            // Parse the remaining room objects to populate the rooms
            foreach (Room room in rooms)
            {
                room.Parse();
            }
        }

        private readonly HashSet<Room> seen = new HashSet<Room>();
        private void ConnectAdjacentRooms(Room room, Vector2 position)
        {
            room.Position = position;
            seen.Add(room);

            // Parse the adajcent rooms
            AdjacentRoomParser adjacentRoomParser = new AdjacentRoomParser(room, room.AdjacentRooms, this);
            adjacentRoomParser.Parse();

            // Recursively link adjacent rooms
            int roomWidth = Settings.ROOM_WIDTH * Settings.BLOCK_SIZE + 2 * Settings.BORDER_SIZE;
            int roomHeight = Settings.ROOM_HEIGHT * Settings.BLOCK_SIZE + 2 * Settings.BORDER_SIZE;
            foreach (KeyValuePair<Room.Direction, Room> entry in room.AdjacentRooms)
            {
                Room adjacentRoom = entry.Value;
                if (seen.Contains(adjacentRoom))
                {
                    continue;
                }
                Room.Direction direction = entry.Key;
                Vector2 adjacentRoomOffset;
                if (direction == Room.Direction.Left)
                    adjacentRoomOffset = new Vector2(-roomWidth, 0);
                else if (direction == Room.Direction.Right)
                    adjacentRoomOffset = new Vector2(roomWidth, 0);
                else if (direction == Room.Direction.Top)
                    adjacentRoomOffset = new Vector2(0, -roomHeight);
                else
                    adjacentRoomOffset = new Vector2(0, roomHeight);
                ConnectAdjacentRooms(adjacentRoom, position + adjacentRoomOffset);
            }
        }

        public Room GetRoom(string name)
        {
            return roomMap.GetValueOrDefault(name);
        }

        public void Update(GameTime gameTime)
        {
            rooms[i].Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Room room in rooms)
            {
                room.Draw(spriteBatch);
            }
        }

        public void DrawTopLayer(SpriteBatch spriteBatch)
        {
            rooms[i].DrawTopLayer(spriteBatch);
        }

        public void NextRoom()
        {
            i = (i + 1) % rooms.Length;
            windowPosition = CurrentRoom.Position;
            ProjectileStorage.Clear();
        }

        public void PreviousRoom()
        {
            i = i > 0 ? i - 1 : rooms.Length - 1;
            windowPosition = CurrentRoom.Position;
            ProjectileStorage.Clear();
        }
    }
}
