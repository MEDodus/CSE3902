using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

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

        public static readonly int PAUSE_HUD_X = 180;
        public static readonly int PAUSE_HUD_Y = 500;
        public static readonly int PAUSE_HUD_INVENTORY_Y = HUD_Y;
        public static readonly int PAUSE_HUD_WIDTH = 255;
        public static readonly int PAUSE_HUD_HEIGHT = 175;

        //DUNGEON HUD MAP 
        public static readonly int MAP_WIDTH = 48;
        public static readonly int MAP_HEIGHT = 24;
        public static readonly int MAP_X = 30;// HUD_X + 30;
        public static readonly int MAP_Y = 70;// HUD_Y + 70;
        public static readonly int MAP_BLOCK_SIZE = 3;

        //DUNGEON HUD MAP - ROOM INDICATOR
        public static int ROOM_INDICATOR_LENGTH = 1;
        public static double ROOM_INDICATOR_BLOCK_SIZE = 0.125;
        public static readonly Vector2[] ROOM_INDICATOR_POSITION =
        {
            new Vector2(MAP_X + 50,MAP_Y + 5),
            new Vector2(MAP_X + 50,MAP_Y + 10),
            new Vector2(MAP_X + 10,MAP_Y + 10),
            new Vector2(MAP_X + 10,MAP_Y + 10),
            new Vector2(MAP_X + 10,MAP_Y + 10),
            new Vector2(MAP_X + 10,MAP_Y + 10),
            new Vector2(MAP_X + 10,MAP_Y + 10),
            new Vector2(MAP_X + 10,MAP_Y + 10),
            new Vector2(MAP_X + 10,MAP_Y + 10),
            new Vector2(MAP_X + 10,MAP_Y + 10),
            new Vector2(MAP_X + 10,MAP_Y + 10),
            new Vector2(MAP_X + 10,MAP_Y + 10),
            new Vector2(MAP_X + 10,MAP_Y + 10),
            new Vector2(MAP_X + 10,MAP_Y + 10),
            new Vector2(MAP_X + 10,MAP_Y + 10),
            new Vector2(MAP_X + 10,MAP_Y + 10),
            new Vector2(MAP_X + 10,MAP_Y + 10),
            new Vector2(MAP_X + 10,MAP_Y + 10),
            new Vector2(MAP_X + 10,MAP_Y + 10),
            new Vector2(MAP_X + 10,MAP_Y + 10),
            new Vector2(MAP_X + 10,MAP_Y + 10),
            new Vector2(MAP_X + 10,MAP_Y + 10),
            new Vector2(MAP_X + 10,MAP_Y + 10),
            new Vector2(MAP_X + 15,MAP_Y + 30)
        };


        //HEALTH DISPLAY - MAIN
        public static readonly int HEALTH_DISPLAY_X = 510;//HUD_X + 510;
        public static readonly int HEALTH_DISPLAY_Y = 100;//HUD_Y + 100;

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

        //ITEM COUNTS
        public static readonly int ITEM_COUNT_X = 275;//HUD_X + 275;

        public static readonly int RUPY_COUNT_Y = 45;//HUD_Y + 45;
        public static readonly int KEY_COUNT_Y = 85;//HUD_Y + 85;
        public static readonly int BOMB_COUNT_Y = 115;//HUD_Y + 120;

        public static readonly int LEVEL_X = 20;// HUD_X + 20;
        public static readonly int LEVEL_Y = 30;// HUD_Y - 30;

        //ITEM SLOTS
        public static readonly int SLOT_A_X = 420;//HUD_X + 420;
        public static readonly int SLOT_Y = 70; // HUD_Y + 70;
        public static readonly int SLOT_B_X = 353;// HUD_X + 353;

        //PAUSE SCREEN ITEM POSITIONS
        public static readonly int PAUSE_ITEM_X = HUD_X + 125;//HUD_X + 420;
        public static readonly int MAP_ITEM_Y = HUD_Y + 300; // HUD_Y + 70;
        public static readonly int COMPASS_ITEM_Y = HUD_Y + 415;// HUD_X + 353;

        //FONT

    }
}
