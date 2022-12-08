using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Threading;
using Zelda.Blocks;
using Zelda.Blocks.Classes;
using Zelda.Items;

namespace Zelda.Rooms.Parsers
{
    public class BlockParser : Parser
    {
        private HashSet<Block> blocks;
        private Block[,] blocksArray;
        private HashSet<Block> collidableBlocks;
        private HashSet<Block> topLayerBlocks;

        public BlockParser(Room room, HashSet<Block> blocks, HashSet<Block> collidableBlocks, HashSet<Block> topLayerBlocks, Block[,] blocksArray)
            : base(room, room.Name + "\\blocks.csv")
        {
            this.blocks = blocks;
            this.collidableBlocks = collidableBlocks;
            this.topLayerBlocks = topLayerBlocks;
            this.blocksArray = blocksArray;
        }

        public override void Parse()
        {
            base.Parse();
            // add floors that will show underneath doors
            ParseObject("blue_floor", -1, Settings.ROOM_HEIGHT / 2);
            ParseObject("blue_floor", Settings.ROOM_WIDTH, Settings.ROOM_HEIGHT / 2);
            ParseObject("blue_floor", Settings.ROOM_WIDTH / 2 - 1, -1);
            ParseObject("blue_floor", Settings.ROOM_WIDTH / 2, -1);
            ParseObject("blue_floor", Settings.ROOM_WIDTH / 2 - 1, Settings.ROOM_HEIGHT);
            ParseObject("blue_floor", Settings.ROOM_WIDTH / 2, Settings.ROOM_HEIGHT);
        }

        protected override void ParseObject(string identifier, int i, int j)
        {
            Block block;
            Vector2 spawnPos = GetSpawnPosition(i, j, room);
            switch (identifier)
            {
                case "black_gap":
                    block = new BlackGap(spawnPos);
                    break;
                case "blue_floor":
                    block = new BlueFloor(spawnPos);
                    break;
                case "blue_gap":
                    block = new BlueGap(spawnPos);
                    break;
                case "blue_sand":
                    block = new BlueSand(spawnPos);
                    break;
                case "ladder":
                    block = new Ladder(spawnPos);
                    break;
                case "pushable_block":
                    block = new BlueFloor(spawnPos);
                    PushableBlock pushableBlock = new PushableBlock(spawnPos);
                    topLayerBlocks.Add(pushableBlock);
                    collidableBlocks.Add(pushableBlock);
                    break;
                case "static_block":
                    block = new StaticBlock(spawnPos);
                    break;
                case "stairs":
                    block = new Stairs(spawnPos);
                    Vector2 rightBlockPos = spawnPos + new Vector2(Settings.BLOCK_SIZE, 0);
                    collidableBlocks.Add(new StairsTrigger(rightBlockPos + new Vector2(Settings.BLOCK_SIZE / 2, Settings.BLOCK_SIZE / 2)));
                    topLayerBlocks.Add(new BlueFloor(rightBlockPos));
                    break;
                case "statue_1":
                    block = new Statue1(spawnPos);
                    break;
                case "statue_2":
                    block = new Statue2(spawnPos);
                    break;
                case "white_brick":
                    block = new WhiteBrick(spawnPos);
                    break;
                case "invisible_barrier":
                    block = new InvisibleBarrier(spawnPos);
                    break;
                case "invisible_path":
                    block = new InvisiblePath(spawnPos);
                    break;
                case "fire":
                    block = new Fire(spawnPos);
                    break;
                default:
                    throw new Exception("Block type not found: " + identifier);
            }
            blocks.Add(block);
            if (i >= 0 && j >= 0 && i < Settings.ROOM_WIDTH && j < Settings.ROOM_HEIGHT)
            {
                blocksArray[i, j] = block;
            }
            if (block.CanCollide)
            {
                collidableBlocks.Add(block);
            }
        }
    }
}
