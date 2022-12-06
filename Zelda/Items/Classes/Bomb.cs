using Microsoft.Xna.Framework;
using Zelda.Projectiles;
using Zelda.Sprites.Factories;

namespace Zelda.Items.Classes
{
    public class Bomb : IItem
    {
        public Bomb(Vector2 position) : base(ItemSpriteFactory.BombSprite(), position, 8, new Zelda.ItemEffects.BombEffect())
        {

        }

        public override IProjectile CreateProjectile(Vector2 position, Vector2 facingDirection)
        {
            return new Projectiles.Classes.Bomb(position + (Settings.BLOCK_SIZE * facingDirection));
        }
    }
}
