using Microsoft.Xna.Framework.Graphics;
using Zelda.Sprites.Classes;

namespace Zelda.Sprites.Factories
{
    public class MenuSpriteFactory : SpriteFactory
    {
        public static ISprite TitleScreenSprite()
        {
            return new AnimatedSprite(GetTexture("title_screen"), 6, 1, 10, 10);
        }

        public static SpriteFont MenuFont()
        {
            return content.Load<SpriteFont>("spriteFonts\\MenuFont");
        }

        public static ISprite MenuButtonSprite()
        {
            return new Sprite(GetTexture("menu_button"));
        }

        public static ISprite BackButtonSprite()
        {
            return new Sprite(GetTexture("back_arrow"));
        }

        public static ISprite AchievementSprite()
        {
            return new Sprite(GetTexture("achievement"), 8);
        }

        public static SpriteFont AchievementFont()
        {
            return content.Load<SpriteFont>("spriteFonts\\AchievementFont");
        }
    }
}
