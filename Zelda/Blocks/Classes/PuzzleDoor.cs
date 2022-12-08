using Microsoft.Xna.Framework;
using System;
using Zelda.Sprites.Factories;

namespace Zelda.Blocks.Classes
{
    public class PuzzleDoor : Block
    {
        public PuzzleDoor(Vector2 position) : base(BlockSpriteFactory.InvisibleSprite(), position, true, false)
        {

        }
    }
}
