using Microsoft.Xna.Framework;
using Zelda.ItemEffects;
using Zelda.Sprites.Factories;

namespace Zelda.Items.Classes
{
    public class Mushroom : IItem
    {
        public Mushroom(Vector2 position) : base(ItemSpriteFactory.MushroomSprite(), position, 0, new MushroomEffect())
        {

        }

        /* Default constructor for item in inventory or not displayed in game */
        public Mushroom() : base(ItemSpriteFactory.MushroomSprite(), new Vector2(), 0, new MushroomEffect())
        {

        }
    }
}
