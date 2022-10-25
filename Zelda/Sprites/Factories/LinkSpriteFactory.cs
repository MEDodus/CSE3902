using Microsoft.Xna.Framework.Graphics;
using Zelda.Sprites.Classes;

namespace Zelda.Sprites.Factories
{
    public class LinkSpriteFactory : SpriteFactory
    {
        private static readonly string FILE_NAME = "link2";
        private static readonly string FILE_NAME_2 = "Link";
        private static readonly double SIZE_IN_BLOCKS = 1;
        private static readonly int CELL_SIZE = 16;
        private static readonly int FPS = 6;

        // Idle
        public static ISprite LinkFacingDownSprite()
        {
            return new Sprite(GetTexture(FILE_NAME), 0, 0, CELL_SIZE, CELL_SIZE, SIZE_IN_BLOCKS);
        }

        public static ISprite LinkFacingLeftSprite()
        {
            return new Sprite(GetTexture(FILE_NAME), 3 * CELL_SIZE, CELL_SIZE + 1, CELL_SIZE, CELL_SIZE, SIZE_IN_BLOCKS);
        }

        public static ISprite LinkFacingRightSprite()
        {
            return new Sprite(GetTexture(FILE_NAME), 3 * CELL_SIZE, 0, CELL_SIZE, CELL_SIZE, SIZE_IN_BLOCKS);
        }

        public static ISprite LinkFacingUpSprite()
        {
            return new Sprite(GetTexture(FILE_NAME), 0, CELL_SIZE, CELL_SIZE, CELL_SIZE, SIZE_IN_BLOCKS);
        }

        // Moving
        public static ISprite LinkMovingDownSprite()
        {
            return new AnimatedSprite(GetTexture(FILE_NAME), 0, 0, 1, 2, CELL_SIZE, CELL_SIZE, FPS, SIZE_IN_BLOCKS);
        }

        public static ISprite LinkMovingLeftSprite()
        {
            return new AnimatedSprite(GetTexture(FILE_NAME), 2 * CELL_SIZE, CELL_SIZE, 1, 2, CELL_SIZE, CELL_SIZE, FPS, SIZE_IN_BLOCKS);
        }

        public static ISprite LinkMovingRightSprite()
        {
            return new AnimatedSprite(GetTexture(FILE_NAME), 2 * CELL_SIZE, 0, 1, 2, CELL_SIZE, CELL_SIZE, FPS, SIZE_IN_BLOCKS);
        }

        public static ISprite LinkMovingUpSprite()
        {
            return new AnimatedSprite(GetTexture(FILE_NAME), 0, CELL_SIZE, 1, 2, CELL_SIZE, CELL_SIZE, FPS, SIZE_IN_BLOCKS);
        }

        // Using item
        public static ISprite LinkUsingItemDownSprite()
        {
            return new Sprite(GetTexture(FILE_NAME), 0, 2 * CELL_SIZE, CELL_SIZE, CELL_SIZE, SIZE_IN_BLOCKS);
        }

        public static ISprite LinkUsingItemLeftSprite()
        {
            return new Sprite(GetTexture(FILE_NAME), 3 * CELL_SIZE, 2 * CELL_SIZE, CELL_SIZE, CELL_SIZE, SIZE_IN_BLOCKS);
        }

        public static ISprite LinkUsingItemRightSprite()
        {
            return new Sprite(GetTexture(FILE_NAME), CELL_SIZE, 2 * CELL_SIZE, CELL_SIZE, CELL_SIZE, SIZE_IN_BLOCKS);
        }

        public static ISprite LinkUsingItemUpSprite()
        {
            return new Sprite(GetTexture(FILE_NAME), 2 * CELL_SIZE, 2 * CELL_SIZE, CELL_SIZE, CELL_SIZE, SIZE_IN_BLOCKS);
        }

        public static ISprite LinkUsingSwordDownSprite()
        {
            return new SwordSprite(GetTexture(FILE_NAME_2), 6, SIZE_IN_BLOCKS, 0);
        }

        public static ISprite LinkUsingSwordLeftSprite()
        {
            return new SwordSprite(GetTexture(FILE_NAME_2), 6, SIZE_IN_BLOCKS, 1);
        }

        public static ISprite LinkUsingSwordRightSprite()
        {
            return new SwordSprite(GetTexture(FILE_NAME_2), 6, SIZE_IN_BLOCKS, 2);
        }

        public static ISprite LinkUsingSwordUpSprite()
        {
            return new SwordSprite(GetTexture(FILE_NAME_2), 6, SIZE_IN_BLOCKS, 3);
        }
    }
}
