using Microsoft.Xna.Framework;
using Zelda.Sprites.Factories;

namespace Zelda.Items.Classes
{
    public class Food : IItem
    {
        public Food(Vector2 position) : base(ItemSpriteFactory.FoodSprite(), position)
        {

        }
    }
}
