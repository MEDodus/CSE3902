using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Threading;
using Zelda.Blocks;
using Zelda.Blocks.Classes;

namespace Zelda.Rooms.Parsers
{
    public class BlockParser : Parser
    {
        private HashSet<IBlock> blocks;
        private HashSet<IBlock> collidableBlocks;
        private HashSet<IBlock> belowLayerBlocks;

        public BlockParser(string filename, HashSet<IBlock> blocks, HashSet<IBlock> collidableBlocks, HashSet<IBlock> belowLayerBlocks) 
            : base("..\\..\\..\\Rooms\\Files\\" + filename + "\\blocks.csv")
        {
            this.blocks = blocks;
            this.collidableBlocks = collidableBlocks;
            this.belowLayerBlocks = belowLayerBlocks;
        }

        protected override void ParseObject(string identifier, int i, int j)
        {
            IBlock block;
            Vector2 spawnPos = GetSpawnPosition(i, j ) - new Vector2(Settings.BLOCK_SIZE, Settings.BLOCK_SIZE);
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
                    block = new PushableBlock(spawnPos);
                    belowLayerBlocks.Add(new BlueFloor(spawnPos));
                    break;
                case "static_block":
                    block = new StaticBlock(spawnPos);
                    break;
                case "stairs":
                    block = new Stairs(spawnPos);
                    break;
                case "statue_1":
                    block = new Statue1(spawnPos);
                    break;
                case "statue_2":
                    block = new Statue2(spawnPos);
                    break;
                case "invisible_barrier":
                    block = new InvisibleBarrier(spawnPos);
                    break;
                case "invisible_path":
                    block = new InvisiblePath(spawnPos);
                    break;
                default:
                    throw new Exception("Block type not found: " + identifier);
            }

            blocks.Add(block);
            if (block.CanCollide)
            {
                collidableBlocks.Add(block);
            }
        }
    }
}
