using Microsoft.Xna.Framework;
using System;
using System.IO;
using Zelda.Blocks;
using Zelda.Blocks.Classes;

namespace Zelda.Parsers
{
    public static class ItemParser
    {

        public static void ReadFile(string filename, IBlock[,] blocks)
        {
            string actualFileName = "..\\..\\..\\Rooms\\Files\\" + filename + "\\blocks.csv";
            try
            {
                StreamReader reader = new StreamReader(actualFileName);
                int j = 0;
                while (!reader.EndOfStream)
                {
                    string[] blocksInRow = reader.ReadLine().Split(',');
                    int i = 0;
                    foreach (string blockName in blocksInRow)
                    {
                        blocks[i, j] = CreateBlock(blockName, i, j);
                        i++;
                    }
                    j++;
                }
                reader.Close();
            }
            catch
            {
                throw new Exception("Failed to parse blocks from file: " + actualFileName);
            }
        }

        private static IBlock CreateBlock(string value, int i, int j)
        {
            switch (value)
            {
                case "black_gap":
                    return new BlackGap(new Vector2(Settings.ROOM_POSITION_X + (i * Settings.BLOCK_SIZE), Settings.ROOM_POSITION_Y + (j * Settings.BLOCK_SIZE)));
                case "blue_floor":
                    return new BlueFloor(new Vector2(Settings.ROOM_POSITION_X + (i * Settings.BLOCK_SIZE), Settings.ROOM_POSITION_Y + (j * Settings.BLOCK_SIZE)));
                case "blue_gap":
                    return new BlueGap(new Vector2(Settings.ROOM_POSITION_X + (i * Settings.BLOCK_SIZE), Settings.ROOM_POSITION_Y + (j * Settings.BLOCK_SIZE)));
                case "blue_sand":
                    return new BlueSand(new Vector2(Settings.ROOM_POSITION_X + (i * Settings.BLOCK_SIZE), Settings.ROOM_POSITION_Y + (j * Settings.BLOCK_SIZE)));
                case "ladder":
                    return new Ladder(new Vector2(Settings.ROOM_POSITION_X + (i * Settings.BLOCK_SIZE), Settings.ROOM_POSITION_Y + (j * Settings.BLOCK_SIZE)));
                case "pushable_block":
                    return new PushableBlock(new Vector2(Settings.ROOM_POSITION_X + (i * Settings.BLOCK_SIZE), Settings.ROOM_POSITION_Y + (j * Settings.BLOCK_SIZE)));
                case "stairs":
                    return new Stairs(new Vector2(Settings.ROOM_POSITION_X + (i * Settings.BLOCK_SIZE), Settings.ROOM_POSITION_Y + (j * Settings.BLOCK_SIZE)));
                case "statue_1":
                    return new Statue1(new Vector2(Settings.ROOM_POSITION_X + (i * Settings.BLOCK_SIZE), Settings.ROOM_POSITION_Y + (j * Settings.BLOCK_SIZE)));
                case "statue_2":
                    return new Statue2(new Vector2(Settings.ROOM_POSITION_X + (i * Settings.BLOCK_SIZE), Settings.ROOM_POSITION_Y + (j * Settings.BLOCK_SIZE)));
                default:
                    throw new Exception("Block type not found");
            }
        }
    }
}
