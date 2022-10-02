using Microsoft.Xna.Framework;
using Zelda.Sprites.Factories;

namespace Zelda.Blocks.Classes
{
    public class PushableBlock : IBlock
    {
        public PushableBlock(Vector2 position) : base(BlockSpriteFactory.PushableBlockSprite(), position)
        {

        }
    }
}
