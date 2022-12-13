using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using Zelda.Achievements;
using Zelda.Menu;
using Zelda.Sound;

namespace Zelda.GameStates.Classes
{
    public class MenuGameState : IGameState
    {
        private readonly int X = 350;
        private readonly int Y = 300;
        private readonly int BUTTON_OFFSET_Y = 100;

        private Game1 game;
        private double clickCooldown = 0.75; // when entering menu, left click is already down from the title screen, so wait to accept input
        private MenuButton levelSelectButton;
        private MenuButton achievementsButton;
        private MenuButton resetButton;
        private MenuButton multiplayerButton, multiplayerButtonOne, multiplayerButtonTwo;

        public MenuGameState(Game1 game)
        {
            this.game = game;
            SoundManager.Instance.PlayMainThemeSound();
            game.GraphicClear();
            levelSelectButton = new MenuButton(new Vector2(X, Y), " LEVEL SELECT");
            achievementsButton = new MenuButton(new Vector2(X, Y + BUTTON_OFFSET_Y), "ACHIEVEMENTS");
            resetButton = new MenuButton(new Vector2(X, Y + 2 * BUTTON_OFFSET_Y), "  RESET DATA");
            multiplayerButtonOne = new MenuButton(new Vector2(X, Y - BUTTON_OFFSET_Y), "   PLAYERS: 1");
            multiplayerButtonTwo = new MenuButton(new Vector2(X, Y - BUTTON_OFFSET_Y), "   PLAYERS: 2");
            if(game.PlayerCount == 1)
            {
                multiplayerButton = multiplayerButtonOne;
            } else
            {
                multiplayerButton = multiplayerButtonTwo;
            }
        }

        public void Update(GameTime gameTime)
        {
            if (clickCooldown > 0)
            {
                clickCooldown -= gameTime.ElapsedGameTime.TotalSeconds;
            }
            levelSelectButton.Update(gameTime);
            achievementsButton.Update(gameTime);
            resetButton.Update(gameTime);
            multiplayerButton.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            levelSelectButton.Draw(spriteBatch);
            achievementsButton.Draw(spriteBatch);
            resetButton.Draw(spriteBatch);
            multiplayerButton.Draw(spriteBatch);
        }

        public void LeftClick()
        {
            if (clickCooldown > 0)
            {
                return;
            }
            Point position = Mouse.GetState().Position;
            if (levelSelectButton.Destination.Contains(position))
            {
                SoundManager.Instance.PlayMenuClickSound();
                game.GameState = new LevelSelectGameState(game);
            }
            else if (achievementsButton.Destination.Contains(position))
            {
                SoundManager.Instance.PlayMenuClickSound();
                game.GameState = new AchievementGameState(game);
            }
            else if (resetButton.Destination.Contains(position))
            {
                clickCooldown = 0.5;
                SoundManager.Instance.PlayMenuClickSound();
                AchievementManager.Reset();
            } else if (multiplayerButton.Destination.Contains(position))
            {
                clickCooldown = 0.5;
                SoundManager.Instance.PlayMenuClickSound();
                if(multiplayerButton == multiplayerButtonOne)
                {
                    multiplayerButton = multiplayerButtonTwo;
                    game.PlayerCount = 2;
                } else
                {
                    multiplayerButton = multiplayerButtonOne;
                    game.PlayerCount = 1;
                }
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
