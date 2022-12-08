using Microsoft.Xna.Framework;
using Zelda.Items.Classes;
using Zelda.Puzzles;
using Zelda.Rooms.Parsers;

namespace Zelda.Rooms.Puzzles.Classes
{
    public class DodongoBossPuzzle : Puzzle
    {
        public DodongoBossPuzzle(Room room) : base(room)
        {
            
        }

        protected override bool CanSolve()
        {
            // If the boss was defeated, there will be no NPCs left in the room.
            return Room.NPCs.Count == 0;
        }

        protected override void Solve()
        {
            Room.UnlockDoor(Room.Direction.Left, false);
            Vector2 spawnPos = Parser.GetSpawnPosition(5, 3, Room) + new Vector2(5, 5);
            Room.Items.Add(new HeartContainer(spawnPos));
        }
    }
}
