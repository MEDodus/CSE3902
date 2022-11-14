using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zelda.Items;
using Zelda.Link;
using Zelda.Sprites.Factories;
using Zelda.Utilities;

namespace Zelda.HUD
{
    public class HUDText : IHUDElement
    {
        private SpriteFont font;
        private Vector2 destination;
        private Color color;
        private string text;

        public HUDText(String text, Color color, Vector2 position)
        {
            font = HUDSpriteFactory.HUDFont();
            destination = new Vector2(position.X, position.Y);
            this.text = text;
            this.color = color;
        }
        public void Update(GameTime gameTime, ILink link)
        {

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, text, destination, color);
        }
    }
}
