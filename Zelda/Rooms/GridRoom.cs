using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Zelda.Blocks;
using Zelda.Items;
using Zelda.NPCs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Vector2 = Microsoft.Xna.Framework.Vector2;
using System.IO;
using Zelda.Sprites.Factories;
using Zelda.Blocks.Classes;
using Zelda.Parsers;

namespace Zelda.Rooms
{
    /* Grid room is a room that uses set array of tiles with a set number of rows and columns
     * strict csv files must be used, that is, csv file for blocks, items, and npcs.
     * They must all have the same number of rows and columns
     */
    public class GridRoom : IRoom
    {
        private BlockParser blockParser;
        private ItemParser itemParser;
        private NpcParser npcParser;
        private Dictionary<int, List<IBlock>> blocks;
        private Dictionary<int, List<Items.INPC>> items;
        private Dictionary<int, List<NPCs.INPC>> npcs;

        public GridRoom(string file)
        {
            blocks = new Dictionary<int, List<IBlock>>();
            items = new Dictionary<int, List<Items.INPC>>();
            npcs = new Dictionary<int, List<NPCs.INPC>>();
            blockParser = new BlockParser(file + "/block.csv", blocks);
            itemParser = new ItemParser(file + "/item.csv", items);
            npcParser = new NpcParser(file + "/npc.csv", npcs);
        }

        public void ReadFile()
        {
            blockParser.ReadFile();
            itemParser.ReadFile();
            npcParser.ReadFile();
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

                List<NPCs.INPC> npcList = npcs[row];
                foreach (NPCs.INPC npc in npcList)
                {
                    npc.Draw(spriteBatch);
                }

                List<Items.INPC> itemList = items[row];
                foreach (Items.INPC item in itemList)
                {
                    item.Draw(spriteBatch);
                }
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

                List<NPCs.INPC> npcList = npcs[row];
                foreach (NPCs.INPC npc in npcList)
                {
                    npc.Update(gameTime);
                }

                List<Items.INPC> itemList = items[row];
                foreach (Items.INPC item in itemList)
                {
                    item.Update(gameTime);
                }
                row++;
            }
        }
    }
}
