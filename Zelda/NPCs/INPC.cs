using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zelda.Items;
using Zelda.Sprites;

namespace Zelda.NPCs
{
    public interface INPC
    {
        public enum Group { A, B, C, D, X };
        public bool Dead { get; }
        public ISprite Sprite { get; }
        public int Damage { get; }

        public void Update(GameTime gameTime);
        public void Draw(SpriteBatch spriteBatch);
        public IItem DropItem();
    }
}
