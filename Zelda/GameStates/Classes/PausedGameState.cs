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
            this.items = new HUDItem[10];
            pauseHUD = new LinkHUD(game, new Vector2(HUDUtilities.PAUSE_HUD_X, HUDUtilities.PAUSE_HUD_Y));
            pauseHUDBackground = new HUDBackground(HUDSpriteFactory.PauseHUDBackground(), new Vector2(HUDUtilities.PAUSE_HUD_X, HUDUtilities.PAUSE_HUD_INVENTORY_Y));
            PauseHUDBuilder.BuildHUD(items);
        }

        public void Update(GameTime gameTime)
        {
            pauseHUD.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            pauseHUD.Draw(spriteBatch);
            pauseHUDBackground.Draw(spriteBatch);

            // TODO: Refactor so we don't have a bunch of branching
            if (inventory.Contains(new Map(new Vector2())))
            {
                items[0].Draw(spriteBatch);
            }
            if (inventory.Contains(new Compass(new Vector2())))
            {
                items[1].Draw(spriteBatch);
            }
            if (inventory.Contains(new Boomerang(new Vector2())))
            {
                items[2].Draw(spriteBatch);
            }
            if (inventory.Contains(new Bomb(new Vector2())))
            {
                items[3].Draw(spriteBatch);
            }
            if (inventory.Contains(new Bow(new Vector2())))
            {
                items[4].Draw(spriteBatch);
            }
            if (inventory.Contains(new BlueCandle(new Vector2())))
            {
                items[5].Draw(spriteBatch);
            }
            if (inventory.Contains(new Recorder(new Vector2())))
            {
                items[6].Draw(spriteBatch);
            }
            if (inventory.Contains(new Food(new Vector2())))
            {
                items[7].Draw(spriteBatch);
            }
            // Change so RedPotion defaults over BluePotion if the player has both... at least that's how I think it works in the game
            if (inventory.Contains(new BluePotion(new Vector2())) || inventory.Contains(new RedPotion(new Vector2())))
            {
                items[8].Draw(spriteBatch);
            }
            if (inventory.Contains(new MagicalRod(new Vector2())))
            {
                items[9].Draw(spriteBatch);
            }
        }

        public void LeftClick()
        {

        }

        public void RightClick()
        {

        }

        // TODO: make below functions change inventory selection 
        public void Up()
        {

        }

        public void Down()
        {

        }

        public void Left()
        {

        }

        public void Right()
        {

        }
    }
}
