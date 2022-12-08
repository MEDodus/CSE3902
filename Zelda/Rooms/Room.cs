using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Zelda.Achievements;
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
        private HashSet<Block> blocks;
        private Block[,] blocksArray = new Block[Settings.ROOM_WIDTH, Settings.ROOM_HEIGHT];
        private HashSet<Block> collidableBlocks;
        private HashSet<Block> topLayerBlocks;
        private HashSet<INPC> npcs;
        private HashSet<Item> items;
        private HashSet<Item> itemsToRemove;
        private Dictionary<Direction, Border> borders;
        private Dictionary<Direction, Block> doors;
        private Dictionary<Direction, Room> adjacentRooms;
        private Vector2 position;
        private Puzzle puzzle;

        public string Name { get { return filename; } }
        public HashSet<Block> Blocks { get { return blocks; } }
        public Block[,] BlocksArray { get { return blocksArray; } }
        public HashSet<Block> CollidableBlocks { get { return collidableBlocks; } }
        public HashSet<INPC> NPCs { get { return npcs; } }
        public HashSet<Item> Items { get { return items; } }
        public Dictionary<Direction, Border> Borders { get { return borders; } }
        public Dictionary<Direction, Block> Doors { get { return doors; } }
        public Dictionary<Direction, Room> AdjacentRooms { get { return adjacentRooms; } }
        public Vector2 Position { get { return position; } set { position = value; } }
        public Puzzle Puzzle { set { puzzle = value; } }

        public Room(string filename)
        {
            this.filename = filename;
            blocks = new HashSet<Block>();
            collidableBlocks = new HashSet<Block>();
            topLayerBlocks = new HashSet<Block>();
            npcs = new HashSet<INPC>();
            items = new HashSet<Item>();
            itemsToRemove = new HashSet<Item>();
            borders = new Dictionary<Direction, Border>();
            doors = new Dictionary<Direction, Block>();
            adjacentRooms = new Dictionary<Direction, Room>();
            puzzle = null;
        }

        public void Parse()
        {
            BlockParser blockParser = new BlockParser(this, blocks, collidableBlocks, topLayerBlocks, blocksArray);
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
            foreach (Block block in blocks)
            {
                block.Update(gameTime);
            }
            foreach (Block block in topLayerBlocks)
            {
                block.Update(gameTime);
            }
            foreach (Border border in borders.Values)
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
                    Item item = npc.DropItem();
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
            foreach (Item item in itemsToRemove)
            {
                items.Remove(item);
            }
            itemsToRemove.Clear();
            foreach (Item item in items)
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
            foreach (Block block in blocks)
            {
                block.Draw(spriteBatch);
            }
            foreach (Block block in collidableBlocks)
            {
                // border blocks are in collidableBlocks but not in blocks
                block.Draw(spriteBatch);
            }
            foreach (INPC npc in npcs)
            {
                npc.Draw(spriteBatch);
            }
            foreach (Item item in items)
            {
                item.Draw(spriteBatch);
            }
        }

        public void DrawTopLayer(SpriteBatch spriteBatch)
        {
            foreach (Block block in topLayerBlocks)
            {
                block.Draw(spriteBatch);
            }
            foreach (Border border in borders.Values)
            {
                border.Draw(spriteBatch);
            }
        }

        public void RemoveItem(Item item)
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
                    AchievementManager.GrantAchievement(Achievement.DoorUnlocked);
                    AdjacentRooms[direction].UnlockDoor(opposite, false);
                }
                else
                {
                    SoundManager.Instance.PlayDoorUnlockSound();
                }
            }
        }

        public void ShowNPCs()
        {
            foreach (INPC npc in npcs)
            {
                npc.Appear();
            }
        }

        public void HideNPCs()
        {
            foreach (INPC npc in npcs)
            {
                npc.Disappear();
            }
        }
    }
}
