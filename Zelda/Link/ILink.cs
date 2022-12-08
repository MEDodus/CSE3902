using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zelda.Inventory;
using Zelda.Items;
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
        public IInventory Inventory { get; }
        public int PlayerNumber { get; }
        
        public void Update(GameTime gameTime);
        public void Draw(SpriteBatch spriteBatch);
        public void Reset();

        public void MoveUp();
        public void MoveDown();
        public void MoveLeft();
        public void MoveRight();
        public void TakeDamage(int damage, Vector2 direction);
        public bool AddToInventory(IItem item);
        public void Attack();
        public void AttackSecondary();
        public bool TryUsePrimary();
        public bool TryUseSecondary();
    }
}
