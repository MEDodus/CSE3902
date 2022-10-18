using Microsoft.Xna.Framework;
using System;
using Zelda.Blocks;
using Zelda.Blocks.Classes;

namespace Zelda.Rooms.Parsers
{
    public class BlockParser : Parser
    {
        private IBlock[,] blocks;

        public BlockParser(string filename, IBlock[,] blocks) : base("..\\..\\..\\Rooms\\Files\\" + filename + "\\blocks.csv")
        {
            this.blocks = blocks;
        }

        protected override void ParseObject(string identifier, int i, int j)
        {
            IBlock block;
            Vector2 spawnPos = GetSpawnPosition(i, j);
            switch (identifier)
            {
                case "black_gap":
                    block = new BlackGap(spawnPos, false);
                    break;
                case "blue_floor":
                    block = new BlueFloor(spawnPos, false);
                    break;
                case "blue_gap":
                    block = new BlueGap(spawnPos, false);
                    break;
                case "blue_sand":
                    block = new BlueSand(spawnPos, false);
                    break;
                case "ladder":
                    block = new Ladder(spawnPos, true);
                    break;
                case "pushable_block":
                    block = new PushableBlock(spawnPos, true);
                    break;
                case "static_block":
                    block = new StaticBlock(spawnPos, true);
                    break;
                case "stairs":
                    block = new Stairs(spawnPos, false);
                    break;
                case "statue_1":
                    block = new Statue1(spawnPos, true);
                    break;
                case "statue_2":
                    block = new Statue2(spawnPos, true);
                    break;
                default:
                    throw new Exception("Block type not found: " + identifier);
            }

            blocks[i, j] = block;
        }
    }
}
