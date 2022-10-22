using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Security.Cryptography;
using Zelda.Sprites;

namespace Zelda.Link
{
    public interface ILink
    {
        public ILinkState State { get; set; }
        public ISprite Sprite { get; set; }
        public Vector2 Position { get; set; }

        public void Reset();
        public void Update(GameTime gameTime);
        public void Draw(SpriteBatch spriteBatch);

        public void MoveUp();
        public void MoveDown();
        public void MoveLeft();
        public void MoveRight();
        public void TakeDamage(Game1 game);
        public void UseItem(int itemNum);
        public void CreateItem(int itemNum);
    }
}
