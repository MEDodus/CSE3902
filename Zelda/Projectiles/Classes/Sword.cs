using Microsoft.Xna.Framework;
using Zelda.Projectiles.Classes.Abstract;
using Zelda.Sprites.Factories;

namespace Zelda.Projectiles.Classes
{
    public class Sword : MultiDirectionProjectile
    {
        private Vector2 baseVelocity;

        public Sword(Vector2 position, Vector2 direction, double lifetime)
            : base(
                  ProjectileSpriteFactory.LeftSwordSprite(),
                  ProjectileSpriteFactory.RightSwordSprite(),
                  ProjectileSpriteFactory.UpSwordSprite(),
                  ProjectileSpriteFactory.DownSwordSprite(),
                  position, direction, 7, lifetime)
        {
            baseVelocity = velocity;
        }

        public override bool Update(GameTime gameTime)
        {
            // move in original direction until half of the liftime is up, then return towards link
            int multiplier = timeLeftUntilDelete > lifetime / 2.0 ? 1 : -1;
            velocity = baseVelocity * multiplier;
            return base.Update(gameTime);
        }
    }
}
