using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Zelda.Borders;
using Zelda.Borders.Classes;
using Zelda.Borders.Classes.Abstract;
using Zelda.NPCs;
using Zelda.NPCs.Classes;
using Zelda.Rooms.Classes.Abstract;

namespace Zelda.Rooms.Parsers
{
    public class BorderParser : Parser
    {
        private Dictionary<DungeonRoom.Direction, IBorder> borders;

        public BorderParser(string filename, Dictionary<DungeonRoom.Direction, IBorder> borders) : base("..\\..\\..\\Rooms\\Files\\" + filename + "\\borders.csv")
        {
            this.borders = borders;
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

            DungeonRoom.Direction direction;
            if (i == 0)
                direction = DungeonRoom.Direction.Left;
            else if (i == 1)
                direction = DungeonRoom.Direction.Right;
            else if (i == 2)
                direction = DungeonRoom.Direction.Top;
            else
                direction = DungeonRoom.Direction.Bottom;
            borders.Add(direction, border);
        }
    }
}
