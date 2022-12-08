using Microsoft.Xna.Framework;
using Zelda.Sprites.Factories;

namespace Zelda.Items.Classes
{
    public class BluePotion : Item
    {
        public BluePotion(Vector2 position) : base(ItemSpriteFactory.BluePotionSprite(), position, 3, new Zelda.ItemEffects.BluePotionEffect())
        {

        }
    }
}
