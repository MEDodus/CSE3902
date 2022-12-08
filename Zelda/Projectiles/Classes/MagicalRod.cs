using Microsoft.Xna.Framework;
using Zelda.Projectiles.Classes.Abstract;
using Zelda.Sound;
using Zelda.Sprites.Factories;

namespace Zelda.Projectiles.Classes
{
    public class MagicalRod : MultiDirectionProjectile
    {
        public MagicalRod(Vector2 position, Vector2 direction)
            : base(
                  ProjectileSpriteFactory.LeftMagicalRodSprite(),
                  ProjectileSpriteFactory.RightMagicalRodSprite(),
                  ProjectileSpriteFactory.UpMagicalRodSprite(),
                  ProjectileSpriteFactory.DownMagicalRodSprite(),
                  position, direction, 15, 0.8, ProjectileBehavior.Friendly)

        {
            SoundManager.Instance.PlayArrowSound();
        }

        public override void OnDelete()
        {
            ProjectileStorage.Add(new Vanish(position));
        }
    }
}
