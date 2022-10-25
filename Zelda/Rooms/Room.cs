using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
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

        protected HashSet<IBlock> blocks;
        protected HashSet<IBlock> collidableBlocks;
        protected HashSet<IBlock> topLayerBlocks;
        protected HashSet<INPC> npcs;
        protected HashSet<IItem> items;
        private HashSet<IItem> itemsToRemove;
        protected Dictionary<Direction, IBorder> borders;

        public HashSet<IBlock> Blocks { get { return blocks; } }
        public HashSet<IBlock> CollidableBlocks { get { return collidableBlocks; } }
        public HashSet<INPC> NPCs { get { return npcs; } }
        public HashSet<IItem> Items { get { return items; } }
        protected Dictionary<Direction, IBorder> Borders { get { return borders; } }

        public Room(string filename)
        {
            blocks = new HashSet<IBlock>();
            collidableBlocks = new HashSet<IBlock>();
            topLayerBlocks = new HashSet<IBlock>();
            npcs = new HashSet<INPC>();
            items = new HashSet<IItem>();
            itemsToRemove = new HashSet<IItem>();
            borders = new Dictionary<Direction, IBorder>();

            BlockParser blockParser = new BlockParser(filename, blocks, collidableBlocks, topLayerBlocks);
            BorderParser borderParser = new BorderParser(filename, borders, collidableBlocks);
            NPCParser npcParser = new NPCParser(filename, npcs);
            ItemParser itemParser = new ItemParser(filename, items);

            blockParser.Parse();
            borderParser.Parse();
            npcParser.Parse();
            itemParser.Parse();
        }

        public void Update(GameTime gameTime)
        {
            foreach (IBlock block in blocks)
            {
                block.Update(gameTime);
            }
            foreach (IBlock block in topLayerBlocks)
            {
                block.Update(gameTime);
            }
            foreach (IBorder border in borders.Values)
            {
                border.Update(gameTime);
            }
            HashSet<INPC> npcsToRemove = new();
            foreach (INPC npc in npcs)
            {
                npc.Update(gameTime);
                if (npc.Dead)
                {
                    npcsToRemove.Add(npc);
                }
            }
            foreach (INPC npc in npcsToRemove)
            {
                npcs.Remove(npc);
            }
            foreach (IItem item in itemsToRemove)
            {
                items.Remove(item);
            }
            itemsToRemove.Clear();
            foreach (IItem item in items)
            {
                item.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (IBlock block in blocks)
            {
                block.Draw(spriteBatch);
            }
            foreach (IBlock block in collidableBlocks)
            {
                // border blocks are in collidableBlocks but not in blocks
                block.Draw(spriteBatch);
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

        public void DrawTopLayer(SpriteBatch spriteBatch)
        {
            foreach (IBlock block in topLayerBlocks)
            {
                block.Draw(spriteBatch);
            }
            foreach (IBorder border in borders.Values)
            {
                border.Draw(spriteBatch);
            }
        }

        public void RemoveItem(IItem item)
        {
            itemsToRemove.Add(item);
        }
    }
}
