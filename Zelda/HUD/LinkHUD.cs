using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zelda.Link;
using Zelda.Utilities;

namespace Zelda.HUD
{
    internal class LinkHUD : IHUD
    {
        protected HUDBackground hudBackground;
        protected DungeonHUDMap map;
        protected HealthDisplay healthDisplay;
        protected HUDItemQuantity bombQuantity;

        public LinkHUD(ILink link)
        {
            hudBackground = new HUDBackground();
            map = new DungeonHUDMap();
            //initialize weapon/item displays
            healthDisplay = new HealthDisplay(link);
            bombQuantity = new HUDItemQuantity(new Vector2(HUDUtilities.HUD_X + 20, HUDUtilities.MAP_Y - 30), "Level 1");


        }
        public void Update(GameTime gameTime, ILink link)
        {
            hudBackground.Update(gameTime, link);
            map.Update(gameTime, link);
            healthDisplay.Update(gameTime, link);
            bombQuantity.Update(gameTime, link);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            BlackBorders.Draw(spriteBatch);
            hudBackground.Draw(spriteBatch);
            map.Draw(spriteBatch);
            healthDisplay.Draw(spriteBatch);
            bombQuantity.Draw(spriteBatch);
        }
    }
}
