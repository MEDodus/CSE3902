using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Zelda.Blocks;
using Zelda.Borders;
using Zelda.Items;
using Zelda.NPCs;
using Zelda.Rooms.Parsers;

namespace Zelda.Rooms
{
    public class Room
    {
        public enum Direction { Left, Right, Top, Bottom }

        protected IBlock[,] blocks;
        protected HashSet<INPC> npcs;
        protected HashSet<IItem> items;
        protected Dictionary<Direction, IBorder> borders;

        public IBlock[,] Blocks { get { return blocks; } }
        public HashSet<INPC> NPCs { get { return npcs; } }
        public HashSet<IItem> Items { get { return items; } }
        protected Dictionary<Direction, IBorder> Borders { get { return borders; } }

        public Room(string filename)
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
