using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zelda.Link;

namespace Zelda.HUD
{
    public interface IHUDElement
    {
        public void Update(GameTime gameTime, ILink link);
        public void Draw(SpriteBatch spriteBatch);
    }
}
