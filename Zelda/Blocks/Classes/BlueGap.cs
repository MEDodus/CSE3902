using Microsoft.Xna.Framework;
using Zelda.Sprites.Factories;

namespace Zelda.Blocks.Classes
{
    public class BlueGap : IBlock
    {
        public BlueGap(Vector2 position) : base(BlockSpriteFactory.BlueGapSprite(), position)
        {

        }
    }
}
