﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zelda.Sprites;
using Zelda.Utilities;

namespace Zelda.HUD
{
    internal class HealthDisplay : IHUDElement
    {
        protected Heart[] hearts;
        public HealthDisplay()
        {
            this.hearts = new Heart[LinkUtilities.TOTAL_HEALTH];
            for (int currentHeart = 0; currentHeart < LinkUtilities.TOTAL_HEALTH; currentHeart++)
            {
                hearts[currentHeart] = new Heart();
                hearts[currentHeart].SetDestination(currentHeart);
            }
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach(Heart heart in hearts)
            {
                heart.Draw(spriteBatch);
            }
        }
    }
}
