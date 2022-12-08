using Microsoft.Xna.Framework;
using Zelda.Projectiles;
using Zelda.Sprites.Factories;

namespace Zelda.Items.Classes
{
    public class MagicalBoomerang : Item
    {
        public MagicalBoomerang(Vector2 position) : base(ItemSpriteFactory.MagicalBoomerangSprite(), position, INFINITE, null)
        {

        }

        public override Projectile CreateProjectile(Vector2 position, Vector2 facingDirection)
        {
            return new Projectiles.Classes.MagicalBoomerang(position, facingDirection);
        }
    }
}
