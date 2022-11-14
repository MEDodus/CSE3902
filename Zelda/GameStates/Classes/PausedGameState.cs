using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zelda.HUD;
using Zelda.Items.Classes;
using Zelda.Projectiles;
using Zelda.Rooms;
using Zelda.Sound;
using Zelda.Sprites.Factories;
using Zelda.Utilities;

namespace Zelda.GameStates.Classes
{
    public class PausedGameState : IGameState
    {
        private Game1 game;
        protected HUDBackground pauseHUDBackground;
        protected IHUD pauseHUD;
        protected HUDItem map;
        protected HUDItem compass;

        protected bool HasMap = false;
        protected bool HasCompass = false;
        public PausedGameState(Game1 game)
        {
            this.game = game;
            pauseHUD = new LinkHUD(game, new Vector2(HUDUtilities.PAUSE_HUD_X, HUDUtilities.PAUSE_HUD_Y));
            pauseHUDBackground = new HUDBackground(HUDSpriteFactory.PauseHUDBackground(), new Vector2(HUDUtilities.PAUSE_HUD_X, HUDUtilities.PAUSE_HUD_INVENTORY_Y));
            if(game.Link.Inventory.FindInSet(new Map(new Vector2(0, 0)))){
                map = new HUDItem(new Map(new Vector2(0, 0)), new Vector2(HUDUtilities.PAUSE_ITEM_X, HUDUtilities.MAP_ITEM_Y));
                HasMap = true;
            }
            if (game.Link.Inventory.FindInSet(new Compass(new Vector2(0, 0)))){
                compass = new HUDItem(new Compass(new Vector2(0, 0)), new Vector2(HUDUtilities.PAUSE_ITEM_X, HUDUtilities.COMPASS_ITEM_Y));
                HasCompass = true;
            }
        }

        public void Update(GameTime gameTime)
        {
            pauseHUD.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            pauseHUD.Draw(spriteBatch);
            pauseHUDBackground.Draw(spriteBatch);
            if (HasMap)
            {
                map.Draw(spriteBatch);
            }
            if (HasCompass)
            {
                compass.Draw(spriteBatch);
            }
        }
    }
}
