using Microsoft.Xna.Framework;
using Zelda.Sprites.Factories;

namespace Zelda.Projectiles.Classes
{
    public class Boomerang : IProjectile
    {
        private Vector2 baseVelocity;
        public Boomerang(Vector2 position, Vector2 direction) : base(ProjectileSpriteFactory.BoomerangSprite(), position, direction, 8, 3)
        {
            baseVelocity = velocity;
        }

        protected override void UpdateAdditional(GameTime gameTime)
        {
            // start fast, decelerate to 0 when half of the lifetime is up, then speed up again in the opposite direciton
            float multiplier = (float)((2 / LIFETIME) * (timeLeftUntilDelete - (LIFETIME / 2)));
            velocity = new Vector2(multiplier * baseVelocity.X, multiplier * baseVelocity.Y);
            sprite.Update(gameTime);
        }
    }
}
