using Microsoft.Xna.Framework;
using Zelda.Sprites.Factories;

namespace Zelda.Projectiles.Classes
{
    public class Boomerang : IProjectile
    {
        public Boomerang(Vector2 position, Vector2 direction) : base(ProjectileSpriteFactory.Boomerang(), position, direction, 8, 3)
        {

        }
    }
}
