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
        private Dictionary<Room.Direction, Border> borders;
        private HashSet<Block> collidableBlocks;
        private Dictionary<Room.Direction, Block> doors;

        public BorderParser(Room room, Dictionary<Room.Direction, Border> borders, Dictionary<Room.Direction, Block> doors, HashSet<Block> collidableBlocks) 
            : base(room, room.Name + "\\borders.csv")
        {
            this.borders = borders;
            this.doors = doors;
            this.collidableBlocks = collidableBlocks;
        }

        protected override void ParseObject(string identifier, int i, int j)
        {
            Border border = null;
            bool puzzle = false;
            if (identifier == "wall")
            {
                if (i == 0)
                    border = new LeftWall(room);
                else if (i == 1)
                    border = new RightWall(room);
                else if (i == 2)
                    border = new TopWall(room);
                else
                    border = new BottomWall(room);
            }
            else if (identifier == "door")
            {
                if (i == 0)
                    border = new LeftDoor(room);
                else if (i == 1)
                    border = new RightDoor(room);
                else if (i == 2)
                    border = new TopDoor(room);
                else
                    border = new BottomDoor(room);
            }
            else if (identifier == "locked_door")
            {
                if (i == 0)
                    border = new LeftLockedDoor(room);
                else if (i == 1)
                    border = new RightLockedDoor(room);
                else if (i == 2)
                    border = new TopLockedDoor(room);
                else
                    border = new BottomLockedDoor(room);
            }
            else if (identifier == "puzzle_door")
            {
                puzzle = true;
                if (i == 0)
                    border = new LeftPuzzleDoor(room);
                else if (i == 1)
                    border = new RightPuzzleDoor(room);
                else if (i == 2)
                    border = new TopPuzzleDoor(room);
                else
                    border = new BottomPuzzleDoor(room);
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
                    CreateLeftRightInvisibleBlocks(-1, -Settings.BLOCK_SIZE, border, direction, puzzle);
                }
                else if (i == 1)
                {
                    direction = Room.Direction.Right;
                    CreateLeftRightInvisibleBlocks(Settings.ROOM_WIDTH, Settings.BLOCK_SIZE, border, direction, puzzle);
                }
                else if (i == 2)
                {
                    direction = Room.Direction.Up;
                    CreateTopBottomInvisibleBlocks(-1, -Settings.BLOCK_SIZE, border, direction, puzzle);
                }
                else
                {
                    direction = Room.Direction.Down;
                    CreateTopBottomInvisibleBlocks(Settings.ROOM_HEIGHT, Settings.BLOCK_SIZE, border, direction, puzzle);
                }
                borders.Add(direction, border);
            }
        }

        private void CreateLeftRightInvisibleBlocks(int i, int doorOffset, Border border, Room.Direction direction, bool puzzle)
        {
            for (int j = 0; j < Settings.ROOM_HEIGHT; j++)
            {
                Vector2 spawnPosition = GetSpawnPosition(i, j, room);
                if (j == 3)
                {
                    if (border.IsWall)
                    {
                        collidableBlocks.Add(new InvisibleBarrier(spawnPosition));
                    }
                    else if (border.Locked)
                    {
                        Block door = puzzle ? new PuzzleDoor(spawnPosition) : new Door(spawnPosition, true);
                        collidableBlocks.Add(door);
                        doors[direction] = door;
                    }
                }
                else if (j == 2 || j == 4)
                {
                    collidableBlocks.Add(new InvisibleBarrier(spawnPosition));
                    collidableBlocks.Add(new InvisibleBarrier(spawnPosition + new Vector2(doorOffset, 0)));
                }
                else
                {
                    collidableBlocks.Add(new InvisibleBarrier(spawnPosition));
                }
            }
        }

        private void CreateTopBottomInvisibleBlocks(int j, int doorOffset, Border border, Room.Direction direction, bool puzzle)
        {
            for (int i = 0; i < Settings.ROOM_WIDTH; i++)
            {
                Vector2 spawnPosition = GetSpawnPosition(i, j, room);
                if (i == 5)
                {
                    if (border.IsWall)
                    {
                        collidableBlocks.Add(new InvisibleBarrier(spawnPosition));
                    }
                    else if (border.Locked)
                    {
                        Block door = puzzle ? new PuzzleDoor(spawnPosition) : new Door(spawnPosition, true);
                        collidableBlocks.Add(door);
                        doors[direction] = door;
                    }
                    collidableBlocks.Add(new InvisibleBarrier(spawnPosition + new Vector2(-Settings.BLOCK_SIZE / 2, 0)));
                    collidableBlocks.Add(new InvisibleBarrier(spawnPosition + new Vector2(-Settings.BLOCK_SIZE / 2, doorOffset)));
                }
                else if (i == 6)
                {
                    collidableBlocks.Add(new InvisibleBarrier(spawnPosition + new Vector2(Settings.BLOCK_SIZE / 2, 0)));
                    collidableBlocks.Add(new InvisibleBarrier(spawnPosition + new Vector2(Settings.BLOCK_SIZE / 2, doorOffset)));
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
                    collidableBlocks.Add(new WhiteBrick(GetSpawnPosition(i, j, room)));
                }
            }
        }

        private void CreateBottomWhiteBrickBlocks()
        {
            for (int i = -2; i < Settings.ROOM_WIDTH + 2; i++)
            {
                for (int j = Settings.ROOM_HEIGHT; j < Settings.ROOM_HEIGHT + 2; j++)
                {
                    collidableBlocks.Add(new WhiteBrick(GetSpawnPosition(i, j, room)));
                }
            }
        }

        private void CreateTopWhiteBrickBlocks()
        {
            for (int i = -2; i < Settings.ROOM_WIDTH + 2; i++)
            {
                for (int j = -2; j < 0; j++)
                {
                    Vector2 spawnPosition = GetSpawnPosition(i, j, room);
                    if (i == 3)
                    {
                        collidableBlocks.Add(new Ladder(spawnPosition));
                        if (j == -2)
                        {
                            collidableBlocks.Add(new LadderTrigger(GetSpawnPosition(i, j, room) - new Vector2(0, Settings.BLOCK_SIZE / 2)));
                            collidableBlocks.Add(new InvisibleBarrier(GetSpawnPosition(i - 1, j - 1, room)));
                            collidableBlocks.Add(new InvisibleBarrier(GetSpawnPosition(i + 1, j - 1, room)));
                            collidableBlocks.Add(new InvisibleBarrier(GetSpawnPosition(i, j - 2, room)));
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
