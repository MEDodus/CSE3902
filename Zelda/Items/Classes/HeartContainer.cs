﻿using Microsoft.Xna.Framework;
using Zelda.ItemEffects;
using Zelda.Sprites.Factories;

namespace Zelda.Items.Classes
{
    public class HeartContainer : Item
    {
        public HeartContainer(Vector2 position) : base(ItemSpriteFactory.HeartContainerSprite(), position, 0, new HeartContainerEffect())
        {

        }
    }
}
