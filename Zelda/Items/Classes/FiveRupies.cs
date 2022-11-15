using Microsoft.Xna.Framework;
using Zelda.Sprites.Factories;

namespace Zelda.Items.Classes
{
    public class FiveRupies : IItem
    {
        // Can hold 100 5-rupies at the moment, refactor so rupy and five rupies are counted the same instead of via their classes
        public FiveRupies(Vector2 position) : base(ItemSpriteFactory.FiveRupiesSprite(), position, 100, null)
        {

        }
    }
}
