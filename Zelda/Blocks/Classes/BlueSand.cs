using Microsoft.Xna.Framework;
using Zelda.Sprites.Factories;

namespace Zelda.Blocks.Classes
{
    public class BlueSand : IBlock
    {
        public BlueSand(Vector2 position) : base(BlockSpriteFactory.BlueSandSprite(), position)
        {

        }
    }
}
