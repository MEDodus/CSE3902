using Zelda.Sprites.Classes;

namespace Zelda.Sprites.Factories
{
    public class ProjectileSpriteFactory : SpriteFactory
    {
        // Simple
        public static ISprite FireballSprite()
        {
            return new AnimatedSprite(GetTexture("fireball"), 1, 3, 9, 0.75);
        }

        public static ISprite BoomerangSprite()
        {
            return new AnimatedSprite(GetTexture("boomerang"), 1, 3, 9, 0.5);
        }

        public static ISprite MagicalBoomerangSprite()
        {
            return new AnimatedSprite(GetTexture("magical_boomerang"), 1, 3, 9, 0.5);
        }

        public static ISprite BombSprite()
        {
            return ItemSpriteFactory.BombSprite();
        }

        public static ISprite CandleFlameSprite()
        {
            return ItemSpriteFactory.FireSprite();
        }

        // Effects
        public static ISprite ExplosionSprite()
        {
            return new AnimatedSprite(GetTexture("bomb_explosion"), 1, 3, 6, 1);
        }

        public static ISprite VanishSprite()
        {
            return new Sprite(GetTexture("projectile_vanish"), 0.6);
        }

        public static ISprite AppearanceCloudSprite()
        {
            return ExplosionSprite();
        }

        public static ISprite DeathExplosionSprite()
        {
            return new AnimatedSprite(GetTexture("death_explosion"), 1, 4, 8, 1);
        }

        // Arrow
        private static readonly int ARROW_WIDTH = 40;
        private static readonly int ARROW_HEIGHT = 128;
        private static readonly int ARROW_SIZE_IN_BLOCKS = 1;
        public static ISprite UpArrowSprite()
        {
            return new Sprite(GetTexture("arrow"), 0, 0, ARROW_WIDTH, ARROW_HEIGHT, ARROW_SIZE_IN_BLOCKS);
        }

        public static ISprite DownArrowSprite()
        {
            return new Sprite(GetTexture("arrow"), ARROW_WIDTH, 0, ARROW_WIDTH, ARROW_HEIGHT, ARROW_SIZE_IN_BLOCKS);
        }

        public static ISprite RightArrowSprite()
        {
            return new Sprite(GetTexture("arrow"), 2 * ARROW_WIDTH, 48, ARROW_HEIGHT, ARROW_WIDTH, ARROW_SIZE_IN_BLOCKS);
        }

        public static ISprite LeftArrowSprite()
        {
            return new Sprite(GetTexture("arrow"), 2 * ARROW_WIDTH, 88, ARROW_HEIGHT, ARROW_WIDTH, ARROW_SIZE_IN_BLOCKS);
        }

        // Silver Arrow
        public static ISprite UpSilverArrowSprite()
        {
            return new Sprite(GetTexture("silver_arrow"), 0, 0, ARROW_WIDTH, ARROW_HEIGHT, ARROW_SIZE_IN_BLOCKS);
        }

        public static ISprite DownSilverArrowSprite()
        {
            return new Sprite(GetTexture("silver_arrow"), ARROW_WIDTH, 0, ARROW_WIDTH, ARROW_HEIGHT, ARROW_SIZE_IN_BLOCKS);
        }

        public static ISprite RightSilverArrowSprite()
        {
            return new Sprite(GetTexture("silver_arrow"), 2 * ARROW_WIDTH, 48, ARROW_HEIGHT, ARROW_WIDTH, ARROW_SIZE_IN_BLOCKS);
        }

        public static ISprite LeftSilverArrowSprite()
        {
            return new Sprite(GetTexture("silver_arrow"), 2 * ARROW_WIDTH, 88, ARROW_HEIGHT, ARROW_WIDTH, ARROW_SIZE_IN_BLOCKS);
        }

        // Sword beam
        private static int SWORD_BEAM_WIDTH = 56;
        private static int SWORD_BEAM_HEIGHT = 128;
        private static int SWORD_BEAM_FPS = 10;
        private static int SWORD_BEAM_SIZE_IN_BLOCKS = 1;
        public static ISprite UpSwordBeamSprite()
        {
            return new AnimatedSprite(GetTexture("sword_beam"), 0, 0, 1, 2, SWORD_BEAM_HEIGHT, SWORD_BEAM_WIDTH, SWORD_BEAM_FPS, SWORD_BEAM_SIZE_IN_BLOCKS);
        }

        public static ISprite DownSwordBeamSprite()
        {
            return new AnimatedSprite(GetTexture("sword_beam"), 2 * SWORD_BEAM_WIDTH, 0, 1, 2, SWORD_BEAM_HEIGHT, SWORD_BEAM_WIDTH, SWORD_BEAM_FPS, SWORD_BEAM_SIZE_IN_BLOCKS);
        }

        public static ISprite RightSwordBeamSprite()
        {
            return new AnimatedSprite(GetTexture("sword_beam"), 4 * SWORD_BEAM_WIDTH, 0, 2, 1, SWORD_BEAM_WIDTH, SWORD_BEAM_HEIGHT, SWORD_BEAM_FPS, SWORD_BEAM_SIZE_IN_BLOCKS);
        }

        public static ISprite LeftSwordBeamSprite()
        {
            return new AnimatedSprite(GetTexture("sword_beam"), 4 * SWORD_BEAM_WIDTH + SWORD_BEAM_HEIGHT, 0, 2, 1, SWORD_BEAM_WIDTH, SWORD_BEAM_HEIGHT, SWORD_BEAM_FPS,
                SWORD_BEAM_SIZE_IN_BLOCKS);
        }

    }
}
