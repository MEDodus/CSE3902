using Microsoft.Xna.Framework;
using System;
using Zelda.Sprites.Factories;

namespace Zelda.Blocks.Classes
{
    public class Stairs : IBlock
    {
        public Stairs(Vector2 position, Boolean barrier) : base(BlockSpriteFactory.StairsSprite(), position, barrier)
        {

        }
    }
}
