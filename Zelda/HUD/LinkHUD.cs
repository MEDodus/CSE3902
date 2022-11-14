using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zelda.Items.Classes;
using Zelda.Link;
using Zelda.Utilities;

namespace Zelda.HUD
{
    public class LinkHUD : IHUD
    {
        private Game1 game;
        protected HUDBackground hudBackground;
        protected DungeonHUDMap map;
        protected HealthDisplay healthDisplay;
        protected HUDItemQuantity rupyQuantity;
        protected HUDItemQuantity keyQuantity;
        protected HUDItemQuantity bombQuantity;
        protected HUDItemEquipped slotA;
        protected HUDItemEquipped slotB;

        protected Vector2 HUDPosition;
        public LinkHUD(Game1 game, Vector2 position)
        {
            this.game = game;
            hudBackground = new HUDBackground(position);
            map = new DungeonHUDMap(game, new Rectangle((int)position.X + HUDUtilities.MAP_X, (int)position.Y + HUDUtilities.MAP_Y, 
                HUDUtilities.MAP_WIDTH, HUDUtilities.MAP_HEIGHT));
            //initialize weapon/item displays
            healthDisplay = new HealthDisplay(position);
            rupyQuantity = new HUDItemQuantity(new FiveRupies(new Vector2(0, 0)), position + new Vector2(HUDUtilities.ITEM_COUNT_X, HUDUtilities.RUPY_COUNT_Y));
            keyQuantity = new HUDItemQuantity(new Key(new Vector2(0, 0)), position + new Vector2(HUDUtilities.ITEM_COUNT_X, HUDUtilities.KEY_COUNT_Y));
            bombQuantity =  new HUDItemQuantity(new Bomb(new Vector2(0,0)), position + new Vector2(HUDUtilities.ITEM_COUNT_X, HUDUtilities.BOMB_COUNT_Y));
            //new HUDItemQuantity(new Vector2(HUDUtilities.HUD_X + 20, HUDUtilities.MAP_Y - 30), "Level 1");
            slotA = new HUDItemEquipped(new Sword(new Vector2(0, 0)), position + new Vector2(HUDUtilities.SLOT_A_X, HUDUtilities.SLOT_Y));
            slotB = new HUDItemEquipped(new Bomb(new Vector2(0, 0)), position + new Vector2(HUDUtilities.SLOT_B_X, HUDUtilities.SLOT_Y));

        }
        public void Update(GameTime gameTime)
        {
            ILink link = game.Link;
            hudBackground.Update(gameTime, link);
            map.Update(gameTime, link);
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
            healthDisplay.Draw(spriteBatch);
            rupyQuantity.Draw(spriteBatch);
            keyQuantity.Draw(spriteBatch);
            bombQuantity.Draw(spriteBatch);
            slotA.Draw(spriteBatch);
            slotB.Draw(spriteBatch);
        }
    }
}
