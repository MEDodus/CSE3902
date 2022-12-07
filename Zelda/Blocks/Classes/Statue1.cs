using Microsoft.Xna.Framework;
using System;
using Zelda.Sprites.Factories;

namespace Zelda.Blocks.Classes
{
    public class Statue1 : IBlock
    {
        public Statue1(Vector2 position) : base(BlockSpriteFactory.Statue1Sprite(), position, true, false)
        {

        }
    }
}
