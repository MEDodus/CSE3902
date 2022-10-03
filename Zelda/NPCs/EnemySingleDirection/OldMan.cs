using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zelda.Sprites;
using Zelda.Sprites.Factories;

namespace Zelda.NPCs.Classes
{
    public class OldMan : INPC
    {
        protected ISprite sprite;
        protected Vector2 position;
        public OldMan(Vector2 startPosition)
        {
            sprite = NPCSpriteFactory.OldManSprite();
            position = startPosition;
        }

        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, position);
        }
    }
}
