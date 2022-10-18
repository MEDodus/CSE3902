﻿using Microsoft.Xna.Framework;
using Zelda.Sprites;

namespace Zelda.Borders.Classes.Abstract
{
    public abstract class TopBorder : IBorder
    {
        public TopBorder(ISprite sprite) : base(sprite,
            new Rectangle(
                Settings.ROOM_POSITION_X - Settings.BORDER_SIZE,
                Settings.ROOM_POSITION_Y - Settings.BORDER_SIZE,
                (2 * Settings.BORDER_SIZE) + (12 * Settings.BLOCK_SIZE),
                Settings.BORDER_SIZE
            ))
        {

        }
    }
}