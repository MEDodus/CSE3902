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
        private IBlock[,] blocks;
        private List<IBlock> barriers;

        public BlockParser(string filename, IBlock[,] blocks, List<IBlock> barriers) : base("..\\..\\..\\Rooms\\Files\\" + filename + "\\blocks.csv")
        {
            this.blocks = blocks;
            this.barriers = barriers;
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


            if (block.CanCollide)
            {
                barriers.Add(block);
            }

            blocks[i, j] = block;
        }
    }
}
