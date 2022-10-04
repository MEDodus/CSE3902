using Microsoft.Xna.Framework;
using Zelda.Sprites.Factories;

namespace Zelda.Projectiles.Classes
{
    public class Boomerang : IProjectile
    {
        private Vector2 baseVelocity;
        public Boomerang(Vector2 position, Vector2 direction) : base(ProjectileSpriteFactory.BoomerangSprite(), position, direction, 15, 2.5)
        {
            baseVelocity = velocity;
        }

        public override bool Update(GameTime gameTime)
        {
            // start fast, decelerate to 0 when half of the lifetime is up, then speed up again in the opposite direciton
            float multiplier = (float)((2 / lifetime) * (timeLeftUntilDelete - (lifetime / 2)));
            velocity = new Vector2(multiplier * baseVelocity.X, multiplier * baseVelocity.Y);

            return base.Update(gameTime);
        }
    }
}
