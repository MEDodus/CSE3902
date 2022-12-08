using Microsoft.Xna.Framework;
using Zelda.Sprites.Factories;

namespace Zelda.Items.Classes
{
    public class RedPotion : IItem
    {
        public RedPotion(Vector2 position) : base(ItemSpriteFactory.RedPotionSprite(), position, ONE, null /* Add later */)
        {

        }

        /* Default constructor for item in inventory or not displayed in game */
        public RedPotion() : base(ItemSpriteFactory.RedPotionSprite(), new Vector2(), ONE, null /* Add later */)
        {

        }
    }
}
