﻿using Microsoft.Xna.Framework.Graphics;
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
        public static ISprite PauseHUDBackground()
        {
            return new Sprite(GetTexture("pause_hud_background"), HUDUtilities.ORIGIN, HUDUtilities.ORIGIN, HUDUtilities.PAUSE_HUD_WIDTH, HUDUtilities.PAUSE_HUD_HEIGHT, HUDUtilities.BACKGROUND_BLOCK_SIZE);
        }
        public static ISprite PauseHUDMap()
        {
            return new Sprite(GetTexture("pause_hud_inventory_map"));
        }
        public static ISprite PauseHUDMapTile()
        {
            return new Sprite(GetTexture("pause_hud_inventory_map_tile"), HUDUtilities.ORIGIN, HUDUtilities.ORIGIN, HUDUtilities.ROOM_INDICATOR_LENGTH, HUDUtilities.ROOM_INDICATOR_LENGTH, HUDUtilities.ROOM_INDICATOR_BLOCK_SIZE);
        }

        //MAP SPRITES
        public static ISprite DungeonHUDMap()
        {
            return new Sprite(GetTexture("dungeon_hud_map"), HUDUtilities.ORIGIN, HUDUtilities.ORIGIN, HUDUtilities.MAP_WIDTH, HUDUtilities.MAP_HEIGHT, HUDUtilities.MAP_BLOCK_SIZE);
        }
        public static ISprite DungeonHUDMapTile()
        {
            return new Sprite(GetTexture("dungeon_hud_map_tile"));
        }
        public static ISprite RoomIndicator()
        {
            return new Sprite(GetTexture("map_position"), HUDUtilities.ORIGIN, HUDUtilities.ORIGIN, HUDUtilities.ROOM_INDICATOR_LENGTH, HUDUtilities.ROOM_INDICATOR_LENGTH, HUDUtilities.ROOM_INDICATOR_BLOCK_SIZE);

        }

        //FONT SPRITE
        public static SpriteFont HUDFont()
        {
            return content.Load<SpriteFont>("spriteFonts\\Font");
        }
        public static SpriteFont WinOrLoseFont()
        {
            return content.Load<SpriteFont>("spriteFonts\\winOrLose");
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
        public static ISprite InvisibleHeart()
        {
            return new Sprite(GetTexture("black_rectangle"), HUDUtilities.EMPTY_HEART_COLUMN * HUDUtilities.HEART_DISPLAY_COLUMN_WIDTH, HUDUtilities.HEART_ROW * HUDUtilities.HEART_DISPLAY_ROW_HEIGHT, HUDUtilities.HEART_DISPLAY_COLUMN_WIDTH, HUDUtilities.HEART_DISPLAY_ROW_HEIGHT, HUDUtilities.HEART_DISPLAY_BLOCK_SIZE);
        }

        // MISC
        public static ISprite BlackBorder()
        {
            return new Sprite(GetTexture("black_rectangle"));
        }
        public static ISprite ItemSelectSprite()
        {
            return new Sprite(GetTexture("item_select"));
        }
    }
}
