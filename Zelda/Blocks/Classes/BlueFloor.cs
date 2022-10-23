using Microsoft.Xna.Framework;
using System;
using Zelda.Sprites.Factories;

namespace Zelda.Blocks.Classes
{
    public class BlueFloor : IBlock
    {
        public BlueFloor(Vector2 position) : base(BlockSpriteFactory.BlueFloorSprite(), position, true)
        {

        }
    }
}
