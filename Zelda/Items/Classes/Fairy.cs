using Microsoft.Xna.Framework;
using Zelda.Sprites.Factories;

namespace Zelda.Items.Classes
{
    public class Fairy : IItem
    {
        public Fairy(Vector2 position) : base(ItemSpriteFactory.FairySprite(), position, 0, null, 1)
        {

        }

        /* Default constructor for item in inventory or not displayed in game */
        public Fairy() : base(ItemSpriteFactory.FairySprite(), new Vector2(), 0, null, 1)
        {

        }
    }
}
