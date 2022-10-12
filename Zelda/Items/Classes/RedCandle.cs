﻿using Microsoft.Xna.Framework;
using Zelda.Sprites.Factories;

namespace Zelda.Items.Classes
{
    public class RedCandle : INPC
    {
        public RedCandle(Vector2 position) : base(ItemSpriteFactory.RedCandleSprite(), position)
        {

        }
    }
}
