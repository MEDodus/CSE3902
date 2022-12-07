using Zelda.Blocks.Classes;
using Zelda.HUD;
using Zelda.Puzzles;
using Zelda.Rooms.Parsers;
using Zelda.Sound;

namespace Zelda.Rooms.Puzzles.Classes
{
    public class OldManPuzzle : IPuzzle
    {
        public OldManPuzzle(Room room) : base(room)
        {
            
        }

        protected override bool CanSolve()
        {
            // Reveal the secret the old man room is entered
            return RoomBuilder.Instance.CurrentRoom == Room;
        }

        protected override void Solve()
        {
            // TODO: animate words here possibly
            Room.Blocks.Add(new OldManWords(Parser.GetSpawnPosition(1, 1, Room)));
            SoundManager.Instance.PlaySecretSound();
        }
    }
}
