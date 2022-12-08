using Microsoft.Xna.Framework;
using Zelda.ItemEffects;
using Zelda.Projectiles;
using Zelda.Sprites.Factories;

namespace Zelda.Items.Classes
{
    public class MagicalRod : Item
    {
        public MagicalRod(Vector2 position) : base(ItemSpriteFactory.MagicalRodSprite(), position, ONE, new MagicalRodEffect())
        {

        }

        public override Projectile CreateProjectile(Vector2 position, Vector2 facingDirection)
        {
            return new Projectiles.Classes.MagicalRod(position, facingDirection);
        }
    }
}
