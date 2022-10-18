using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Zelda.Blocks;
using Zelda.Borders;
using Zelda.Items;
using Zelda.NPCs;
using Zelda.Rooms.Parsers;

namespace Zelda.Rooms.Classes.Abstract
{
    public abstract class DungeonRoom : IRoom
    {
        public enum Direction { Left, Right, Top, Bottom }

        protected IBlock[,] blocks;
        //used for collision detection
        protected List<IBlock> barriers;
        protected HashSet<INPC> npcs;
        protected HashSet<IItem> items;
        protected Dictionary<Direction, IBorder> borders;

        public List<IBlock> Barriers { get { return barriers; } }

        public DungeonRoom(string filename)
        {
            blocks = new IBlock[Settings.ROOM_WIDTH, Settings.ROOM_HEIGHT];

            npcs = new HashSet<INPC>();
            items = new HashSet<IItem>();
            borders = new Dictionary<Direction, IBorder>();

            BlockParser blockParser = new BlockParser(filename, blocks);
            BorderParser borderParser = new BorderParser(filename, borders);
            NPCParser npcParser = new NPCParser(filename, npcs);
            ItemParser itemParser = new ItemParser(filename, items);

            blockParser.Parse();
            borderParser.Parse();
            npcParser.Parse();
            itemParser.Parse();
        }

        public void Update(GameTime gameTime)
        {
            for (int i = 0; i < Settings.ROOM_WIDTH; i++)
            {
                for (int j = 0; j < Settings.ROOM_HEIGHT; j++)
                {
                    blocks[i, j].Update(gameTime);
                    //if block is a barrier, add it to barrier list
                    if(blocks[i, j].Barrier)
                    {
                        barriers.Add(blocks[i,j]);
                    }
                }
            }
            foreach (IBorder border in borders.Values)
            {
                border.Update(gameTime);
            }
            foreach (INPC npc in npcs)
            {
                npc.Update(gameTime);
            }
            foreach (IItem item in items)
            {
                item.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < Settings.ROOM_WIDTH; i++)
            {
                for (int j = 0; j < Settings.ROOM_HEIGHT; j++)
                {
                    blocks[i, j].Draw(spriteBatch);
                }
            }
            foreach (IBorder border in borders.Values)
            {
                border.Draw(spriteBatch);
            }
            foreach (INPC npc in npcs)
            {
                npc.Draw(spriteBatch);
            }
            foreach (IItem item in items)
            {
                item.Draw(spriteBatch);
            }
        }
    }
}
