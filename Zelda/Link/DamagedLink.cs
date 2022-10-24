using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
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
        public void TakeDamage(Game1 game)
        {
            // Can't take damage while already taking damage
        }

        public void UseItem(int itemNum)
        {
            decoratedLink.UseItem(itemNum);
        }
        
        public void CreateItem(int itemNum)
        {
            decoratedLink.CreateItem(itemNum);
        }
        public void CancelMovement()
        {
            decoratedLink.CancelMovement();
        }

        public void RemoveDecorator()
        {
            decoratedLink.Sprite.Texture = SpriteFactory.GetTexture("link2");
            game.link = decoratedLink;
        }
    }
}
