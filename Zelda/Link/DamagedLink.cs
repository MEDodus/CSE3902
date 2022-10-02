using Microsoft.Xna.Framework.Graphics;
using Zelda.Sprites.Factories;

namespace Zelda.Link
{
    public class DamagedLink : SpriteFactory, ILink
    {
        Game1 game;
        ILink decoratedLink;
        int timer = 24;


        public DamagedLink(ILink decoratedLink, Game1 game)
        {
            this.decoratedLink = decoratedLink;
            this.game = game;
        }
        public void Update()
        {
            timer--;
            if(timer == 0)
            {
                RemoveDecorator();
            }
        }

        public void Reset()
        {

        }
        public void Draw(SpriteBatch spriteBatch)
        {

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
            decoratedLink.TakeDamage();
        }
        public void TakeDamage()
        {
            // Can't take damage while already taking damage
        }

        public void AttackUsingSward()
        {
            //using sward state
        }

        public void RemoveDecorator()
        {
            game.link = decoratedLink;
        }
    }
}
