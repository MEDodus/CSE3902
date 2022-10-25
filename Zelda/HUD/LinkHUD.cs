using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zelda.Link;

namespace Zelda.HUD
{
    internal class LinkHUD : IHUD
    {
        protected HUDBackground hudBackground;
        protected DungeonHUDMap map;
        protected HealthDisplay healthDisplay;

        public LinkHUD()
        {
            hudBackground = new HUDBackground();
            map = new DungeonHUDMap();
            //initialize weapon/item displays
            healthDisplay = new HealthDisplay();


        }
        public void Update(GameTime gameTime, ILink link)
        {
            hudBackground.Update(gameTime, link);
            map.Update(gameTime, link);
            healthDisplay.Update(gameTime, link);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            hudBackground.Draw(spriteBatch);
            map.Draw(spriteBatch);
            healthDisplay.Draw(spriteBatch);
        }
    }
}
