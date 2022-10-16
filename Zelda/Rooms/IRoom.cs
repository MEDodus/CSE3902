using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Zelda.Rooms
{
    public interface IRoom
    {
        public void Draw(SpriteBatch spriteBatch);
        public void Update(GameTime gameTime);
    }
}
