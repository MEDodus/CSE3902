using Microsoft.Xna.Framework;
using System;
using Zelda.Sprites.Factories;

namespace Zelda.Blocks.Classes
{
    public class Statue2 : IBlock
    {
        public Statue2(Vector2 position, Boolean barrier) : base(BlockSpriteFactory.Statue2Sprite(), position, barrier)
        {

        }
    }
}
