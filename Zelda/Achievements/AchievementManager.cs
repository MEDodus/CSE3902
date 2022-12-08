using System;

namespace Zelda.Achievements
{
    public static class AchievementManager
    {
        private static Game1 game;
        private static int maxLevelUnlocked;

        public static void Load(Game1 game)
        {
            // TODO: load from file
            maxLevelUnlocked = 1;
        }

        public static void Save()
        {
            // TODO: write to file (this function needs to be referenced somewhere as well)
        }

        public static void UnlockNextLevel()
        {
            maxLevelUnlocked = Math.Min(maxLevelUnlocked + 1, Settings.NUM_LEVELS);
        }

        public static bool IsUnlocked(int levelNumber)
        {
            return levelNumber <= maxLevelUnlocked;
        }
    }
}
