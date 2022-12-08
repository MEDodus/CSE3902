using Microsoft.Xna.Framework;
using System;
using Zelda.Sprites.Factories;

namespace Zelda.Blocks.Classes
{
    public class BlueSand : Block
    {
        public BlueSand(Vector2 position) : base(BlockSpriteFactory.BlueSandSprite(), position, false, false)
        {

        }
    }
}
