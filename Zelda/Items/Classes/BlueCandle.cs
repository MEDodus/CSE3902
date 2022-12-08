using Microsoft.Xna.Framework;
using Zelda.Projectiles;
using Zelda.Sprites.Factories;

namespace Zelda.Items.Classes
{
    public class BlueCandle : Item
    {
        public BlueCandle(Vector2 position) : base(ItemSpriteFactory.BlueCandleSprite(), position, INFINITE, new Zelda.ItemEffects.BlueCandleEffect())
        {

        }

        public override Projectile CreateProjectile(Vector2 position, Vector2 facingDirection)
        {
            return new Projectiles.Classes.CandleFlame(position, facingDirection);
        }
    }
}
