﻿using Microsoft.Xna.Framework;
using Zelda.Sprites.Factories;

namespace Zelda.Blocks.Classes
{
    public class StaticBlock : IBlock
    {
        // looks the same as pushable block but is not pushable
        public StaticBlock(Vector2 position) : base(BlockSpriteFactory.PushableBlockSprite(), position)
        {

        }
    }
}