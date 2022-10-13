using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zelda.Blocks;
using Zelda.Blocks.Classes;
using Zelda.Sprites.Factories;

namespace Zelda.Parsers
{
    public class BlockParser
    {
        private string fileName;
        private Dictionary<int, List<IBlock>> blocks;
        private Viewport viewport;
        public BlockParser(string value, Dictionary<int, List<IBlock>> dict, Viewport view)
        {
            fileName = value;
            blocks = dict;
            viewport = view;
        }

        public void ReadFile()
        {
            try
            {
                StreamReader blockReader = new StreamReader(fileName);
                int row = 0;
                while (!blockReader.EndOfStream)
                {
                    string[] blocksInRow = blockReader.ReadLine().Split(',');
                    if (!blocks.ContainsKey(row))
                    {
                        blocks.Add(row, new List<IBlock>());
                    }

                    int x = 0;
                    List<IBlock> list = blocks[row];
                    foreach (string blockName in blocksInRow)
                    {
                        list.Add(GetBlock(viewport, blockName, x, row, (double)list.Count));
                        x++;
                    }
                    row++;
                }
                blockReader.Close();
            } catch
            {
                throw new Exception("Failed to create stream reader blockReader at path: " + fileName);
            }
        }

        public IBlock GetBlock(Viewport viewport, string value, int x, int y, double size)
        {
            int midX = viewport.Width / 2;
            int midY = viewport.Height / 2;
            // Default position (0, 0) right now, should be changed to blocks 
            // actual position
            switch (value)
            {
                case "black_gap":
                    return new BlackGap(new Vector2(midX + (x * Settings.BLOCK_SIZE), midY + (y * Settings.BLOCK_SIZE)));
                case "blue_floor":
                    return new BlueFloor(new Vector2(midX + (x * Settings.BLOCK_SIZE), midY + (y * Settings.BLOCK_SIZE)));
                case "blue_gap":
                    return new BlueGap(new Vector2(midX + (x * Settings.BLOCK_SIZE), midY + (y * Settings.BLOCK_SIZE)));
                case "blue_sand":
                    return new BlueSand(new Vector2(midX + (x * Settings.BLOCK_SIZE), midY + (y * Settings.BLOCK_SIZE)));
                case "ladder":
                    return new Ladder(new Vector2(midX + (x * Settings.BLOCK_SIZE), midY + (y * Settings.BLOCK_SIZE)));
                case "pushable_block":
                    return new PushableBlock(new Vector2(midX + (x * Settings.BLOCK_SIZE), midY + (y * Settings.BLOCK_SIZE)));
                case "stairs":
                    return new Stairs(new Vector2(midX + (x * Settings.BLOCK_SIZE), midY + (y * Settings.BLOCK_SIZE)));
                case "statue_1":
                    return new Statue1(new Vector2(midX + (x * Settings.BLOCK_SIZE), midY + (y * Settings.BLOCK_SIZE)));
                case "statue_2":
                    return new Statue2(new Vector2(midX + (x * Settings.BLOCK_SIZE), midY + (y * Settings.BLOCK_SIZE)));
                default:
                    throw new Exception("Block type not found");
            }
        }
    }
}
