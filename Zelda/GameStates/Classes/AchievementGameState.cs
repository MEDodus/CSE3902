using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using Zelda.Achievements;
using Zelda.Menu;
using Zelda.Sound;
using Zelda.Sprites.Factories;

namespace Zelda.GameStates.Classes
{
    public class AchievementGameState : IGameState
    {
        private Game1 game;
        private double clickCooldown = 0.5; // when entering screen, left click is already down from the main menu, so wait to accept input
        private BackButton backButton;
        private SpriteFont font;

        private readonly int X = 200;
        private readonly int Y = 200;
        private readonly int OFFSET_Y = 30;

        public AchievementGameState(Game1 game)
        {
            this.game = game;
            game.GraphicClear();
            backButton = new BackButton(new Vector2(100, 100));
            font = MenuSpriteFactory.MenuFont();
        }

        public void Update(GameTime gameTime)
        {
            if (clickCooldown > 0)
            {
                clickCooldown -= gameTime.ElapsedGameTime.TotalSeconds;
            }
            backButton.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            backButton.Draw(spriteBatch);
            Achievement[] achievements = Enum.GetValues<Achievement>();
            for (int i = 0; i < achievements.Length; i++)
            {
                Achievement achievement= achievements[i];
                bool unlocked = AchievementManager.IsAchievementUnlocked(achievement);
                string text = unlocked ? AchievementManager.GetAchievementName(achievement) : "???";
                Color color = unlocked ? Color.White : Color.Gray;
                spriteBatch.DrawString(font, text, new Vector2(X, Y + i * OFFSET_Y), color);
            }
        }

        public void LeftClick()
        {
            if (clickCooldown > 0)
            {
                return;
            }
            Point position = Mouse.GetState().Position;
            if (backButton.Destination.Contains(position))
            {
                SoundManager.Instance.PlayMenuClickSound();
                game.GameState = new MenuGameState(game);
            }
        }

        public void RightClick()
        {
            
        }

        public void Up()
        {
            
        }

        public void Down()
        {
            
        }

        public void Left()
        {
            
        }

        public void Right()
        {
            
        }
    }
}
