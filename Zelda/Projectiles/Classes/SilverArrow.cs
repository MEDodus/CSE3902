using Microsoft.Xna.Framework;
using Zelda.Projectiles.Classes.Abstract;
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
                  position, direction, 15, 0.85)
        {

        }

        public override void Delete()
        {
            ProjectileStorage.Add(new Vanish(position));
        }
    }
}
