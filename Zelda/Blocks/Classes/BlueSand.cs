using Microsoft.Xna.Framework;
using System;
using Zelda.Sprites.Factories;

namespace Zelda.Blocks.Classes
{
    public class BlueSand : IBlock
    {
        public BlueSand(Vector2 position, Boolean barrier) : base(BlockSpriteFactory.BlueSandSprite(), position, barrier)
        {

        }
    }
}
