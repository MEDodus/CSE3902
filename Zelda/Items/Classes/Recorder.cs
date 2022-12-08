using Microsoft.Xna.Framework;
using Zelda.ItemEffects;
using Zelda.Projectiles;
using Zelda.Sprites.Factories;

namespace Zelda.Items.Classes
{
    public class Recorder : Item
    {
        public Recorder(Vector2 position) : base(ItemSpriteFactory.RecorderSprite(), position, ONE, new RecorderEffect())
        {

        }

        public override Projectile CreateProjectile(Vector2 position, Vector2 facingDirection)
        {
            return new Projectiles.Classes.MusicNote(position, facingDirection);
        }
    }
}
