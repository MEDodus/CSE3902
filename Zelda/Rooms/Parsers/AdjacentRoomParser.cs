using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Zelda.Borders;
using Zelda.Items;
using Zelda.Items.Classes;

namespace Zelda.Rooms.Parsers
{
    public class AdjacentRoomParser : Parser
    {
        private Dictionary<Room.Direction, Room> adjacentRooms;
        private RoomBuilder roomBuilder;

        public AdjacentRoomParser(Room room, Dictionary<Room.Direction, Room> adjacentRooms, RoomBuilder roomBuilder) 
            : base(room, room.Name + "\\adjacent.csv")
        {
            this.adjacentRooms = adjacentRooms;
            this.roomBuilder = roomBuilder;
        }

        protected override void ParseObject(string identifier, int i, int j)
        {
            Room.Direction direction;
            if (i == 0)
                direction = Room.Direction.Left;
            else if (i == 1)
                direction = Room.Direction.Right;
            else if (i == 2)
                direction = Room.Direction.Up;
            else
                direction = Room.Direction.Down;
            adjacentRooms.Add(direction, roomBuilder.GetRoom(identifier));
        }
    }
}
