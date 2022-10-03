using Microsoft.Xna.Framework;
using Zelda.Sprites.Factories;

namespace Zelda.Projectiles.Classes
{
    public class Arrow : IProjectile
    {
        public Arrow(Vector2 position, Vector2 direction) : base(ProjectileSpriteFactory.ArrowSprite(), position, direction, 8, 1.5)
        {

        }
    }
}
