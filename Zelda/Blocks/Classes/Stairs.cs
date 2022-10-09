using Microsoft.Xna.Framework;
using Zelda.Sprites.Factories;

namespace Zelda.Blocks.Classes
{
    public class Stairs : IBlock
    {
        public Stairs(Vector2 position) : base(BlockSpriteFactory.StairsSprite(), position)
        {

        }
    }
}
