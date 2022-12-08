﻿using Microsoft.Xna.Framework;
using Zelda.Sprites.Factories;

namespace Zelda.Items.Classes
{
    public class Clock : Item
    {
        public Clock(Vector2 position) : base(ItemSpriteFactory.ClockSprite(), position, ONE, null)
        {

        }
    }
}
