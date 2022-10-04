using Microsoft.Xna.Framework;
using Zelda.Projectiles.Classes.Abstract;
using Zelda.Sprites.Factories;

namespace Zelda.Projectiles.Classes
{
    public class Arrow : MultiDirectionProjectile
    {
        public Arrow(Vector2 position, Vector2 direction) 
            : base(
                  ProjectileSpriteFactory.LeftArrowSprite(),
                  ProjectileSpriteFactory.RightArrowSprite(),
                  ProjectileSpriteFactory.UpArrowSprite(),
                  ProjectileSpriteFactory.DownArrowSprite(),
                  position, direction, 15, 0.5)
        {

        }

        public override void Delete()
        {
            ProjectileStorage.Add(new Vanish(position));
        }
    }
}
