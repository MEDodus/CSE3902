using Microsoft.Xna.Framework;
using Zelda.Projectiles;
using Zelda.Sprites.Factories;

namespace Zelda.Items.Classes
{
    public class Bomb : Item
    {
        public Bomb(Vector2 position) : base(ItemSpriteFactory.BombSprite(), position, 8, new Zelda.ItemEffects.BombEffect())
        {

        }
        
        /* Default constructor for item in inventory or not displayed in game */
        public Bomb() : base(ItemSpriteFactory.BombSprite(), new Vector2(), 8, new Zelda.ItemEffects.BombEffect())
        {

        }

        public override Projectile CreateProjectile(Vector2 position, Vector2 facingDirection)
        {
            return new Projectiles.Classes.Bomb(position + (Settings.BLOCK_SIZE * facingDirection));
        }
    }
}
