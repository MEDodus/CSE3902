using Microsoft.Xna.Framework;
using Zelda.Sprites.Factories;

namespace Zelda.Projectiles.Classes
{
    public class Vanish : IProjectile
    {
        public Vanish(Vector2 position) : base(ProjectileSpriteFactory.VanishSprite(), position, new Vector2(), 0, 0.2, ProjectileBehavior.NeutralHarmless, false)
        {

        }
    }
}
