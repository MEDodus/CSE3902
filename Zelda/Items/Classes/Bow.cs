using Microsoft.Xna.Framework;
using Zelda.Sprites.Factories;

namespace Zelda.Items.Classes
{
    public class Bow : IItem
    {
        public Bow(Vector2 position) : base(ItemSpriteFactory.BowSprite(), position, INFINITE, new Zelda.ItemEffects.BowEffect(), 1)
        {

        }

        /* Default constructor for item in inventory or not displayed in game */
        public Bow() : base(ItemSpriteFactory.BowSprite(), new Vector2(), INFINITE, new Zelda.ItemEffects.BowEffect(), 1)
        {

        }
    }
}
