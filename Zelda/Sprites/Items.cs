using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Zelda.Sprites
{
    public class Items
    {
        private readonly int itemSize = 35;
        private ISprite[] items;

        public Items()
        {
            items = new ISprite[itemSize];
        }

        public void InitItems()
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            foreach (ISprite item in items)
            {
                spriteBatch.Draw(item.Texture, item.DestinationLocation, item.SourceLocation, Color.White);
            }
            spriteBatch.End();
        }
    }
}
