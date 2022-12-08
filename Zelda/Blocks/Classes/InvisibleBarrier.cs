using Microsoft.Xna.Framework;
using System;
using Zelda.Sprites.Factories;

namespace Zelda.Blocks.Classes
{
    public class InvisibleBarrier : Block
    {
        public InvisibleBarrier(Vector2 position) : base(BlockSpriteFactory.InvisibleSprite(), position, true, false)
        {

        }
    }
}
