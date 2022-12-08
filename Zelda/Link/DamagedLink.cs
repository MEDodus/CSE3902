using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zelda.Inventory;
using Zelda.Items;
using Zelda.Sprites;
using Zelda.Sprites.Factories;

namespace Zelda.Link
{
    public class DamagedLink : ILink
    {
        public ILinkState State { get => decoratedLink.State; set => decoratedLink.State = value; }
        public ISprite Sprite { get => decoratedLink.Sprite; set => decoratedLink.Sprite = value; }
        public Vector2 Position { get => decoratedLink.Position; set => decoratedLink.Position = value; }
        public Vector2 Direction { get => decoratedLink.Direction; }
        public Health Health { get => decoratedLink.Health; }
        public IInventory Inventory { get => decoratedLink.Inventory; }
        public int PlayerNumber { get => decoratedLink.PlayerNumber; }

        Game1 game;
        ILink decoratedLink;
        int timer = 48;
        Vector2 pushDirection;

        public DamagedLink(ILink decoratedLink, Game1 game, Vector2 pushDirection)
        {
            this.decoratedLink = decoratedLink;
            this.game = game;
            this.pushDirection = pushDirection;
        }

        public void Update(GameTime gameTime)
        {
            if (timer % 8 == 0)
            {
                decoratedLink.Sprite.Texture = SpriteFactory.GetTexture("link_hurt_1");
            }
            else if (timer % 8 == 2)
            {
                decoratedLink.Sprite.Texture = SpriteFactory.GetTexture("link_hurt_2");
            }
            else if (timer % 8 == 4)
            {
                decoratedLink.Sprite.Texture = SpriteFactory.GetTexture("link_hurt_3");
            }
            else if (timer % 8 == 6)
            {
                decoratedLink.Sprite.Texture = SpriteFactory.GetTexture("link2");
            }
            if (timer == 0)
            {
                RemoveDecorator();
            }
            timer--;
            decoratedLink.Update(gameTime);
            if(timer >= 32)
            {
                decoratedLink.Position += pushDirection;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            decoratedLink.Draw(spriteBatch);
        }
        public void Reset()
        {
            decoratedLink.Reset();
            RemoveDecorator();
        }

        public void MoveUp()
        {
            decoratedLink.MoveUp();
            
        }
        public void MoveDown()
        {
            decoratedLink.MoveDown();
        }
        public void MoveLeft()
        {
            decoratedLink.MoveLeft();
        }
        public void MoveRight()
        {
            decoratedLink.MoveRight();
        }
        public void TakeDamage(int damage, Vector2 direction)
        {
            // Can't take damage while already taking damage
        }
        public bool AddToInventory(Item item)
        {
            // Can't equip items when damaged
            return false;
        }
        public void Attack()
        {
            // Can't attack when damaged
        }
        public void AttackSecondary()
        {
            // Can't attack when damaged
        }
        public bool TryUsePrimary()
        {
            // Can't use items when damaged
            return false;
        }
        public bool TryUseSecondary()
        {
            // Can't use items when damaged
            return false;
        }
        public void RemoveDecorator()
        {
            decoratedLink.Sprite.Texture = SpriteFactory.GetTexture("link2");
            if(decoratedLink.PlayerNumber == 1)
            {
                game.Link = decoratedLink;
            } else
            {
                game.LinkCompanion = decoratedLink;
            }
        }
    }
}
