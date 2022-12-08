using Microsoft.Xna.Framework;
using System;
using Zelda.Sprites.Factories;

namespace Zelda.Blocks.Classes
{
    public class Statue2 : Block
    {
        public Statue2(Vector2 position) : base(BlockSpriteFactory.Statue2Sprite(), position, false, false)
        {

        }
    }
}
