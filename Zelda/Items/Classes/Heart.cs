using Microsoft.Xna.Framework;
using Zelda.Sprites.Factories;

namespace Zelda.Items.Classes
{
    public class Heart : IItem
    {
        public Heart(Vector2 position) : base(ItemSpriteFactory.HeartSprite(), position, 0, null, 1)
        {

        }

        /* Default constructor for item in inventory or not displayed in game */
        public Heart() : base(ItemSpriteFactory.HeartSprite(), new Vector2(), 0, null, 1)
        {

        }
    }
}
