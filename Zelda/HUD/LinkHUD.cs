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
        protected HealthDisplay healthDisplay;
        protected HUDBackground hudBackground;
        public LinkHUD()
        {
            hudBackground = new HUDBackground();
            //initialize map
            //initialize weapon/item displays
            healthDisplay = new HealthDisplay();


        }
        public void Update(GameTime gameTime, ILink link)
        {
            hudBackground.Update(gameTime, link);   
            healthDisplay.Update(gameTime, link);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            hudBackground.Draw(spriteBatch);
            healthDisplay.Draw(spriteBatch);
        }
    }
}
