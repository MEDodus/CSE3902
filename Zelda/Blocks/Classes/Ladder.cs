using Microsoft.Xna.Framework;
using System;
using Zelda.Sprites.Factories;

namespace Zelda.Blocks.Classes
{
    public class Ladder : Block
    {
        public Ladder(Vector2 position) : base(BlockSpriteFactory.LadderSprite(), position, false, false)
        {

        }
    }
}
