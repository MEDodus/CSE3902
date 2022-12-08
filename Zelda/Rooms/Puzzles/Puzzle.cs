using Zelda.Rooms;

namespace Zelda.Puzzles
{
    public abstract class Puzzle
    {
        protected Room Room { get { return room; } }

        private readonly Room room;
        private bool solved = false;

        public Puzzle(Room room)
        {
            this.room = room;
        }

        public void Update()
        {
            if (!solved && CanSolve())
            {
                solved = true;
                Solve();
            }
        }

        protected abstract bool CanSolve();

        protected abstract void Solve();
    }
}
