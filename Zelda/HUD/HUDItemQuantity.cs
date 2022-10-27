using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zelda.Link;
using Zelda.Sprites.Factories;
using Zelda.Utilities;

namespace Zelda.HUD
{
    internal class HUDItemQuantity : IHUDElement
    {
        private SpriteFont font;
        private Vector2 destination;
        private int quantity;
        private string text;
        public HUDItemQuantity(Vector2 position, String text)
        {
            font = HUDSpriteFactory.HUDFont();
            destination = new Vector2(position.X, position.Y);
            this.text = text;
        }
        public void Update(GameTime gameTime, ILink link)
        {

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, text, destination, Color.White);
        }
    }
}
