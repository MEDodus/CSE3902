using Microsoft.Xna.Framework;
using Zelda.Sprites.Factories;

namespace Zelda.Blocks.Classes
{
    public class Fire : IBlock
    {
        public Fire(Vector2 position) : base(BlockSpriteFactory.FireSprite(), position, false, true)
        {

        }
    }
}

