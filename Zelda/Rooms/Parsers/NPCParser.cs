using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using Zelda.NPCs;
using Zelda.NPCs.Classes;

namespace Zelda.Parsers
{
    public class NPCParser
    {
        private string fileName;
        private Dictionary<int, List<INPC>> npcs;
        public NPCParser(string value, Dictionary<int, List<INPC>> dict)
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
                        npcs.Add(row, new List<INPC>());
                    }

                    List<INPC> list = npcs[row];
                    foreach (string npcName in npcsInRow)
                    {
                        list.Add(GetNPC(npcName));
                    }
                }
                npcReader.Close();
            }
            catch
            {
                throw new Exception("Failed to create stream reader blockReader");
            }
        }

        public INPC GetNPC(string value)
        {
            // TODO:
            /* Using switch statement or mapping to retrieve npc type */
            return new Gel(new Vector2(0, 0));
        }
    }
}
