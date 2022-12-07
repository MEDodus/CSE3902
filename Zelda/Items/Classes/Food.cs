using Microsoft.Xna.Framework;
using Zelda.Sprites.Factories;

namespace Zelda.Items.Classes
{
    public class Food : IItem
    {
        public Food(Vector2 position) : base(ItemSpriteFactory.FoodSprite(), position, 0, null, 1)
        {

        }

        /* Default constructor for item in inventory or not displayed in game */
        public Food() : base(ItemSpriteFactory.FoodSprite(), new Vector2(), 0, null, 1)
        {

        }
    }
}
