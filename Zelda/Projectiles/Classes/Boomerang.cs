using Microsoft.Xna.Framework;
using Zelda.Sound;
using Zelda.Sprites.Factories;

namespace Zelda.Projectiles.Classes
{
    public class Boomerang : IProjectile
    {
        private Vector2 baseVelocity;
        public Boomerang(Vector2 position, Vector2 direction, ProjectileBehavior behavior) 
            : base(ProjectileSpriteFactory.BoomerangSprite(), position, direction, 15, 1.1, behavior, false)
        {
            baseVelocity = velocity;
            SoundManager.Instance.PlayArrowBoomerangSound();
        }

        public override bool Update(GameTime gameTime)
        {
            // start fast, decelerate to 0 when half of the lifetime is up, then speed up again in the opposite direciton
            float multiplier = (float)((2 / lifetime) * (timeLeftUntilDelete - (lifetime / 2)));
            velocity = new Vector2(multiplier * baseVelocity.X, multiplier * baseVelocity.Y);

            return base.Update(gameTime);
        }

        public override void OnDelete()
        {
            //ProjectileStorage.Add(new Vanish(position)); TODO: only show when hitting a block/player/enemy
        }
    }
}
