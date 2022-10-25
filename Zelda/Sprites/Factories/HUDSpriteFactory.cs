﻿using System.Data;
using Zelda.Sprites.Classes;
using Zelda.Utilities;

namespace Zelda.Sprites.Factories
{
    public class HUDSpriteFactory : SpriteFactory
    {
        //BACKGROUND SPRITES
        public static ISprite LinkHUDBackground()
        {
            return new Sprite(GetTexture("link_hud_background"), HUDUtilities.ORIGIN, HUDUtilities.ORIGIN, HUDUtilities.HUD_WIDTH, HUDUtilities.HUD_HEIGHT, HUDUtilities.BACKGROUND_BLOCK_SIZE);
        }

        //MAP SPRITES
        public static ISprite DungeonHUDMap()
        {
            return new Sprite(GetTexture("dungeon_hud_map"), HUDUtilities.ORIGIN, HUDUtilities.ORIGIN, HUDUtilities.MAP_WIDTH, HUDUtilities.MAP_HEIGHT, HUDUtilities.MAP_BLOCK_SIZE);
        }

        //HEART SPRITES
        public static ISprite FullHeart()
        {
            return new Sprite(GetTexture("heart_display"), HUDUtilities.FULL_HEART_COLUMN * HUDUtilities.HEART_DISPLAY_COLUMN_WIDTH, HUDUtilities.HEART_ROW * HUDUtilities.HEART_DISPLAY_ROW_HEIGHT, HUDUtilities.HEART_DISPLAY_COLUMN_WIDTH, HUDUtilities.HEART_DISPLAY_ROW_HEIGHT, HUDUtilities.HEART_DISPLAY_BLOCK_SIZE);
        }
        public static ISprite HalfHeart()
        {
            return new Sprite(GetTexture("heart_display"), HUDUtilities.HALF_HEART_COLUMN * HUDUtilities.HEART_DISPLAY_COLUMN_WIDTH, HUDUtilities.HEART_ROW * HUDUtilities.HEART_DISPLAY_ROW_HEIGHT, HUDUtilities.HEART_DISPLAY_COLUMN_WIDTH, HUDUtilities.HEART_DISPLAY_ROW_HEIGHT, HUDUtilities.HEART_DISPLAY_BLOCK_SIZE);
        }
        public static ISprite EmptyHeart()
        {
            return new Sprite(GetTexture("heart_display"), HUDUtilities.EMPTY_HEART_COLUMN * HUDUtilities.HEART_DISPLAY_COLUMN_WIDTH, HUDUtilities.HEART_ROW * HUDUtilities.HEART_DISPLAY_ROW_HEIGHT, HUDUtilities.HEART_DISPLAY_COLUMN_WIDTH, HUDUtilities.HEART_DISPLAY_ROW_HEIGHT, HUDUtilities.HEART_DISPLAY_BLOCK_SIZE);
        }
    }
}
