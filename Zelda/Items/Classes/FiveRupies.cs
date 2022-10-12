using Microsoft.Xna.Framework;
using Zelda.Sprites.Factories;

namespace Zelda.Items.Classes
{
    public class FiveRupies : INPC
    {
        public FiveRupies(Vector2 position) : base(ItemSpriteFactory.FiveRupiesSprite(), position)
        {

        }
    }
}
