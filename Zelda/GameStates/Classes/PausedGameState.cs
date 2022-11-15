using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Linq.Expressions;
using System.Security.Principal;
using Zelda.HUD;
using Zelda.Inventory;
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
        private IInventory inventory;
        protected HUDBackground pauseHUDBackground;
        protected IHUD pauseHUD;
        protected HUDItem[] items;
        protected HUDItem map;
        protected HUDItem compass;
        protected HUDItem boomerang;
        protected HUDItem bomb;
        protected HUDItem bow;
        protected HUDItem candle;
        protected HUDItem recorder;
        protected HUDItem bluePotion;
        protected HUDItem redPotion;
        public PausedGameState(Game1 game)
        {
            this.inventory = game.Link.Inventory;
            this.game = game;
            PauseHUDBuilder.BuildHUD(items, pauseHUD, pauseHUDBackground, game);
        }

        public void Update(GameTime gameTime)
        {
            pauseHUD.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            pauseHUD.Draw(spriteBatch);
            pauseHUDBackground.Draw(spriteBatch);
            if (inventory.Contains(new Map(new Vector2())))
            {
                map.Draw(spriteBatch);
            }
            if (inventory.Contains(new Compass(new Vector2())))
            {
                compass.Draw(spriteBatch);
            }
            if (inventory.Contains(new Boomerang(new Vector2())))
            {
                boomerang.Draw(spriteBatch);
            }
            if (inventory.Contains(new Bomb(new Vector2())))
            {
                bomb.Draw(spriteBatch);
            }
            if (inventory.Contains(new Bow(new Vector2())))
            {
                bow.Draw(spriteBatch);
            }
            if (inventory.Contains(new BlueCandle(new Vector2())))
            {
                candle.Draw(spriteBatch);
            }
            if (inventory.Contains(new Recorder(new Vector2())))
            {
                recorder.Draw(spriteBatch);
            }
            if (inventory.Contains(new BluePotion(new Vector2())))
            {
                bluePotion.Draw(spriteBatch);
            }
        }
    }
}
