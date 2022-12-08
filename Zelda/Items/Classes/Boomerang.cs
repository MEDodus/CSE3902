using Microsoft.Xna.Framework;
using Zelda.Projectiles;
using Zelda.Sprites.Factories;

namespace Zelda.Items.Classes
{
    public class Boomerang : IItem
    {
        public Boomerang(Vector2 position) : base(ItemSpriteFactory.BoomerangSprite(), position, INFINITE, new Zelda.ItemEffects.BoomerangEffect())
        {

        }

        /* Default constructor for item in inventory or not displayed in game */
        public Boomerang() : base(ItemSpriteFactory.BoomerangSprite(), new Vector2(), INFINITE, new Zelda.ItemEffects.BoomerangEffect())
        {

        }

        public override IProjectile CreateProjectile(Vector2 position, Vector2 facingDirection)
        {
            return new Projectiles.Classes.Boomerang(position, facingDirection, ProjectileBehavior.Friendly);
        }
    }
}
