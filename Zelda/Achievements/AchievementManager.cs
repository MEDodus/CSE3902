using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Zelda.Sound;
using Zelda.Sprites;
using Zelda.Sprites.Factories;

namespace Zelda.Achievements
{
    public enum Achievement { DoorUnlocked, DragonKilled, DodongoKilled, FirstKill, BoomerangFound, MagicalRodFound, MapFound }

    public static class AchievementManager
    {
        public static int NumAchievements { get { return Enum.GetNames<Achievement>().Length; } }

        // Achievement info
        private static readonly Dictionary<Achievement, string> ACHIEVEMENT_NAMES = new Dictionary<Achievement, string>()
        {
            { Achievement.DoorUnlocked, "Breaking and entering" },
            { Achievement.DragonKilled, "Dragon killer" },
            { Achievement.DodongoKilled, "Dinosaur killer" },
            { Achievement.FirstKill, "First blood" },
            { Achievement.BoomerangFound, "Australian" },
            { Achievement.MagicalRodFound, "You're a wizard Harry" },
            { Achievement.MapFound, "Mapped out" },
        };
        // Save file
        private static readonly string FILENAME = "save.txt";
        // UI
        private static readonly Vector2 POSITION= new Vector2(Settings.ROOM_WINDOW_X + 10, Settings.ROOM_WINDOW_Y - 100);
        private static readonly Vector2 TEXT_POSITION = POSITION + new Vector2(75, 30);
        private static readonly double ACHIEVEMENT_DISPLAY_LENGTH = 5;

        private static Game1 game;
        private static int maxLevelUnlocked = 1;
        private static HashSet<Achievement> unlockedAchievements= new HashSet<Achievement>();
        private static ISprite achievementSprite;
        private static SpriteFont font;
        private static Achievement lastAchievement;
        private static double achievementDisplayTime = 0;

        public static void Update(GameTime gameTime)
        {
            if (achievementDisplayTime > 0 )
            {
                achievementDisplayTime -= gameTime.ElapsedGameTime.TotalSeconds;
            }
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            if (achievementDisplayTime > 0)
            {
                achievementSprite.Draw(spriteBatch, POSITION);
                spriteBatch.DrawString(font, ACHIEVEMENT_NAMES[lastAchievement], TEXT_POSITION, Color.WhiteSmoke);
            }
        }

        public static void Load(Game1 game)
        {
            achievementSprite = MenuSpriteFactory.AchievementSprite();
            font = MenuSpriteFactory.AchievementFont();
            // TODO: load from file
        }

        public static void Save()
        {
            // TODO: write to file (this function needs to be referenced somewhere as well)
        }

        public static void UnlockNextLevel()
        {
            if (maxLevelUnlocked < Settings.NUM_LEVELS)
            {
                maxLevelUnlocked++;
                Save();
            }
        }

        public static bool IsLevelUnlocked(int levelNumber)
        {
            return levelNumber <= maxLevelUnlocked;
        }

        public static void GrantAchievement(Achievement achievement)
        {
            if (!unlockedAchievements.Contains(achievement))
            {
                SoundManager.Instance.PlayAchievementSound();
                unlockedAchievements.Add(achievement);
                lastAchievement = achievement;
                achievementDisplayTime = ACHIEVEMENT_DISPLAY_LENGTH;
            }
        }

        public static bool IsAchievementUnlocked(Achievement achievement)
        {
            return unlockedAchievements.Contains(achievement);
        }

        public static string GetAchievementName(Achievement achievement)
        {
            return ACHIEVEMENT_NAMES[achievement];
        }
    }
}
