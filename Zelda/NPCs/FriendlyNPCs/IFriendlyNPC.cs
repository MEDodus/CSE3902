using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zelda.Sprites;

namespace Zelda.NPCs
{
    public interface IFriendlyNPC
    {
        public ISprite Sprite { get; }
        public Vector2 Position { get; set; }

        public void Update(Game1 game, GameTime gameTime);

        public void Draw(SpriteBatch spriteBatch);
    }
}

