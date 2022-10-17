using Zelda.Sprites.Classes;

namespace Zelda.Sprites.Factories
{
    public class BorderSpriteFactory : SpriteFactory
    {
        private static readonly int WIDTH = 1000;
        private static readonly int HEIGHT = 688;
        private static readonly int BORDER_SIZE = 125; // size of borders for source rectangles, NOT the same as Settings.BORDER_SIZE (which is for destination rectangles)

        // Utility (all borders have the same size/positions, only some have doors)
        private static ISprite TopSprite(string filename)
        {
            return new Sprite(GetTexture(filename), 0, 0, WIDTH, BORDER_SIZE);
        }
        private static ISprite BottomSprite(string filename)
        {
            return new Sprite(GetTexture(filename), 0, HEIGHT - BORDER_SIZE, WIDTH, BORDER_SIZE);
        }
        private static ISprite LeftSprite(string filename)
        {
            return new Sprite(GetTexture(filename), 0, BORDER_SIZE, BORDER_SIZE, HEIGHT - (2 * BORDER_SIZE));
        }
        private static ISprite RightSprite(string filename)
        {
            return new Sprite(GetTexture(filename), WIDTH - BORDER_SIZE, BORDER_SIZE, BORDER_SIZE, HEIGHT - (2 * BORDER_SIZE));
        }

        // Walls
        public static ISprite TopWallSprite()
        {
            return TopSprite("borders");
        }
        public static ISprite BottomWallSprite()
        {
            return BottomSprite("borders");
        }
        public static ISprite LeftWallSprite()
        {
            return LeftSprite("borders");
        }
        public static ISprite RightWallSprite()
        {
            return RightSprite("borders");
        }

        // Open doors
        public static ISprite TopOpenDoorSprite()
        {
            return TopSprite("borders_doors_open");
        }
        public static ISprite BottomOpenDoorSprite()
        {
            return BottomSprite("borders_doors_open");
        }
        public static ISprite LeftOpenDoorSprite()
        {
            return LeftSprite("borders_doors_open");
        }
        public static ISprite RightOpenDoorSprite()
        {
            return RightSprite("borders_doors_open");
        }

        // Locked doors
        public static ISprite TopLockedDoorSprite()
        {
            return TopSprite("borders_doors_locked");
        }
        public static ISprite BottomLockedDoorSprite()
        {
            return BottomSprite("borders_doors_locked");
        }
        public static ISprite LeftLockedDoorSprite()
        {
            return LeftSprite("borders_doors_locked");
        }
        public static ISprite RightLockedDoorSprite()
        {
            return RightSprite("borders_doors_locked");
        }
    }
}
