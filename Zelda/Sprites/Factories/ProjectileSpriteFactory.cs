using Zelda.Sprites.Classes;

namespace Zelda.Sprites.Factories
{
    public class ProjectileSpriteFactory : SpriteFactory
    {
        public static ISprite FireballSprite()
        {
            return new AnimatedSprite(GetTexture("fireball"), 1, 3, 9, 0.75);
        }
        public static ISprite ArrowSprite()
        {
            return ItemSpriteFactory.ArrowSprite();
        }
        public static ISprite BoomerangSprite()
        {
            return new AnimatedSprite(GetTexture("boomerang"), 1, 3, 9, 0.75);
        }
    }
}
