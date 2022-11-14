using Microsoft.Xna.Framework;
using System;
using Zelda.Sprites.Factories;

namespace Zelda.Blocks.Classes
{
    public class OldManWords : IBlock
    {
        public OldManWords(Vector2 position) : base(BlockSpriteFactory.OldManWordsSprite(), position, false, true)
        {

        }
    }
}
