using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zelda.HUD
{
    internal class LinkHUD : IHUD
    {
        protected HealthDisplay healthDisplay;
        public LinkHUD()
        {
            //initialize map
            //initialize weapon/item displays
            //initialize Health Sprite
            healthDisplay = new HealthDisplay();

        }
        public void Update(GameTime gameTime)
        {
            healthDisplay.Update(gameTime);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            healthDisplay.Draw(spriteBatch);
        }
    }
}
