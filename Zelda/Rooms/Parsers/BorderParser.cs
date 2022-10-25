using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Zelda.Blocks;
using Zelda.Blocks.Classes;
using Zelda.Borders;
using Zelda.Borders.Classes;

namespace Zelda.Rooms.Parsers
{
    public class BorderParser : Parser
    {
        private Dictionary<Room.Direction, IBorder> borders;
        private HashSet<IBlock> collidableBlocks;

        public BorderParser(string filename, Dictionary<Room.Direction, IBorder> borders, HashSet<IBlock> collidableBlocks) 
            : base("..\\..\\..\\Rooms\\Files\\" + filename + "\\borders.csv")
        {
            this.borders = borders;
            this.collidableBlocks = collidableBlocks;
        }

        protected override void ParseObject(string identifier, int i, int j)
        {
            IBorder border = null;
            if (identifier == "wall")
            {
                if (i == 0)
                    border = new LeftWall();
                else if (i == 1)
                    border = new RightWall();
                else if (i == 2)
                    border = new TopWall();
                else
                    border = new BottomWall();
            }
            else if (identifier == "door")
            {
                if (i == 0)
                    border = new LeftDoor();
                else if (i == 1)
                    border = new RightDoor();
                else if (i == 2)
                    border = new TopDoor();
                else
                    border = new BottomDoor();
            }
            else if (identifier == "locked_door")
            {
                if (i == 0)
                    border = new LeftLockedDoor();
                else if (i == 1)
                    border = new RightLockedDoor();
                else if (i == 2)
                    border = new TopLockedDoor();
                else
                    border = new BottomLockedDoor();
            }
            else if (identifier == "white_brick")
            {
                if (i == 0)
                    CreateLeftRightWhiteBrickBlocks(-2);
                else if (i == 1)
                    CreateLeftRightWhiteBrickBlocks(Settings.ROOM_WIDTH);
                else if (i == 2)
                    CreateTopWhiteBrickBlocks();
                else
                    CreateBottomWhiteBrickBlocks();
            }

            if (border != null)
            {
                Room.Direction direction;
                if (i == 0)
                {
                    direction = Room.Direction.Left;
                    CreateLeftRightInvisibleBlocks(-1, -Settings.BLOCK_SIZE, border);
                }
                else if (i == 1)
                {
                    direction = Room.Direction.Right;
                    CreateLeftRightInvisibleBlocks(Settings.ROOM_WIDTH, Settings.BLOCK_SIZE, border);
                }
                else if (i == 2)
                {
                    direction = Room.Direction.Top;
                    CreateTopBottomInvisibleBlocks(-1, -Settings.BLOCK_SIZE, border);
                }
                else
                {
                    direction = Room.Direction.Bottom;
                    CreateTopBottomInvisibleBlocks(Settings.ROOM_HEIGHT, Settings.BLOCK_SIZE, border);
                }
                borders.Add(direction, border);
            }
        }

        private void CreateLeftRightInvisibleBlocks(int i, int doorOffset, IBorder border)
        {
            for (int j = 0; j < Settings.ROOM_HEIGHT; j++)
            {
                Vector2 spawnPosition = GetSpawnPosition(i, j);
                if (j == 3)
                {
                    Door door = new Door(spawnPosition, border.Locked);
                    collidableBlocks.Add(door);
                    collidableBlocks.Add(new InvisibleBarrier(spawnPosition + new Vector2(doorOffset, 0)));
                }
                else
                {
                    collidableBlocks.Add(new InvisibleBarrier(spawnPosition));
                }
            }
        }

        private void CreateTopBottomInvisibleBlocks(int j, int doorOffset, IBorder border)
        {
            for (int i = 0; i < Settings.ROOM_WIDTH; i++)
            {
                Vector2 spawnPosition = GetSpawnPosition(i, j);
                if (i == 5)
                {
                    Vector2 doorSpawnPosition = spawnPosition + new Vector2(Settings.BLOCK_SIZE / 2, 0);
                    Door door = new Door(doorSpawnPosition, border.Locked);
                    collidableBlocks.Add(door);
                    collidableBlocks.Add(new InvisibleBarrier(doorSpawnPosition + new Vector2(0, doorOffset)));
                    collidableBlocks.Add(new InvisibleBarrier(spawnPosition - new Vector2(Settings.BLOCK_SIZE / 2, 0)));
                }
                else if (i == 6)
                {
                    collidableBlocks.Add(new InvisibleBarrier(spawnPosition + new Vector2(Settings.BLOCK_SIZE / 2, 0)));
                }
                else
                {
                    collidableBlocks.Add(new InvisibleBarrier(spawnPosition));
                }
            }
        }

        private void CreateLeftRightWhiteBrickBlocks(int iStart)
        {
            for (int i = iStart; i < iStart + 2; i++)
            {
                for (int j = 0; j < Settings.ROOM_HEIGHT; j++)
                {
                    collidableBlocks.Add(new WhiteBrick(GetSpawnPosition(i, j)));
                }
            }
        }

        private void CreateBottomWhiteBrickBlocks()
        {
            for (int i = -2; i < Settings.ROOM_WIDTH + 2; i++)
            {
                for (int j = Settings.ROOM_HEIGHT; j < Settings.ROOM_HEIGHT + 2; j++)
                {
                    collidableBlocks.Add(new WhiteBrick(GetSpawnPosition(i, j)));
                }
            }
        }

        private void CreateTopWhiteBrickBlocks()
        {
            for (int i = -2; i < Settings.ROOM_WIDTH + 2; i++)
            {
                for (int j = -2; j < 0; j++)
                {
                    Vector2 spawnPosition = GetSpawnPosition(i, j);
                    if (i == 3)
                    {
                        collidableBlocks.Add(new Ladder(spawnPosition));
                        if (j == -2)
                        {
                            collidableBlocks.Add(new Door(GetSpawnPosition(i, j - 1), false));
                            collidableBlocks.Add(new InvisibleBarrier(GetSpawnPosition(i - 1, j - 1)));
                            collidableBlocks.Add(new InvisibleBarrier(GetSpawnPosition(i + 1, j - 1)));
                            collidableBlocks.Add(new InvisibleBarrier(GetSpawnPosition(i, j - 2)));
                        }
                    }
                    else
                    {
                        collidableBlocks.Add(new WhiteBrick(spawnPosition));
                    }
                }
            }
        }
    }
}
