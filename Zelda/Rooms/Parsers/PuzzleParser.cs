using Microsoft.Xna.Framework;
using System.Linq;
using Zelda.Items.Classes;
using Zelda.Rooms.Puzzles.Classes;

namespace Zelda.Rooms.Parsers
{
    public class PuzzleParser
    {
        private Room room;
        private readonly string[] KEY_DROP_ROOMS = { "Room1", "Room2", "Room9", "Room11", "Room14", "Room16" };

        public PuzzleParser(Room room)
        {
            this.room = room;
        }

        public void Parse()
        {
            if (room.Name.Equals("Room3"))
            {
                room.Puzzle = new DragonBossPuzzle(room);
            }
            else if (room.Name.Equals("Room5"))
            {
                room.Puzzle = new OldManPuzzle(room);
            }
            else if (room.Name.Equals("Room6"))
            {
                room.Puzzle = new PushableBlockPuzzle(room);
            }
            else if (KEY_DROP_ROOMS.Contains(room.Name))
            {
                room.Puzzle = new ItemDropPuzzle(room, new Key(new Vector2()));
            }
            else if (room.Name.Equals("Room7"))
            {
                room.Puzzle = new ItemDropPuzzle(room, new Map(new Vector2()));
            }
            else if (room.Name.Equals("Room8"))
            {
                room.Puzzle = new ItemDropPuzzle(room, new Boomerang(new Vector2()));
            }
            else if (room.Name.Equals("Room12"))
            {
                room.Puzzle = new ItemDropPuzzle(room, new Compass(new Vector2()));
            }
        }
    }
}
