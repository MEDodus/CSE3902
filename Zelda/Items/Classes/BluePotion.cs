using Microsoft.Xna.Framework;
using Zelda.Sprites.Factories;

namespace Zelda.Items.Classes
{
    public class BluePotion : IItem
    {
        public BluePotion(Vector2 position) : base(ItemSpriteFactory.BluePotionSprite(), position, ONE, new Zelda.ItemEffects.BluePotionEffect(), 1)
        {

        }

        /* Default constructor for item in inventory or not displayed in game */
        public BluePotion() : base(ItemSpriteFactory.BluePotionSprite(), new Vector2(), ONE, new Zelda.ItemEffects.BluePotionEffect(), 1)
        {

        }
    }
}
