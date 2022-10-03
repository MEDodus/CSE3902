using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zelda.Sprites;

namespace Zelda.Projectiles
{
    public abstract class IProjectile
    {
        protected ISprite sprite;
        protected Vector2 position;
        protected Vector2 velocity; // pixels per second
        protected readonly double LIFETIME;
        protected double timeLeftUntilDelete;

        public IProjectile(ISprite sprite, Vector2 position, Vector2 direction, double blocksPerSecondSpeed, double lifetime)
        {
            this.sprite = sprite;
            this.position = position;
            direction.Normalize();
            double pixelsPerSecondSpeed = blocksPerSecondSpeed * Settings.BLOCK_SIZE;
            velocity = new Vector2((float)(direction.X * pixelsPerSecondSpeed), (float)(direction.Y * pixelsPerSecondSpeed));
            LIFETIME = lifetime;
            timeLeftUntilDelete = lifetime;
        }

        protected virtual void UpdateAdditional(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }

        // Returns whether the projectile should be deleted
        public virtual bool Update(GameTime gameTime)
        {
            double time = gameTime.ElapsedGameTime.TotalSeconds;

            timeLeftUntilDelete -= time;
            if (timeLeftUntilDelete <= 0)
            {
                return true;
            }

            position += new Vector2((float)(velocity.X * time), (float)(velocity.Y * time));
            UpdateAdditional(gameTime);
            return false;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, position);
        }

        protected virtual void Delete()
        {
            // TODO: deletion effects (clouds)
        }
    }
}
