using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zelda.Blocks.Classes;
using Zelda.Blocks;
using Zelda.Items;
using Microsoft.Xna.Framework;
using Zelda.Items.Classes;

namespace Zelda.Parsers
{
    public class ItemParser
    {
        private string fileName;
        private Dictionary<int, List<INPC>> items;
        public ItemParser(string value, Dictionary<int, List<INPC>> dict)
        {
            fileName = value;
            items = dict;
        }

        public void ReadFile()
        {
            StreamReader itemReader;
            try
            {
                itemReader = new StreamReader(fileName);
                int row = 0;
                while (!itemReader.EndOfStream)
                {
                    string[] itemsInRow = itemReader.ReadLine().Split(',');
                    if (!items.ContainsKey(row))
                    {
                        items.Add(0, new List<INPC>());
                    }

                    List<INPC> list = items[row];
                    foreach (string itemName in itemsInRow)
                    {
                        list.Add(GetItem(itemName));
                    }
                }
                itemReader.Close();
            }
            catch
            {
                throw new Exception("Failed to create stream reader blockReader");
            }
        }

        public INPC GetItem(string value)
        {
            // TODO:
            /* Using switch statement or mapping to retrieve item type */
            return new Fairy(new Vector2(0, 0));
        }
    }
}
