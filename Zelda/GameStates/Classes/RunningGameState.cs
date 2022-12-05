using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zelda.Projectiles;
using Zelda.Rooms;

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
        }

        public void Update(GameTime gameTime)
        {
            if (roomSwitchTimer > 0)
            {
                roomSwitchTimer -= gameTime.ElapsedGameTime.TotalSeconds;
            }
            // Update all game objects
            RoomBuilder.Instance.Update(gameTime);
            RoomTransitions.Update(gameTime, game.Link);
            ProjectileStorage.Update(gameTime);
            game.Link.Update(gameTime);
            game.Collisions.DetectCollisions(game, gameTime, game.Link);
            game.HUD.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // Draw all game objects
            RoomBuilder.Instance.Draw(spriteBatch);
            ProjectileStorage.Draw(spriteBatch);
            game.Link.Draw(spriteBatch);
            RoomBuilder.Instance.DrawTopLayer(spriteBatch);
            game.HUD.Draw(spriteBatch);
        }

        public void LeftClick()
        {
            if (roomSwitchTimer <= 0)
            {
                roomSwitchTimer = ROOM_SWITCH_DELAY;
                RoomBuilder.Instance.NextRoom(game.Link);
            }
        }

        public void RightClick()
        {
            if (roomSwitchTimer <= 0)
            {
                roomSwitchTimer = ROOM_SWITCH_DELAY;
                RoomBuilder.Instance.PreviousRoom(game.Link);
            }
        }

        public void Up()
        {
            game.Link.MoveUp();
        }

        public void Down()
        {
            game.Link.MoveDown();
        }

        public void Left()
        {
            game.Link.MoveLeft();
        }

        public void Right()
        {
            game.Link.MoveRight();
        }
    }
}
