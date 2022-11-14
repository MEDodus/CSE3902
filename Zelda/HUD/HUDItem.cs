using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zelda.Items;
using Zelda.Sprites;
using Zelda.Link;
using Zelda.Sprites.Factories;
using Zelda.Utilities;

namespace Zelda.HUD
{
    public class HUDItem : IHUDElement
    {
        private ISprite sprite;
        private Vector2 destination;
        private int quantity;
        //private string text;
        private IItem item;
        public HUDItem(IItem item, Vector2 position)
        {
            sprite = item.Sprite;
            destination = new Vector2(position.X, position.Y);
            //this.text = text;
            this.item = item;
        }
        public void Update(GameTime gameTime, ILink link)
        {
            //TODO: LINK CURRENT ITEM??
            //this.quantity = link.Inventory.GetCount(this.item);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, destination, Color.White);
        }
    }
}
