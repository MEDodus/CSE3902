using Microsoft.Xna.Framework;
using System;
using System.IO;

namespace Zelda.Rooms.Parsers
{
    public abstract class Parser
    {
        private string filename;

        public Parser(string filename)
        {
            this.filename = filename;
        }

        public void Parse()
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

        protected static Vector2 GetSpawnPosition(int i, int j)
        {
            return new Vector2(Settings.ROOM_POSITION_X + (i * Settings.BLOCK_SIZE), Settings.ROOM_POSITION_Y + (j * Settings.BLOCK_SIZE));
        }
    }
}
