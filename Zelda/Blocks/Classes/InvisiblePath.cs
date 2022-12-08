using Microsoft.Xna.Framework;
using System;
using Zelda.Sprites.Factories;

namespace Zelda.Blocks.Classes
{
    public class InvisiblePath : Block
    {
        public InvisiblePath(Vector2 position) : base(BlockSpriteFactory.InvisibleSprite(), position, false, false)
        {

        }
    }
}
