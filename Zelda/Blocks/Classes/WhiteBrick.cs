using Microsoft.Xna.Framework;
using Zelda.Sprites.Factories;

namespace Zelda.Blocks.Classes
{
    public class WhiteBrick : Block
    {
        public WhiteBrick(Vector2 position) : base(BlockSpriteFactory.WhiteBrickSprite(), position, true, false)
        {

        }
    }
}
