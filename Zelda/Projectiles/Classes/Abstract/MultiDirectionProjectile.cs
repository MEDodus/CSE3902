using Microsoft.Xna.Framework;
using Zelda.Sprites;

namespace Zelda.Projectiles.Classes.Abstract
{
    public abstract class MultiDirectionProjectile : IProjectile
    {
        public MultiDirectionProjectile(ISprite leftSprite, ISprite rightSprite, ISprite upSprite, ISprite downSprite, Vector2 position, Vector2 direction,
            double blocksPerSecondSpeed, double lifetime, ProjectileBehavior behavior)
            : base(null, position, direction, blocksPerSecondSpeed, lifetime, behavior)
        {
            direction.Normalize();
            if (direction.Equals(new Vector2(-1, 0)))
            {
                sprite = leftSprite;
            }
            else if (direction.Equals(new Vector2(1, 0)))
            {
                sprite = rightSprite;
            }
            else if (direction.Equals(new Vector2(0, -1)))
            {
                sprite = upSprite;
            }
            else
            {
                sprite = downSprite;
            }
        }
    }
}
