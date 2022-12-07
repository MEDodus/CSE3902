using Microsoft.Xna.Framework;
using System.Linq;
using Zelda.Items.Classes;
using Zelda.Rooms.Puzzles.Classes;

namespace Zelda.Rooms.Parsers
{
    public class PuzzleParser
    {
        private Room room;
        private readonly string[] KEY_DROP_ROOMS_LEVEL1 = { "Room1", "Room2", "Room9", "Room11", "Room14", "Room16" };
        private readonly string[] KEY_DROP_ROOMS_LEVEL2 = { "Room4", "Room6", "Room9", "Room10", "Room12"};

        public PuzzleParser(Room room)
        {
            this.room = room;
        }

        public void Parse()
        {
            string levelName = RoomBuilder.Instance.CurrentLevel;
            string roomName = room.Name;
            if (levelName.Equals("Level1"))
            {
                if (KEY_DROP_ROOMS_LEVEL1.Contains(roomName))
                {
                    room.Puzzle = new ItemDropPuzzle(room, new Key(new Vector2()));
                }
                else if (roomName.Equals("Room3"))
                {
                    room.Puzzle = new DragonBossPuzzle(room);
                }
                else if (roomName.Equals("Room5"))
                {
                    room.Puzzle = new OldManPuzzle(room);
                }
                else if (roomName.Equals("Room6"))
                {
                    room.Puzzle = new PushableBlockPuzzle(room);
                }
                else if (roomName.Equals("Room7"))
                {
                    room.Puzzle = new ItemDropPuzzle(room, new Map(new Vector2()));
                }
                else if (roomName.Equals("Room8"))
                {
                    room.Puzzle = new ItemDropPuzzle(room, new Boomerang(new Vector2()));
                }
                else if (roomName.Equals("Room12"))
                {
                    room.Puzzle = new ItemDropPuzzle(room, new Compass(new Vector2()));
                }
            }
            else if (levelName.Equals("Level2"))
            {
                if (KEY_DROP_ROOMS_LEVEL2.Contains(roomName))
                {
                    room.Puzzle = new ItemDropPuzzle(room, new Key(new Vector2()));
                }
                else if (roomName.Equals("Room2"))
                {
                    room.Puzzle = new BowArrowPuzzle(room);
                }
                else if (roomName.Equals("Room3"))
                {
                    room.Puzzle = new PushableBlockPuzzle(room);
                }
                else if (roomName.Equals("Room5"))
                {
                    room.Puzzle = new ItemDropPuzzle(room, new Compass(new Vector2()));
                }
                else if (roomName.Equals("Room7"))
                {
                    room.Puzzle = new ItemDropPuzzle(room, new Map(new Vector2()));
                }
                else if (roomName.Equals("Room13"))
                {
                    room.Puzzle = new ItemDropPuzzle(room, new MagicalRod(new Vector2()));
                }
                else if (roomName.Equals("Room14"))
                {
                    room.Puzzle = new DodongoBossPuzzle(room);
                }
            }
        }
    }
}
