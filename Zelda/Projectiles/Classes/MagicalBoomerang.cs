using Microsoft.Xna.Framework;
using Zelda.Sprites.Factories;

namespace Zelda.Projectiles.Classes
{
    public class MagicalBoomerang : Boomerang
    {
        public MagicalBoomerang(Vector2 position, Vector2 direction) : base(position, direction)
        {
            sprite = ProjectileSpriteFactory.MagicalBoomerangSprite();
            lifetime = 3.5;
            timeLeftUntilDelete = 3.5;
        }
    }
}
