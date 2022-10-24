using Microsoft.Xna.Framework;
using Zelda.Sprites.Factories;

namespace Zelda.Projectiles.Classes
{
    public class MagicalBoomerang : Boomerang
    {
        public MagicalBoomerang(Vector2 position, Vector2 direction) : base(position, direction, ProjectileBehavior.Friendly)
        {
            sprite = ProjectileSpriteFactory.MagicalBoomerangSprite();
            lifetime = 2.5;
            timeLeftUntilDelete = lifetime;
        }
    }
}
