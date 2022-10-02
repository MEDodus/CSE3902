namespace Zelda
{
    public static class Settings
    {
        public static readonly int BLOCK_SIZE = 40; // pixels
                                                    // To use for items classes for sizing items in window
        public static readonly int ITEMS_MULT = 3;

        // To calculate destinationRectangle of link attachking up, array initialized from l-r in link spriteshite reference
        public static readonly int[] LINK_ATTACKING_UP_FRAMES_Y = { 0, 12, 11, 3 };

        // To calculate destinationRectangle of link attachking left, array initialized from l-r in link spriteshite reference
        public static readonly int[] LINK_ATTACKING_LEFT_FRAMES_X = { 0, 12, 8, 4 };

        // To use for link classes for sizing link in window
        public static readonly int LINK_SIZE_MULT = 3;
    }
}
