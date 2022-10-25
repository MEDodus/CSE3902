using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zelda.Utilities
{
    public static class HUDUtilities
    {
        //MAIN HUD VARIABLES
        public static readonly int HUD_X = 0;
        public static readonly int HUD_Y = 0;

        //HEALTH DISPLAY - MAIN
        public static readonly int HEALTH_DISPLAY_X = HUD_X + 0;
        public static readonly int HEALTH_DISPLAY_Y = HUD_Y + 0;

        //HEALTH DISPLAY - HEART
        public static readonly int HEART_DISPLAY_ROW_HEIGHT = 8;
        public static readonly int HEART_DISPLAY_COLUMN_WIDTH = 7;
        public static readonly double HEART_DISPLAY_BLOCK_SIZE = 0.5;
        public static readonly int HEART_DISPLAY_ROWS = 1;
        public static readonly int HEART_DISPLAY_COLUMNS = 3;
        public static readonly int EMPTY_HEART_COLUMN = 0;
        public static readonly int HALF_HEART_COLUMN = 1;
        public static readonly int FULL_HEART_COLUMN = 2;
        public static readonly int HEART_ROW = 0;
        public static readonly int HEART_OFFSET = 17;
    }
}
