using Microsoft.Xna.Framework;
using Zelda.Sprites.Factories;

namespace Zelda.Items.Classes
{
    public class RedPotion : Item
    {
        public RedPotion(Vector2 position) : base(ItemSpriteFactory.RedPotionSprite(), position, ONE, null /* Add later */)
        {

        }
    }
}
