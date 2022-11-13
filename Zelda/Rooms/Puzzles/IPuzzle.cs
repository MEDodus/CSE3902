using Zelda.Rooms;

namespace Zelda.Puzzles
{
    public abstract class IPuzzle
    {
        protected Room Room { get { return room; } }

        private readonly Room room;
        private bool solved = false;

        public IPuzzle(Room room)
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
