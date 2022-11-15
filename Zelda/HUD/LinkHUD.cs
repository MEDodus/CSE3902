using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zelda.Items.Classes;
using Zelda.Link;
using Zelda.Sprites.Factories;
using Zelda.Utilities;

namespace Zelda.HUD
{
    public class LinkHUD : IHUD
    {
        private Game1 game;
        protected HUDBackground hudBackground;
        protected DungeonHUDMap map;
        protected PauseMenuMap pauseMenuMap;
        protected HealthDisplay healthDisplay;
        protected IHUDElement rupyQuantity;
        protected IHUDElement keyQuantity;
        protected IHUDElement bombQuantity;
        protected HUDItem slotA;
        protected HUDItem slotB;

        protected Vector2 HUDPosition;
        public LinkHUD(Game1 game, Vector2 position)
        {
            this.game = game;
            hudBackground = new HUDBackground(HUDSpriteFactory.LinkHUDBackground(), position);
            map = new DungeonHUDMap(game, new Rectangle((int)position.X + HUDUtilities.MAP_X, (int)position.Y + HUDUtilities.MAP_Y, 
                HUDUtilities.MAP_WIDTH, HUDUtilities.MAP_HEIGHT));
            pauseMenuMap = new PauseMenuMap(game, position);
            //initialize weapon/item displays
            healthDisplay = new HealthDisplay(position);
            rupyQuantity = new HUDRupyQuantity(new FiveRupies(new Vector2(0, 0)), position + new Vector2(HUDUtilities.ITEM_COUNT_X, HUDUtilities.RUPY_COUNT_Y));
            keyQuantity = new HUDItemQuantity(new Key(new Vector2(0, 0)), position + new Vector2(HUDUtilities.ITEM_COUNT_X, HUDUtilities.KEY_COUNT_Y));
            bombQuantity = new HUDItemQuantity(new Bomb(new Vector2(0, 0)), position + new Vector2(HUDUtilities.ITEM_COUNT_X, HUDUtilities.BOMB_COUNT_Y));
            //new HUDItemQuantity(new Vector2(HUDUtilities.HUD_X + 20, HUDUtilities.MAP_Y - 30), "Level 1");
            slotA = new HUDItem(new Sword(new Vector2(0, 0)), position + new Vector2(HUDUtilities.SLOT_A_X, HUDUtilities.SLOT_Y));
            slotB = new HUDItem(new Bomb(new Vector2(0, 0)), position + new Vector2(HUDUtilities.SLOT_B_X, HUDUtilities.SLOT_Y));

        }
        public void Update(GameTime gameTime)
        {
            ILink link = game.Link;
            hudBackground.Update(gameTime, link);
            map.Update(gameTime, link);
            pauseMenuMap.Update(gameTime, link);
            healthDisplay.Update(gameTime, link);
            rupyQuantity.Update(gameTime, link);
            keyQuantity.Update(gameTime, link);
            bombQuantity.Update(gameTime, link);
            slotA.Update(gameTime, link);
            slotB.Update(gameTime, link);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            BlackBorders.Draw(spriteBatch);
            hudBackground.Draw(spriteBatch);
            map.Draw(spriteBatch);
            if (game.Link.Inventory.Contains(new Map(new Vector2())))
            {
                pauseMenuMap.Draw(spriteBatch);
            }
            healthDisplay.Draw(spriteBatch);
            rupyQuantity.Draw(spriteBatch);
            keyQuantity.Draw(spriteBatch);
            bombQuantity.Draw(spriteBatch);
            slotA.Draw(spriteBatch);
            slotB.Draw(spriteBatch);
        }
    }
}
