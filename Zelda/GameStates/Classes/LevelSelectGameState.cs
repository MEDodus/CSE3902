using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using Zelda.Menu;
using Zelda.Rooms;
using Zelda.Sound;

namespace Zelda.GameStates.Classes
{
    public class LevelSelectGameState : IGameState
    {
        private readonly int X = 350;
        private readonly int Y = 300;
        private readonly int BUTTON_OFFSET_Y = 100;

        private Game1 game;
        private double clickCooldown = 0.75; // when entering menu, left click is already down from the title screen, so wait to accept input
        private List<MenuButton> menuButtons;

        public LevelSelectGameState(Game1 game)
        {
            this.game = game;
            game.GraphicClear();
            menuButtons = new List<MenuButton>();
            for (int i = 1; i <= Settings.NUM_LEVELS; i++)
            {
                menuButtons.Add(new MenuButton(new Vector2(X, Y + (i - 1) * BUTTON_OFFSET_Y), "     LEVEL " + i));
            }
        }

        public void Update(GameTime gameTime)
        {
            if (clickCooldown > 0)
            {
                clickCooldown -= gameTime.ElapsedGameTime.TotalSeconds;
            }
            foreach(MenuButton button in menuButtons)
            {
                button.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (MenuButton button in menuButtons)
            {
                button.Draw(spriteBatch);
            }
        }

        public void LeftClick()
        {
            if (clickCooldown > 0)
            {
                return;
            }
            Point position = Mouse.GetState().Position;
            for (int i = 0; i < menuButtons.Count; i++)
            {
                MenuButton button = menuButtons[i];
                if (button.Destination.Contains(position)) // TODO: check if level is unlocked
                {
                    SoundManager.Instance.PlayMenuClickSound();
                    RoomBuilder.Instance.LoadLevel("Level" + (i + 1));
                    game.Reset();
                    game.GameState = new RunningGameState(game);
                    break;
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
