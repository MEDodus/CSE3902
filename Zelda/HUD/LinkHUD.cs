using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zelda.Items.Classes;
using Zelda.Link;
using Zelda.Utilities;

namespace Zelda.HUD
{
    public class LinkHUD : IHUD
    {
        protected HUDBackground hudBackground;
        protected DungeonHUDMap map;
        protected HealthDisplay healthDisplay;
        protected HUDItemQuantity rupyQuantity;
        protected HUDItemQuantity keyQuantity;
        protected HUDItemQuantity bombQuantity;
        protected HUDItemEquipped slotA;
        protected HUDItemEquipped slotB;

        protected Vector2 HUDPosition;
        public LinkHUD(ILink link, Vector2 position)
        {
            hudBackground = new HUDBackground(position);
            map = new DungeonHUDMap(position);
            //initialize weapon/item displays
            healthDisplay = new HealthDisplay(link, position);
            rupyQuantity = new HUDItemQuantity(new FiveRupies(new Vector2(0, 0)), position + new Vector2(HUDUtilities.ITEM_COUNT_X, HUDUtilities.RUPY_COUNT_Y));
            keyQuantity = new HUDItemQuantity(new Key(new Vector2(0, 0)), position + new Vector2(HUDUtilities.ITEM_COUNT_X, HUDUtilities.KEY_COUNT_Y));
            bombQuantity =  new HUDItemQuantity(new Bomb(new Vector2(0,0)), position + new Vector2(HUDUtilities.ITEM_COUNT_X, HUDUtilities.BOMB_COUNT_Y));
            //new HUDItemQuantity(new Vector2(HUDUtilities.HUD_X + 20, HUDUtilities.MAP_Y - 30), "Level 1");
            slotA = new HUDItemEquipped(new Sword(new Vector2(0, 0)), position + new Vector2(HUDUtilities.SLOT_A_X, HUDUtilities.SLOT_Y));
            slotB = new HUDItemEquipped(new Bomb(new Vector2(0, 0)), position + new Vector2(HUDUtilities.SLOT_B_X, HUDUtilities.SLOT_Y));

        }
        public void Update(GameTime gameTime, ILink link)
        {
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
