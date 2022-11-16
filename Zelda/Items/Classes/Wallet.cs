﻿using Microsoft.Xna.Framework;
using Zelda.Sprites.Factories;

namespace Zelda.Items.Classes
{
    public class Wallet : IItem
    {
        /* Doesn't need to spawn anywhere, use IItem properties such as quantity held to let link hold some rupies */
        public Wallet(Vector2 position) : base(ItemSpriteFactory.RupySprite(), position, 255, null)
        {

        }
    }
}