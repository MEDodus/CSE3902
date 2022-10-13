using System.Collections.Generic;
using Zelda.Blocks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zelda.Parsers;
using Zelda.Items;
using Zelda.NPCs;

namespace Zelda.Rooms
{
    /* Grid room is a room that uses set array of tiles with a set number of rows and columns
     * strict csv files must be used, that is, csv file for blocks, items, and npcs.
     * They must all have the same number of rows and columns
     */
    public class GridRoom : IRoom
    {
        private BlockParser blockParser;
        //private ItemParser itemParser;
        //private NpcParser npcParser;
        private Dictionary<int, List<IBlock>> blocks;
        //private Dictionary<int, List<IItem>> items;
        //private Dictionary<int, List<INPC>> npcs;

        public GridRoom(string file, Viewport viewport)
        {
            blocks = new Dictionary<int, List<IBlock>>();
            //items = new Dictionary<int, List<IItem>>();
            //npcs = new Dictionary<int, List<INPC>>();
            blockParser = new BlockParser(file, blocks, viewport);
            //itemParser = new ItemParser(file + "/item.csv", items);
            //npcParser = new NpcParser(file + "/npc.csv", npcs);
            ReadFile();
        }

        public void ReadFile()
        {
            blockParser.ReadFile();
            //itemParser.ReadFile();
            //npcParser.ReadFile();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            int row = 0, length = blocks.Count;
            while (row < length)
            {
                List<IBlock> blockList = blocks[row];
                foreach (IBlock block in blockList)
                {
                    block.Draw(spriteBatch);
                }

                /*
                List<INPC> npcList = npcs[row];
                foreach (INPC npc in npcList)
                {
                    npc.Draw(spriteBatch);
                }

                List<IItem> itemList = items[row];
                foreach (IItem item in itemList)
                {
                    item.Draw(spriteBatch);
                } */
                row++;
            }
        }

        public void Update(GameTime gameTime)
        {
            int row = 0, length = blocks.Count;
            while (row < length)
            {
                List<IBlock> blockList = blocks[row];
                foreach (IBlock block in blockList)
                {
                    block.Update(gameTime);
                }

                /*
                List<INPC> npcList = npcs[row];
                foreach (INPC npc in npcList)
                {
                    npc.Update(gameTime);
                }

                List<IItem> itemList = items[row];
                foreach (IItem item in itemList)
                {
                    item.Update(gameTime);
                } */
                row++;
            }
        }
    }
}
