using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zelda.HUD;
using Zelda.Projectiles;
using Zelda.Rooms;
using Zelda.Sprites.Factories;
using Zelda.Utilities;

namespace Zelda.GameStates.Classes
{
    public class PausedGameState : IGameState
    {
        private Game1 game;
        protected HUDBackground pauseHUDBackground;
        protected IHUD pauseHUD;
        public PausedGameState(Game1 game)
        {
            this.game = game;
            pauseHUD = new LinkHUD(game.Link, new Vector2(HUDUtilities.PAUSE_HUD_X, HUDUtilities.PAUSE_HUD_Y));
            pauseHUDBackground = new HUDBackground(HUDSpriteFactory.PauseHUDBackground(), new Vector2(HUDUtilities.PAUSE_HUD_X, HUDUtilities.PAUSE_HUD_Y));

        }

        public void Update(GameTime gameTime)
        {
            pauseHUD.Update(gameTime, game.Link);
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            pauseHUD.Draw(spriteBatch);
            pauseHUDBackground.Draw(spriteBatch);
        }
    }
}
