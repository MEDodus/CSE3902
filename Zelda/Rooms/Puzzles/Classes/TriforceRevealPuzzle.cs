using Zelda.Blocks.Classes;
using Zelda.HUD;
using Zelda.Puzzles;
using Zelda.Rooms.Parsers;

namespace Zelda.Rooms.Puzzles.Classes
{
    public class TriforceRevealPuzzle : IPuzzle
    {
        public TriforceRevealPuzzle(Room room) : base(room)
        {
            
        }

        protected override bool CanSolve()
        {
            // Reveal the triforce once the old man room is entered
            return RoomBuilder.Instance.CurrentRoom == Room;
        }

        protected override void Solve()
        {
            //DungeonHUDMap.TriforceVisible = true;
            Room.Blocks.Add(new OldManWords(Parser.GetSpawnPosition(1, 1, Room)));
        }
    }
}
