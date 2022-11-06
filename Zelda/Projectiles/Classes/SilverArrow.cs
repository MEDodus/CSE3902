using Microsoft.Xna.Framework;
using Zelda.Projectiles.Classes.Abstract;
using Zelda.Sound;
using Zelda.Sprites.Factories;

namespace Zelda.Projectiles.Classes
{
    public class SilverArrow : MultiDirectionProjectile
    {
        public SilverArrow(Vector2 position, Vector2 direction)
            : base(
                  ProjectileSpriteFactory.LeftSilverArrowSprite(),
                  ProjectileSpriteFactory.RightSilverArrowSprite(),
                  ProjectileSpriteFactory.UpSilverArrowSprite(),
                  ProjectileSpriteFactory.DownSilverArrowSprite(),
                  position, direction, 15, 0.7, ProjectileBehavior.Friendly)
        {
            SoundManager.Instance.PlayArrowBoomerangSound();
        }

        public override void OnDelete()
        {
            ProjectileStorage.Add(new Vanish(position));
        }
    }
}
