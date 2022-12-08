using Zelda.Blocks;
using Zelda.Blocks.Classes;
using Zelda.Puzzles;

namespace Zelda.Rooms.Puzzles.Classes
{
    public class PushableBlockPuzzle : IPuzzle
    {
        public PushableBlockPuzzle(Room room) : base(room)
        {
            
        }

        protected override bool CanSolve()
        {
            foreach (IBlock block in Room.CollidableBlocks)
            {
                if (block is PushableBlock)
                {
                    // Only one pushable block in the room, so once it is found, we can simply return
                    // whether or not it has been pushed yet
                    PushableBlock pushableBlock = (PushableBlock) block;
                    return pushableBlock.Pushed;
                }
            }
            return false;
        }

        protected override void Solve()
        {
            Room.UnlockDoor(Room.Direction.Left, false);
        }
    }
}
