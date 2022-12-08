using Microsoft.Xna.Framework;
using Zelda.ItemEffects;
using Zelda.Projectiles;
using Zelda.Sprites.Factories;

namespace Zelda.Items.Classes
{
    public class Arrow : IItem
    {
        public Arrow(Vector2 position) : base(ItemSpriteFactory.ArrowSprite(), position, INFINITE, null)
        {

        }

        /* Default constructor for item in inventory or not displayed in game */
        public Arrow() : base(ItemSpriteFactory.ArrowSprite(), new Vector2(), INFINITE, null)
        {

        }

        public override IProjectile CreateProjectile(Vector2 position, Vector2 facingDirection)
        {
            return new Projectiles.Classes.Arrow(position, facingDirection);
        }
    }
}
