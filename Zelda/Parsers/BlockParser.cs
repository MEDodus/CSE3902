using Microsoft.Xna.Framework;
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
        public BlockParser(string value, Dictionary<int, List<IBlock>> dict)
        {
            fileName = value;
            blocks = dict;
        }

        public void ReadFile()
        {
            StreamReader blockReader;
            try
            {
                blockReader = new StreamReader(fileName);
                int row = 0;
                while (!blockReader.EndOfStream)
                {
                    string[] blocksInRow = blockReader.ReadLine().Split(',');
                    if (!blocks.ContainsKey(row))
                    {
                        blocks.Add(row, new List<IBlock>());
                    }

                    List<IBlock> list = blocks[row];
                    foreach (string blockName in blocksInRow)
                    {
                        if (list.Count != 0) list.Add(GetBlock(blockName, list[list.Count - 1].Position));
                        else { list.Add(GetBlock(blockName, new Vector2(0, 0))); }
                    }
                }
                blockReader.Close();
            } catch
            {
                throw new Exception("Failed to create stream reader blockReader");
            }
        }

        public IBlock GetBlock(string value, Vector2 lastBlock)
        {
            // Default position (0, 0) right now, should be changed to blocks 
            // actual position
            switch (value)
            {
                case "black_gap":
                    return new BlackGap(new Vector2(0, 0));
                case "blue_floor":
                    return new BlueFloor(new Vector2(0, 0));
                case "blue_gap":
                    return new BlueGap(new Vector2(0, 0));
                case "blue_sand":
                    return new BlueSand(new Vector2(0, 0));
                case "ladder":
                    return new Ladder(new Vector2(0, 0));
                case "pushable_block":
                    return new PushableBlock(new Vector2(0, 0));
                case "stairs":
                    return new Stairs(new Vector2(0, 0));
                case "statue_1":
                    return new Statue1(new Vector2(0, 0));
                case "statue_2":
                    return new Statue2(new Vector2(0, 0));
                default:
                    throw new Exception("Block type not found");
            }
        }
    }
}
