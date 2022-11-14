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
    public class HUDItemQuantity : IHUDElement
    {
        private SpriteFont font;
        private Vector2 destination;
        private int quantity;
        //private string text;
        private IItem item;
        public HUDItemQuantity(IItem item, Vector2 position)
        {
            font = HUDSpriteFactory.HUDFont();
            destination = new Vector2(position.X, position.Y);
            //this.text = text;
            this.item = item;
        }
        public void Update(GameTime gameTime, ILink link)
        {
            this.quantity = link.Inventory.GetCount(this.item);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, "X " + Convert.ToString(quantity), destination, Color.White);
        }
    }
}
