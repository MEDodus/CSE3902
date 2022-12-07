using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Zelda.Controllers;
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
            SoundManager.Instance.PlayMainThemeSound();
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
            game.Link.Update(gameTime);
            game.LinkCompanion.Update(gameTime);
            game.Collisions.DetectCollisions(game, gameTime, game.Link, game.LinkCompanion);
            game.HUD.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // Draw all game objects
            RoomBuilder.Instance.Draw(spriteBatch);
            ProjectileStorage.Draw(spriteBatch);
            game.Link.Draw(spriteBatch);
            game.LinkCompanion.Draw(spriteBatch);
            RoomBuilder.Instance.DrawTopLayer(spriteBatch);
            game.HUD.Draw(spriteBatch);
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
            if(KeyboardController.mostRecentLinkMovementKey(Keys.W) == Keys.W)
            {
                game.Link.MoveUp();
            }
            else if(KeyboardController.mostRecentCompMovementKey(Keys.Up) == Keys.Up)
            {
                game.LinkCompanion.MoveUp();
            }
        }

        public void Down()
        {
            if (KeyboardController.mostRecentLinkMovementKey(Keys.S) == Keys.S)
            {
                game.Link.MoveDown();
            }
            if (KeyboardController.mostRecentCompMovementKey(Keys.Down) == Keys.Down)
            {
                game.LinkCompanion.MoveDown();
            }
        }

        public void Left()
        {
            if (KeyboardController.mostRecentLinkMovementKey(Keys.A) == Keys.A)
            {
                game.Link.MoveLeft();
            }
            if (KeyboardController.mostRecentCompMovementKey(Keys.Left) == Keys.Left)
            {
                game.LinkCompanion.MoveLeft();
            }
        }

        public void Right()
        {
            if (KeyboardController.mostRecentLinkMovementKey(Keys.D) == Keys.D)
            {
                game.Link.MoveRight();
            }
            if (KeyboardController.mostRecentCompMovementKey(Keys.Right) == Keys.Right)
            {
                game.LinkCompanion.MoveRight();
            }
        }
    }
}
