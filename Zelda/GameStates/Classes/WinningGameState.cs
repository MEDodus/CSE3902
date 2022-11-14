using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zelda.Link;
using Zelda.Projectiles;
using Zelda.Rooms;

namespace Zelda.GameStates.Classes
{
    public class WinningGameState : IGameState
    {
        private Game1 game;
        private TriforceLink decoratedLink;
        private double timer;

        public WinningGameState(Game1 game)
        {
            this.game = game;
            decoratedLink = new TriforceLink(game.Link, game);
            game.Link = decoratedLink;
            timer = 1.5;
        }

        public void Update(GameTime gameTime)
        {
            timer -= gameTime.ElapsedGameTime.TotalSeconds;
            if (timer <= 0)
            {
                decoratedLink.RemoveDecorator();
                game.GameState = new RunningGameState(game); // TODO: change to win screen?
            }
            // Update only some game objects
            RoomBuilder.Instance.Update(gameTime);
            game.Link.Update(gameTime);
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
