﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zelda.Utilities
{
    public static class HUDUtilities
    {
        //MISC VARIABLES
        public static readonly int ORIGIN = 0;

        //LINK HUD VARIABLES
        public static readonly int HUD_X = 180;
        public static readonly int HUD_Y = 10;
        public static readonly int HUD_WIDTH = 256;
        public static readonly int HUD_HEIGHT = 56;
        public static readonly int BACKGROUND_BLOCK_SIZE = 14;

        //DUNGEON HUD MAP 
        public static readonly int MAP_WIDTH = 48;
        public static readonly int MAP_HEIGHT = 24;
        public static readonly int MAP_X = HUD_X + 30;
        public static readonly int MAP_Y = HUD_Y + 70;
        public static readonly int MAP_BLOCK_SIZE = 3;

        //HEALTH DISPLAY - MAIN
        public static readonly int HEALTH_DISPLAY_X = HUD_X + 510;
        public static readonly int HEALTH_DISPLAY_Y = HUD_Y + 100;

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

        //FONT

    }
}