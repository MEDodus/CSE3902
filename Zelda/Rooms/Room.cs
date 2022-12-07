using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Zelda.Blocks;
using Zelda.Blocks.Classes;
using Zelda.Borders;
using Zelda.Items;
using Zelda.NPCs;
using Zelda.Puzzles;
using Zelda.Rooms.Parsers;
using Zelda.Rooms.Puzzles.Classes;
using Zelda.Sound;

namespace Zelda.Rooms
{
    public class Room
    {
        public enum Direction { Left, Right, Up, Down }

        private string filename;
        private HashSet<IBlock> blocks;
        private HashSet<IBlock> collidableBlocks;
        private HashSet<IBlock> topLayerBlocks;
        private HashSet<INPC> npcs;
        private HashSet<IItem> items;
        private HashSet<IItem> itemsToRemove;
        private Dictionary<Direction, IBorder> borders;
        private Dictionary<Direction, IBlock> doors;
        private Dictionary<Direction, Room> adjacentRooms;
        private Vector2 position;
        private IPuzzle puzzle;

        public string Name { get { return filename; } }
        public HashSet<IBlock> Blocks { get { return blocks; } }
        public HashSet<IBlock> CollidableBlocks { get { return collidableBlocks; } }
        public HashSet<INPC> NPCs { get { return npcs; } }
        public HashSet<IItem> Items { get { return items; } }
        public Dictionary<Direction, IBorder> Borders { get { return borders; } }
        public Dictionary<Direction, IBlock> Doors { get { return doors; } }
        public Dictionary<Direction, Room> AdjacentRooms { get { return adjacentRooms; } }
        public Vector2 Position { get { return position; } set { position = value; } }
        public IPuzzle Puzzle { set { puzzle = value; } }

        public Room(string filename)
        {
            this.filename = filename;
            blocks = new HashSet<IBlock>();
            collidableBlocks = new HashSet<IBlock>();
            topLayerBlocks = new HashSet<IBlock>();
            npcs = new HashSet<INPC>();
            items = new HashSet<IItem>();
            itemsToRemove = new HashSet<IItem>();
            borders = new Dictionary<Direction, IBorder>();
            doors = new Dictionary<Direction, IBlock>();
            adjacentRooms = new Dictionary<Direction, Room>();
            puzzle = null;
        }

        public void Parse()
        {
            BlockParser blockParser = new BlockParser(this, blocks, collidableBlocks, topLayerBlocks);
            BorderParser borderParser = new BorderParser(this, borders, doors, collidableBlocks);
            NPCParser npcParser = new NPCParser(this, npcs);
            ItemParser itemParser = new ItemParser(this, items);
            PuzzleParser puzzleParser = new PuzzleParser(this);
            blockParser.Parse();
            borderParser.Parse();
            npcParser.Parse();
            itemParser.Parse();
            puzzleParser.Parse();
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
                    IItem item = npc.DropItem();
                    if (item != null)
                    {
                        items.Add(item);
                    }
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
            if (puzzle != null)
            {
                puzzle.Update();
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

        public void UnlockDoor(Direction direction, bool unlockAdjacent)
        {
            if (!Doors.ContainsKey(direction))
            {
                return;
            }
            Borders[direction].Unlock();
            Doors[direction].CanCollide = false;
            if (AdjacentRooms.ContainsKey(direction))
            {
                Direction opposite;
                switch (direction)
                {
                    case Direction.Left:
                        opposite = Direction.Right;
                        break;
                    case Direction.Right:
                        opposite = Direction.Left;
                        break;
                    case Direction.Up:
                        opposite = Direction.Down;
                        break;
                    default:
                        opposite = Direction.Up;
                        break;
                }
                if (unlockAdjacent)
                {
                    AdjacentRooms[direction].UnlockDoor(opposite, false);
                }
                else
                {
                    SoundManager.Instance.PlayDoorUnlockSound();
                }
            }
        }
    }
}
