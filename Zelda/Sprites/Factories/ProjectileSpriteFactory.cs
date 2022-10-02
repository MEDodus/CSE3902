using Zelda.Sprites.Classes;

namespace Zelda.Sprites.Factories
{
    public class ProjectileSpriteFactory : SpriteFactory
    {
        public static ISprite Fireball()
        {
            return new AnimatedSprite(GetTexture("fireball"), 1, 3, 9, 0.75);
        }
    }
}
