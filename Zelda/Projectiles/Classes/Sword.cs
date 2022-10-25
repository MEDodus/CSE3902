using Microsoft.Xna.Framework;
using System.Reflection.Metadata.Ecma335;
using Zelda.Projectiles.Classes.Abstract;
using Zelda.Sprites.Classes;
using Zelda.Sprites.Factories;

namespace Zelda.Projectiles.Classes
{
    public class Sword : MultiDirectionProjectile
    {
        private Vector2 baseVelocity;

        public Sword(Vector2 position, Vector2 direction, double lifetime)
            : base(
                  LinkSpriteFactory.LinkUsingSwordLeftSprite(),
                  LinkSpriteFactory.LinkUsingSwordRightSprite(),
                  LinkSpriteFactory.LinkUsingSwordUpSprite(),
                  LinkSpriteFactory.LinkUsingSwordDownSprite(),
                  position, direction, 7, lifetime)
        {
            baseVelocity = velocity;
        }

        public override bool Update(GameTime gameTime)
        {
            double time = gameTime.ElapsedGameTime.TotalSeconds;
            timeLeftUntilDelete -= time;
            if (timeLeftUntilDelete <= 0)
            {
                return true;
            }

            //position += new Vector2((float)(velocity.X * time), (float)(velocity.Y * time));
            this.sprite.Update(gameTime);
            SwordSprite sprite = (SwordSprite)this.Sprite;
            return sprite.AnimationFinished();
        }
    }
}
