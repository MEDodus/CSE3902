using Microsoft.Xna.Framework;
using System;
using Zelda.Achievements;
using Zelda.Blocks;
using Zelda.Items;
using Zelda.Items.Classes;
using Zelda.Puzzles;
using Zelda.Rooms.Parsers;
using Zelda.Sound;

namespace Zelda.Rooms.Puzzles.Classes
{
    public class ItemDropPuzzle : IPuzzle
    {
        private IItem item;

        public ItemDropPuzzle(Room room, IItem item) : base(room)
        {
            this.item = item;
        }

        protected override bool CanSolve()
        {
            // Once all enemies are killed, drop the item.
            return Room.NPCs.Count == 0;
        }

        protected override void Solve()
        {
            // Spawn the item in a random location within the room that is not occupied by a collidable block.
            Random rng = new Random();
            IBlock block;
            do
            {
                block = Room.BlocksArray[rng.Next(Settings.ROOM_WIDTH), rng.Next(Settings.ROOM_HEIGHT)];
            } while (block.CanCollide || block.IsGap);
            item.Position = block.Position + new Vector2(rng.Next(10), rng.Next(10));
            Room.Items.Add(item);
            SoundManager.Instance.PlayItemAppearSound();
            if (item is Boomerang)
                AchievementManager.GrantAchievement(Achievement.BoomerangFound);
            else if (item is MagicalRod)
                AchievementManager.GrantAchievement(Achievement.MagicalRodFound);
            else if (item is Map)
                AchievementManager.GrantAchievement(Achievement.MapFound);
        }
    }
}
