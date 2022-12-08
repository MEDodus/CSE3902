using Microsoft.Xna.Framework;
using System;
using Zelda.Sprites.Factories;

namespace Zelda.Blocks.Classes
{
    public class Statue1 : Block
    {
        public Statue1(Vector2 position) : base(BlockSpriteFactory.Statue1Sprite(), position, false, false)
        {

        }
    }
}
