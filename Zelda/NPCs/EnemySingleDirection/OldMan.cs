using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zelda.Projectiles;
using Zelda.Projectiles.Classes;
using Zelda.Sprites;
using Zelda.Sprites.Factories;

namespace Zelda.NPCs.Classes
{
    public class OldMan : INPC
    {
        public ISprite Sprite { get { return sprite; } }

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
                AppearanceCloud cloud = new AppearanceCloud(position);
                cloud.Draw(spriteBatch);
                ProjectileStorage.Add(new AppearanceCloud(position));
            }
        }
    }
}
