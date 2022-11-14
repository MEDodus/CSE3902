using Zelda.Rooms.Puzzles.Classes;

namespace Zelda.Rooms.Parsers
{
    public class PuzzleParser
    {
        private Room room;

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
                room.Puzzle = new TriforceRevealPuzzle(room);
            }
            else if (room.Name.Equals("Room6"))
            {
                room.Puzzle = new PushableBlockPuzzle(room);
            }
        }
    }
}
