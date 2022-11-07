using Microsoft.Xna.Framework;
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
    internal class HealthDisplay : IHUDElement
    {
        protected Heart[] hearts;
        public HealthDisplay(ILink link)
        {
            this.hearts = new Heart[LinkUtilities.MAX_HEARTS];
            for (int currentHeart = 0; currentHeart < LinkUtilities.MAX_HEARTS; currentHeart++)
            {
                hearts[currentHeart] = new Heart();
                hearts[currentHeart].SetDestination(currentHeart);
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
                else
                {
                    hearts[currentHeart].EmptyHeart();
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
