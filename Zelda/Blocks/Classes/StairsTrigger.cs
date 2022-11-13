using Microsoft.Xna.Framework;
using Zelda.Sprites.Factories;

namespace Zelda.Blocks.Classes
{
    public class StairsTrigger : IBlock
    {
        public StairsTrigger(Vector2 position) : base(BlockSpriteFactory.InvisibleSprite(0.1), position, true, false)
        {

        }
    }
}
