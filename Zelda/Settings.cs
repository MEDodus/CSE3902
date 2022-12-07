namespace Zelda
{
    public static class Settings
    {
        // Object sizes (pixels)
        public static readonly int BLOCK_SIZE = 50;
        public static readonly int BORDER_SIZE = 2 * BLOCK_SIZE; // keep this aspect ratio or else it will size incorrectly

        // Room size not including borders (blocks)
        public static readonly int ROOM_WIDTH = 12;
        public static readonly int ROOM_HEIGHT = 7;

        // Game window size
        public static readonly int WINDOW_WIDTH = 1024;
        public static readonly int WINDOW_HEIGHT = 768;

        // Room drawing window position/size including borders (pixels)
        public static readonly int ROOM_WINDOW_X = 100;
        public static readonly int ROOM_WINDOW_Y = 200;
        public static readonly int ROOM_WINDOW_WIDTH = ROOM_WIDTH * BLOCK_SIZE + 2 * BORDER_SIZE;
        public static readonly int ROOM_WINDOW_HEIGHT = ROOM_HEIGHT * BLOCK_SIZE + 2 * BORDER_SIZE;

        // Level info
        public static readonly int NUM_LEVELS = 2;
        public static readonly int START_ROOM = 15;

        // Link movement settings
        public static readonly float LINK_SPEED = 3f; // pixels per frame
    }
}
