using Microsoft.Xna.Framework;
using System;
using Zelda.Sprites.Factories;

namespace Zelda.Blocks.Classes
{
    public class Door : Block
    {
        public Door(Vector2 position, bool locked) : base(BlockSpriteFactory.InvisibleSprite(), position, locked, false)
        {

        }
    }
}
