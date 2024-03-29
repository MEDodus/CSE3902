﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zelda.Link;
using Zelda.Sprites;
using Zelda.Utilities;

namespace Zelda.HUD
{
    public class HealthDisplay : IHUDElement
    {
        protected Heart[] hearts;
        protected Vector2 offset;
        public HealthDisplay(Vector2 position)
        {
            offset = position;
            this.hearts = new Heart[LinkUtilities.MAX_HEARTS];
            for (int currentHeart = 0; currentHeart < LinkUtilities.MAX_HEARTS; currentHeart++)
            {
                hearts[currentHeart] = new Heart();
                hearts[currentHeart].SetDestination(currentHeart, offset);
            }
        }

        public void Update(GameTime gameTime, ILink link)
        {
            int offset = 1;
            for (int currentHeart = 0; currentHeart < LinkUtilities.MAX_HEARTS; currentHeart++)
            {
                if ((currentHeart + offset) * 2 <= link.Health.CurrentHealth)
                {
                    hearts[currentHeart].FullHeart();
                }
                else if ((currentHeart + offset) * 2 - 1 == link.Health.CurrentHealth)
                {
                    hearts[currentHeart].HalfHeart();
                }
                else if ((currentHeart + offset) * 2 <= link.Health.MaxHealth)
                {
                    hearts[currentHeart].EmptyHeart();
                } else
                {
                    hearts[currentHeart].InvisibleHeart();
                }
            }
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
