using Microsoft.Xna.Framework.Graphics;
using Zelda.Sprites.Factories;

namespace Zelda.Link
{
    public class DamagedLink : SpriteFactory, ILink
    {

        Game1 game;
        ILink decoratedLink;
        int timer = 48;


        public DamagedLink(ILink decoratedLink, Game1 game)
        {
            this.decoratedLink = decoratedLink;
            this.game = game;
        }
        public void Update()
        {
            if (timer % 8 == 0)
            {
                decoratedLink.Texture = GetTexture("Link_hurt1");
            }
            else if (timer % 8 == 2)
            {
                decoratedLink.Texture = GetTexture("Link_hurt2");
            }
            else if (timer % 8 == 4)
            {
                decoratedLink.Texture = GetTexture("Link_hurt3");
            }
            else if (timer % 8 == 6)
            {
                decoratedLink.Texture = GetTexture("Link");
            }
            if (timer == 0)
            {
                RemoveDecorator();
            }
            timer--;
            decoratedLink.Update();
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
        public void Attack()
        {
            decoratedLink.Attack();
        }
        public void UseItem()
        {
            decoratedLink.UseItem();
        }
        public void TakeDamage(Game1 game)
        {
            // Can't take damage while already taking damage
        }

        public void AttackUsingSward()
        {
            //using sward state
        }

        public void RemoveDecorator()
        {
            decoratedLink.Texture = GetTexture("Link");
            game.link = decoratedLink;
        }
    }
}
