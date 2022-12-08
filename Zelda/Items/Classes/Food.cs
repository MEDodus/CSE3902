using Microsoft.Xna.Framework;
using Zelda.ItemEffects;
using Zelda.Sprites.Factories;

namespace Zelda.Items.Classes
{
    public class Food : Item
    {
        public Food(Vector2 position) : base(ItemSpriteFactory.FoodSprite(), position, 3, new FoodEffect())
        {

        }
    }
}
