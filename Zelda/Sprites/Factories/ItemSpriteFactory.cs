using Zelda.Sprites.Classes;

namespace Zelda.Sprites.Factories
{
    public class ItemSpriteFactory : SpriteFactory
    {
        public static ISprite ArrowSprite()
        {
            return new Sprite(GetTexture("arrow"), 0, 0, 40, 128, 1);
        }

        public static ISprite BlueCandleSprite()
        {
            return new Sprite(GetTexture("blue_candle"), 1);
        }

        public static ISprite BluePotionSprite()
        {
            return new Sprite(GetTexture("blue_potion"), 1);
        }

        public static ISprite BlueRingSprite()
        {
            return new Sprite(GetTexture("blue_ring"), 1);
        }

        public static ISprite BombSprite()
        {
            return new Sprite(GetTexture("bomb"), 0.85);
        }

        public static ISprite BookOfMagicSprite()
        {
            return new Sprite(GetTexture("book_of_magic"), 1);
        }

        public static ISprite BoomerangSprite()
        {
            return new Sprite(GetTexture("boomerang"), 0, 0, 96, 96, 0.5);
        }

        public static ISprite BowSprite()
        {
            return new Sprite(GetTexture("bow"), 1);
        }

        public static ISprite ClockSprite()
        {
            return new Sprite(GetTexture("clock"), 1);
        }

        public static ISprite CompassSprite()
        {
            return new Sprite(GetTexture("compass"), 0.8);
        }

        public static ISprite FairySprite()
        {
            return new AnimatedSprite(GetTexture("fairy"), 1, 2, 4, 1);
        }

        public static ISprite FiveRupiesSprite()
        {
            return new Sprite(GetTexture("five_rupies"), 1);
        }

        public static ISprite FoodSprite()
        {
            return new Sprite(GetTexture("food"), 1);
        }

        public static ISprite HeartSprite()
        {
            return new AnimatedSprite(GetTexture("heart"), 1, 2, 4, 1);
        }

        public static ISprite HeartContainerSprite()
        {
            return new Sprite(GetTexture("heart_container"), 0.8);
        }

        public static ISprite KeySprite()
        {
            return new Sprite(GetTexture("key"), 0.8);
        }

        public static ISprite LetterSprite()
        {
            return new Sprite(GetTexture("letter"), 1);
        }

        public static ISprite MagicalBoomerangSprite()
        {
            return new Sprite(GetTexture("magical_boomerang"), 0, 0, 96, 96, 0.5);
        }

        public static ISprite MagicalKeySprite()
        {
            return new Sprite(GetTexture("magical_key"), 1);
        }

        public static ISprite MagicalRodSprite()
        {
            return new Sprite(GetTexture("magical_rod"), 1);
        }

        public static ISprite MagicalShieldSprite()
        {
            return new Sprite(GetTexture("magical_shield"), 1);
        }

        public static ISprite MapSprite()
        {
            return new Sprite(GetTexture("map"), 0.8);
        }

        public static ISprite PowerBraceletSprite()
        {
            return new Sprite(GetTexture("power_bracelet"), 1);
        }

        public static ISprite RaftSprite()
        {
            return new Sprite(GetTexture("raft"), 1);
        }

        public static ISprite RecorderSprite()
        {
            return new Sprite(GetTexture("recorder"), 1);
        }

        public static ISprite RedCandleSprite()
        {
            return new Sprite(GetTexture("red_candle"), 1);
        }

        public static ISprite RedPotionSprite()
        {
            return new Sprite(GetTexture("red_potion"), 1);
        }

        public static ISprite RedRingSprite()
        {
            return new Sprite(GetTexture("red_ring"), 1);
        }

        public static ISprite RupySprite()
        {
            return new AnimatedSprite(GetTexture("rupy"), 1, 2, 4, 1);
        }

        public static ISprite SilverArrowSprite()
        {
            return new Sprite(GetTexture("silver_arrow"), 0, 0, 40, 128, 1);
        }

        public static ISprite StepladderSprite()
        {
            return new Sprite(GetTexture("stepladder"), 1);
        }

        public static ISprite SwordSprite()
        {
            return new Sprite(GetTexture("sword"), 1);
        }

        public static ISprite TriforceSprite()
        {
            return new AnimatedSprite(GetTexture("triforce"), 1, 2, 4, 0.6);
        }

        public static ISprite WhiteSwordSprite()
        {
            return new Sprite(GetTexture("white_sword"), 1);
        }
    }
}
