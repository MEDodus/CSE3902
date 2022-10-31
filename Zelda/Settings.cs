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

        // Room drawing window position/size including borders (pixels)
        public static readonly int ROOM_WINDOW_X = 200;
        public static readonly int ROOM_WINDOW_Y = 300;
        public static readonly int ROOM_WINDOW_WIDTH = ROOM_WIDTH * BLOCK_SIZE + 2 * BORDER_SIZE;
        public static readonly int ROOM_WINDOW_HEIGHT = ROOM_HEIGHT * BLOCK_SIZE + 2 * BORDER_SIZE;
    }
}
