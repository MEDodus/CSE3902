using Microsoft.Xna.Framework;
using Zelda.Sprites.Factories;

namespace Zelda.Projectiles.Classes
{
    public class AppearanceCloud : Projectile
    {
        public AppearanceCloud(Vector2 position) : base(ProjectileSpriteFactory.AppearanceCloudSprite(), position, new Vector2(), 0, 0.5, ProjectileBehavior.NeutralHarmless, false)
        {

        }
    }
}
