using Microsoft.Xna.Framework;
using Zelda.Projectiles.Classes;
using Zelda.Projectiles;
using Zelda.Sprites.Factories;

namespace Zelda.Items.Classes
{
    public class Bow : Item
    {
        public Bow(Vector2 position) : base(ItemSpriteFactory.BowSprite(), position, INFINITE, new Zelda.ItemEffects.BowEffect())
        {

        }

        public override Projectile CreateProjectile(Vector2 position, Vector2 facingDirection)
        {
            return new Projectiles.Classes.Arrow(position, facingDirection);
        }
    }
}
