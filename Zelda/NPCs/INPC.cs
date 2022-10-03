using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zelda.Sprites;

namespace Zelda.NPCs
{
    public interface INPC
    {
        public void Update(GameTime gameTime);

        public void Draw(SpriteBatch spriteBatch);
    }
}
