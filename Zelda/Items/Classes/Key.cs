﻿using Microsoft.Xna.Framework;
using Zelda.Sprites.Factories;

namespace Zelda.Items.Classes
{
    public class Key : Item
    {
        public Key(Vector2 position) : base(ItemSpriteFactory.KeySprite(), position, INFINITE, new Zelda.ItemEffects.KeyEffect())
        {

        }
    }
}
