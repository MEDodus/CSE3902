using Microsoft.Xna.Framework;
using Zelda.Sprites.Factories;

namespace Zelda.Items.Classes
{
    public class SilverArrow : IItem
    {
        public SilverArrow(Vector2 position) : base(ItemSpriteFactory.SilverArrowSprite(), position, INFINITE)
        {

        }
    }
}
