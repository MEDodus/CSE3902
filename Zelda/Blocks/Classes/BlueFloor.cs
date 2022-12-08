using Microsoft.Xna.Framework;
using System;
using Zelda.Sprites.Factories;

namespace Zelda.Blocks.Classes
{
    public class BlueFloor : Block
    {
        public BlueFloor(Vector2 position) : base(BlockSpriteFactory.BlueFloorSprite(), position, false, false)
        {

        }
    }
}
