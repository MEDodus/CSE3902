using Microsoft.Xna.Framework;
using Zelda.Projectiles.Classes;
using Zelda.Projectiles;
using Zelda.Sprites.Factories;

namespace Zelda.Items.Classes
{
    public class RedCandle : IItem
    {
        public RedCandle(Vector2 position) : base(ItemSpriteFactory.RedCandleSprite(), position, ONE, null)
        {

        }

        /* Default constructor for item in inventory or not displayed in game */
        public RedCandle() : base(ItemSpriteFactory.RedCandleSprite(), new Vector2(), ONE, null)
        {

        }

        public override IProjectile CreateProjectile(Vector2 position, Vector2 facingDirection)
        {
            return new CandleFlame(position, facingDirection);
        }
    }
}
