using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using Zelda.Achievements;
using Zelda.Controllers;
using Zelda.NPCs.FriendlyNPCs;
using Zelda.Projectiles;
using Zelda.Rooms;
using Zelda.Sound;

namespace Zelda.GameStates.Classes
{
    public class RunningGameState : IGameState
    {
        private Game1 game;
        private double roomSwitchTimer = 1; // start at a high delay time since you have to click to start game from the title screen
        private readonly double ROOM_SWITCH_DELAY = 0.25;

        public RunningGameState(Game1 game)
        {
            this.game = game;
            SoundManager.Instance.PlayDungeonThemeSound();
        }

        public void Update(GameTime gameTime)
        {
            if (roomSwitchTimer > 0)
            {
                roomSwitchTimer -= gameTime.ElapsedGameTime.TotalSeconds;
            }
            // Update all game objects
            RoomBuilder.Instance.Update(gameTime);
            RoomTransitions.Update(gameTime, game.Link, game.LinkCompanion);
            ProjectileStorage.Update(gameTime);
            FriendlyNPCManager.Instance.Update(game, gameTime);
            game.Link.Update(gameTime);
            if(game.PlayerCount > 1)
            {
                game.LinkCompanion.Update(gameTime);
            }
            game.Collisions.DetectCollisions(game, gameTime, game.Link, game.LinkCompanion);
            game.HUD.Update(gameTime);
            AchievementManager.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // Draw all game objects
            RoomBuilder.Instance.Draw(spriteBatch);
            ProjectileStorage.Draw(spriteBatch);
            game.Link.Draw(spriteBatch);
            if(game.PlayerCount > 1)
            {
                game.LinkCompanion.Draw(spriteBatch);
            }
            RoomBuilder.Instance.DrawTopLayer(spriteBatch);
            game.HUD.Draw(spriteBatch);
            FriendlyNPCManager.Instance.Draw(spriteBatch);
            AchievementManager.Draw(spriteBatch);
        }

        public void LeftClick()
        {
            if (roomSwitchTimer <= 0)
            {
                roomSwitchTimer = ROOM_SWITCH_DELAY;
                RoomBuilder.Instance.NextRoom(game.Link, game.LinkCompanion);
            }
        }

        public void RightClick()
        {
            if (roomSwitchTimer <= 0)
            {
                roomSwitchTimer = ROOM_SWITCH_DELAY;
                RoomBuilder.Instance.PreviousRoom(game.Link, game.LinkCompanion);
            }
        }

        public void Up()
        {
            if (KeyboardController.PlayerMovingUpKey(1))
            {
                game.Link.MoveUp();
            }
            if(KeyboardController.PlayerMovingUpKey(2))
            {
                game.LinkCompanion.MoveUp();
            }
        }

        public void Down()
        {
            if (KeyboardController.PlayerMovingDownKey(1))
            {
                game.Link.MoveDown();
            }
            if (KeyboardController.PlayerMovingDownKey(2))
            {
                game.LinkCompanion.MoveDown();
            }
        }

        public void Left()
        {
            if (KeyboardController.PlayerMovingLeftKey(1))
            {
                game.Link.MoveLeft();
            }
            if (KeyboardController.PlayerMovingLeftKey(2))
            {
                game.LinkCompanion.MoveLeft();
            }
        }

        public void Right()
        {
            if (KeyboardController.PlayerMovingRightKey(1))
            {
                game.Link.MoveRight();
            }
            if (KeyboardController.PlayerMovingRightKey(2))
            {
                game.LinkCompanion.MoveRight();
            }
        }
    }
}
