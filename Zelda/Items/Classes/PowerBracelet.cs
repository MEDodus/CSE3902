﻿using Microsoft.Xna.Framework;
using Zelda.Sprites.Factories;

namespace Zelda.Items.Classes
{
    public class PowerBracelet : Item
    {
        public PowerBracelet(Vector2 position) : base(ItemSpriteFactory.PowerBraceletSprite(), position, ONE, null)
        {

        }
    }
}
