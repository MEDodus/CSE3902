using Zelda.Sprites.Classes;

namespace Zelda.Sprites.Factories
{
    public class NPCSpriteFactory : SpriteFactory
    {
        // Neutral
        public static ISprite OldManSprite()
        {
            return new Sprite(GetTexture("old_man"), 1);
        }

        // Enemies (single state)
        public static ISprite BatSprite()
        {
            return new AnimatedSprite(GetTexture("bat"), 1, 2, 8, 1);
        }

        public static ISprite GelSprite()
        {
            return new AnimatedSprite(GetTexture("gel"), 1, 2, 8, 0.6);
        }

        public static ISprite SkeletonSprite()
        {
            return new AnimatedSprite(GetTexture("skeleton"), 1, 2, 8, 1);
        }

        public static ISprite SpikeCross()
        {
            return new Sprite(GetTexture("spike_cross"), 1);
        }

        public static ISprite WallmasterSprite()
        {
            return new AnimatedSprite(GetTexture("hand"), 1, 2, 8, 1);
        }

        public static ISprite ZolSprite()
        {
            return new AnimatedSprite(GetTexture("zol"), 1, 2, 8, 0.9);
        }

        // Dragon
        private static int DRAGON_ROW_HEIGHT = 256;
        private static int DRAGON_COLUMN_WIDTH = 192;
        private static int DRAGON_FPS = 3;
        private static double DRAGON_SIZE_IN_BLOCKS = 2.5;
        public static ISprite NonAttackingDragonSprite()
        {
            return new AnimatedSprite(GetTexture("dragon"), 384, 0, 1, 2, DRAGON_ROW_HEIGHT, DRAGON_COLUMN_WIDTH, DRAGON_FPS, DRAGON_SIZE_IN_BLOCKS);
        }

        public static ISprite AttackingDragonSprite()
        {
            return new AnimatedSprite(GetTexture("dragon"), 0, 0, 1, 2, DRAGON_ROW_HEIGHT, DRAGON_COLUMN_WIDTH, DRAGON_FPS, DRAGON_SIZE_IN_BLOCKS);
        }
    }
}
