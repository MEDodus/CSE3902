using Microsoft.Xna.Framework;
using Zelda.Items.Classes;
using Zelda.Puzzles;
using Zelda.Rooms.Parsers;

namespace Zelda.Rooms.Puzzles.Classes
{
    public class DragonBossPuzzle : IPuzzle
    {

        public DragonBossPuzzle(Room room) : base(room)
        {
            
        }

        protected override bool CanSolve()
        {
            // If the dragon was defeated, there will be no NPCs left in the room.
            return Room.NPCs.Count == 0;
        }

        protected override void Solve()
        {
            Room.UnlockDoor(Room.Direction.Right, false);
            Vector2 spawnPos = Parser.GetSpawnPosition(10, 3, Room);
            System.Diagnostics.Debug.WriteLine(spawnPos + Room.Name);
            Room.Items.Add(new HeartContainer(spawnPos));
        }
    }
}
