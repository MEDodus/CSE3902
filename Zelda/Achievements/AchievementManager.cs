using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using Zelda.Sound;
using Zelda.Sprites;
using Zelda.Sprites.Factories;

namespace Zelda.Achievements
{
    public enum Achievement { DoorUnlocked, DragonKilled, DodongoKilled, OldManKilled, FirstKill, BoomerangFound, MagicalRodFound, MapFound }

    public static class AchievementManager
    {
        public static int NumAchievements { get { return Enum.GetNames<Achievement>().Length; } }

        // Achievement info
        private static readonly Dictionary<Achievement, string> ACHIEVEMENT_NAMES = new Dictionary<Achievement, string>()
        {
            { Achievement.DoorUnlocked, "Breaking and entering" },
            { Achievement.DragonKilled, "Dragon killer" },
            { Achievement.DodongoKilled, "Dinosaur killer" },
            { Achievement.OldManKilled, "Elder abuse" },
            { Achievement.FirstKill, "First blood" },
            { Achievement.BoomerangFound, "Australian" },
            { Achievement.MagicalRodFound, "You're a wizard Harry" },
            { Achievement.MapFound, "Mapped out" },
        };
        // Save file
        private static readonly string FILENAME = "..\\..\\..\\Achievements\\save.txt";
        // UI
        private static readonly Vector2 POSITION = new Vector2(Settings.ROOM_WINDOW_X + 10, Settings.ROOM_WINDOW_Y - 100);
        private static readonly Vector2 TEXT_POSITION = POSITION + new Vector2(75, 30);
        private static readonly double ACHIEVEMENT_DISPLAY_LENGTH = 5;

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

        public static void Load()
        {
            achievementSprite = MenuSpriteFactory.AchievementSprite();
            font = MenuSpriteFactory.AchievementFont();
            // Load from file
            string[] lines = File.ReadAllLines(FILENAME);
            maxLevelUnlocked = int.Parse(lines[0]);
            for (int i = 1; i < lines.Length; i++)
            {
                Achievement achievement = GetAchievementFromName(lines[i]);
                if (!unlockedAchievements.Contains(achievement))
                {
                    unlockedAchievements.Add(achievement);
                }
            }
        }

        public static void Save()
        {
            string content = maxLevelUnlocked.ToString() + "\n";
            foreach (Achievement achievement in unlockedAchievements)
            {
                content += GetAchievementName(achievement) + "\n";
            }
            File.WriteAllText(FILENAME, content);
        }

        public static void Reset()
        {
            maxLevelUnlocked = 1;
            unlockedAchievements.Clear();
            Save();
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
                Save();
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

        private static Achievement GetAchievementFromName(string name)
        {
            foreach (KeyValuePair<Achievement, string> pair in ACHIEVEMENT_NAMES)
            {
                if (pair.Value == name)
                {
                    return pair.Key;
                }
            }
            throw new Exception(name + " is not mapped to an Achievement enum.");
        }
    }
}
