using Microsoft.Xna.Framework;
using System;
using Zelda.Sprites.Factories;

namespace Zelda.Blocks.Classes
{
    public class BlackGap : IBlock
    {
        public BlackGap(Vector2 position) : base(BlockSpriteFactory.BlackGapSprite(), position, false)
        {

        }
    }
}
