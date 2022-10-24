using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Windows.Markup;
using Zelda.Sprites;

namespace Zelda.Projectiles
{
    public enum ProjectileBehavior { Friendly, Enemy, NeutralHarmless, NeutralHarmful }

    public abstract class IProjectile
    {
        protected ISprite sprite;
        protected Vector2 position;
        protected Vector2 velocity; // pixels per second
        protected double lifetime;
        protected double timeLeftUntilDelete;
        protected ProjectileBehavior behavior;
        
        public ISprite Sprite { get { return sprite; } }
        public Vector2 Velocity { get { return velocity; } }
        public ProjectileBehavior Behavior { get { return behavior; } }

        public IProjectile(ISprite sprite, Vector2 position, Vector2 direction, double blocksPerSecondSpeed, double lifetime, ProjectileBehavior behavior)
        {
            this.sprite = sprite;
            this.position = position;
            if (direction.Length() > 0)
            {
                direction.Normalize();
            }
            double pixelsPerSecondSpeed = blocksPerSecondSpeed * Settings.BLOCK_SIZE;
            velocity = new Vector2((float)(direction.X * pixelsPerSecondSpeed), (float)(direction.Y * pixelsPerSecondSpeed));
            this.lifetime = lifetime;
            timeLeftUntilDelete = lifetime;
            this.behavior = behavior;
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
            sprite.Update(gameTime);
            return false;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, position);
        }

        public virtual void Delete()
        {
            timeLeftUntilDelete = 0;
            // put any deletion effects here (bomb explosions, disappearing clouds, etc.)
        }
    }
}
