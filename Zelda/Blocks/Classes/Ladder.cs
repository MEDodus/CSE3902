using Microsoft.Xna.Framework;
using System;
using Zelda.Sprites.Factories;

namespace Zelda.Blocks.Classes
{
    public class Ladder : IBlock
    {
        public Ladder(Vector2 position, Boolean barrier) : base(BlockSpriteFactory.LadderSprite(), position, barrier)
        {

        }
    }
}
