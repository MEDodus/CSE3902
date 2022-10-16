using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Zelda.Blocks;
using Zelda.Items;
using Zelda.NPCs;
using Zelda.Rooms.Parsers;

namespace Zelda.Rooms.Classes.Abstract
{
    public abstract class DungeonRoom : IRoom
    {
        protected static readonly int ROOM_WIDTH = 12; // blocks
        protected static readonly int ROOM_HEIGHT = 7; // blocks

        protected IBlock[,] blocks;
        protected HashSet<INPC> npcs;
        protected HashSet<IItem> items;

        public DungeonRoom(string filename)
        {
            blocks = new IBlock[ROOM_WIDTH, ROOM_HEIGHT];
            npcs = new HashSet<INPC>();
            items = new HashSet<IItem>();

            BlockParser blockParser = new BlockParser(filename, blocks);

            blockParser.Parse();
        }

        public void Update(GameTime gameTime)
        {
            for (int i = 0; i < ROOM_WIDTH; i++)
            {
                for (int j = 0; j < ROOM_HEIGHT; j++)
                {
                    blocks[i, j].Update(gameTime);
                }
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
            for (int i = 0; i < ROOM_WIDTH; i++)
            {
                for (int j = 0; j < ROOM_HEIGHT; j++)
                {
                    blocks[i, j].Draw(spriteBatch);
                }
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
