﻿using Microsoft.Xna.Framework;
using Zelda.Sprites.Factories;

namespace Zelda.Items.Classes
{
    public class Stepladder : INPC
    {
        public Stepladder(Vector2 position) : base(ItemSpriteFactory.StepladderSprite(), position)
        {

        }
    }
}
