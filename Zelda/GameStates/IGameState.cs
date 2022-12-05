using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Zelda.GameStates
{
    public interface IGameState
    {
        public void Update(GameTime gameTime);
        public void Draw(SpriteBatch spriteBatch);
        public void LeftClick();
        public void RightClick();
        public void Up();
        public void Down();
        public void Left();
        public void Right();

    }
}
