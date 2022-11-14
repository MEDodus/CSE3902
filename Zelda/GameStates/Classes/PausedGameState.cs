using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zelda.HUD;
using Zelda.Projectiles;
using Zelda.Rooms;
using Zelda.Utilities;

namespace Zelda.GameStates.Classes
{
    public class PausedGameState : IGameState
    {
        private Game1 game;
        protected IHUD pauseHUD;
        public PausedGameState(Game1 game)
        {
            this.game = game;
            pauseHUD =  new LinkHUD(game, new Vector2(HUDUtilities.PAUSED_HUD_X, HUDUtilities.PAUSED_HUD_Y));

        }

        public void Update(GameTime gameTime)
        {
            pauseHUD.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            pauseHUD.Draw(spriteBatch);
        }
    }
}
