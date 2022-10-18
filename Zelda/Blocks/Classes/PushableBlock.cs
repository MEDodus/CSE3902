using Microsoft.Xna.Framework;
using System;
using Zelda.Sprites.Factories;

namespace Zelda.Blocks.Classes
{
    public class PushableBlock : IBlock
    {
        public PushableBlock(Vector2 position, Boolean barrier) : base(BlockSpriteFactory.PushableBlockSprite(), position, barrier)
        {

        }
    }
}
