using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Zelda.Items;
using Zelda.Items.Classes;

namespace Zelda.Rooms.Parsers
{
    public class ItemParser : Parser
    {
        private HashSet<IItem> items;

        public ItemParser(string filename, HashSet<IItem> items) : base("..\\..\\..\\Rooms\\Files\\" + filename + "\\items.csv")
        {
            this.items = items;
        }

        protected override void ParseObject(string identifier, int i, int j)
        {
            IItem item;
            Vector2 spawnPos = GetSpawnPosition(i, j);
            switch (identifier)
            {
                case "arrow":
                    item = new Arrow(spawnPos);
                    break;
                default:
                    throw new Exception("Item type not found: " + identifier);
            }

            items.Add(item);
        }
    }
}
