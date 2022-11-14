using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zelda.Projectiles;
using Zelda.Rooms;

namespace Zelda.GameStates.Classes
{
    public class RunningGameState : IGameState
    {
        private Game1 game;

        public RunningGameState(Game1 game)
        {
            this.game = game;
        }

        public void Update(GameTime gameTime)
        {
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
    }
}
