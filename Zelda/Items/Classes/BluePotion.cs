using Microsoft.Xna.Framework;
using Zelda.Sprites.Factories;

namespace Zelda.Items.Classes
{
    public class BluePotion : INPC
    {
        public BluePotion(Vector2 position) : base(ItemSpriteFactory.BluePotionSprite(), position)
        {

        }
    }
}
