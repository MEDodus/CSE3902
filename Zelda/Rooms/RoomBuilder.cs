using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using Zelda.Items;
using Zelda.Items.Classes;
using Zelda.Link;
using Zelda.NPCs;
using Zelda.Projectiles;
using Zelda.Rooms.Parsers;

namespace Zelda.Rooms
{
    public class RoomBuilder
    {
        private static RoomBuilder instance = new RoomBuilder();
        public static RoomBuilder Instance { get { return instance; } }

        public Room CurrentRoom { 
            get 
            { 
                return rooms[i]; 
            } 
            set 
            {
                for (int j = 0; j < rooms.Length; j++)
                {
                    if (rooms[j] == value)
                    {
                        i = j;
                        break;
                    }
                }
            } 
        }
        public string CurrentLevel { get { return currentLevel; } }
        public Room[] Rooms { get { return rooms; } }
        public Vector2 WindowPosition { get { return windowPosition; } set { windowPosition = value; } }
        public Vector2 BaseWindowPosition { get { return BASE_WINDOW_POSITION; } }
        public Vector2 WindowOffset { get { return BASE_WINDOW_POSITION - windowPosition; } }
        public Room TriforceRoom { get { return triforceRoom; } }

        private string currentLevel;
        private Room[] rooms;
        private Dictionary<string, Room> roomMap = new Dictionary<string, Room>();
        private int i;
        private Vector2 windowPosition;
        private int startRoom;
        private Room triforceRoom;

        private static readonly Vector2 BASE_WINDOW_POSITION = new Vector2(Settings.ROOM_WINDOW_X, Settings.ROOM_WINDOW_Y);

        private RoomBuilder()
        { 
        }

        public void LoadLevel(string filename)
        {
            // Reset
            currentLevel = filename;
            LevelData levelData = new LevelData();
            LevelParser levelParser = new LevelParser(filename, levelData);
            levelParser.Parse();
            rooms = new Room[levelData.RoomCount];
            startRoom = levelData.StartRoom;
            i = startRoom;
            roomMap.Clear();

            // Build the rooms first
            for (int j = 0; j < levelData.RoomCount; j++)
            {
                Room room = new Room("Room" + j);
                rooms[j] = room;
                roomMap.Add(room.Name, room);
            }

            // Create the room graph starting from the entrance room
            windowPosition = BASE_WINDOW_POSITION;
            ConnectAdjacentRooms(CurrentRoom, windowPosition);

            // Parse the remaining room objects to populate the rooms
            foreach (Room room in rooms)
            {
                room.Parse();
            }

            // Check for the triforce room
            triforceRoom = CurrentRoom;
            foreach (Room room in rooms)
            {
                foreach (Item item in room.Items)
                {
                    if (item is Triforce)
                    {
                        triforceRoom = room;
                        break;
                    }
                }
            }
        }

        public void Reset()
        {
            LoadLevel(currentLevel);
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
                    adjacentRoomOffset = new Vector2(-Settings.ROOM_WINDOW_WIDTH, 0);
                else if (direction == Room.Direction.Right)
                    adjacentRoomOffset = new Vector2(Settings.ROOM_WINDOW_WIDTH, 0);
                else if (direction == Room.Direction.Up)
                    adjacentRoomOffset = new Vector2(0, -Settings.ROOM_WINDOW_HEIGHT);
                else
                    adjacentRoomOffset = new Vector2(0, Settings.ROOM_WINDOW_HEIGHT);
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
            foreach (Room room in rooms)
            {
                room.DrawTopLayer(spriteBatch);
            }
        }

        private void SetRoom(int roomIndex, ILink link, ILink linkCompanion)
        {
            CurrentRoom.HideNPCs();
            i = roomIndex;
            windowPosition = CurrentRoom.Position;
            CurrentRoom.ShowNPCs();
            link.Position = CurrentRoom.Position + new Vector2(7.5f * Settings.BLOCK_SIZE, 7 * Settings.BLOCK_SIZE);
            linkCompanion.Position = CurrentRoom.Position + new Vector2(8.5f * Settings.BLOCK_SIZE, 7 * Settings.BLOCK_SIZE);
            ProjectileStorage.Clear();
        }

        public void NextRoom(ILink link, ILink linkCompanion)
        {
            SetRoom((i + 1) % rooms.Length, link, linkCompanion);
        }

        public void PreviousRoom(ILink link, ILink linkCompanion)
        {
            SetRoom(i > 0 ? i - 1 : rooms.Length - 1, link, linkCompanion);
        }
    }
}
