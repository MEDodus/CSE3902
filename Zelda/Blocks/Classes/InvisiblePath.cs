using Microsoft.Xna.Framework;
using System;
using Zelda.Sprites.Factories;

namespace Zelda.Blocks.Classes
{
    public class InvisiblePath : IBlock
    {
        public InvisiblePath(Vector2 position) : base(BlockSpriteFactory.InvisibleSprite(), position, true)
        {

        }
    }
}
