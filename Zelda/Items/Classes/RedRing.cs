﻿using Microsoft.Xna.Framework;
using Zelda.Sprites.Factories;

namespace Zelda.Items.Classes
{
    public class RedRing : INPC
    {
        public RedRing(Vector2 position) : base(ItemSpriteFactory.RedRingSprite(), position)
        {

        }
    }
}
