namespace Zelda.Rooms.Parsers
{
    public class LevelData
    {
        public int RoomCount { get { return roomCount; } set { roomCount = value; } }
        public int StartRoom { get { return startRoom; } set { startRoom = value; } }

        private int roomCount;
        private int startRoom;

        public LevelData()
        {
            
        }
    }
}
