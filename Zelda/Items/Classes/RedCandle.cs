using Microsoft.Xna.Framework;
using Zelda.Projectiles.Classes;
using Zelda.Projectiles;
using Zelda.Sprites.Factories;

namespace Zelda.Items.Classes
{
    public class RedCandle : Item
    {
        public RedCandle(Vector2 position) : base(ItemSpriteFactory.RedCandleSprite(), position, ONE, null)
        {

        }

        public override Projectile CreateProjectile(Vector2 position, Vector2 facingDirection)
        {
            return new CandleFlame(position, facingDirection);
        }
    }
}
