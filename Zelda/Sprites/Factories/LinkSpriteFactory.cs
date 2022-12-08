using Microsoft.Xna.Framework.Graphics;
using Zelda.Sprites.Classes;

namespace Zelda.Sprites.Factories
{
    public class LinkSpriteFactory : SpriteFactory
    {
        private static readonly string FILE_NAME = "link2";
        private static readonly string FILE_NAME_COMPANION = "link2_blue";
        private static readonly double SIZE_IN_BLOCKS = 0.9;
        private static readonly int CELL_SIZE = 16;
        private static readonly int FPS = 6;

        // Idle
        public static ISprite LinkFacingDownSprite(int playerNumber)
        {
            return new Sprite(GetTexture(LinkSpriteFromPlayerNumber(playerNumber)), 0, 0, CELL_SIZE, CELL_SIZE, SIZE_IN_BLOCKS);
        }

        public static ISprite LinkFacingLeftSprite(int playerNumber)
        {
            return new Sprite(GetTexture(LinkSpriteFromPlayerNumber(playerNumber)), 3 * CELL_SIZE, CELL_SIZE, CELL_SIZE, CELL_SIZE, SIZE_IN_BLOCKS);
        }

        public static ISprite LinkFacingRightSprite(int playerNumber)
        {
            return new Sprite(GetTexture(LinkSpriteFromPlayerNumber(playerNumber)), 3 * CELL_SIZE, 0, CELL_SIZE, CELL_SIZE, SIZE_IN_BLOCKS);
        }

        public static ISprite LinkFacingUpSprite(int playerNumber)
        {
            return new Sprite(GetTexture(LinkSpriteFromPlayerNumber(playerNumber)), 0, CELL_SIZE, CELL_SIZE, CELL_SIZE, SIZE_IN_BLOCKS);
        }

        // Moving
        public static ISprite LinkMovingDownSprite(int playerNumber)
        {
            return new AnimatedSprite(GetTexture(LinkSpriteFromPlayerNumber(playerNumber)), 0, 0, 1, 2, CELL_SIZE, CELL_SIZE, FPS, SIZE_IN_BLOCKS);
        }

        public static ISprite LinkMovingLeftSprite(int playerNumber)
        {
            return new AnimatedSprite(GetTexture(LinkSpriteFromPlayerNumber(playerNumber)), 2 * CELL_SIZE, CELL_SIZE, 1, 2, CELL_SIZE, CELL_SIZE, FPS, SIZE_IN_BLOCKS);
        }

        public static ISprite LinkMovingRightSprite(int playerNumber)
        {
            return new AnimatedSprite(GetTexture(LinkSpriteFromPlayerNumber(playerNumber)), 2 * CELL_SIZE, 0, 1, 2, CELL_SIZE, CELL_SIZE, FPS, SIZE_IN_BLOCKS);
        }

        public static ISprite LinkMovingUpSprite(int playerNumber)
        {
            return new AnimatedSprite(GetTexture(LinkSpriteFromPlayerNumber(playerNumber)), 0, CELL_SIZE, 1, 2, CELL_SIZE, CELL_SIZE, FPS, SIZE_IN_BLOCKS);
        }

        // Using item
        public static ISprite LinkUsingItemDownSprite(int playerNumber)
        {
            return new Sprite(GetTexture(LinkSpriteFromPlayerNumber(playerNumber)), 0, 2 * CELL_SIZE, CELL_SIZE, CELL_SIZE, SIZE_IN_BLOCKS);
        }

        public static ISprite LinkUsingItemLeftSprite(int playerNumber)
        {
            return new Sprite(GetTexture(LinkSpriteFromPlayerNumber(playerNumber)), 3 * CELL_SIZE, 2 * CELL_SIZE, CELL_SIZE, CELL_SIZE, SIZE_IN_BLOCKS);
        }

        public static ISprite LinkUsingItemRightSprite(int playerNumber)
        {
            return new Sprite(GetTexture(LinkSpriteFromPlayerNumber(playerNumber)), CELL_SIZE, 2 * CELL_SIZE, CELL_SIZE, CELL_SIZE, SIZE_IN_BLOCKS);
        }

        public static ISprite LinkUsingItemUpSprite(int playerNumber)
        {
            return new Sprite(GetTexture(LinkSpriteFromPlayerNumber(playerNumber)), 2 * CELL_SIZE, 2 * CELL_SIZE, CELL_SIZE, CELL_SIZE, SIZE_IN_BLOCKS);
        }

        // Triforce
        public static ISprite LinkTriforceSprite(int playerNumber)
        {
            if(playerNumber == 1)
            {
                return new AnimatedSprite(GetTexture("link_triforce"), 1, 2, 4, 1.55);
            }
            else
            {
                return new AnimatedSprite(GetTexture("link_triforce_blue"), 1, 2, 4, 1.55);
            }
        }

        private static string LinkSpriteFromPlayerNumber(int number)
        {
            if (number == 1) { return FILE_NAME; }
            else { return FILE_NAME_COMPANION; }
        }
    }
}
