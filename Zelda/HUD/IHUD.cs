using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zelda.Link;

namespace Zelda.HUD
{
    internal interface IHUD
    {
        public void Update(GameTime gameTime, ILink link);
        public void Draw(SpriteBatch spriteBatch);
    }
}
