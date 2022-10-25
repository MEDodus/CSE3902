using System.Data;
using Zelda.Sprites.Classes;

namespace Zelda.Sprites.Factories
{
    public class HUDSpriteFactory : SpriteFactory
    {
        public static ISprite FullHeart()
        {
            return new Sprite(GetTexture("heart_display"), 0, 0, 40, 128, 1);
        }
        public static ISprite HalfHeart()
        {
            return new Sprite(GetTexture("heart_display"), 0, 0, 40, 128, 1);
        }
        public static ISprite EmptyHeart()
        {
            return new Sprite(GetTexture("heart_display"), 0, 0, 40, 128, 1);
        }
    }
}
