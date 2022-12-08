using Microsoft.Xna.Framework;
using Zelda.Projectiles.Classes;
using Zelda.Projectiles;
using Zelda.Sprites.Factories;

namespace Zelda.Items.Classes
{
    public class Bow : IItem
    {
        public Bow(Vector2 position) : base(ItemSpriteFactory.BowSprite(), position, INFINITE, new Zelda.ItemEffects.BowEffect())
        {

        }

        /* Default constructor for item in inventory or not displayed in game */
        public Bow() : base(ItemSpriteFactory.BowSprite(), new Vector2(), INFINITE, new Zelda.ItemEffects.BowEffect())
        {

        }

        public override IProjectile CreateProjectile(Vector2 position, Vector2 facingDirection)
        {
            return new Projectiles.Classes.Arrow(position, facingDirection);
        }
    }
}
