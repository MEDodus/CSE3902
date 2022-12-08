using Microsoft.Xna.Framework;
using System;
using Zelda.Sprites.Factories;

namespace Zelda.Blocks.Classes
{
    public class OldManWords : Block
    {
        public OldManWords(Vector2 position) : base(BlockSpriteFactory.OldManWordsSprite(), position, false, true)
        {

        }
    }
}
