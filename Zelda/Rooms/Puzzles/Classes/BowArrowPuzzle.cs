using Microsoft.Xna.Framework;
using Zelda.Items.Classes;
using Zelda.Puzzles;
using Zelda.Rooms.Parsers;

namespace Zelda.Rooms.Puzzles.Classes
{
    public class BowArrowPuzzle : IPuzzle
    {
        // for level 2 (NOT the white brick dungeon from level 1)
        public BowArrowPuzzle(Room room) : base(room)
        {
            
        }

        protected override bool CanSolve()
        {
            // Reveal the bow and arrow when all enemies are killed
            return Room.NPCs.Count == 0;
        }

        protected override void Solve()
        {
            Room.UnlockDoor(Room.Direction.Left, false);
            Vector2 spawnPos = Parser.GetSpawnPosition(10, 3, Room) + new Vector2(5, 5);
            Room.Items.Add(new Bow(spawnPos));
            Room.Items.Add(new Arrow(spawnPos + new Vector2(Settings.BLOCK_SIZE, 0)));
        }
    }
}
