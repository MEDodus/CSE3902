using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Zelda.Items;
using Zelda.Projectiles;
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

        Game1 game;
        ILink decoratedLink;
        int timer = 48;

        public DamagedLink(ILink decoratedLink, Game1 game)
        {
            this.decoratedLink = decoratedLink;
            this.game = game;
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
        }

        public void Reset()
        {
            decoratedLink.Reset();
            RemoveDecorator();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            decoratedLink.Draw(spriteBatch);
        }

        public void MoveUp()
        {
            // Can't move when damaged
        }
        public void MoveDown()
        {
            // Can't move when damaged
        }
        public void MoveLeft()
        {
            // Can't move when damaged
        }
        public void MoveRight()
        {
            // Can't move when damaged
        }
        public void TakeDamage(Game1 game, int damage)
        {
            // Can't take damage while already taking damage
        }

        public void UseItem(int itemNum)
        {
            // Can't use items when damaged
        }
        
        public void CreateItem(int itemNum)
        {
            // Can't create items when damaged
        }

        public bool AddToInventory(IItem item)
        {
            // Can't equip items when damaged
            return false;
        }

        public void RemoveDecorator()
        {
            decoratedLink.Sprite.Texture = SpriteFactory.GetTexture("link2");
            game.link = decoratedLink;
        }
    }
}
