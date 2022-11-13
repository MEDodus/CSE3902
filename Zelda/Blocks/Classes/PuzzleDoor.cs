using Microsoft.Xna.Framework;
using System;
using Zelda.Sprites.Factories;

namespace Zelda.Blocks.Classes
{
    public class PuzzleDoor : IBlock
    {
        public PuzzleDoor(Vector2 position) : base(BlockSpriteFactory.InvisibleSprite(), position, true, false)
        {

        }
    }
}
