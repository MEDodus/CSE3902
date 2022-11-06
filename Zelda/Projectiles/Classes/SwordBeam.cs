using Microsoft.Xna.Framework;
using Zelda.Projectiles.Classes.Abstract;
using Zelda.Sound;
using Zelda.Sprites.Factories;

namespace Zelda.Projectiles.Classes
{
    public class SwordBeam : MultiDirectionProjectile
    {
        public SwordBeam(Vector2 position, Vector2 direction)
            : base(
                  ProjectileSpriteFactory.LeftSwordBeamSprite(),
                  ProjectileSpriteFactory.RightSwordBeamSprite(),
                  ProjectileSpriteFactory.UpSwordBeamSprite(),
                  ProjectileSpriteFactory.DownSwordBeamSprite(),
                  position, direction, 15, 0.6, ProjectileBehavior.Friendly)
        {
            SoundManager.Instance.PlaySwardCombinedSound();
        }

        public override void OnDelete()
        {
            ProjectileStorage.Add(new Vanish(position));
        }
    }
}
