using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zelda.HUD;
using Zelda.Projectiles;
using Zelda.Rooms;

namespace Zelda.GameStates.Classes
{
    public class PausedGameState : IGameState
    {
        private Game1 game;

        public PausedGameState(Game1 game)
        {
            this.game = game;
        }

        public void Update(GameTime gameTime)
        {
            // no updating in paused state
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // TODO: change to draw the pause screen instead
            RoomBuilder.Instance.Draw(spriteBatch);
            ProjectileStorage.Draw(spriteBatch);
            game.Link.Draw(spriteBatch);
            RoomBuilder.Instance.DrawTopLayer(spriteBatch);
            game.HUD.Draw(spriteBatch);
        }
    }
}
