using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zelda.Items.Classes;
using Zelda.Link;
using Zelda.Sprites;
using Zelda.Sprites.Factories;
using Zelda.Utilities;

namespace Zelda.HUD
{
    public class HUDBackground : IHUDElement
    {
        protected ISprite background;
        protected Vector2 destination;
        public HUDBackground(Vector2 destination)
        {
            this.background = HUDSpriteFactory.LinkHUDBackground();
            this.destination = destination;
                               //new Vector2(HUDUtilities.HUD_X, HUDUtilities.HUD_Y);
        }
        public void Update(GameTime gameTime, ILink link)
        {

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            background.Draw(spriteBatch, destination);
        }

    }
}
