using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zelda.Projectiles.Classes;
using Zelda.Projectiles;
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

        bool appeared = false;
        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, position);
            if (!appeared)
            {
                appeared = true;
                ProjectileStorage.Add(new AppearanceCloud(position));
            }
            sprite.Draw(spriteBatch, position);
        }
    }
}
