using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zelda.NPCs.Classes;
using Microsoft.Xna.Framework;
using Zelda.NPCs;

namespace Zelda.Parsers
{
    public class NpcParser
    {
        private string fileName;
        private Dictionary<int, List<INPC>> npcs;
        public NpcParser(string value, Dictionary<int, List<INPC>> dict)
        {
            fileName = value;
            npcs = dict;
        }

        public void ReadFile()
        {
            StreamReader npcReader;
            try
            {
                npcReader = new StreamReader(fileName);
                int row = 0;
                while (!npcReader.EndOfStream)
                {
                    string[] npcsInRow = npcReader.ReadLine().Split(',');
                    if (!npcs.ContainsKey(row))
                    {
                        npcs.Add(0, new List<INPC>());
                    }

                    List<INPC> list = npcs[row];
                    foreach (string npcName in npcsInRow)
                    {
                        list.Add(GetNpc(npcName));
                    }
                }
                npcReader.Close();
            }
            catch
            {
                throw new Exception("Failed to create stream reader blockReader");
            }
        }

        public INPC GetNpc(string value)
        {
            // TODO:
            /* Using switch statement or mapping to retrieve npc type */
            return new Gel(new Vector2(0, 0));
        }
    }
}
