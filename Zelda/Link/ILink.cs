using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Security.Cryptography;
using Zelda.Items;
using Zelda.Projectiles;
using Zelda.Sprites;

namespace Zelda.Link
{
    public interface ILink
    {
        public ILinkState State { get; set; }
        public ISprite Sprite { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Direction { get; }
        public Health Health { get; }

        public void Reset();
        public void Update(GameTime gameTime);
        public void Draw(SpriteBatch spriteBatch);

        public void MoveUp();
        public void MoveDown();
        public void MoveLeft();
        public void MoveRight();
        public void TakeDamage(Game1 game, int damage);
        public void UseItem(int itemNum);
        public void CreateItem(int itemNum);
        public bool Equip(IItem item);
    }
}
