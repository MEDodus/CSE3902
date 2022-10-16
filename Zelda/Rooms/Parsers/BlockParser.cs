using Microsoft.Xna.Framework;
using System;
using Zelda.Blocks;
using Zelda.Blocks.Classes;

namespace Zelda.Rooms.Parsers
{
    public class BlockParser : Parser
    {
        public BlockParser(string filename, IBlock[,] blocks) : base("..\\..\\..\\Rooms\\Files\\" + filename + "\\blocks.csv", blocks)
        {

        }

        protected override void ParseObject(string value, int i, int j)
        {
            IBlock block;
            IBlock[,] blocks = (IBlock[,])collection;

            switch (value)
            {
                case "black_gap":
                    block = new BlackGap(new Vector2(Settings.ROOM_POSITION_X + (i * Settings.BLOCK_SIZE), Settings.ROOM_POSITION_Y + (j * Settings.BLOCK_SIZE)));
                    break;
                case "blue_floor":
                    block = new BlueFloor(new Vector2(Settings.ROOM_POSITION_X + (i * Settings.BLOCK_SIZE), Settings.ROOM_POSITION_Y + (j * Settings.BLOCK_SIZE)));
                    break;
                case "blue_gap":
                    block = new BlueGap(new Vector2(Settings.ROOM_POSITION_X + (i * Settings.BLOCK_SIZE), Settings.ROOM_POSITION_Y + (j * Settings.BLOCK_SIZE)));
                    break;
                case "blue_sand":
                    block = new BlueSand(new Vector2(Settings.ROOM_POSITION_X + (i * Settings.BLOCK_SIZE), Settings.ROOM_POSITION_Y + (j * Settings.BLOCK_SIZE)));
                    break;
                case "ladder":
                    block = new Ladder(new Vector2(Settings.ROOM_POSITION_X + (i * Settings.BLOCK_SIZE), Settings.ROOM_POSITION_Y + (j * Settings.BLOCK_SIZE)));
                    break;
                case "pushable_block":
                    block = new PushableBlock(new Vector2(Settings.ROOM_POSITION_X + (i * Settings.BLOCK_SIZE), Settings.ROOM_POSITION_Y + (j * Settings.BLOCK_SIZE)));
                    break;
                case "stairs":
                    block = new Stairs(new Vector2(Settings.ROOM_POSITION_X + (i * Settings.BLOCK_SIZE), Settings.ROOM_POSITION_Y + (j * Settings.BLOCK_SIZE)));
                    break;
                case "statue_1":
                    block = new Statue1(new Vector2(Settings.ROOM_POSITION_X + (i * Settings.BLOCK_SIZE), Settings.ROOM_POSITION_Y + (j * Settings.BLOCK_SIZE)));
                    break;
                case "statue_2":
                    block = new Statue2(new Vector2(Settings.ROOM_POSITION_X + (i * Settings.BLOCK_SIZE), Settings.ROOM_POSITION_Y + (j * Settings.BLOCK_SIZE)));
                    break;
                default:
                    throw new Exception("Block type not found");
            }

            blocks[i, j] = block;
        }
    }
}
