using System.IO;
using System;

namespace Zelda.Rooms.Parsers
{
    public abstract class Parser
    {
        private string filename;
        protected object collection;

        public Parser(string filename, object collection)
        {
            this.filename = filename;
            this.collection = collection;
        }

        public void Parse()
        {
            try
            {
                StreamReader reader = new StreamReader(filename);
                int j = 0;
                while (!reader.EndOfStream)
                {
                    string[] row = reader.ReadLine().Split(',');
                    int i = 0;
                    foreach (string identifier in row)
                    {
                        ParseObject(identifier, i, j);
                        i++;
                    }
                    j++;
                }
                reader.Close();
            }
            catch
            {
                throw new Exception("Failed to parse blocks from file: " + filename);
            }
        }

        protected abstract void ParseObject(string identifier, int i, int j);
    }
}
