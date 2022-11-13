using Microsoft.Xna.Framework;
using System.IO;

namespace Zelda.Rooms.Parsers
{
    public abstract class Parser
    {
        protected Room room;
        private string filename;

        public Parser(Room room, string filename)
        {
            this.room = room;
            this.filename = filename;
        }

        public virtual void Parse()
        {
            if (!File.Exists(filename))
            {
                return;
            }
            StreamReader reader = new StreamReader(filename);
            int j = 0;
            while (!reader.EndOfStream)
            {
                string[] row = reader.ReadLine().Split(',');
                int i = 0;
                foreach (string identifier in row)
                {
                    if (identifier != ".")
                    {
                        ParseObject(identifier, i, j);
                    }
                    i++;
                }
                j++;
            }
            reader.Close();
        }

        protected abstract void ParseObject(string identifier, int i, int j);

        public static Vector2 GetSpawnPosition(int i, int j, Room room)
        {
            Vector2 offset = room.Position - RoomBuilder.Instance.BaseWindowPosition + new Vector2(Settings.BORDER_SIZE, Settings.BORDER_SIZE);
            return new Vector2(Settings.ROOM_WINDOW_X + (i * Settings.BLOCK_SIZE), Settings.ROOM_WINDOW_Y + (j * Settings.BLOCK_SIZE)) + offset;
        }
    }
}
