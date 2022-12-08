using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Zelda.Items;
using Zelda.Link;
using Zelda.Sprites.Factories;

namespace Zelda.HUD
{
    public class HUDItemQuantity : IHUDElement
    {
        private SpriteFont font;
        private Vector2 destination;
        private int quantity;
        private Item item;

        public HUDItemQuantity(Item item, Vector2 position)
        {
            font = HUDSpriteFactory.HUDFont();
            destination = new Vector2(position.X, position.Y);
            this.item = item;
        }

        public void Update(GameTime gameTime, ILink link)
        {
            quantity = link.Inventory.GetCount(item);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, "X " + Convert.ToString(quantity), destination, Color.White);
        }
    }
}
