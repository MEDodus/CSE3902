using Microsoft.Xna.Framework;
using Zelda.Sprites.Factories;

namespace Zelda.Projectiles.Classes
{
    public class Fireball : IProjectile
    {
        public Fireball(Vector2 position, Vector2 direction) : base(ProjectileSpriteFactory.Fireball(), position, direction, 8, 3)
        {

        }
    }
}
