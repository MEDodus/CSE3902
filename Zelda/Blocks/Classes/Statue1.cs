using Microsoft.Xna.Framework;
using System;
using Zelda.Sprites.Factories;

namespace Zelda.Blocks.Classes
{
    public class Statue1 : IBlock
    {
        public Statue1(Vector2 position, Boolean barrier) : base(BlockSpriteFactory.Statue1Sprite(), position, barrier)
        {

        }
    }
}
