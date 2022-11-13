using Microsoft.Xna.Framework;
using Zelda.Sprites.Factories;

namespace Zelda.Blocks.Classes
{
    public class LadderTrigger : IBlock
    {
        public LadderTrigger(Vector2 position) : base(BlockSpriteFactory.InvisibleSprite(), position, true, false)
        {

        }
    }
}
