using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zelda.Items.Classes;
using Zelda.Sprites.Factories;
using Zelda.Utilities;

namespace Zelda.HUD
{
    public static class PauseHUDBuilder
    {
        public static void BuildHUD(HUDItem[] items)
        {
            items[0] = new HUDItem(new Map(new Vector2(0, 0)), new Vector2(HUDUtilities.PAUSE_ITEM_X, HUDUtilities.MAP_ITEM_Y));
            items[1] = new HUDItem(new Compass(new Vector2(0, 0)), new Vector2(HUDUtilities.PAUSE_ITEM_X, HUDUtilities.COMPASS_ITEM_Y));
            items[2] = new HUDItem(new Boomerang(new Vector2(0, 0)), new Vector2(HUDUtilities.SLOT_0_X, HUDUtilities.SLOT_0_Y));
            items[3] = new HUDItem(new Bomb(new Vector2(0, 0)), new Vector2(HUDUtilities.SLOT_1_X, HUDUtilities.SLOT_1_Y));
            items[4] = new HUDItem(new Bow(new Vector2(0, 0)), new Vector2(HUDUtilities.SLOT_2_X, HUDUtilities.SLOT_2_Y));
            items[5] = new HUDItem(new BlueCandle(new Vector2(0, 0)), new Vector2(HUDUtilities.SLOT_3_X, HUDUtilities.SLOT_3_Y));
            items[6] = new HUDItem(new Recorder(new Vector2(0, 0)), new Vector2(HUDUtilities.SLOT_4_X, HUDUtilities.SLOT_4_Y));
            items[7] = new HUDItem(new Food(new Vector2(0, 0)), new Vector2(HUDUtilities.SLOT_5_X, HUDUtilities.SLOT_5_Y));
            items[8] = new HUDItem(new BluePotion(new Vector2(0, 0)), new Vector2(HUDUtilities.SLOT_6_X, HUDUtilities.SLOT_6_Y));
            items[9] = new HUDItem(new MagicalRod(new Vector2(0, 0)), new Vector2(HUDUtilities.SLOT_7_X, HUDUtilities.SLOT_7_Y));
        }
    }
}
